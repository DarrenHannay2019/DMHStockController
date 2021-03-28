Imports System.Data.SqlClient
Public Class FShopTransfers
    Dim save As New CSave
    Dim udp As New CUpdate
    Dim ut As New CUtils
    Dim chk As New CCheck
    Dim st As New CStockMovements
    Dim olddate As Date
    Dim syslog As New CSystemLog
    Dim sqlcon As String = ut.GetConnString()
    Private Sub FShopTransfers_Load(sender As Object, e As EventArgs) Handles Me.Load
        'DtpDate.Value = ut.GetSundaysDate(Now)
        DtpDate.Value = ut.GetNextSundaysDate(Now)
        Using conn As New SqlConnection(sqlcon)
            Dim ds As New DataSet
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT ShopRef FROM tblShops", conn)}
            conn.Open()
            adp.Fill(ds)
            Dim ACSC As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ACSC.Add(ds.Tables(0).Rows(i).Item(0).ToString())
            Next
            TxtFromShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtFromShopRef.AutoCompleteCustomSource = ACSC
            TxtFromShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
        If CmdOK.Text = "OK" Then LoadOld()
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(sqlcon)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from tblShopTransfers WHERE TransferID = '" + TxtTransferID.Text.ToString() + "'", conn)}
            adp.Fill(dt)
            TxtTFNote.Text = dt.Rows(0).Item("Reference")
            TxtFromShopRef.Text = dt.Rows(0).Item("ShopRef")
            txtFromShopName.Text = dt.Rows(0).Item("ShopName")
            TxtToShopRef.Text = dt.Rows(0).Item("ToShopRef")
            txtToShopName.Text = dt.Rows(0).Item("ToShopName")
            txtTotalTransferTo.Text = dt.Rows(0).Item("TotalQtyIn")
            DtpDate.Value = dt.Rows(0).Item("TransferDate")
            olddate = dt.Rows(0).Item("TransferDate")
        End Using
        Using conn As New SqlConnection(sqlcon)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from tblShopTransferLines WHERE TransferID = '" + TxtTransferID.Text.ToString() + "'", conn)}
            adp.Fill(dt)
            With DgvRecords
                .Columns.Clear()
                .DataSource = dt
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
                With DgvRecords.Columns
                    .Item(0).Visible = False
                    .Item(1).Visible = False
                    .Item(2).Visible = False
                    .Item(3).Visible = False
                    .Item(4).HeaderText = "Stock Code"
                    .Item(5).Visible = False
                    .Item(6).Visible = True
                    .Item(6).HeaderText = "Qty"
                    .Item(7).Visible = False
                End With
            End With
        End Using
    End Sub
    Private Sub CmdAddToGrid_Click(sender As Object, e As EventArgs) Handles CmdAddToGrid.Click
        Dim value, Linevalue As Decimal
        Using conn As New SqlConnection(sqlcon)
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT UnitPrice From qryUnitPrice Where StockCode = @StockCode"
                .Parameters.AddWithValue("@StockCode", TxtStockCode.Text)
                value = .ExecuteScalar
            End With
            Linevalue = CDec(CInt(TxtTransferFromQty.Text) * CDec(value))
        End Using
        Dim RowNum As Integer = DgvRecords.Rows.Add()
        DgvRecords.Rows.Item(RowNum).Cells(0).Value = "0"
        DgvRecords.Rows.Item(RowNum).Cells(1).Value = "0"
        DgvRecords.Rows.Item(RowNum).Cells(2).Value = "0"
        DgvRecords.Rows.Item(RowNum).Cells(3).Value = "0"
        DgvRecords.Rows.Item(RowNum).Cells(4).Value = TxtStockCode.Text
        DgvRecords.Rows.Item(RowNum).Cells(5).Value = TxtCurrentQty.Text
        DgvRecords.Rows.Item(RowNum).Cells(6).Value = TxtTransferFromQty.Text
        DgvRecords.Rows.Item(RowNum).Cells(7).Value = TxtTransferFromQty.Text
        TxtStockCode.Clear()
        TxtTransferFromQty.Clear()
        TxtCurrentQty.Clear()
        TxtStockCode.Select()
        Total()
    End Sub

    Private Sub CmdDeleteFromGrid_Click(sender As Object, e As EventArgs) Handles CmdDeleteFromGrid.Click
        If DgvRecords.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DgvRecords.SelectedRows
                DgvRecords.Rows.Remove(row)
            Next
        ElseIf DgvRecords.SelectedRows.count = 1 Then
            DgvRecords.Rows.Remove(DgvRecords.CurrentRow)
        ElseIf DgvRecords.SelectedRows.count = 0 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        If CmdOK.Text = "ADD" Then
            SaveToDB()
        ElseIf CmdOK.Text = "OK" Then
            UpdateToDB()
        End If
        FGridSHTransfers.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then FGridSHTransfers.TsbRefresh.PerformClick() : Me.Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        DgvRecords.Rows.Clear()
        TxtStockCode.Clear()
        TxtTransferFromQty.Clear()
        TxtCurrentQty.Clear()
        txtFromShopName.Clear()
        TxtFromShopRef.Clear()
        TxtTFNote.Clear()
        txtToShopName.Clear()
        TxtToShopRef.Clear()
        DtpDate.Value = ut.GetNextSundaysDate(Now)
        txtTotalTransferTo.Clear()
    End Sub

    Private Sub TxtFromShopRef_Leave(sender As Object, e As EventArgs) Handles TxtFromShopRef.Leave
        TxtFromShopRef.Text = UCase(TxtFromShopRef.Text)
        Using conn As New SqlConnection(sqlcon)
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT ShopName from tblShops Where ShopRef =@ShopRef"
                .Parameters.AddWithValue("ShopRef", TxtFromShopRef.Text)
                txtFromShopName.Text = .ExecuteScalar
            End With
        End Using
        Using conn As New SqlConnection(sqlcon)
            Dim ds As New DataSet
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT ShopRef FROM tblShops WHERE ShopRef <>'" + TxtFromShopRef.Text + "'", conn)}
            conn.Open()
            adp.Fill(ds)
            Dim ACSC As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ACSC.Add(ds.Tables(0).Rows(i).Item(0).ToString())
            Next
            TxtToShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtToShopRef.AutoCompleteCustomSource = ACSC
            TxtToShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
        Using conn As New SqlConnection(sqlcon)
            Dim ds As New DataSet
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SMStockCode FROM qryShopStock WHERE SMLocation ='" + TxtFromShopRef.Text + "'", conn)}
            conn.Open()
            adp.Fill(ds)
            Dim ACSC As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ACSC.Add(ds.Tables(0).Rows(i).Item(0).ToString())
            Next
            TxtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtStockCode.AutoCompleteCustomSource = ACSC
            TxtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles TxtStockCode.Leave
        TxtStockCode.Text = UCase(TxtStockCode.Text)
        Using conn As New SqlConnection(sqlcon)
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT Qty from qryShopStock WHERE SMLocation = @SMLocation AND SMStockCode = @SMStockCode"
                With .Parameters
                    .AddWithValue("@SMLocation", TxtFromShopRef.Text)
                    .AddWithValue("@SMStockCode", TxtStockCode.Text)
                End With
                TxtCurrentQty.Text = .ExecuteScalar
            End With
        End Using
    End Sub

    Private Sub TxtToShopRef_Leave(sender As Object, e As EventArgs) Handles TxtToShopRef.Leave
        TxtToShopRef.Text = UCase(TxtToShopRef.Text)
        Using conn As New SqlConnection(sqlcon)
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT ShopName from tblShops Where ShopRef =@ShopRef"
                .Parameters.AddWithValue("ShopRef", TxtToShopRef.Text)
                txtToShopName.Text = .ExecuteScalar
            End With
        End Using
    End Sub
    Private Sub DgvRecords_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecords.CellEndEdit
        Total()
    End Sub

    Private Sub TxtTFNote_Leave(sender As Object, e As EventArgs) Handles TxtTFNote.Leave
        TxtTFNote.Text = StrConv(TxtTFNote.Text, VbStrConv.Uppercase)
    End Sub
    Public Sub Total()
        Dim total As Integer = 0
        For i As Integer = 0 To DgvRecords.Rows.Count - 1
            total += DgvRecords.Rows(i).Cells(6).Value
        Next
        txtTotalTransferTo.Text = total.ToString()
    End Sub
    Private Sub SaveToDB()
        syslog.SaveSystemLog("N/A", "N/A", TxtFromShopRef.Text, CInt(txtTotalTransferTo.Text), "Shop-Transfer-Start-ADD", "Shop-Out", CDate(DtpDate.Value), "Start Shop Transfer")
        syslog.SaveSystemLog("N/A", "N/A", TxtToShopRef.Text, CInt(txtTotalTransferTo.Text), "Shop-Transfer-Start-ADD", "Shop-In", CDate(DtpDate.Value), "Start Shop Transfer")
        save.SaveShopTransHead(TxtTFNote.Text, CDate(DtpDate.Value), TxtFromShopRef.Text, txtFromShopName.Text, TxtToShopRef.Text, txtToShopName.Text, CInt(txtTotalTransferTo.Text), CInt(txtTotalTransferTo.Text))
        TxtTransferID.Text = chk.SaveShopTransHead()
        For i As Integer = 0 To DgvRecords.Rows.Count - 1
            Dim stockcode As String = DgvRecords.Rows(i).Cells(4).Value
            Dim Qty As Integer = DgvRecords.Rows(i).Cells(6).Value
            Dim Value As Integer = DgvRecords.Rows(i).Cells(5).Value
            Dim SMIDOUT, SMIDIN As Integer
            syslog.SaveSystemLog(stockcode, "N/A", TxtFromShopRef.Text, CInt(Qty), "Shop-Transfer", "Add New Item", CDate(DtpDate.Value), "Add Item to Shop Transfer")
            syslog.SaveSystemLog(stockcode, "N/A", TxtToShopRef.Text, CInt(Qty), "Shop-Transfer", "Add New Item", CDate(DtpDate.Value), "Add Item to Shop Transfer")
            st.SaveStockMovements(stockcode, "N/A", TxtFromShopRef.Text, "Shop", CInt(Qty * -1), 0, "Shop Transfer", CDate(DtpDate.Value), CDec(Value * -1), TxtTFNote.Text, CInt(TxtTransferID.Text))
            SMIDOUT = st.ChkStockMovements("Shop Transfer", CInt(TxtTransferID.Text), TxtTFNote.Text, CDate(DtpDate.Value))
            st.SaveStockMovements(stockcode, "N/A", TxtToShopRef.Text, "Shop", CInt(Qty), 0, "Shop Transfer", CDate(DtpDate.Value), CDec(Value), TxtTFNote.Text, CInt(TxtTransferID.Text))
            SMIDIN = st.ChkStockMovementsplus("Shop Transfer", CInt(TxtTransferID.Text), TxtTFNote.Text, CDate(DtpDate.Value))
            save.SaveShopTransLines(CInt(TxtTransferID.Text), CInt(SMIDOUT), CInt(SMIDIN), stockcode, Value, CInt(Qty), CInt(Qty))
        Next
        syslog.SaveSystemLog("N/A", "N/A", TxtFromShopRef.Text, CInt(txtTotalTransferTo.Text), "Shop-Transfer-End-ADD", "Shop-Out", CDate(DtpDate.Value), "End Shop Transfer")
        syslog.SaveSystemLog("N/A", "N/A", TxtToShopRef.Text, CInt(txtTotalTransferTo.Text), "Shop-Transfer-End-ADD", "Shop-In", CDate(DtpDate.Value), "End Shop Transfer")
    End Sub
    Private Sub UpdateToDB()
        syslog.SaveSystemLog("N/A", "N/A", TxtFromShopRef.Text, CInt(txtTotalTransferTo.Text), "Shop-Transfer-Start-Update", "Shop-Out", CDate(DtpDate.Value), "Start Shop Transfer")
        syslog.SaveSystemLog("N/A", "N/A", TxtToShopRef.Text, CInt(txtTotalTransferTo.Text), "Shop-Transfer-Start-Update", "Shop-In", CDate(DtpDate.Value), "Start Shop Transfer")
        udp.SaveShopTransHead(CInt(TxtTransferID.Text), TxtTFNote.Text, CDate(DtpDate.Value), TxtFromShopRef.Text, txtFromShopName.Text, TxtToShopRef.Text, txtToShopName.Text, CInt(txtTotalTransferTo.Text), CInt(txtTotalTransferTo.Text))
        st.DeleteStockMovements("Shop Transfer", CInt(TxtTransferID.Text), TxtTFNote.Text, CDate(olddate))
        For i As Integer = 0 To DgvRecords.Rows.Count - 1
            Dim stockcode As String = DgvRecords.Rows(i).Cells(4).Value
            Dim Qty As Integer = DgvRecords.Rows(i).Cells(6).Value
            Dim Value As Integer = DgvRecords.Rows(i).Cells(5).Value
            Dim SMIDOUT, SMIDIN As Integer
            syslog.SaveSystemLog(stockcode, "N/A", TxtFromShopRef.Text, CInt(Qty), "Shop-Transfer", "Add New Item", CDate(DtpDate.Value), "Add Item to Shop Transfer")
            syslog.SaveSystemLog(stockcode, "N/A", TxtToShopRef.Text, CInt(Qty), "Shop-Transfer", "Add New Item", CDate(DtpDate.Value), "Add Item to Shop Transfer")
            st.SaveStockMovements(stockcode, "N/A", TxtFromShopRef.Text, "Shop", CInt(Qty * -1), 0, "Shop Transfer", CDate(DtpDate.Value), CDec(Value * -1), TxtTFNote.Text, CInt(TxtTransferID.Text))
            SMIDOUT = st.ChkStockMovements("Shop Transfer", CInt(TxtTransferID.Text), TxtTFNote.Text, CDate(DtpDate.Value))
            st.SaveStockMovements(stockcode, "N/A", TxtToShopRef.Text, "Shop", CInt(Qty), 0, "Shop Transfer", CDate(DtpDate.Value), CDec(Value), TxtTFNote.Text, CInt(TxtTransferID.Text))
            SMIDIN = st.ChkStockMovementsplus("Shop Transfer", CInt(TxtTransferID.Text), TxtTFNote.Text, CDate(DtpDate.Value))
            udp.SaveShopTransLines(CInt(TxtTransferID.Text), CInt(SMIDOUT), CInt(SMIDIN), stockcode, Value, CInt(Qty), CInt(Qty))
        Next
        syslog.SaveSystemLog("N/A", "N/A", TxtFromShopRef.Text, CInt(txtTotalTransferTo.Text), "Shop-Transfer-End-Update", "Shop-Out", CDate(DtpDate.Value), "End Shop Transfer")
        syslog.SaveSystemLog("N/A", "N/A", TxtToShopRef.Text, CInt(txtTotalTransferTo.Text), "Shop-Transfer-End-Update", "Shop-In", CDate(DtpDate.Value), "End Shop Transfer")
    End Sub
End Class