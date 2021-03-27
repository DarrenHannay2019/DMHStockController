Imports System.Data.SqlClient

Public Class FUpdatedSales
    Dim connectionString As String = "Initial Catalog=DMHStockv4;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim insertcommand2 As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Dim SelectCommand As New SqlCommand
    Dim selectcommand4 As New SqlCommand
    Dim strWarehouse As String
    Dim strStock As String
    Dim dds As DataTable = New DataTable()
    Dim dSales As DataSet
    Dim dds2 As DataTable = New DataTable()
    Dim strStockCode As String
    Dim dLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
    Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FUpdatedSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "NEW" Then loadnew()
        If FMain.txtMode.Text = "OLD" Then LoadOldRecord()
        If FMain.txtMode.Text = "DELETE" Then DeleteRecords()
    End Sub

    Private Sub txtShopRef_Leave(sender As Object, e As EventArgs) Handles txtShopRef.Leave
        '   If txtShopRef.Text <> "" Then Exit Sub

        txtShopRef.Text = UCase(txtShopRef.Text)
        SelectCommand.Connection = connection
        SelectCommand.Connection.Close()
        SelectCommand.CommandText = "SELECT ShopName from tblShops Where ShopRef='" + txtShopRef.Text.Trim + "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        Label17.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()
        Me.Text = "Sales for [" + txtShopRef.Text + "]  " + Label17.Text
        Dim sql As String = "SELECT * from qrySalesGrid2 WHERE SMLocation ='" + txtShopRef.Text + "' AND CurrentQty <> 0 AND DeadCode ='0' Order by SMStockCode"
        Dim sql1 As String = "SELECT * from qrySalesGrid2 WHERE SMLocation ='" + txtShopRef.Text + "' Order by SMStockCode"
        Dim strSQL As String = "SELECT dbo.tblStockMovements.SMStockCode, SUM(dbo.tblStockMovements.MovementQtyHangers) AS Qty,dbo.qrySalesEntryQtyDelivered.Delivered, dbo.qrySalesEntryQtySold.Sold, '' AS SoldQty, '' AS SalesAmount,                      dbo.tblStockMovements.SMLocation FROM dbo.qrySalesEntryQtyDelivered INNER JOIN dbo.tblStockMovements ON dbo.qrySalesEntryQtyDelivered.SMStockCode = dbo.tblStockMovements.SMStockCode AND dbo.qrySalesEntryQtyDelivered.SMLocation = dbo.tblStockMovements.SMLocation INNER JOIN dbo.tblStock ON dbo.tblStockMovements.SMStockCode = dbo.tblStock.StockCode INNER JOIN  dbo.qrySalesEntryQtySold ON dbo.tblStockMovements.SMStockCode = dbo.qrySalesEntryQtySold.SMStockCode AND dbo.tblStockMovements.SMLocation = dbo.qrySalesEntryQtySold.SMLocation WHERE tblStockMovements.SMLocation = '" + txtShopRef.Text.ToString() + "' GROUP BY dbo.tblStockMovements.SMStockCode, dbo.qrySalesEntryQtyDelivered.Delivered, dbo.qrySalesEntryQtySold.Sold, dbo.tblStockMovements.SMLocation, dbo.tblStockMovements.SMLocationType HAVING (dbo.tblStockMovements.SMLocationType = N'Shop')"
        Try
            connection.Open()
            Dim cbodata As New SqlDataAdapter
            cbodata.SelectCommand = New SqlCommand(sql, connection)
            cbodata.Fill(dds)
            connection.Close()
            DataGridView1.DataSource = dds
            Do_Layout()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Visible = False
        Button3.Visible = True
        DataGridView2.Visible = True
        DataGridView1.Visible = False
        Button1.Visible = True
        cmdAdd.Visible = False
        viewAll()
        txtVATRate.Select()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Visible = False
        Button2.Visible = True
        DataGridView1.Visible = True
        DataGridView2.Visible = False
        Button1.Visible = False
        cmdAdd.Visible = True
        txtVATRate.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        createSales2()
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        createSales()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub DataGridView2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellEndEdit
        'Dim curnetSales As Double
        Dim curnetSales As Decimal
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView2.RowCount - 1

            lngtotaldel += CInt((DataGridView2.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView2.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView2.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"

            curnetSales += CDec(IIf(DataGridView2.Rows(x).Cells(5).Value = "", 0, DataGridView2.Rows(x).Cells(5).Value))
            lngQtyHangers += CLng(IIf(DataGridView2.Rows(x).Cells(4).Value = "", 0, DataGridView2.Rows(x).Cells(4).Value))
            DataGridView2.Columns(5).DefaultCellStyle.Format = "c"

        Next
        txtVATRate.Text = "0.0"
        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
        txtTotalGarments.Text = lngQtyHangers
        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat
        DataGridView2.Columns.Item(5).DefaultCellStyle.Format = "c"
        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        'Dim curnetSales As Double
        Dim curnetSales As Decimal
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView1.RowCount - 1

            lngtotaldel += CInt((DataGridView1.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView1.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView1.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"

            curnetSales += CDec(IIf(DataGridView1.Rows(x).Cells(5).Value = "", 0, DataGridView1.Rows(x).Cells(5).Value))
            lngQtyHangers += CLng(IIf(DataGridView1.Rows(x).Cells(4).Value = "", 0, DataGridView1.Rows(x).Cells(4).Value))
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"

        Next
        txtVATRate.Text = "0.0"
        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
        txtTotalGarments.Text = lngQtyHangers
        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat
        DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If Not IsNothing(e.Value) Then
            If e.ColumnIndex().ToString = 5 And IsNumeric(e.Value) Then
                e.Value = Format(FormatCurrency(e.Value))
            End If
        End If
        Dim curnetSales As Double
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView1.RowCount - 1
            curnetSales += CDec(DataGridView1.Rows(x).Cells(5).Value)
            lngQtyHangers += CInt(DataGridView1.Rows(x).Cells(4).Value)
            lngtotaldel += CInt((DataGridView1.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView1.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView1.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"
        Next
        txtTotalGarments.Text = lngQtyHangers
        txtVATRate.Text = "0.00"

        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
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
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        UpdateRecords()
    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        If Not IsNothing(e.Value) Then
            If e.ColumnIndex().ToString = 5 And IsNumeric(e.Value) Then
                e.Value = Format(FormatCurrency(e.Value))
            End If
        End If
        'Dim curnetSales As Double
        Dim curnetSales As Decimal
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView2.RowCount - 1

            lngtotaldel += CInt((DataGridView2.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView2.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView2.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"

            curnetSales += CDec(IIf(DataGridView2.Rows(x).Cells(5).Value = "", 0, DataGridView2.Rows(x).Cells(5).Value))
            lngQtyHangers += CLng(IIf(DataGridView2.Rows(x).Cells(4).Value = "", 0, DataGridView2.Rows(x).Cells(4).Value))
            DataGridView2.Columns(5).DefaultCellStyle.Format = "c"

        Next
        txtVATRate.Text = "0.0"
        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
        txtTotalGarments.Text = lngQtyHangers
        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat
        DataGridView2.Columns.Item(5).DefaultCellStyle.Format = "c"
        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)
    End Sub

    Private Sub DataGridView2_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellEnter
        DataGridView2.Columns.Item(5).DefaultCellStyle.Format = "c"
        If DataGridView2.CurrentCell.ReadOnly Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
        If DataGridView1.CurrentCell.ReadOnly Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub deleterecord()
        LoadOldRecord()
        Button1.Visible = True
    End Sub
    Private Sub loadnew()
        'Dim VATRate As Double

        DateTimePicker1.Value = dLastSunday
        cmdOK.Visible = False
        Try
            Dim sqlds As New DataSet
            Dim adp As New SqlDataAdapter
            connection.Close()
            connection.Open()
            Dim comm As New SqlCommand("SELECT ShopRef From tblShops", connection)
            comm.CommandType = CommandType.Text
            adp.SelectCommand = comm
            adp.Fill(sqlds)
            comm.Dispose()
            adp.Dispose()
            Dim ACSC As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To sqlds.Tables(0).Rows.Count - 1
                ACSC.Add(sqlds.Tables(0).Rows(i).Item(0).ToString)
            Next
            txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtShopRef.AutoCompleteCustomSource = ACSC
            txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            connection.Close()

        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
        txtVATRate.Text = "0.00"
    End Sub
    Private Sub LoadOldRecord()
        cmdAdd.Visible = False
        cmdOK.Visible = True
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
        ' DataGridView1.Columns.Clear()
        Dim sql As String = "Select * from tblSalesLines Where SalesID='" + txtSalesID.Text + "'"
        Dim dtTable As DataTable
        Dim sqlCMD As New SqlCommand
        sqlCMD.CommandText = "Select StockCode,'0' As Delivered,'0' AS Sold, CurrentQty,QtySold,SalesAmount from tblSalesLines Where SalesID='" + txtSalesID.Text + "'"
        sqlCMD.CommandType = CommandType.Text
        sqlCMD.Connection = connection
        Dim sqladp As New SqlDataAdapter
        sqladp.SelectCommand = sqlCMD
        dtTable = New DataTable
        sqladp.Fill(dtTable)
        DataGridView1.DataSource = dtTable
        DataGridView1.AutoGenerateColumns = True
        DataGridView1.Columns(0).Width = 250
        DataGridView1.Columns(1).Width = 70
        DataGridView1.Columns(2).Width = 70
        DataGridView1.Columns(3).Width = 70
        DataGridView1.Columns(4).Width = 80
        DataGridView1.Columns(5).Width = 140
        '  DataGridView1.Columns(6).Visible = False
        ' DataGridView1.Columns(0).Visible = False
        ' DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
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
        For x As Integer = 0 To DataGridView1.RowCount - 1
            lngTotalDel += CInt((DataGridView1.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView1.Rows(x).Cells(4).Value)
            lngTotalCurrent += CInt(DataGridView1.Rows(x).Cells(3).Value)
            curNetSales += CLng(DataGridView1.Rows(x).Cells(5).Value)
            'lngQtyHangers += CInt(DataGridView1.Rows(x).Cells(4).Value)
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"

        Next
        txtTotalDelivered.Text = lngTotalDel
        '  txtTotalCurrQty.Text = lngTotalSold
        txtTotalSold.Text = lngTotalCurrent
        txtTotalGarments.Text = lngTotalSold
        txtNet.Text = curNetSales
        DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
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
        cmdOK.Select()

    End Sub
    Private Sub DeleteRecords()
        MsgBox("Are you sure that you wish to delete this Sales record", vbYesNo, ProductName)


        If MsgBoxResult.No Then FMain.RefreshToolStripButton.PerformClick() : Me.Close()
        If MsgBoxResult.Yes Then
            Dim i As Integer = FMain.DgvRecords.SelectedRows(0).Cells(0).Value
            'i = FMain.DgvRecords.CurrentRow.Index
            '  txtSalesID.Text = FMain.DgvRecords.Item(0, i).Value
            txtSalesID.Text = i
            DeleteCommand.CommandType = CommandType.Text
            DeleteCommand.CommandText = "Delete From tblSalesLines where SalesID='" + txtSalesID.Text + "';Delete from tblStockmovements where MovementType='Sale' AND TransferReference='" + txtSalesID.Text + "';Delete from tblSales where SalesID='" + txtSalesID.Text.ToString + "';"
            DeleteCommand.Connection = connection
            DeleteCommand.Connection.Close()
            DeleteCommand.Connection.Open()
            DeleteCommand.ExecuteNonQuery()
            DeleteCommand.Connection.Close()
            FMain.SalesToolStripMenuItem.PerformClick()

            Me.Close()
        End If
    End Sub
    Private Sub SaveRecordsToDB()

    End Sub
    Private Sub SaveStockMovements()

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            '  insertcommand2.Connection.Close()

            InsertCommand.CommandType = CommandType.Text
            InsertCommand.CommandText = " INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            InsertCommand.Parameters.Clear()
            InsertCommand.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(0).Value) '1
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", " ") '2
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtShopRef.Text) '3 
            InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop") '4
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(4).Value * -1)) '5
            InsertCommand.Parameters.AddWithValue("@MovementType", "Sale") '6
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value) '7
            InsertCommand.Parameters.AddWithValue("@MovementValue", DataGridView1.Rows(i).Cells(5).Value * -1)  '8
            InsertCommand.Parameters.AddWithValue("@Reference", TextBox2.Text) '9
            InsertCommand.Parameters.AddWithValue("@TransferReference", CInt(txtSalesID.Text)) '10
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text) '11
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now) '12
            InsertCommand.Parameters.Add("@StockMovementID", SqlDbType.Int, 16, "StockMovementID").Direction = ParameterDirection.Output '0
            InsertCommand.Connection.Close()
            InsertCommand.Connection.Open()
            InsertCommand.ExecuteNonQuery()

            insertcommand2.Connection = connection
            '  insertcommand2.Connection.ConnectionString = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
            Dim id2 As Integer


            '     id2 = InsertCommand.Parameters("@StockMovementID").Value
            Dim selectcommand4 As New SqlCommand
            selectcommand4.CommandText = "Select Max(StockMovementID) From tblStockMovements Where SMLocation='" + txtShopRef.Text + "' AND MovementType ='Sale'"
            selectcommand4.Connection = connection
            selectcommand4.Connection.Close()
            selectcommand4.CommandType = CommandType.Text
            selectcommand4.Connection = connection
            selectcommand4.Connection.Open()
            id2 = selectcommand4.ExecuteScalar()
            selectcommand4.Connection.Close()


            InsertCommand.Parameters.Clear()
            'For p As Integer = 0 To DataGridView1.Rows.Count - 1
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
            insertcommand2.Parameters.AddWithValue("@StockCode", DataGridView1.Rows(i).Cells(0).Value)
            insertcommand2.Parameters.AddWithValue("@CurrentQty", DataGridView1.Rows(i).Cells(3).Value)
            insertcommand2.Parameters.AddWithValue("@QtySold", DataGridView1.Rows(i).Cells(4).Value)
            insertcommand2.Parameters.AddWithValue("@SalesAmount", DataGridView1.Rows(i).Cells(5).Value)
            insertcommand2.Parameters.AddWithValue("@StockMovementID", id2)
            insertcommand2.Connection.Open()
            insertcommand2.ExecuteNonQuery()
            insertcommand2.Parameters.Clear()
            insertcommand2.Connection.Close()
            InsertCommand.Connection.Close()
            insertcommand2.Connection.Close()

        Next
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "Delete From tblSalesLines where SalesID='" + txtSalesID.Text + "'AND QtySold ='0' AND SalesAmount='0';Delete from tblStockmovements where MovementType='Sale' AND TransferReference='" + txtSalesID.Text + "' AND MovementQtyHangers ='0' AND MovementValue='0'"
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection.Open()
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        Using dconn As New SqlConnection(connectionString)
            Dim insertcommand As New SqlCommand
            insertcommand.Connection = dconn
            insertcommand.CommandType = CommandType.Text
            insertcommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            insertcommand.Connection.Open()
            insertcommand.Parameters.AddWithValue("@StockCode", " ")
            insertcommand.Parameters.AddWithValue("@SupplierRef", " ")
            insertcommand.Parameters.AddWithValue("@Location", Label17.Text)
            insertcommand.Parameters.AddWithValue("@Qty", txtTotalGarments.Text)
            insertcommand.Parameters.AddWithValue("@MovementType", "Sales")
            insertcommand.Parameters.AddWithValue("@RecordType", "Sales-Add")
            insertcommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            insertcommand.Parameters.AddWithValue("@Timestamp", Date.Now)
            insertcommand.Parameters.AddWithValue("@Reference", txtSalesID.Text)
            insertcommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
            insertcommand.ExecuteNonQuery()
        End Using
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
        InsertCommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now())
        InsertCommand.Parameters.Add("@SalesID", SqlDbType.Int, 0, "SalesID").Direction = ParameterDirection.Output
        InsertCommand.Connection.Close()
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
    Private Sub Do_Layout2()
        DataGridView1.Columns(0).HeaderText = "Stock Code"
        DataGridView1.Columns(0).Width = 250
        DataGridView1.Columns(1).Width = 70
        DataGridView1.Columns(2).Width = 70
        DataGridView1.Columns(3).Width = 70
        DataGridView1.Columns(4).Width = 80
        DataGridView1.Columns(5).Width = 150
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        '  DataGridView1.Columns(4).ReadOnly = True
        '  DataGridView1.Columns(5).ReadOnly = True
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoResizeColumns()

        DataGridView1.Columns(5).DefaultCellStyle.Format = "c"
        Dim curnetSales As Double
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView1.RowCount - 1
            curnetSales += CDec(DataGridView1.Rows(x).Cells(5).Value)
            lngQtyHangers += CInt(DataGridView1.Rows(x).Cells(4).Value)
            lngtotaldel += CInt((DataGridView1.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView1.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView1.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"
        Next
        txtTotalGarments.Text = lngQtyHangers
        txtVATRate.Text = "0.00"

        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
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
        txtVATRate.Select()
    End Sub
    Private Sub Do_Layout()
        DataGridView1.Columns(0).HeaderText = "Stock Code"
        DataGridView1.Columns(0).Width = 200
        DataGridView1.Columns(1).Width = 70
        DataGridView1.Columns(2).Width = 70
        DataGridView1.Columns(3).Width = 70
        DataGridView1.Columns(4).Width = 80
        DataGridView1.Columns(5).Width = 150
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        '  DataGridView1.Columns(4).ReadOnly = True
        '  DataGridView1.Columns(5).ReadOnly = True
        DataGridView1.Columns(6).Visible = False
        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoResizeColumns()

        DataGridView1.Columns(5).DefaultCellStyle.Format = "c"
        Dim curnetSales As Double
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView1.RowCount - 1
            curnetSales += CDec(DataGridView1.Rows(x).Cells(5).Value)
            lngQtyHangers += CInt(DataGridView1.Rows(x).Cells(4).Value)
            lngtotaldel += CInt((DataGridView1.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView1.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView1.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"
        Next
        txtTotalGarments.Text = lngQtyHangers
        txtVATRate.Text = "0.00"

        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
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
        txtVATRate.Select()
    End Sub
    Private Sub UpdateRecords()
        Using conn As New SqlConnection(connectionString)
            Dim Insertcmd As New SqlCommand()
            Insertcmd.Connection = conn
            Insertcmd.CommandText = "UPDATE tblSales SET TransactionDate = @TransactionDate,TotalQty = @TotalQty,TotalValue = @TotalValue WHERE SalesID=@SalesID"
            Insertcmd.Parameters.AddWithValue("@SalesID", txtSalesID.Text)
            Insertcmd.Parameters.AddWithValue("@TransactionDate", DateTimePicker1.Value)
            Insertcmd.Parameters.AddWithValue("@TotalQty", txtTotalGarments.Text)
            Insertcmd.Parameters.AddWithValue("@TotalValue", txtTotal.Text)
            Insertcmd.Connection.Open()
            Insertcmd.ExecuteNonQuery()
        End Using

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Using conn As New SqlConnection(connectionString)
                Dim insertcommand As New SqlCommand()
                insertcommand.Connection = conn
                insertcommand.CommandType = CommandType.Text
                insertcommand.CommandText = "UPDATE tblStockMovements SET MovementQtyHangers = @MovementQtyHangers, MovementValue = @MovementValue Where TransferReference ='" + txtSalesID.Text + "' and SMStockCode ='" + DataGridView1.Rows(i).Cells(0).Value + "'"
                insertcommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(4).Value * -1)) '5
                insertcommand.Parameters.AddWithValue("@MovementValue", DataGridView1.Rows(i).Cells(5).Value * -1)  '8
                insertcommand.Connection.Open()
                insertcommand.ExecuteNonQuery()
                connection.Close()

            End Using
            Using conn As New SqlConnection(connectionString)
                Dim insertcommand2 As New SqlCommand()
                insertcommand2.Connection = connection
                insertcommand2.CommandType = CommandType.Text
                insertcommand2.CommandText = "UPDATE tblSalesLines SET QtySold = @QtySold, SalesAmount = @SalesAmount Where SalesID ='" + txtSalesID.Text + "' and StockCode ='" + DataGridView1.Rows(i).Cells(0).Value + "'"
                insertcommand2.Parameters.AddWithValue("@QtySold", DataGridView1.Rows(i).Cells(4).Value)
                insertcommand2.Parameters.AddWithValue("@SalesAmount", DataGridView1.Rows(i).Cells(5).Value)
                insertcommand2.Connection.Open()
                insertcommand2.ExecuteNonQuery()
                connection.Close()
            End Using
        Next
        FMain.SalesToolStripMenuItem.PerformClick()
        Using dconn As New SqlConnection(connectionString)
            Dim insertcommand As New SqlCommand
            insertcommand.Connection = dconn
            insertcommand.CommandType = CommandType.Text
            insertcommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            insertcommand.Connection.Open()
            insertcommand.Parameters.AddWithValue("@StockCode", " ")
            insertcommand.Parameters.AddWithValue("@SupplierRef", " ")
            insertcommand.Parameters.AddWithValue("@Location", Label17.Text)
            insertcommand.Parameters.AddWithValue("@Qty", txtTotalGarments.Text)
            insertcommand.Parameters.AddWithValue("@MovementType", "Sales")
            insertcommand.Parameters.AddWithValue("@RecordType", "Sales-Update")
            insertcommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            insertcommand.Parameters.AddWithValue("@Timestamp", Date.Now)
            insertcommand.Parameters.AddWithValue("@Reference", txtSalesID.Text)
            insertcommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
            insertcommand.ExecuteNonQuery()
        End Using
        Me.Close()
    End Sub
    Private Sub viewAll()
        Dim sql1 As String = "SELECT * from qrySalesGrid2 WHERE SMLocation ='" + txtShopRef.Text + "' Order by SMStockCode"
        Dim strSQL As String = "SELECT dbo.tblStockMovements.SMStockCode, SUM(dbo.tblStockMovements.MovementQtyHangers) AS Qty,dbo.qrySalesEntryQtyDelivered.Delivered, dbo.qrySalesEntryQtySold.Sold, '' AS SoldQty, '' AS SalesAmount,                      dbo.tblStockMovements.SMLocation FROM dbo.qrySalesEntryQtyDelivered INNER JOIN dbo.tblStockMovements ON dbo.qrySalesEntryQtyDelivered.SMStockCode = dbo.tblStockMovements.SMStockCode AND dbo.qrySalesEntryQtyDelivered.SMLocation = dbo.tblStockMovements.SMLocation INNER JOIN dbo.tblStock ON dbo.tblStockMovements.SMStockCode = dbo.tblStock.StockCode INNER JOIN  dbo.qrySalesEntryQtySold ON dbo.tblStockMovements.SMStockCode = dbo.qrySalesEntryQtySold.SMStockCode AND dbo.tblStockMovements.SMLocation = dbo.qrySalesEntryQtySold.SMLocation WHERE tblStockMovements.SMLocation = '" + txtShopRef.Text.ToString() + "' GROUP BY dbo.tblStockMovements.SMStockCode, dbo.qrySalesEntryQtyDelivered.Delivered, dbo.qrySalesEntryQtySold.Sold, dbo.tblStockMovements.SMLocation, dbo.tblStockMovements.SMLocationType HAVING (dbo.tblStockMovements.SMLocationType = N'Shop')"

        Try
            connection.Open()
            Dim cbodata2 As New SqlDataAdapter
            cbodata2.SelectCommand = New SqlCommand(sql1, connection)
            cbodata2.Fill(dds2)
            connection.Close()
            DataGridView2.DataSource = dds2
            DataGridView2.Columns(0).HeaderText = "Stock Code"
            DataGridView2.Columns(0).Width = 250
            DataGridView2.Columns(1).Width = 70
            DataGridView2.Columns(2).Width = 70
            DataGridView2.Columns(3).Width = 70
            DataGridView2.Columns(4).Width = 80
            DataGridView2.Columns(5).Width = 150
            DataGridView2.Columns(0).ReadOnly = True
            DataGridView2.Columns(1).ReadOnly = True
            DataGridView2.Columns(2).ReadOnly = True
            DataGridView2.Columns(3).ReadOnly = True
            '  DataGridView1.Columns(4).ReadOnly = True
            '  DataGridView1.Columns(5).ReadOnly = True
            DataGridView2.Columns(6).Visible = False
            DataGridView2.Columns(7).Visible = False
            DataGridView2.Columns(8).Visible = False
            ' DataGridView2.Columns(9).Visible = False


            DataGridView2.Columns(5).DefaultCellStyle.Format = "c"

        Catch ex As Exception

        End Try
        'Dim curnetSales As Double
        Dim curnetSales As Decimal
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView1.RowCount - 1

            lngtotaldel += CInt((DataGridView2.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView2.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView2.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"

            curnetSales += CDec(IIf(DataGridView2.Rows(x).Cells(5).Value = "", 0, DataGridView2.Rows(x).Cells(5).Value))
            lngQtyHangers += CLng(IIf(DataGridView2.Rows(x).Cells(4).Value = "", 0, DataGridView2.Rows(x).Cells(4).Value))
            DataGridView2.Columns(5).DefaultCellStyle.Format = "c"

        Next
        txtVATRate.Text = "0.0"
        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
        txtTotalGarments.Text = lngQtyHangers
        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat
        DataGridView2.Columns.Item(5).DefaultCellStyle.Format = "c"
        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)

    End Sub
    Private Sub ViewCurrent()
        '  txtShopRef.Text = UCase(txtShopRef.Text)
        'Dim curnetSales As Double
        Dim curnetSales As Decimal
        Dim lngQtyHangers As Integer
        Dim lngtotaldel As Integer
        Dim lngTotalSold As Integer
        Dim lngTotalCurrent As Integer
        For x As Integer = 0 To DataGridView1.RowCount - 1

            lngtotaldel += CInt((DataGridView1.Rows(x).Cells(1).Value))
            lngTotalSold += CInt(DataGridView1.Rows(x).Cells(2).Value)
            lngTotalCurrent += CInt(DataGridView1.Rows(x).Cells(3).Value)
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"

            curnetSales += CDec(IIf(DataGridView1.Rows(x).Cells(5).Value = "", 0, DataGridView1.Rows(x).Cells(5).Value))
            lngQtyHangers += CLng(IIf(DataGridView1.Rows(x).Cells(4).Value = "", 0, DataGridView1.Rows(x).Cells(4).Value))
            DataGridView1.Columns(5).DefaultCellStyle.Format = "c"

        Next
        txtVATRate.Text = "0.0"
        txtTotalCurrQty.Text = lngTotalCurrent
        txtTotalDelivered.Text = lngtotaldel
        txtTotalSold.Text = lngTotalSold
        txtNet.Text = curnetSales
        txtTotalGarments.Text = lngQtyHangers
        txtNet.Text = FormatCurrency(txtNet.Text)
        txtVAT.Text = txtVATRate.Text / 100 * CDbl(txtNet.Text)
        txtVAT.Text = FormatCurrency(txtVAT.Text)
        Dim totalsale As Double
        Dim totalvat As Double
        Dim saletotal As Double
        totalsale = CDbl(txtNet.Text)
        totalvat = CDbl(txtVAT.Text)
        saletotal = totalsale + totalvat
        DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
        txtTotal.Text = saletotal
        txtTotal.Text = FormatCurrency(txtTotal.Text)
    End Sub
    Private Sub SaveStockMovements2()

        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            '  insertcommand2.Connection.Close()

            InsertCommand.CommandType = CommandType.Text
            InsertCommand.CommandText = " INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            InsertCommand.Parameters.Clear()
            InsertCommand.Parameters.AddWithValue("@SMStockCode", DataGridView2.Rows(i).Cells(0).Value) '1
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", " ") '2
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtShopRef.Text) '3 
            InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop") '4
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView2.Rows(i).Cells(4).Value * -1)) '5
            InsertCommand.Parameters.AddWithValue("@MovementType", "Sale") '6
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value) '7
            InsertCommand.Parameters.AddWithValue("@MovementValue", DataGridView2.Rows(i).Cells(5).Value * -1)  '8
            InsertCommand.Parameters.AddWithValue("@Reference", TextBox2.Text) '9
            InsertCommand.Parameters.AddWithValue("@TransferReference", CInt(txtSalesID.Text)) '10
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text) '11
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now) '12
            InsertCommand.Parameters.Add("@StockMovementID", SqlDbType.Int, 16, "StockMovementID").Direction = ParameterDirection.Output '0
            InsertCommand.Connection.Close()
            InsertCommand.Connection.Open()
            InsertCommand.ExecuteNonQuery()

            insertcommand2.Connection = connection
            '  insertcommand2.Connection.ConnectionString = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
            Dim id3 As Integer


            '     id2 = InsertCommand.Parameters("@StockMovementID").Value
            Dim selectcommand4 As New SqlCommand
            selectcommand4.CommandText = "Select Max(StockMovementID) From tblStockMovements Where SMLocation='" + txtShopRef.Text + "' AND MovementType ='Sale'"
            selectcommand4.Connection = connection
            selectcommand4.Connection.Close()
            selectcommand4.CommandType = CommandType.Text
            selectcommand4.Connection = connection
            selectcommand4.Connection.Open()
            id3 = selectcommand4.ExecuteScalar()
            selectcommand4.Connection.Close()


            InsertCommand.Parameters.Clear()
            'For p As Integer = 0 To DataGridView1.Rows.Count - 1
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
            insertcommand2.Parameters.AddWithValue("@StockCode", DataGridView2.Rows(i).Cells(0).Value)
            insertcommand2.Parameters.AddWithValue("@CurrentQty", DataGridView2.Rows(i).Cells(3).Value)
            insertcommand2.Parameters.AddWithValue("@QtySold", DataGridView2.Rows(i).Cells(4).Value)
            insertcommand2.Parameters.AddWithValue("@SalesAmount", DataGridView2.Rows(i).Cells(5).Value)
            insertcommand2.Parameters.AddWithValue("@StockMovementID", id3)
            insertcommand2.Connection.Open()
            insertcommand2.ExecuteNonQuery()
            insertcommand2.Parameters.Clear()
            insertcommand2.Connection.Close()
            InsertCommand.Connection.Close()
            insertcommand2.Connection.Close()

        Next
        Using dconn As New SqlConnection(connectionString)
            Dim insertcommand As New SqlCommand
            insertcommand.Connection = dconn
            insertcommand.CommandType = CommandType.Text
            insertcommand.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            insertcommand.Connection.Open()
            insertcommand.Parameters.AddWithValue("@StockCode", " ")
            insertcommand.Parameters.AddWithValue("@SupplierRef", " ")
            insertcommand.Parameters.AddWithValue("@Location", Label17.Text)
            insertcommand.Parameters.AddWithValue("@Qty", txtTotalGarments.Text)
            insertcommand.Parameters.AddWithValue("@MovementType", "Sales")
            insertcommand.Parameters.AddWithValue("@RecordType", "Sales-Add")
            insertcommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            insertcommand.Parameters.AddWithValue("@Timestamp", Date.Now)
            insertcommand.Parameters.AddWithValue("@Reference", txtSalesID.Text)
            insertcommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
            insertcommand.ExecuteNonQuery()
        End Using
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "Delete From tblSalesLines where SalesID='" + txtSalesID.Text + "'AND QtySold ='0' AND SalesAmount='0';Delete from tblStockmovements where MovementType='Sale' AND TransferReference='" + txtSalesID.Text + "' AND MovementQtyHangers ='0' AND MovementValue='0'"
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection.Open()
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        FMain.SalesToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub createSales2()
        InsertCommand.Connection = connection
        InsertCommand.CommandText = "InsertSalesReturnID"
        InsertCommand.CommandType = CommandType.StoredProcedure
        InsertCommand.Parameters.AddWithValue("@ShopRef", txtShopRef.Text.Trim())
        InsertCommand.Parameters.AddWithValue("@ShopName", Label17.Text)
        InsertCommand.Parameters.AddWithValue("@SAReference", TextBox2.Text.Trim())
        InsertCommand.Parameters.AddWithValue("@TransactionDate", DateTimePicker1.Value)
        InsertCommand.Parameters.AddWithValue("@TotalQty", txtTotalGarments.Text)
        InsertCommand.Parameters.AddWithValue("@TotalValue", txtTotal.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now())
        InsertCommand.Parameters.Add("@SalesID", SqlDbType.Int, 0, "SalesID").Direction = ParameterDirection.Output
        InsertCommand.Connection.Close()
        InsertCommand.Connection.Open()
        InsertCommand.ExecuteNonQuery()
        ' InsertCommand.CommandText = "Select @@Identity"
        Dim id4 As Integer
        id4 = InsertCommand.Parameters("@SalesID").Value
        InsertCommand.Connection.Close()
        txtSalesID.Text = id4
        InsertCommand.Parameters.Clear()
        SaveStockMovements2()

    End Sub

End Class