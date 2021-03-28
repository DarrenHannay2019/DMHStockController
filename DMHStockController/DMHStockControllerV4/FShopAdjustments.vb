Imports System.Data.SqlClient
Public Class FShopAdjustments
    Dim save As New CSave
    Dim udp As New CUpdate
    Dim ut As New CUtils
    Dim chk As New CCheck
    Dim st As New CStockMovements
    Dim sys As New CSystemLog
    Dim olddate As Date
    Private Sub FShopAdjustments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using conn As New SqlConnection(ut.GetConnString())
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ACSC As New AutoCompleteStringCollection
            conn.Open()
            adp.SelectCommand = New SqlCommand("SELECT ShopRef from tblShops", conn)
            adp.Fill(dt)
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                ACSC.Add(dt.Rows(i).Item(0).ToString())
            Next
            txtWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtWarehouseRef.AutoCompleteCustomSource = ACSC
            txtWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ACSC As New AutoCompleteStringCollection
            conn.Open()
            adp.SelectCommand = New SqlCommand("SELECT StockCode from tblStock WHERE DeadCode ='0'", conn)
            adp.Fill(dt)
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                ACSC.Add(dt.Rows(i).Item(0).ToString())
            Next
            txtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtStockCode.AutoCompleteCustomSource = ACSC
            txtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
        DateTimePicker1.Value = ut.GetSundaysDate(Now)
        If CmdOK.Text = "OK" Then loadOld()
    End Sub
    Private Sub loadOld()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {
                .SelectCommand = New SqlCommand("SELECT * from qryShopAdjustNew WHERE ID = '" + TxtSID.Text.ToString() + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            With Me
                .CmdOK.Text = "OK"
                .txtWarehouseRef.Text = dt.Rows(0).Item("ShopRef")
                .txtReference.Text = dt.Rows(0).Item("Reference")
                .txtWarehouseName.Text = dt.Rows(0).Item("ShopName")
                .txtTotalGain.Text = dt.Rows(0).Item("TotalGainItems")
                .txtTotalLoss.Text = dt.Rows(0).Item("TotalLossItems")
                .DateTimePicker1.Value = dt.Rows(0).Item("MovementDate")
            End With
        End Using
        olddate = DateTimePicker1.Value
        With Me
            .DataGridView1.Columns.Clear()
            Using conn As New SqlConnection(ut.GetConnString())
                Dim dgd As New SqlDataAdapter("SELECT * from tblShopAdjustmentsLines WHERE ShopAdjustID = '" + TxtSID.Text.ToString() + "'", conn)
                Dim ds As New DataTable
                dgd.Fill(ds)
                With .DataGridView1
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
        End With
    End Sub
    Private Sub TxtWarehouseRef_Leave(sender As Object, e As EventArgs) Handles txtWarehouseRef.Leave
        txtWarehouseRef.Text = UCase(txtWarehouseRef.Text)
        Dim ShopResult As String
        Using conn As New SqlConnection(ut.GetConnString())
            Dim SelCmd As New SqlCommand
            With SelCmd
                .Connection = conn
                .Connection.Open()
                .CommandText = "SELECT ShopName FROM tblShops WHERE ShopRef = @ShopRef"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ShopRef", txtWarehouseRef.Text)
                ShopResult = .ExecuteScalar
            End With
        End Using
        If ShopResult = "" Then
            MessageBox.Show("Please enter a valid Shop Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWarehouseRef.Select()
        Else
            Me.Text = "Shop Adjustments for: [" + txtWarehouseRef.Text + "] " + ShopResult
            txtWarehouseName.Text = ShopResult
            txtStockCode.Select()
        End If
    End Sub

    Private Sub CmdAddToGrid_Click(sender As Object, e As EventArgs) Handles CmdAddToGrid.Click
        Dim Value, TotalValue As Decimal
        Dim qty As Integer = CInt(txtAdjustHangers.Text)
        If txtAdjustHangers.Text = "0" Then
            MsgBox("Unable to add zero Qty for Adjustment", MsgBoxStyle.Critical, Application.ProductName)
        Else
            Using conn As New SqlConnection(ut.GetConnString())
                Dim selectcmd As New SqlCommand
                With selectcmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT UnitPrice from qryUnitPrice WHERE StockCode = @StockCode"
                    .Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                    Value = .ExecuteScalar
                End With
            End Using
            TotalValue = CDec(qty * Value)
            Dim rownum As Integer = DataGridView1.Rows.Add()
            With DataGridView1.Rows.Item(rownum)
                .Cells(0).Value = txtStockCode.Text.ToString()
                .Cells(1).Value = txtWarehouseRef.Text.ToString()
                .Cells(2).Value = txtCurrentHangers.Text.ToString()
                If cboType.Text = "Gain" Then .Cells(3).Value = "Stock Gain"
                If cboType.Text = "Loss" Then .Cells(3).Value = "Stock Loss"
                .Cells(4).Value = txtAdjustHangers.Text.ToString()
                .Cells(6).Value = DateTimePicker1.Value()
                .Cells(5).Value = TotalValue
            End With
            txtStockCode.Clear()
            txtCurrentHangers.Clear()
            txtAdjustHangers.Clear()
            cboType.Text = ""
        End If
        txtStockCode.Select()
        Totals()
    End Sub

    Private Sub CmdDeleteFromGrid_Click(sender As Object, e As EventArgs) Handles CmdDeleteFromGrid.Click
        If DataGridView1.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
        ElseIf DataGridView1.SelectedRows.Count = 1 And DataGridView1.CurrentRow.Cells(2).Value <> "0" Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Me.BackColor = Color.LightGray
        ElseIf DataGridView1.SelectedRows.Count = 1 And DataGridView1.CurrentRow.Cells(2).Value = "0" Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Me.BackColor = Color.LightGray
        ElseIf DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        If CmdOK.Text = "OK" Then UpdateToDB()
        If CmdOK.Text = "ADD" Then SaveToDB()
        FGridSHAdjust.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        txtReference.Clear()
        txtCurrentHangers.Clear()
        txtAdjustHangers.Clear()
        txtStockCode.Clear()
        txtWarehouseName.Clear()
        txtWarehouseRef.Clear()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows.Clear()
        Next
        DateTimePicker1.Value = ut.GetSundaysDate(Now)
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        txtStockCode.Text = UCase(txtStockCode.Text)
        Dim qty As Integer = 0
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selCmd As New SqlCommand
            With selCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT Qty from qryShopStock WHERE SMLocation = @SMLocation AND SMStockCode = @SMStockCode"
                With .Parameters
                    .AddWithValue("@SMLocation", txtWarehouseRef.Text)
                    .AddWithValue("@SMStockCode", txtStockCode.Text)
                End With
                qty = .ExecuteScalar
            End With
        End Using
        If qty = Nothing Then
            txtCurrentHangers.Text = "0"
        Else
            txtCurrentHangers.Text = qty
        End If
    End Sub

    Private Sub TxtReference_Leave(sender As Object, e As EventArgs) Handles txtReference.Leave
        txtReference.Text = StrConv(txtReference.Text, VbStrConv.ProperCase)
    End Sub
    Private Sub Totals()
        Dim lngqtyhangers, lqtyhangers As Integer
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(3).Value = "Stock Gain" Then lngqtyhangers += CInt(DataGridView1.Rows(i).Cells(4).Value)
            If DataGridView1.Rows(i).Cells(3).Value = "Stock Loss" Then lqtyhangers += CInt(DataGridView1.Rows(i).Cells(4).Value * -1)
        Next
        txtTotalGain.Text = lngqtyhangers
        txtTotalLoss.Text = lqtyhangers
    End Sub
    Private Sub SaveToDB()
        sys.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGain.Text), "Shop-Adjust-Start-ADD", "TotalGain", CDate(DateTimePicker1.Value), "Start Total Gain")
        sys.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalLoss.Text), "Shop-Adjust-Start-ADD", "TotalLoss", CDate(DateTimePicker1.Value), "Start Total Loss")
        save.SaveSHAdjustHead(txtWarehouseRef.Text, txtReference.Text, CInt(txtTotalLoss.Text), CInt(txtTotalGain.Text), CDate(DateTimePicker1.Value))
        TxtSID.Text = chk.SaveShopAdjustHead()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim stockcode As String = DataGridView1.Rows(i).Cells(0).Value
            Dim adjustmenttype As String = DataGridView1.Rows(i).Cells(3).Value
            Dim unitprice As Decimal = DataGridView1.Rows(i).Cells(5).Value
            Dim adjustqty As Integer = DataGridView1.Rows(i).Cells(4).Value
            If adjustmenttype = "Stock Loss" Then
                sys.SaveSystemLog(stockcode, "N/A", txtWarehouseRef.Text, adjustqty, "Shop-Adjust-" + adjustmenttype, adjustmenttype, CDate(DateTimePicker1.Value), txtReference.Text)
                st.SaveStockMovements(stockcode, "N/A", txtWarehouseRef.Text, "Shop", CInt(adjustqty * -1), "0", "Stock Loss", CDate(DateTimePicker1.Value), CDec(unitprice * -1), txtReference.Text, CInt(TxtSID.Text))
                save.SaveSHAdjustLines(CInt(TxtSID.Text), stockcode, adjustmenttype, CInt(adjustqty), CDec(unitprice))
            ElseIf adjustmenttype = "Stock Gain" Then
                sys.SaveSystemLog(stockcode, "N/A", txtWarehouseRef.Text, adjustqty, "Shop-Adjust-" + adjustmenttype, adjustmenttype, CDate(DateTimePicker1.Value), txtReference.Text)
                st.SaveStockMovements(stockcode, "N/A", txtWarehouseRef.Text, "Shop", CInt(adjustqty), "0", "Stock Gain", CDate(DateTimePicker1.Value), CDec(unitprice), txtReference.Text, CInt(TxtSID.Text))
                save.SaveSHAdjustLines(CInt(TxtSID.Text), stockcode, adjustmenttype, CInt(adjustqty), CDec(unitprice))
            End If

        Next
        sys.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGain.Text), "Shop-Adjust-End-ADD", "TotalGain", CDate(DateTimePicker1.Value), "End Total Gain")
        sys.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalLoss.Text), "Shop-Adjust-End-ADD", "TotalLoss", CDate(DateTimePicker1.Value), "End Total Loss")
    End Sub
    Private Sub UpdateToDB()
        sys.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGain.Text), "Shop-Adjust-Start-Update", "TotalGain", CDate(DateTimePicker1.Value), "Start Total Gain")
        sys.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalLoss.Text), "Shop-Adjust-Start-Update", "TotalLoss", CDate(DateTimePicker1.Value), "Start Total Loss")
        st.DeleteStockMovements("Stock Loss", CInt(TxtSID.Text), txtReference.Text, CDate(olddate))
        st.DeleteStockMovements("Stock Gain", CInt(TxtSID.Text), txtReference.Text, CDate(olddate))
        udp.SaveShopAdjustHead(CInt(TxtSID.Text), txtWarehouseRef.Text, txtReference.Text, CInt(txtTotalLoss.Text), CInt(txtTotalGain.Text), CDate(DateTimePicker1.Value))
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim stockcode As String = DataGridView1.Rows(i).Cells(2).Value
            Dim adjustmenttype As String = DataGridView1.Rows(i).Cells(3).Value
            Dim unitprice As Decimal = DataGridView1.Rows(i).Cells(5).Value
            Dim adjustqty As Integer = DataGridView1.Rows(i).Cells(4).Value
            If adjustmenttype = "Stock Loss" Then
                sys.SaveSystemLog(stockcode, "N/A", txtWarehouseRef.Text, adjustqty, "Shop-Adjust-" + adjustmenttype + "-Update", "update-" + adjustmenttype, CDate(DateTimePicker1.Value), txtReference.Text)
                st.SaveStockMovements(stockcode, "N/A", txtWarehouseRef.Text, "Shop", CInt(adjustqty * -1), "0", "Stock Loss", CDate(DateTimePicker1.Value), CDec(unitprice * -1), txtReference.Text, CInt(TxtSID.Text))
                udp.SaveShopAdjustLines(stockcode, adjustmenttype, CInt(adjustqty), CDec(unitprice), CInt(TxtSID.Text))
            Else
                sys.SaveSystemLog(stockcode, "N/A", txtWarehouseRef.Text, adjustqty, "Shop-Adjust-" + adjustmenttype + "-Update", "update-" + adjustmenttype, CDate(DateTimePicker1.Value), txtReference.Text)
                st.SaveStockMovements(stockcode, "N/A", txtWarehouseRef.Text, "Shop", CInt(adjustqty), "0", "Stock Gain", CDate(DateTimePicker1.Value), CDec(unitprice), txtReference.Text, CInt(TxtSID.Text))
                udp.SaveShopAdjustLines(stockcode, adjustmenttype, CInt(adjustqty), CDec(unitprice), CInt(TxtSID.Text))
            End If
        Next
        sys.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGain.Text), "Shop-Adjust-End-Update", "TotalGain", CDate(DateTimePicker1.Value), "End Total Gain")
        sys.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalLoss.Text), "Shop-Adjust-End-Update", "TotalLoss", CDate(DateTimePicker1.Value), "End Total Loss")
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Totals()
    End Sub
End Class