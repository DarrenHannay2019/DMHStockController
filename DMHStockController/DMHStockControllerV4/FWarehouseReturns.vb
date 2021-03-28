Imports System.Data.SqlClient

Public Class FWarehouseReturns
    Dim save As New CSave
    Dim udp As New CUpdate
    Dim ut As New CUtils
    Dim chk As New CCheck
    Dim st As New CStockMovements
    Dim syslog As New CSystemLog

    Private Sub FWarehouseReturns_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        cmdOK.Text = "ADD"
        txtFWarehouseRef.Text = "UNI"
        txtFWarehouseName.Text = "Universal Warehouse"
        txtTWarehouseRef.Text = "WOFF"
        txtTWarehouseName.Text = "Return To Supplier"
        If TxtRecordNo.Text <> "" Then LoadOld()
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim value, Linevalue As Decimal
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT UnitPrice From qryUnitPrice Where StockCode = @StockCode"
                .Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                value = .ExecuteScalar
            End With
            Linevalue = CDec(CInt(txtTransferQty.Text) * CDec(value))
        End Using
        Dim RowNum As Integer = DgvRecords.Rows.Add()
        DgvRecords.Rows.Item(RowNum).Cells(0).Value = "0"
        DgvRecords.Rows.Item(RowNum).Cells(1).Value = "0"
        DgvRecords.Rows.Item(RowNum).Cells(2).Value = txtStockCode.Text
        DgvRecords.Rows.Item(RowNum).Cells(3).Value = txtTransferQty.Text
        DgvRecords.Rows.Item(RowNum).Cells(4).Value = Linevalue
        txtStockCode.Clear()
        txtTransferQty.Clear()
        txtCurrentQty.Clear()
        txtStockCode.Select()
        Total()
    End Sub

    Private Sub CmdClearGrid_Click(sender As Object, e As EventArgs) Handles cmdClearGrid.Click
        If DgvRecords.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DgvRecords.SelectedRows
                DgvRecords.Rows.Remove(row)
            Next
        ElseIf DgvRecords.SelectedRows.Count = 1 Then
            DgvRecords.Rows.Remove(DgvRecords.CurrentRow)
        ElseIf DgvRecords.SelectedRows.Count = 0 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If cmdOK.Text = "OK" Then
            Dim result As Integer
            syslog.SaveSystemLog("N/A", "N/A", txtFWarehouseRef.Text, CInt(txtTotalItems.Text), "WH-Return-Start-ADD", "WH-Out", CDate(DtpDate.Value), "Start Warhouse Return")
            syslog.SaveSystemLog("N/A", "N/A", txtTWarehouseRef.Text, CInt(txtTotalItems.Text), "WH-Return-Start-ADD", "WH-In", CDate(DtpDate.Value), "Start Warehouse Return")
            save.SaveWHReturnHead(txtFWarehouseRef.Text, txtTWarehouseRef.Text, txtReference.Text, CInt(txtTotalItems.Text), CDate(DtpDate.Value))
            result = chk.SaveWHReturns()
            TxtRecordNo.Text = result.ToString()
            For i As Integer = 0 To DgvRecords.Rows.Count - 1
                Dim stockcode As String = DgvRecords.Rows(i).Cells(4).Value
                Dim Qty As Integer = DgvRecords.Rows(i).Cells(6).Value
                Dim Value As Integer = DgvRecords.Rows(i).Cells(5).Value
                syslog.SaveSystemLog(stockcode, "N/A", txtFWarehouseRef.Text, CInt(Qty), "WH-Return", "Add New Item", CDate(DtpDate.Value), "Add Item to Warehouse Return")
                syslog.SaveSystemLog(stockcode, "N/A", txtTWarehouseRef.Text, CInt(Qty), "WH-Return", "Add New Item", CDate(DtpDate.Value), "Add Item to Warehouse Return")
                st.SaveStockMovements(stockcode, "N/A", txtFWarehouseRef.Text, "Warehouse", CInt(Qty * -1), 0, "WHReturn", CDate(DtpDate.Value), CDec(Value * -1), txtReference.Text, CInt(TxtRecordNo.Text))
                st.SaveStockMovements(stockcode, "N/A", txtTWarehouseRef.Text, "Wharehouse", CInt(Qty), 0, "WHReturn", CDate(DtpDate.Value), CDec(Value), txtReference.Text, CInt(TxtRecordNo.Text))
                save.SaveWhReturnLines(CInt(TxtRecordNo.Text), stockcode, Qty, Value)
            Next
            syslog.SaveSystemLog("N/A", "N/A", txtFWarehouseRef.Text, CInt(txtTotalItems.Text), "WH-Return-End-ADD", "WH-Out", CDate(DtpDate.Value), "End Warhouse Return")
            syslog.SaveSystemLog("N/A", "N/A", txtTWarehouseRef.Text, CInt(txtTotalItems.Text), "WH-Return-End-ADD", "WH-In", CDate(DtpDate.Value), "End Warehouse Return")
        ElseIf cmdOK.Text = "ADD" Then
            syslog.SaveSystemLog("N/A", "N/A", txtFWarehouseRef.Text, CInt(txtTotalItems.Text), "WH-Return-Start-Update", "WH-Out", CDate(DtpDate.Value), "Start Warhouse Return")
            syslog.SaveSystemLog("N/A", "N/A", txtTWarehouseRef.Text, CInt(txtTotalItems.Text), "WH-Return-Start-Update", "WH-In", CDate(DtpDate.Value), "Start Warehouse Return")
            st.DeleteStockMovements("WHReturn", CInt(TxtRecordNo.Text), txtReference.Text, CDate(DtpDate.Value))
            For i As Integer = 0 To DgvRecords.Rows.Count - 1
                Dim stockcode As String = DgvRecords.Rows(i).Cells(4).Value
                Dim Qty As Integer = DgvRecords.Rows(i).Cells(6).Value
                Dim Value As Integer = DgvRecords.Rows(i).Cells(5).Value
                syslog.SaveSystemLog(stockcode, "N/A", txtFWarehouseRef.Text, CInt(Qty), "WH-Return", "Add New Item", CDate(DtpDate.Value), "Add Item to Warehouse Return")
                syslog.SaveSystemLog(stockcode, "N/A", txtTWarehouseRef.Text, CInt(Qty), "WH-Return", "Add New Item", CDate(DtpDate.Value), "Add Item to Warehouse Return")
                st.SaveStockMovements(stockcode, "N/A", txtFWarehouseRef.Text, "Warehouse", CInt(Qty * -1), 0, "WHReturn", CDate(DtpDate.Value), CDec(Value * -1), txtReference.Text, CInt(TxtRecordNo.Text))
                st.SaveStockMovements(stockcode, "N/A", txtTWarehouseRef.Text, "Wharehouse", CInt(Qty), 0, "WHReturn", CDate(DtpDate.Value), CDec(Value), txtReference.Text, CInt(TxtRecordNo.Text))
                udp.SaveWhReturnLines(CInt(TxtRecordNo.Text), stockcode, Qty, Value)
            Next
            udp.SaveWHReturnHead(CInt(TxtRecordNo.Text), txtFWarehouseRef.Text, txtTWarehouseRef.Text, txtReference.Text, CInt(txtTotalItems.Text), CDate(DtpDate.Value))
        End If
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtTotalItems.Text = "0"
        txtStockCode.Clear()
        DgvRecords.Rows.Clear()
        DtpDate.Value = ut.GetSundaysDate(Now)

    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        txtStockCode.Text = UCase(txtStockCode.Text)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT Qty form qryWarehouseStock Where SMLocation = @SMLocation AND StockCode = @StockCode"
                With .Parameters
                    .AddWithValue("@SMLocation", txtFWarehouseRef.Text)
                    .AddWithValue("@StockCode", txtStockCode.Text)
                End With
                txtCurrentQty.Text = .ExecuteScalar
            End With
        End Using
    End Sub

    Private Sub DgvRecords_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecords.CellEndEdit
        Total()
    End Sub

    Private Sub TxtReference_Leave(sender As Object, e As EventArgs) Handles txtReference.Leave
        txtReference.Text = StrConv(txtReference.Text, VbStrConv.ProperCase)
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {
                .SelectCommand = New SqlCommand("SELECT * from qryWarehouseReturns WHERE WReturnsID = '" + TxtRecordNo.Text.ToString() + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            With Me
                .cmdOK.Text = "OK"
                .txtFWarehouseRef.Text = dt.Rows(0).Item("WarehouseRef")
                .txtReference.Text = dt.Rows(0).Item("Reference")
                .txtFWarehouseName.Text = dt.Rows(0).Item("WarehouseName")
                .txtTWarehouseRef.Text = dt.Rows(0).Item("SWarehouseRef")
                .txtTWarehouseName.Text = dt.Rows(0).Item("ToWarehouse")
                .txtTotalItems.Text = dt.Rows(0).Item("TotalItems")
                .DtpDate.Value = dt.Rows(0).Item("TransactionDate")
            End With
        End Using
        With Me
            .DgvRecords.Columns.Clear()
            Using conn As New SqlConnection(ut.GetConnString())
                Dim dgd As New SqlDataAdapter("SELECT * from tblWReturnsLines WHERE WReturnID = '" + TxtRecordNo.Text.ToString() + "'", conn)
                Dim ds As New DataTable
                dgd.Fill(ds)
                With .DgvRecords
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
                        .Item(3).HeaderText = "Qty"
                        .Item(3).Width = 80
                        .Item(4).Visible = False
                    End With
                End With
                .TxtRecordNo.Enabled = False
                .cmdClear.Enabled = False
            End Using
        End With
    End Sub
    Private Sub Total()
        Dim total As Integer = 0
        For i As Integer = 0 To DgvRecords.Rows.Count - 1
            total += DgvRecords.Rows(i).Cells(3).Value
        Next
        txtTotalItems.Text = total.ToString()
    End Sub
End Class