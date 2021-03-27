Imports System.Data.SqlClient

Public Class FSales
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim insertcommand2 As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Dim SelectCommand As New SqlCommand
    Dim strWarehouse As String
    Dim strStock As String
    Dim dds As DataTable = New DataTable()
    Dim dSales As DataSet
    Dim strStockCode As String
    Dim dLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
    Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "NEW" Then loadnew()
        If FMain.txtMode.Text = "OLD" Then LoadOldRecord()
        If FMain.txtMode.Text = "DELETE" Then DeleteRecords()
    End Sub

    Private Sub chkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAll.CheckedChanged
        If chkShowAll.CheckState = CheckState.Checked Then
            getallstock()
        Else
            getshopStock()
        End If
    End Sub

    Private Sub cmdClearGrid_Click(sender As Object, e As EventArgs) Handles cmdClearGrid.Click

    End Sub

    Private Sub cmdFindShop_Click(sender As Object, e As EventArgs) Handles cmdFindShop.Click

    End Sub

    Private Sub cmdAddToGrid_Click(sender As Object, e As EventArgs) Handles cmdAddToGrid.Click

        Dim newrow As DataRow = dds.NewRow
        newrow(0) = ComboBox1.Text
        newrow(2) = txtDelivered.Text
        newrow(1) = txtCurrentQty.Text
        newrow(3) = txtSoldToDate.Text
        newrow(4) = txtQty.Text
        newrow(5) = txtNetSale.Text

        dds.Rows.Add(newrow)

        ' Dim rowNum As dds.Rows.Add()
        ' DataGridView1.Rows.Item(rowNum).Cells(0).Value = ComboBox1.Text.ToString()
        ' DataGridView1.Rows.Item(rowNum).Cells(1).Value = txtDelivered.Text.ToString()
        ' DataGridView1.Rows.Item(rowNum).Cells(2).Value = txtSoldToDate.Text.ToString()
        ' DataGridView1.Rows.Item(rowNum).Cells(3).Value = txtCurrentQty.Text.ToString()
        ' DataGridView1.Rows.Item(rowNum).Cells(5).Value = txtNetSale.Text.ToString()
        ' DataGridView1.Rows.Item(rowNum).Cells(4).Value = txtQty.Text.ToString()
        '    dds.Rows.Add()
        totals()
        txtStockCode.Clear()
        txtCurrentQty.Clear()
        txtNetSale.Clear()
        txtSoldToDate.Clear()
    End Sub

    Private Sub cmdFindStock_Click(sender As Object, e As EventArgs) Handles cmdFindStock.Click

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If FMain.txtMode.Text = "OLD" Then
            Me.Close()
        Else
            createSales()

            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click

    End Sub

    Private Sub txtShopRef_Leave(sender As Object, e As EventArgs) Handles txtShopRef.Leave
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "SELECT ShopName from tblShops Where ShopRef='" + txtShopRef.Text.Trim + "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        Label17.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()
        Me.Text = "Sales for [" + txtShopRef.Text + "]  " + Label17.Text
        getshopStock()
        'TODO: This line of code loads data into the 'DMHStockv1DataSet10.qrySalesGrid' table. You can move, or remove it, as needed.
        ' Me.QrySalesGridTableAdapter.Fill(Me.DMHStockv1DataSet10.qrySalesGrid)
        ' BindingSource1.Filter = "SMLocation Like '" + txtShopRef.Text + "'"
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        If chkShowAll.Checked = False Then
            If ComboBox1.Items.Count > 0 Then
                Dim sql As String = "Select Qty,Delivered,Sold from qrySalesGrid where SMStockCode ='" + ComboBox1.Text + "'"
                Dim cbodata As New SqlDataAdapter
                Dim dds As DataTable = New DataTable()
                cbodata.SelectCommand = New SqlCommand(sql, connection)
                cbodata.Fill(dds)
                txtCurrentQty.Text = dds.Rows(0)("Qty").ToString
                ' txtCurrentQty.Text = dds.Rows(0)("Qty").ToString
            Else
                txtCurrentQty.Text = "0"
            End If
        Else
            If ComboBox1.Items.Count > 0 Then
                Dim sql As String = "Select DeliveredQtyHangers from tblStock where StockCode ='" + ComboBox1.Text + "'"
                Dim cbodata As New SqlDataAdapter
                Dim dds As DataTable = New DataTable()
                cbodata.SelectCommand = New SqlCommand(sql, connection)
                cbodata.Fill(dds)
                txtCurrentQty.Text = dds.Rows(0)("DeliveredQtyHangers").ToString
                ' txtCurrentQty.Text = dds.Rows(0)("Qty").ToString
            Else
                txtCurrentQty.Text = "0"
            End If
        End If
    End Sub

    Private Sub loadnew()
        'Dim VATRate As Double
        'txtVATRate.Text = FormatPercent(VATRate, "0.00")
        DateTimePicker1.Value = dLastSunday

    End Sub

    Private Sub getallstock()
        Dim selectdata As String = "SELECT StockCode from tblStock where DeadCode=0"
        Dim da As New SqlDataAdapter(selectdata, connectionString)
        Dim ds As New DataSet
        connection.Open()
        da.Fill(ds)
        connection.Close()
        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.DisplayMember = "StockCode"
    End Sub
    Private Sub getshopStock()
        DataGridView1.Columns.Clear()
        Dim sql As String = "Select SMStockCode,Qty,Delivered,Sold,SoldQty,SalesAmount from qrySalesGrid where SMLocation ='" + txtShopRef.Text + "'"
        Dim strSQL As String = "SELECT dbo.tblStockMovements.SMStockCode, SUM(dbo.tblStockMovements.MovementQtyHangers) AS Qty,dbo.qrySalesEntryQtyDelivered.Delivered, dbo.qrySalesEntryQtySold.Sold, '' AS SoldQty, '' AS SalesAmount,                      dbo.tblStockMovements.SMLocation FROM dbo.qrySalesEntryQtyDelivered INNER JOIN dbo.tblStockMovements ON dbo.qrySalesEntryQtyDelivered.SMStockCode = dbo.tblStockMovements.SMStockCode AND dbo.qrySalesEntryQtyDelivered.SMLocation = dbo.tblStockMovements.SMLocation INNER JOIN                        dbo.tblStock ON dbo.tblStockMovements.SMStockCode = dbo.tblStock.StockCode INNER JOIN  dbo.qrySalesEntryQtySold ON dbo.tblStockMovements.SMStockCode = dbo.qrySalesEntryQtySold.SMStockCode AND dbo.tblStockMovements.SMLocation = dbo.qrySalesEntryQtySold.SMLocation WHERE tblStockMovements.SMLocation = '" + txtShopRef.Text.ToString() + "' GROUP BY dbo.tblStockMovements.SMStockCode, dbo.qrySalesEntryQtyDelivered.Delivered, dbo.qrySalesEntryQtySold.Sold, dbo.tblStockMovements.SMLocation, dbo.tblStockMovements.SMLocationType HAVING (dbo.tblStockMovements.SMLocationType = N'Shop')"
        Dim cbodata As New SqlDataAdapter

        cbodata.SelectCommand = New SqlCommand(sql, connection)
        cbodata.Fill(dds)
        DataGridView1.Refresh()
        '  ComboBox1.DataSource = dds
        '  ComboBox1.DisplayMember = "SMStockCode"
        '  txtCurrentQty.Text = dds.Rows(0)("Qty").ToString


        DataGridView1.DataSource = cbodata
        DataGridView1.Refresh()
        ' DataGridView1.Columns.Item(6).Visible = False
        DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
        DataGridView1.Columns.Item(5).HeaderText = "Sales Amount"
        DataGridView1.Columns.Item(1).Width = "60"
        DataGridView1.Columns.Item(4).HeaderText = "Units Sold"
        DataGridView1.Columns.Item(2).Width = "60"
        ' DataGridView1.Columns.Add("SalesAmt", "Sales Amount")


    End Sub
    Private Sub SaveSalesRecord()
        InsertCommand.CommandType = CommandType.StoredProcedure
        InsertCommand.CommandText = "InsertSalesReturnID"
        InsertCommand.Connection = connection
        ' InsertCommand.Connection.Open()
        InsertCommand.Parameters.AddWithValue("@ShopRef", txtShopRef.Text.Trim())
        InsertCommand.Parameters.AddWithValue("@Reference", TextBox2.Text.Trim())
        InsertCommand.Parameters.AddWithValue("@TransactionDate", DateTimePicker1.Value)
        InsertCommand.Parameters.AddWithValue("@TotalQty", txtTotalGarments.Text)
        InsertCommand.Parameters.AddWithValue("@TotalValue", txtTotal.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now())
        ' InsertCommand.ExecuteNonQuery()
        InsertCommand.Connection.Open()
        Dim id As String = InsertCommand.Parameters("@SalesID").Value.ToString()
        txtSalesID.Text = InsertCommand.ExecuteScalar
        InsertCommand.Connection.Close()

    End Sub

    Private Sub SaveSalesLine()
        InsertCommand.CommandType = CommandType.StoredProcedure
        InsertCommand.CommandText = "InsertStockMovements"
        InsertCommand.Parameters.Add("@SMStockCode") '0
        InsertCommand.Parameters.Add("@SMSupplierRef") '1
        InsertCommand.Parameters.Add("@SMLocation") '2
        InsertCommand.Parameters.Add("@SMLocationType") '3
        InsertCommand.Parameters.Add("@MovementQtyHangers") '4
        InsertCommand.Parameters.Add("@MovementType") '5
        InsertCommand.Parameters.Add("@MovementDate") '6
        InsertCommand.Parameters.Add("@MovementValue") '7
        InsertCommand.Parameters.Add("@Reference") '8
        InsertCommand.Parameters.Add("@TransferReference") '9
        InsertCommand.Parameters.Add("@SMCreatedBy") '10
        InsertCommand.Parameters.Add("@SMCreatedDate") '11
        ' InsertCommand.Connection.Open()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            InsertCommand.Parameters(0).Value = DataGridView1.Rows(i).Cells(0).Value
            InsertCommand.Parameters(1).Value = Nothing
            InsertCommand.Parameters(2).Value = txtShopRef.Text.ToString()
            InsertCommand.Parameters(3).Value = "Shop"
            InsertCommand.Parameters(4).Value = DataGridView1.Rows(i).Cells(4).Value * -1
            InsertCommand.Parameters(5).Value = "Sale"
            InsertCommand.Parameters(6).Value = DateTimePicker1.Value
            InsertCommand.Parameters(7).Value = DataGridView1.Rows(i).Cells(5).Value
            InsertCommand.Parameters(8).Value = txtSalesID.Text.ToString()
            InsertCommand.Parameters(9).Value = txtSalesID.Text.ToString()
            InsertCommand.Parameters(10).Value = FLoginForm.UsernameTextBox.Text
            InsertCommand.Parameters(11).Value = Date.Now
            ' InsertCommand.ExecuteNonQuery()
            '   Dim ids As String = InsertCommand.Parameters("@StockMovementID").Value.ToString()
            Dim ids As Integer
            InsertCommand.Connection.Open()
            ids = InsertCommand.ExecuteScalar
            InsertCommand.Connection.Close()

            InsertCommand.CommandType = CommandType.Text
            InsertCommand.CommandText = "INSERT INTO tblSalesLine (SalesID,StockCode,CurrentQty,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@CurrentQty@QtySold,@SalesAmount,@StockMovementID)"
            InsertCommand.Parameters.AddWithValue("@SalesID", txtSalesID.Text)
            InsertCommand.Parameters.AddWithValue("@StockCode", DataGridView1.Rows(i).Cells(0).Value)
            InsertCommand.Parameters.AddWithValue("@CurrentQty", DataGridView1.Rows(i).Cells(3).Value)
            InsertCommand.Parameters.AddWithValue("@QtySold", DataGridView1.Rows(i).Cells(4).Value)
            InsertCommand.Parameters.AddWithValue("@SalesAmount", DataGridView1.Rows(i).Cells(6).Value)
            InsertCommand.Parameters.AddWithValue("@StockMovementID", ids)
            InsertCommand.Connection.Open()
            InsertCommand.ExecuteNonQuery()
            InsertCommand.Connection.Close()
        Next

    End Sub

    Private Sub totals()
        ' Dim x As Integer
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

        If txtVATRate.Text = "" Then
            txtVATRate.Text = "20.00"
        End If

        Dim total As Integer = 0
        Dim total2 As Integer
        Dim total3 As Integer
        Dim total4 As Integer
        Dim total5 As Double
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total += DataGridView1.Rows(i).Cells(1).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        txtTotalDelivered.Text = total
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total2 += DataGridView1.Rows(i).Cells(2).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        txtTotalSold.Text = total2
        ' For i As Integer = 0 To DataGridView1.RowCount - 1
        'total3 += DataGridView1.Rows(i).Cells(3).Value
        'Change the number 2 to your column index number (The first column has a 0 index column)
        'In this example the column index of Price is 2
        '  Next
        '  txtTotalCurrQty.Text = total3
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total4 += CDbl(DataGridView1.Rows(i).Cells(4).Value)
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        txtNet.Text = total4
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total5 += CDbl(DataGridView1.Rows(i).Cells(5).Value)
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next


        txtTotalDelivered.Text = total
        txtTotalCurrQty.Text = total3
        txtTotalSold.Text = total2
        txtTotalGarments.Text = total4
        txtNet.Text = total5
        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat

        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)

        txtTotal.Text = FormatCurrency(txtTotal.Text)



    End Sub

    Private Sub LoadOldRecord()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        txtSalesID.Text = FMain.DgvRecords.Item(0, i).Value
        DateTimePicker1.Value = FMain.DgvRecords.Item(4, i).Value
        Label17.Text = FMain.DgvRecords.Item(2, i).Value
        txtShopRef.Text = FMain.DgvRecords.Item(1, i).Value
        txtTotalGarments.Text = FMain.DgvRecords.Item(5, i).Value
        txtTotal.Text = FMain.DgvRecords.Item(6, i).Value
        txtVATRate.Text = "0.00"
        LoadLines()
    End Sub
    Private Sub LoadLines()
        Dim sql As String = "Select * from tblSalesLines Where SalesID='" + txtSalesID.Text + "'"
        ' Dim dtable As New DataTable
        '  Dim cmd As New SqlCommand(sql, connection)
        '  Dim tadapter As New SqlDataAdapter
        '  connection.Open()

        ' tadapter.SelectCommand = cmd
        ' tadapter.Fill(dtable)
        ' Dim ds As DataSet = New DataSet()
        ' tadapter.Fill(ds)
        ' DataGridView1.DataSource = ds
        'DataGridView1.DataBind()
        ' connection.Close()

        'SelectCommand.CommandType = CommandType.Text
        'SelectCommand.Connection = connection
        'SelectCommand.Connection.Open()
        'DataGridView1.DataSource = SelectCommand.ExecuteReader()
        'SelectCommand.Connection.Close()
        ' DataGridView1.Refresh()
        Dim dtTable As DataTable
        Dim sqlCMD As New SqlCommand
        sqlCMD.CommandText = "Select * from tblSalesLines Where SalesID='" + txtSalesID.Text + "'"
        sqlCMD.CommandType = CommandType.Text
        sqlCMD.Connection = connection
        Dim sqladp As New SqlDataAdapter
        sqladp.SelectCommand = sqlCMD
        dtTable = New DataTable
        sqladp.Fill(dtTable)
        DataGridView1.DataSource = dtTable
        'DataGridView1.DataMember = "tblSalesLines"
        DataGridView1.AutoGenerateColumns = True
        DataGridView1.Columns.Item(0).Visible = False
        DataGridView1.Columns.Item(1).Visible = False
        DataGridView1.Columns.Item(2).Visible = False
        DataGridView1.Columns.Item(3).Visible = False
        DataGridView1.Columns.Item(4).Visible = False
        DataGridView1.Columns.Item(5).Visible = False
        DataGridView1.Columns.Item(6).Visible = False
        DataGridView1.Columns.Item(7).Visible = False
        DataGridView1.Columns.Item(12).Visible = False
        DataGridView1.Columns.Item(11).DefaultCellStyle.Format = "c"
        totals2()

    End Sub
    Private Sub DeleteRecords()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        txtSalesID.Text = FMain.DgvRecords.Item(0, i).Value
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "Delete From tblSalesLines where SalesID='" + txtSalesID.Text + "';Delete from tblStockmovements where MovementType='Sale' AND TransferReference='" + txtSalesID.Text + "';Delete from tblSales where SalesID='" + txtSalesID.Text + "'"
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection.Open()
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        FMain.SalesToolStripMenuItem.PerformClick()

        Me.Close()

    End Sub
    Private Sub SaveStockMovements()
        InsertCommand.CommandType = CommandType.Text
        InsertCommand.CommandText = " INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            InsertCommand.Parameters.Clear()
            InsertCommand.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(0).Value) '1
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", "") '2
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtShopRef.Text) '3 
            InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop") '4
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(4).Value * -1)) '5
            InsertCommand.Parameters.AddWithValue("@MovementType", "Sale") '6
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value) '7
            InsertCommand.Parameters.AddWithValue("@MovementValue", DataGridView1.Rows(i).Cells(6).Value) '8
            InsertCommand.Parameters.AddWithValue("@Reference", TextBox2.Text) '9
            InsertCommand.Parameters.AddWithValue("@TransferReference", CInt(txtSalesID.Text)) '10
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text) '11
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now) '12
            ' InsertCommand.Parameters.Add("@StockMovementID", SqlDbType.Int, 16, "StockMovementID").Direction = ParameterDirection.Output '0
            InsertCommand.Connection.Close()
            InsertCommand.Connection.Open()
            InsertCommand.ExecuteNonQuery()
        Next
        insertcommand2.Connection = connection
        '  insertcommand2.Connection.ConnectionString = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"

        For p As Integer = 0 To DataGridView1.Rows.Count - 1
            ' InsertCommand.CommandText = "Select @@Identity"
            '  Dim sid As Integer
            ' sid = InsertCommand.Parameters("@StockMovementID").Value
            ' InsertCommand.Parameters(0).Value = DataGridView1.Rows(i).Cells(1).Value
            'InsertCommand.Parameters(1).Value = Nothing
            '   InsertCommand.Parameters(2).Value = txtShopRef.Text
            '    InsertCommand.Parameters.AddWithValue("@LocationType", "Shop")
            '   InsertCommand.Parameters(7).Value = DataGridView1.Rows(i).Cells(6).Value
            '   InsertCommand.Parameters(5).Value = "Sale"
            '    InsertCommand.Parameters(6).Value = DateTimePicker1.Value
            '   InsertCommand.Parameters(4).Value = CInt(DataGridView1.Rows(i).Cells(5).Value * -1)
            '   InsertCommand.Parameters(8).Value = txtSalesID.Text.ToString()
            '   InsertCommand.Parameters(9).Value = txtSalesID.Text.ToString()
            '  InsertCommand.Parameters(10).Value = LoginForm.UsernameTextBox.Text
            '  InsertCommand.Parameters(11).Value = Date.Now
            ' InsertCommand.ExecuteNonQuery()
            'InsertCommand.CommandText = "INSERT INTO tblSalesLines (SalesID,StockCode,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@QtySold,@SalesAmount,@StockMovementID)"
            '  insertcommand2.Connection.Close()
            insertcommand2.Parameters.Clear()
            insertcommand2.Connection.Close()

            insertcommand2.CommandType = CommandType.Text
            insertcommand2.CommandText = "INSERT INTO tblSalesLines (SalesID,StockCode,CurrentQty,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@CurrentQty,@QtySold,@SalesAmount,@StockMovementID)"
            insertcommand2.Parameters.AddWithValue("@SalesID", txtSalesID.Text)
            insertcommand2.Parameters.AddWithValue("@StockCode", DataGridView1.Rows(p).Cells(0).Value)
            insertcommand2.Parameters.AddWithValue("@CurrentQty", DataGridView1.Rows(p).Cells(3).Value)
            insertcommand2.Parameters.AddWithValue("@QtySold", DataGridView1.Rows(p).Cells(4).Value)
            insertcommand2.Parameters.AddWithValue("@SalesAmount", DataGridView1.Rows(p).Cells(6).Value)
            insertcommand2.Parameters.AddWithValue("@StockMovementID", "0")
            insertcommand2.Connection.Open()
            insertcommand2.ExecuteNonQuery()
            insertcommand2.Parameters.Clear()
            insertcommand2.Connection.Close()
        Next
        InsertCommand.Connection.Close()
        insertcommand2.Connection.Close()
        FMain.SalesToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub createSales()
        InsertCommand.Connection = connection
        InsertCommand.CommandText = "InsertSalesReturnID"
        InsertCommand.CommandType = CommandType.StoredProcedure
        InsertCommand.Parameters.AddWithValue("@ShopRef", txtShopRef.Text.Trim())
        InsertCommand.Parameters.AddWithValue("@ShopName", Label17.Text)
        InsertCommand.Parameters.AddWithValue("@SAReference", TextBox2.Text.Trim())
        InsertCommand.Parameters.AddWithValue("@TransactionDate", DateTimePicker1.Value)
        InsertCommand.Parameters.AddWithValue("@TotalQty", txtTotalGarments.Text)
        InsertCommand.Parameters.AddWithValue("@TotalValue", txtTotal.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now())
        InsertCommand.Parameters.Add("@SalesID", SqlDbType.Int, 0, "SalesID").Direction = ParameterDirection.Output
        InsertCommand.Connection.Open()
        InsertCommand.ExecuteNonQuery()
        ' InsertCommand.CommandText = "Select @@Identity"
        Dim id As Integer
        id = InsertCommand.Parameters("@SalesID").Value
        InsertCommand.Connection.Close()
        txtSalesID.Text = id
        InsertCommand.Parameters.Clear()
        SaveStockMovements()

    End Sub
    Private Sub totals2()
        ' Dim x As Integer
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

        ' If txtVATRate.Text = "" Then
        txtVATRate.Text = "0.00"
        ' End If
        '   For x As Integer = 0 To DataGridView1.RowCount - 1
        ' curNetSales += CLng(DataGridView1.Rows(i).Cells(5).Value)
        'curNetSales += CLng(IIf(DataGridView1.Rows(x).Cells(5).Value = "", 0, DataGridView1.Rows(x).Cells(5).Value))

        ' lngQtyHangers += CLng(IIf(DataGridView1.Rows(x).Cells(4).Value = "", 0, DataGridView1.Rows(x).Cells(4).Value))
        '   lngTotalDel += CLng(IIf(DataGridView1.Rows(x).Cells(1).Value = "", 0, DataGridView1.Rows(x).Cells(1).Value))
        'lngTotalSold += CLng(IIf(DataGridView1.Rows(x).Cells(2).Value = "", 0, DataGridView1.Rows(x).Cells(2).Value))
        '  lngTotalCurrent += CLng(IIf(DataGridView1.Rows(x).Cells(3).Value = "", 0, DataGridView1.Rows(x).Cells(3).Value))
        '   Next
        ' Dim total2 As String = 0
        ' Dim total3 As String = 0
        ' Dim total4 As String = 0
        ' Dim total5 As String = 0
        Dim total As Integer = 0
        Dim total2 As Integer
        ' Dim total3 As Integer
        Dim total4 As Integer
        ' Dim total5 As Double
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total += DataGridView1.Rows(i).Cells(1).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        ' txtTotalDelivered.Text = total
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total2 += DataGridView1.Rows(i).Cells(2).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        ' txtTotalSold.Text = total2
        ' For i As Integer = 0 To DataGridView1.RowCount - 1
        'total3 += DataGridView1.Rows(i).Cells(3).Value
        'Change the number 2 to your column index number (The first column has a 0 index column)
        'In this example the column index of Price is 2
        '  Next
        '  txtTotalCurrQty.Text = total3
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total4 += DataGridView1.Rows(i).Cells(3).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        txtNet.Text = total4
        '  For i As Integer = 0 To DataGridView1.RowCount - 1
        ' total5 += DataGridView1.Rows(i).Cells(11).Value
        'Change the number 2 to your column index number (The first column has a 0 index column)
        'In this example the column index of Price is 2
        '    Next


        'txtTotalDelivered.Text = total
        txtTotalCurrQty.Text = total
        txtTotalSold.Text = total2
        '  txtTotalGarments.Text = total4
        txtNet.Text = total4
        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat

        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)
        'Dim decCost As Double
        ' Dim qty As Double
        ' Dim override As Double
        '  Dim purchase As Double

        'calculate the purchase

        ' Note: i changed the "CDec" to "decimal.Parse"

        '  decCost = txtNet.Text
        '  override = txtVATRate.Text
        ' qty = Decimal.Parse(txtVAT.Text)
        ' qty = decCost * override
        '  txtVAT.Text = qty
        ' txtVAT.Text = FormatCurrency(txtVAT.Text)
        '  purchase = qty + decCost

        ' txtTotal.Text = purchase
        txtTotal.Text = FormatCurrency(txtTotal.Text)


        '  Dim RetailPrice As Double
        '  Dim RetailDisc As Double
        '  Dim DiscountResult As Double
        '  Dim DiscountValue As Double

        '  DiscountValue = RetailPrice * RetailDisc
        '   DiscountResult = RetailPrice - DiscountValue
        '  txtVAT.Text = DiscountValue
        '  txtTotal.Text = CDbl(DiscountResult).ToString()
        '  txtVAT.Text = FormatCurrency(txtVAT.Text)
        '  txtTotal.Text = FormatCurrency(txtTotal.Text)
        '  Dim totalsum As Integer
        '  For i As Integer = 0 To DataGridView1.Rows.Count - 1
        'totalsum += DataGridView1.Rows(i).Cells(5).Value
        '  Next
        '  txtTotal.Text = totalsum.ToString()
    End Sub
















End Class