Imports System.Data.SqlClient
Public Class FWarehouseAdjust
    Dim ut As New CUtils
    Dim save As New CSave
    Dim upd As New CUpdate
    Dim Chk As New CCheck
    Dim st As New CStockMovements
    Dim Syslog As New CSystemLog
    Dim olddate As Date
    Dim constr As String = ut.GetConnString()
    Private Sub FWarehouseAdjust_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtWarehouseRef.Text = "UNI"
        TxtWarehouseName.Text = "Universal Warehouse"
        Using conn As New SqlConnection(constr)
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ACSC As New AutoCompleteStringCollection
            conn.Open()
            adp.SelectCommand = New SqlCommand("SELECT StockCode from qryWarehouseStock", conn)
            adp.Fill(dt)
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                ACSC.Add(dt.Rows(i).Item(0).ToString())
            Next
            TxtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtStockCode.AutoCompleteCustomSource = ACSC
            TxtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
        If CmdOK.Text = "OK" Then LoadOld()
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(constr)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from tblWarehouseAdjustments WHERE ID = '" + TxtRecordID.Text.ToString() + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            TxtRecordID.Text = dt.Rows(0).Item("ID").ToString()
            ' TxtWarehouseRef.Text = dt.Rows(0).Item("WarehouseRef")
            '  TxtWarehouseName.Text = dt.Rows(0).Item("WarehouseName")
            TxtReference.Text = dt.Rows(0).Item("Reference")
            TxtTotalGain.Text = dt.Rows(0).Item("TotalGainItems")
            TxtTotalLoss.Text = dt.Rows(0).Item("TotalLossItems")
            DateTimePicker1.Value = dt.Rows(0).Item("MovementDate")
        End Using
        olddate = DateTimePicker1.Value
        DataGridView1.Columns.Clear()
        Text = "Warehouse Adjustment for [" + TxtWarehouseName.Text + "]"
        Using conn As New SqlConnection(constr)
            Dim dgd As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from tblWarehouseAdjustmentsLines WHERE WarehouseAdjustID = '" + TxtRecordID.Text.ToString() + "'", conn)}
            Dim ds As New DataTable
            dgd.Fill(ds)
            With DataGridView1
                .DataSource = ds
                .AutoGenerateColumns = True
                .EditMode = DataGridViewEditMode.EditOnF2
                .CellBorderStyle = DataGridViewCellBorderStyle.None
                .BackgroundColor = Color.LightCoral
                .DefaultCellStyle.SelectionBackColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Yellow
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AllowUserToResizeColumns = False
                .RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                With .Columns
                    .Item(0).Visible = False
                    .Item(1).Visible = False
                    .Item(2).Visible = True
                    .Item(2).HeaderText = "Stock Code"
                    .Item(2).Width = 80
                    .Item(3).Visible = True
                    .Item(3).HeaderText = "Movement Type"
                    .Item(4).Visible = True
                    .Item(4).HeaderText = "Qty"
                    .Item(4).Width = 80
                    .Item(5).Visible = False
                End With
            End With
        End Using
        CmdClear.Enabled = False
    End Sub
    Private Sub CmdAddToGrid_Click(sender As Object, e As EventArgs) Handles CmdAddToGrid.Click
        Dim Value, LineValue As Decimal
        Using conn As New SqlConnection(constr)
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT unitPrice from qryUnitPrice WHERE StockCode = @StockCode"
                .Parameters.AddWithValue("@StockCode", TxtStockCode.Text)
                Value = .ExecuteScalar
            End With
        End Using
        LineValue = CDec(CDec(Value) * CInt(TxtAdjustHangers.Text))
        Dim RowNum As Integer = DataGridView1.Rows.Add()
        DataGridView1.Rows.Item(RowNum).Cells(0).Value = "0"
        DataGridView1.Rows.Item(RowNum).Cells(1).Value = "0"
        DataGridView1.Rows.Item(RowNum).Cells(2).Value = TxtStockCode.Text.ToString()
        If CboType.Text = "Loss" Then DataGridView1.Rows.Item(RowNum).Cells(3).Value = "Stock Loss"
        If CboType.Text = "Gain" Then DataGridView1.Rows.Item(RowNum).Cells(3).Value = "Stock Gain"
        DataGridView1.Rows.Item(RowNum).Cells(4).Value = TxtAdjustHangers.Text.ToString()
        DataGridView1.Rows.Item(RowNum).Cells(5).Value = LineValue
        TxtStockCode.Text = ""
        TxtAdjustHangers.Text = ""
        TxtCurrentHangers.Text = ""
        CboType.Text = ""
        Value = 0
        LineValue = 0
        Totals()
        TxtStockCode.Select()
    End Sub

    Private Sub CmdRemoveFromGrid_Click(sender As Object, e As EventArgs) Handles CmdRemoveFromGrid.Click
        If DataGridView1.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
        End If
        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Totals()
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        If CmdOK.Text = "ADD" Then
            SaveToDb()
        ElseIf CmdOK.Text = "OK" Then
            UpdateToDb()
        End If
        FGridWHAdjust.TsbRefresh.PerformClick()
        Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        TxtAdjustHangers.Clear()
        TxtCurrentHangers.Clear()
        TxtReference.Clear()
        TxtStockCode.Clear()
        DataGridView1.Rows.Clear()
        DateTimePicker1.Value = ut.GetSundaysDate(Now)
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then FGridWHAdjust.TsbRefresh.PerformClick() : Me.Close()
    End Sub

    Private Sub TxtReference_Leave(sender As Object, e As EventArgs) Handles TxtReference.Leave
        TxtReference.Text = StrConv(TxtReference.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles TxtStockCode.Leave
        TxtStockCode.Text = UCase(TxtStockCode.Text)
        Dim qty As Integer = 0
        Using conn As New SqlConnection(constr)
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT Qty from qryWarehouseStock2 WHERE SMStockCode = @SMStockCode AND SMLocation = 'UNI'"
                .Parameters.AddWithValue("@SMStockCode", TxtStockCode.Text)
                qty = .ExecuteScalar
            End With
        End Using
        If qty = Nothing Then
            TxtCurrentHangers.Text = "0"
        Else
            TxtCurrentHangers.Text = qty
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Totals()
    End Sub
    Public Sub Totals()
        Dim lngqtyhangers, lqtyhangers As Integer
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(3).Value = "Stock Gain" Then lngqtyhangers += CInt(DataGridView1.Rows(i).Cells(4).Value)
            If DataGridView1.Rows(i).Cells(3).Value = "Stock Loss" Then lqtyhangers += CInt(DataGridView1.Rows(i).Cells(4).Value * -1)
        Next
        TxtTotalGain.Text = lngqtyhangers.ToString()
        TxtTotalLoss.Text = lqtyhangers.ToString()
    End Sub
    Private Sub SaveToDb()
        Syslog.SaveSystemLog("N/A", "N/A", TxtWarehouseRef.Text, CInt(TxtTotalGain.Text), "Warehouse-Adjust-Start-ADD", "TotalGain", CDate(DateTimePicker1.Value), "Start Total Gain")
        Syslog.SaveSystemLog("N/A", "N/A", TxtWarehouseRef.Text, CInt(TxtTotalLoss.Text), "Warehouse-Adjust-Start-ADD", "TotalLoss", CDate(DateTimePicker1.Value), "Start Total Loss")
        save.SaveWHAdjustHead(TxtWarehouseRef.Text, TxtReference.Text, CInt(txtTotalLoss.Text), CInt(txtTotalGain.Text), CDate(DateTimePicker1.Value))
        TxtRecordID.Text = Chk.SaveWHAdjustHead()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim stockcode As String = DataGridView1.Rows(i).Cells(2).Value
            Dim adjustmenttype As String = DataGridView1.Rows(i).Cells(3).Value
            Dim unitprice As Decimal = DataGridView1.Rows(i).Cells(5).Value
            Dim adjustqty As Integer = DataGridView1.Rows(i).Cells(4).Value
            If adjustmenttype = "Stock Loss" Then
                Syslog.SaveSystemLog(stockcode, "N/A", TxtWarehouseRef.Text, adjustqty, "Warehouse-Adjust-" + adjustmenttype, adjustmenttype, CDate(DateTimePicker1.Value), TxtReference.Text)
                st.SaveStockMovements(stockcode, "N/A", TxtWarehouseRef.Text, "Warehouse", CInt(adjustqty * -1), "0", "Stock Loss", CDate(DateTimePicker1.Value), CDec(unitprice * -1), TxtReference.Text, CInt(TxtRecordID.Text))
                save.SaveWhAdjustLines(CInt(TxtRecordID.Text), stockcode, adjustmenttype, CInt(adjustqty), CDec(unitprice))
            Else
                Syslog.SaveSystemLog(stockcode, "N/A", TxtWarehouseRef.Text, adjustqty, "Warehouse-Adjust-" + adjustmenttype, adjustmenttype, CDate(DateTimePicker1.Value), TxtReference.Text)
                st.SaveStockMovements(stockcode, "N/A", TxtWarehouseRef.Text, "Warehouse", CInt(adjustqty), "0", "Stock Gain", CDate(DateTimePicker1.Value), CDec(unitprice), TxtReference.Text, CInt(TxtRecordID.Text))
                save.SaveWhAdjustLines(CInt(TxtRecordID.Text), stockcode, adjustmenttype, CInt(adjustqty), CDec(unitprice))
            End If

        Next
        Syslog.SaveSystemLog("N/A", "N/A", TxtWarehouseRef.Text, CInt(TxtTotalGain.Text), "Warehouse-Adjust-End-ADD", "TotalGain", CDate(DateTimePicker1.Value), "End Total Gain")
        Syslog.SaveSystemLog("N/A", "N/A", TxtWarehouseRef.Text, CInt(TxtTotalLoss.Text), "Warehouse-Adjust-End-ADD", "TotalLoss", CDate(DateTimePicker1.Value), "End Total Loss")
    End Sub
    Private Sub UpdateToDb()
        st.DeleteStockMovements("Stock Loss", CInt(TxtRecordID.Text), TxtReference.Text, CDate(olddate))
        st.DeleteStockMovements("Stock Gain", CInt(TxtRecordID.Text), TxtReference.Text, CDate(olddate))

        Syslog.SaveSystemLog("N/A", "N/A", TxtWarehouseRef.Text, CInt(TxtTotalGain.Text), "Warehouse-Adjust-Start-Update", "TotalGain", CDate(DateTimePicker1.Value), "Start Total Gain")
        Syslog.SaveSystemLog("N/A", "N/A", TxtWarehouseRef.Text, CInt(TxtTotalLoss.Text), "Warehouse-Adjust-Start-Update", "TotalLoss", CDate(DateTimePicker1.Value), "Start Total Loss")
        upd.SaveWHAdjustHead(CInt(TxtRecordID.Text), TxtWarehouseRef.Text, TxtReference.Text, CInt(TxtTotalLoss.Text), CInt(TxtTotalGain.Text), CDate(DateTimePicker1.Value))
        ' TxtRecordID.Text = Chk.SaveWHAdjustHead()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim stockcode As String = DataGridView1.Rows(i).Cells(2).Value
            Dim adjustmenttype As String = DataGridView1.Rows(i).Cells(3).Value
            Dim unitprice As Decimal = DataGridView1.Rows(i).Cells(5).Value
            Dim adjustqty As Integer = DataGridView1.Rows(i).Cells(4).Value
            If adjustmenttype = "Stock Loss" Then
                Syslog.SaveSystemLog(stockcode, "N/A", TxtWarehouseRef.Text, adjustqty, "Warehouse-Adjust-" + adjustmenttype, adjustmenttype, CDate(DateTimePicker1.Value), TxtReference.Text)
                st.SaveStockMovements(stockcode, "N/A", TxtWarehouseRef.Text, "Warehouse", CInt(adjustqty * -1), "0", "Stock Loss", CDate(DateTimePicker1.Value), CDec(unitprice * -1), TxtReference.Text, CInt(TxtRecordID.Text))
                save.SaveWhAdjustLines(CInt(TxtRecordID.Text), stockcode, adjustmenttype, CInt(adjustqty), CDec(unitprice))
            Else
                Syslog.SaveSystemLog(stockcode, "N/A", TxtWarehouseRef.Text, adjustqty, "Warehouse-Adjust-" + adjustmenttype, adjustmenttype, CDate(DateTimePicker1.Value), TxtReference.Text)
                st.SaveStockMovements(stockcode, "N/A", TxtWarehouseRef.Text, "Warehouse", CInt(adjustqty), "0", "Stock Gain", CDate(DateTimePicker1.Value), CDec(unitprice), TxtReference.Text, CInt(TxtRecordID.Text))
                upd.SaveWHAdjustLines(stockcode, adjustmenttype, CInt(adjustqty), CDec(unitprice), CInt(TxtRecordID.Text))
            End If

        Next
        Syslog.SaveSystemLog("N/A", "N/A", TxtWarehouseRef.Text, CInt(TxtTotalGain.Text), "Warehouse-Adjust-End-Update", "TotalGain", CDate(DateTimePicker1.Value), "End Total Gain")
        Syslog.SaveSystemLog("N/A", "N/A", TxtWarehouseRef.Text, CInt(TxtTotalLoss.Text), "Warehouse-Adjust-End-Update", "TotalLoss", CDate(DateTimePicker1.Value), "End Total Loss")
    End Sub
End Class