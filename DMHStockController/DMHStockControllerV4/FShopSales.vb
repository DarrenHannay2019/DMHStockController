Imports System.Data.SqlClient
Public Class FShopSales
    Dim ut As New CUtils
    Dim save As New CSave
    Dim upd As New CUpdate
    Dim Ch As New CCheck
    Dim Syslog As New CSystemLog
    Dim st As New CStockMovements
    Dim dt As New DataTable
    Dim mode As String
    Dim olddate As Date
    Dim con As String = ut.GetConnString()
    Private Sub FShopSales_Load(sender As Object, e As EventArgs) Handles Me.Load
        DateTimePicker1.Value = ut.GetSundaysDate(Now)
        Using conn As New SqlConnection(con)
            Dim ds As New DataSet
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT ShopRef from tblShops", conn)}
            conn.Open()
            adp.Fill(ds)
            Dim ACSC As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ACSC.Add(ds.Tables(0).Rows(i).Item(0).ToString)
            Next
            txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtShopRef.AutoCompleteCustomSource = ACSC
            txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
        ' Using conn As New SqlConnection(con)
        '     Dim Selectcmd As New SqlCommand
        '      With Selectcmd
        '    .Connection = conn
        '     .Connection.Open()
        '      .CommandType = CommandType.Text
        '       .CommandText = "SELECT VATRate from tblCompanyDetails"
        '        txtVATRate.Text = .ExecuteScalar
        '     End With
        '      txtVATRate.Text = FormatPercent(txtVATRate.Text)
        '   End Using
        If cmdOK.Text = "OK" Then LoadOld()
        If cmdOK.Text = "ADD" Then mode = "New"
        txtVATRate.Text = "0.00"
        txtVAT.Text = "0.00"
        txtCurrentQty.Enabled = False
        TxtStockCode.Enabled = False
        txtDelivered.Enabled = False
        txtSoldToDate.Enabled = False
        txtNetSale.Enabled = False
        txtQty.Enabled = False
    End Sub
    Private Sub LoadOld()
        With Me
            Using conn As New SqlConnection(con)
                Dim dt As New DataTable
                Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from tblSales WHERE SalesID = '" + txtSalesID.Text + "'", conn)}
                conn.Open()
                adp.Fill(dt)
                .txtSalesID.Text = dt.Rows(0).Item("SalesID")
                .DateTimePicker1.Value = dt.Rows(0).Item("TransactionDate")
                .lblShopName.Text = dt.Rows(0).Item("ShopName")
                .txtShopRef.Text = dt.Rows(0).Item("ShopRef")
                .txtTotalGarments.Text = dt.Rows(0).Item("TotalQty")
                .txtTotal.Text = dt.Rows(0).Item("TotalValue")
            End Using
            olddate = DateTimePicker1.Value
            Using conn As New SqlConnection(con)
                Dim dt As New DataTable
                Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("Select StockCode,'0' As Delivered,'0' AS Sold, CurrentQty,QtySold,SalesAmount from tblSalesLines Where SalesID='" + txtSalesID.Text.ToString() + "'", conn)}
                conn.Open()
                adp.Fill(dt)
                .DataGridView1.DataSource = dt
            End Using
        End With
        mode = "Old"
        DoOldLayout()
    End Sub

    Private Sub txtShopRef_Leave(sender As Object, e As EventArgs) Handles txtShopRef.Leave
        txtShopRef.Text = UCase(txtShopRef.Text)
        Using conn As New SqlConnection(con)
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT ShopName from tblShops Where ShopRef = @ShopRef"
                .Parameters.AddWithValue("@ShopRef", txtShopRef.Text)
                lblShopName.Text = .ExecuteScalar
            End With
        End Using
        Me.Text = "Sales for [" + txtShopRef.Text + "]  " + lblShopName.Text
        If mode = "New" Then
            Using conn As New SqlConnection(con)
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SMStockCode from qrySalesGrid2 WHERE SMLocation = '" + txtShopRef.Text + "'", conn)}
                conn.Open()
                adp.Fill(ds)
                Dim ACSC As New AutoCompleteStringCollection
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    ACSC.Add(ds.Tables(0).Rows(i).Item(0).ToString)
                Next
                TxtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource
                TxtStockCode.AutoCompleteCustomSource = ACSC
                TxtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End Using
            Using conn As New SqlConnection(con)
                Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SMStockCode,Delivered,TotalSold,CurrentQty,SoldQty,SalesAmount from qrySalesGrid2 Where smLocation ='" + txtShopRef.Text + "' AND CurrentQty <>0 and DeadCode ='0' Order By SMStockCode", conn)}
                conn.Open()
                adp.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
            DoLayOut()
        ElseIf mode = "Old" Then

        End If

    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles TxtStockCode.Leave
        Using conn As New SqlConnection(con)
            Dim dta As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * FROM qrySalesGrid2 Where SMStockCode = '" + TxtStockCode.Text + "'AND SMLocation = '" + txtShopRef.Text + "'", conn)}
            conn.Open()
            adp.Fill(dta)
            txtDelivered.Text = dta.Rows(0).Item("Delivered")
            txtCurrentQty.Text = dta.Rows(0).Item("CurrentQty")
            txtSoldToDate.Text = dta.Rows(0).Item("TotalSold")
        End Using
        TxtStockCode.Text = UCase(TxtStockCode.Text)
        txtQty.Select()
    End Sub

    Private Sub cmdAddToGrid_Click(sender As Object, e As EventArgs) Handles cmdAddToGrid.Click
        Dim myrow = dt.NewRow
        myrow(0) = TxtStockCode.Text
        myrow(1) = txtDelivered.Text
        myrow(2) = txtSoldToDate.Text
        myrow(3) = txtCurrentQty.Text
        myrow(4) = txtQty.Text
        myrow(5) = txtNetSale.Text
        dt.Rows.Add(myrow)
        Totals()
        TxtStockCode.Clear()
        txtDelivered.Clear()
        txtSoldToDate.Clear()
        txtCurrentQty.Clear()
        txtQty.Clear()
        txtNetSale.Clear()
    End Sub

    Private Sub cmdDelToGrid_Click(sender As Object, e As EventArgs) Handles cmdDelToGrid.Click
        If DataGridView1.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
        ElseIf DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        ElseIf DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If cmdOK.Text = "OK" Then
            UpdateToDB()
        Else
            SavetoDB()
        End If
        FGridShopSales.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        ut.GetSundaysDate(DateTimePicker1.Value)
    End Sub
    Private Sub DoLayOut()
        DataGridView1.Columns(0).HeaderText = "Stock Code"
        DataGridView1.Columns(0).Width = 270
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).Width = 70
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).Width = 70
        DataGridView1.Columns(2).HeaderText = "Total Sold"
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).Width = 70
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(3).HeaderText = "Current Qty"
        DataGridView1.Columns(4).Width = 80
        DataGridView1.Columns(4).HeaderText = "Sold Qty"
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(5).HeaderText = "Sales Amount"
        '   DataGridView1.Columns(6).Visible = False
        '  DataGridView1.Columns(7).Visible = False
        '  DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(5).DefaultCellStyle.Format = "C2"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoResizeColumns()
        Totals()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If Not IsNothing(e.Value) Then
            If e.ColumnIndex().ToString = 5 And IsNumeric(e.Value) Then
                e.Value = Format(FormatCurrency(e.Value))
            End If
        End If
        '   Totals()
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If (e.ColumnIndex = 4) Or (e.ColumnIndex = 5) Then   ' Checking numeric value for Column1 only
            ''   Dim value As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
            ' For Each c As Char In value
            'If Not Char.IsDigit(c) Then
            'MessageBox.Show("Please enter numeric value.")
            'DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
            'SendKeys.Send("+{TAB}")
            'Exit Sub
            'End If
            '   Next
            If Not IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                MessageBox.Show("Please enter numeric value.")
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
                SendKeys.Send("+{TAB}")
                Exit Sub
            End If
        End If
            If (e.ColumnIndex = 5) Then
            If IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then

                Dim sat As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                sat.TrimStart("£")
            End If
        End If
        '   If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
        '    Dim value As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        '  If Not Information.IsNumeric(value) Then
        ' MessageBox.Show("Please enter numeric value.")
        ' DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
        '   Exit Sub
        '   End If
        '   End If
        DataGridView1.Columns(5).DefaultCellStyle.Format = "C2"
        Totals()
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        '   DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "C2"
        If DataGridView1.CurrentCell.ReadOnly Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Totals()
        Dim curnetSales As Double
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView1.RowCount - 1
            curnetSales += CDec(DataGridView1.Rows(x).Cells(5).Value)
            lngQtyHangers += CInt(DataGridView1.Rows(x).Cells(4).Value)
            lngtotaldel += CInt(DataGridView1.Rows(x).Cells(1).Value)
            lngTotalSold += CInt(DataGridView1.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView1.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "C2"
        Next
        txtTotalGarments.Text = lngQtyHangers
        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
        txtNet.Text = FormatCurrency(txtNet.Text)
        '     txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        '     txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        '   Dim totalvat As Double
        '  Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        '    totalvat = CDbl(txtVAT.Text)
        '   saletotal = totalsale + totalvat
        txtTotal.Text = totalsale
        txtTotal.Text = FormatCurrency(txtTotal.Text)
    End Sub
    Private Sub SavetoDB()
        Totals()
        save.SaveShopSalesHead(txtShopRef.Text, lblShopName.Text, DateTimePicker1.Value, txtTotalGarments.Text, txtTotal.Text)
        Syslog.SaveSystemLog("N/A", "N/A", txtShopRef.Text, txtTotalGarments.Text, "Shop-Sale-Start-ADD", "Sales", DateTimePicker1.Value, "Start Shop Sale")
        txtSalesID.Text = Ch.SaveShopSalesHead()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim stockcode As String = DataGridView1.Rows(i).Cells(0).Value
            Dim Qty As Integer = DataGridView1.Rows(i).Cells(4).Value
            Dim CQty As Integer = DataGridView1.Rows(i).Cells(3).Value
            Dim Value As Decimal = DataGridView1.Rows(i).Cells(5).Value
            Dim deqty As Int32 = DataGridView1.Rows(i).Cells(1).Value
            If DataGridView1.Rows(i).Cells(1).Value = CType(deqty, Int32) Then deqty = "0"
            st.SaveStockMovements(stockcode, "N/A", txtShopRef.Text, "Shop", Qty * -1, 0, "Sale", DateTimePicker1.Value, Value, "Sale", txtSalesID.Text)
            Syslog.SaveSystemLog(stockcode, "N/A", txtShopRef.Text, Qty, "Shop-Sale-Item-ADD", "Sales", DateTimePicker1.Value, "Sale Add Item")
            save.SaveShopSalesLines(txtSalesID.Text, stockcode, CQty, Qty, Value, 0)
        Next
        st.DeleteZeroStockMovements("Sale", CInt(txtSalesID.Text), "Sale", CDate(DateTimePicker1.Value))
        save.deleteShopSalesLines(CInt(txtSalesID.Text.TrimEnd))
        Syslog.SaveSystemLog("N/A", "N/A", txtShopRef.Text, txtTotalGarments.Text, "Shop-Sale-End-ADD", "Sales", DateTimePicker1.Value, "End Shop Sale")
    End Sub
    Private Sub UpdateToDB()
        st.DeleteStockMovements("Sale", CInt(txtSalesID.Text), "Sale", CDate(olddate))
        upd.SaveShopSalesHead(CInt(txtSalesID.Text), txtShopRef.Text, lblShopName.Text, "0", CDate(DateTimePicker1.Value), CInt(txtTotalGarments.Text), CDec(txtTotal.Text))
        Syslog.SaveSystemLog("N/A", "N/A", txtShopRef.Text, CInt(txtTotalGarments.Text), "Shop-Sale-Start-Update", "Sales", CDate(DateTimePicker1.Value), "Start Shop Sale")
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim stockcode As String = DataGridView1.Rows(i).Cells(0).Value
            Dim Qty As Integer = DataGridView1.Rows(i).Cells(4).Value
            Dim CQty As Integer = DataGridView1.Rows(i).Cells(3).Value
            Dim Value As Decimal = DataGridView1.Rows(i).Cells(5).Value
            st.SaveStockMovements(stockcode, "N/A", txtShopRef.Text, "Shop", CInt(Qty * -1), 0, "Sale", CDate(DateTimePicker1.Value), CDec(Value), "Sale", CInt(txtSalesID.Text))
            Syslog.SaveSystemLog(stockcode, "N/A", txtShopRef.Text, CInt(Qty), "Shop-Sale-Item-ADD", "Sales", CDate(DateTimePicker1.Value), "Sale Add Item")
            upd.SaveShopSalesLines(CInt(txtSalesID.Text), stockcode, CInt(CQty), CInt(Qty), CDec(Value), 0)
        Next
        Syslog.SaveSystemLog("N/A", "N/A", txtShopRef.Text, CInt(txtTotalGarments.Text), "Shop-Sale-End-Update", "Sales", CDate(DateTimePicker1.Value), "End Shop Sale")
    End Sub

    Public Sub DoOldLayout()
        DataGridView1.AutoGenerateColumns = True
        DataGridView1.Columns(0).HeaderText = "Stock Code"
        DataGridView1.Columns(0).Width = 150
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).Width = 50
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).Width = 50
        DataGridView1.Columns(2).HeaderText = "Total Sold"
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(3).HeaderText = "Current Qty"
        DataGridView1.Columns(4).Width = 50
        DataGridView1.Columns(4).HeaderText = "Sold Qty"
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(5).HeaderText = "Sales Amount"
        '     DataGridView1.Columns(6).Visible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoResizeColumns()
        Dim lngQtyHangers As Long
        Dim curNetSales As Double
        Dim lngTotalDel As Long
        Dim lngTotalSold As Long
        Dim lngTotalCurrent As Long
        lngQtyHangers = 0
        curNetSales = 0
        lngTotalDel = 0
        lngTotalSold = 0
        lngTotalCurrent = 0
        '0 StockCode
        '1 Delivered
        '2 Sold
        '3 CurrentQty
        '4 QtySold
        '5 SalesAmount
        For x As Integer = 0 To DataGridView1.RowCount - 1
            lngTotalDel += CInt(DataGridView1.Rows(x).Cells(1).Value)
            lngTotalCurrent += CInt(DataGridView1.Rows(x).Cells(3).Value)
            lngTotalSold += CInt(DataGridView1.Rows(x).Cells(4).Value)
            curNetSales += CLng(DataGridView1.Rows(x).Cells(5).Value)
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "C2"
        Next
        txtTotalDelivered.Text = lngTotalDel
        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalSold.Text = lngTotalSold
        txtTotalGarments.Text = lngTotalSold
        txtNet.Text = curNetSales
        txtNet.Text = FormatCurrency(txtNet.Text)
        'txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        '   txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Decimal
        Dim totalvat As Decimal
        Dim saletotal As Decimal
        totalsale = CDec(txtNet.Text)
        '       totalvat = CDec(txtVAT.Text)
        saletotal = totalsale '+ totalvat
        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)
        cmdOK.Select()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            txtCurrentQty.Enabled = False
            TxtStockCode.Enabled = False
            txtDelivered.Enabled = False
            txtSoldToDate.Enabled = False
            txtNetSale.Enabled = False
            txtQty.Enabled = False
        ElseIf CheckBox1.Checked = True Then
            TxtStockCode.Enabled = True
            txtNetSale.Enabled = True
            txtQty.Enabled = True
        End If
    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        If Me.DataGridView1.IsCurrentCellDirty Then
            Dim d As Double
            'string cellvalue = this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            If Me.DataGridView1.Columns(e.ColumnIndex).Name = "UnitCost" AndAlso Not Double.TryParse(e.FormattedValue.ToString(), d) Then
                e.Cancel = True
                Me.DataGridView1(e.ColumnIndex, e.RowIndex).Value = 0
                MessageBox.Show("Non numeric characters are not allowed for Unit Cost")
            End If
        End If
    End Sub
End Class