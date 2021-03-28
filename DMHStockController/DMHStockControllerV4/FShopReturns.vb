Imports System.Data.SqlClient
Public Class FShopReturns
    Dim ut As New CUtils
    Dim save As New CSave
    Dim upd As New CUpdate
    Dim Ch As New CCheck
    Dim Syslog As New CSystemLog
    Dim st As New CStockMovements
    Dim olddate As Date
    Dim con As String = ut.GetConnString()

    Private Sub FShopReturns_Load(sender As Object, e As EventArgs) Handles Me.Load
        If cmdOK.Text = "OK" Then LoadOld()
        If cmdOK.Text = "ADD" Then LoadNew()
    End Sub
    Private Sub LoadNew()
        txtWarehouseRef.Text = "UNI" : txtWarehouseName.Text = "Universal Warehouse"
        DtpDate.Value = ut.GetSundaysDate(Now)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ds As New DataSet
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT ShopRef from tblShops", conn)}
            Dim ACSC As New AutoCompleteStringCollection
            conn.Open()
            adp.Fill(ds)
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ACSC.Add(ds.Tables(0).Rows(i).Item(0).ToString())
            Next
            txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtShopRef.AutoCompleteCustomSource = ACSC
            txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(con)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {
            .SelectCommand = New SqlCommand("SELECT * from tblReturns WHERE ReturnsID = '" + txtReturnID.Text.ToString() + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            txtReference.Text = dt.Rows(0).Item("Reference")
            txtShopRef.Text = dt.Rows(0).Item("ShopRef")
            txtTotalItems.Text = dt.Rows(0).Item("TotalItems")
            txtWarehouseRef.Text = dt.Rows(0).Item("WarehouseRef")
            DtpDate.Value = dt.Rows(0).Item("TransactionDate")
            olddate = dt.Rows(0).Item("TransactionDate")
        End Using
        Using conn As New SqlConnection(con)
            Dim ds As New DataSet
            Dim dgd As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from tblReturnLines WHERE ReturnID = '" + txtReturnID.Text.ToString() + "'", conn)}
            conn.Open()
            dgd.Fill(ds, "tblReturnLines")
            DgvRecords.Columns.Clear()
            With DgvRecords
                .DataSource = ds
                .DataMember = "tblReturnLines"
                .AutoGenerateColumns = True
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
                    .Item(2).HeaderText = "Stock Code"
                    '.Item(0).Width = 120
                    .Item(1).Visible = False
                    .Item(3).HeaderText = "Qty"
                    .Item(4).Visible = False
                End With
            End With
        End Using

        '  DgvRecords.Columns.Clear()

        Using conn As New SqlConnection(con)
            Dim selectcmd As New SqlCommand

            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT WarehouseName From tblWarehouses Where WarehouseRef = '" + txtWarehouseRef.Text + "'"
                txtWarehouseName.Text = .ExecuteScalar
            End With
        End Using
        Using conn As New SqlConnection(con)
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT ShopName From tblShops Where ShopRef = '" + txtShopRef.Text + "'"
                txtShopName.Text = .ExecuteScalar
            End With
        End Using
        Totals()
    End Sub
    Private Sub TxtReference_Leave(sender As Object, e As EventArgs) Handles txtReference.Leave
        txtReference.Text = StrConv(txtReference.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtShopRef_Leave(sender As Object, e As EventArgs) Handles txtShopRef.Leave
        txtShopRef.Text = UCase(txtShopRef.Text)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .CommandText = "SELECT ShopName from tblShops WHERE ShopRef = @ShopRef"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ShopRef", txtShopRef.Text.Trim())
                .Connection.Open()
                txtShopName.Text = .ExecuteScalar
            End With
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SMStockCode from qryShopStock WHERE SMLocation ='" + txtShopRef.Text + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            Dim ACSC As New AutoCompleteStringCollection
            For i As Integer = 0 To dt.Rows.Count - 1
                ACSC.Add(dt.Rows(i).Item(0).ToString())
            Next
            txtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtStockCode.AutoCompleteCustomSource = ACSC
            txtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
        If txtShopName.Text = Nothing Then MsgBox("Please check Shop Code") : txtShopRef.Select()
        If txtShopName.Text <> Nothing Then txtStockCode.Select()
    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        txtStockCode.Text = UCase(txtStockCode.Text)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT qty from qryShopStock WHERE SMLocation =@SMLocation AND SMStockCode = @SMStockCode"
                .Parameters.AddWithValue("@SMLocation", txtShopRef.Text)
                .Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
                txtCurrentQty.Text = .ExecuteScalar
            End With
        End Using
        txtTransferQty.Select()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then txtWarehouseRef.Text = "WOFF" : txtWarehouseName.Text = "Back To Supplier"
        If CheckBox1.Checked = False Then txtWarehouseRef.Text = "UNI" : txtWarehouseName.Text = "Universal Warehouse"
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim result As Decimal = 0
        Dim LineResult As Decimal = 0
        Using conn As New SqlConnection(ut.GetConnString())
            Dim cmd As New SqlCommand
            With cmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT unitprice from qryUnitPrice WHERE StockCode = @StockCode"
                .Parameters.AddWithValue("@StockCode", txtStockCode.Text)
                result = .ExecuteScalar
            End With
        End Using
        LineResult = CDec(CInt(txtTransferQty.Text) * result)
        Dim rownum As Integer = DgvRecords.Rows.Add()
        DgvRecords.Rows.Item(rownum).Cells(0).Value = "0"
        DgvRecords.Rows.Item(rownum).Cells(1).Value = "0"
        DgvRecords.Rows.Item(rownum).Cells(2).Value = txtStockCode.Text.ToString()
        DgvRecords.Rows.Item(rownum).Cells(3).Value = txtTransferQty.Text.ToString()
        DgvRecords.Rows.Item(rownum).Cells(4).Value = LineResult.ToString()
        Totals()
        txtStockCode.Clear()
        txtCurrentQty.Clear()
        txtTransferQty.Clear()
        txtStockCode.Clear()
    End Sub

    Private Sub CmdClearGrid_Click(sender As Object, e As EventArgs) Handles cmdClearGrid.Click
        If DgvRecords.SelectedRows.Count = 0 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf DgvRecords.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DgvRecords.SelectedRows
                DgvRecords.Rows.Remove(row)
            Next
        ElseIf DgvRecords.SelectedRows.Count = 1 Then
            DgvRecords.Rows.Remove(DgvRecords.CurrentRow)
        End If
        txtStockCode.Clear()
        txtCurrentQty.Clear()
        txtTransferQty.Clear()
        txtStockCode.Clear()
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If cmdOK.Text = "OK" Then UpdateToDb()
        If cmdOK.Text = "ADD" Then SaveToDb()
        FGridSHReturns.TsbRefresh.PerformClick()
        Close()

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then FGridSHReturns.TsbRefresh.PerformClick() : Me.Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtReference.Clear()
        txtCurrentQty.Clear()
        txtShopName.Clear()
        txtShopRef.Clear()
        txtStockCode.Clear()
        txtTransferQty.Clear()
        txtWarehouseName.Clear()
        txtWarehouseRef.Clear()
        DtpDate.Value = ut.GetSundaysDate(Now)
    End Sub

    Private Sub DgvRecords_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecords.CellEndEdit
        Totals()
    End Sub
    Private Sub SaveToDb()
        Syslog.SaveSystemLog("N/A", "N/A", txtShopRef.Text, CInt(txtTotalItems.Text), "Shop-Return-Start-ADD", "Shop-Out", CDate(DtpDate.Value), "Start Shop Return")
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalItems.Text), "Shop-Return-Start-ADD", "Warehouse-In", CDate(DtpDate.Value), "Start Shop Return")
        save.SaveShopReturnsHead(txtShopRef.Text, txtWarehouseRef.Text, txtReference.Text, CInt(txtTotalItems.Text), CDate(DtpDate.Value))
        txtReturnID.Text = Ch.SaveShopReturnsHead()
        For i As Integer = 0 To DgvRecords.Rows.Count - 1
            Dim stockcode As String = DgvRecords.Rows(i).Cells(2).Value
            Dim Qty As Integer = DgvRecords.Rows(i).Cells(3).Value
            Dim Value As Decimal = DgvRecords.Rows(i).Cells(4).Value
            save.SaveShopReturnsLines(CInt(txtReturnID.Text), stockcode, CInt(Qty), CDec(Value))
            Syslog.SaveSystemLog(stockcode, "N/A", txtShopRef.Text, CInt(Qty), "Shop-Return", "Add New Item", CDate(DtpDate.Value), "Add Item to Return")
            st.SaveStockMovements(stockcode, "N/A", txtShopRef.Text, "Shop", CInt(Qty * -1), 0, "Return", CDate(DtpDate.Value), CDec(Value * -1), txtReference.Text, CInt(txtReturnID.Text))
            st.SaveStockMovements(stockcode, "N/A", txtWarehouseRef.Text, "Warehouse", CInt(Qty), 0, "Return", CDate(DtpDate.Value), CDec(Value), txtReference.Text, CInt(txtReturnID.Text))
        Next
        Syslog.SaveSystemLog("N/A", "N/A", txtShopRef.Text, CInt(txtTotalItems.Text), "Shop-Return-End-ADD", "Shop-Out", CDate(DtpDate.Value), "End Shop Return")
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalItems.Text), "Shop-Return-End-ADD", "Warehouse-In", CDate(DtpDate.Value), "End Shop Return")
    End Sub
    Private Sub UpdateToDb()
        Syslog.SaveSystemLog("N/A", "N/A", txtShopRef.Text, CInt(txtTotalItems.Text), "Shop-Return-Start=Update", "Shop-Out", CDate(DtpDate.Value), "Start Old Shop Return")
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalItems.Text), "Shop-Return-Start-Update", "Warehouse-In", CDate(DtpDate.Value), "Start Old Shop Return")
        st.DeleteStockMovements("Return", CInt(txtReturnID.Text), txtReference.Text, CDate(olddate))
        For i As Integer = 0 To DgvRecords.Rows.Count - 1
            Dim stockcode As String = DgvRecords.Rows(i).Cells(2).Value
            Dim Qty As Integer = DgvRecords.Rows(i).Cells(3).Value
            Dim Value As Decimal = 0
            Dim LineValue As Decimal = 0
            Using conn As New SqlConnection(ut.GetConnString())
                Dim selectcmd As New SqlCommand
                With selectcmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT unitprice from qryUnitPrice WHERE StockCode = @StockCode"
                    With .Parameters
                        .AddWithValue("@StockCode", txtStockCode.Text)
                    End With
                    Value = .ExecuteScalar
                End With
            End Using
            LineValue = CDec(Value * CInt(DgvRecords.Rows(i).Cells(4).Value))
            upd.SaveShopReturnsLines(CInt(txtReturnID.Text), stockcode, CInt(Qty), CDec(LineValue))
            Syslog.SaveSystemLog(stockcode, "N/A", txtShopRef.Text, CInt(Qty), "Shop-Return", "Update Item", CDate(DtpDate.Value), "update item on old Return")
            st.SaveStockMovements(stockcode, "N/A", txtShopRef.Text, "Shop", CInt(Qty * -1), 0, "Return", CDate(DtpDate.Value), CDec(LineValue * -1), txtReference.Text, CInt(txtReturnID.Text))
            st.SaveStockMovements(stockcode, "N/A", txtWarehouseRef.Text, "Warehouse", CInt(Qty), 0, "Return", CDate(DtpDate.Value), CDec(LineValue), txtReference.Text, CInt(txtReturnID.Text))
        Next
        upd.SaveShopReturnsHead(CInt(txtReturnID.Text), txtShopRef.Text, txtWarehouseRef.Text, txtReference.Text, CInt(txtTotalItems.Text), CDate(DtpDate.Value))
        Syslog.SaveSystemLog("N/A", "N/A", txtShopRef.Text, CInt(txtTotalItems.Text), "Shop-Return-End-Update", "Shop-Out", CDate(DtpDate.Value), "End Shop Return")
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalItems.Text), "Shop-Return-End-Update", "Warehouse-In", CDate(DtpDate.Value), "End Shop Return")
    End Sub
    Public Sub Totals()
        Dim Total As Integer = 0
        For p As Integer = 0 To DgvRecords.Rows.Count - 1
            Total += DgvRecords.Rows(p).Cells(3).Value
        Next
        txtTotalItems.Text = Total.ToString()
    End Sub
End Class