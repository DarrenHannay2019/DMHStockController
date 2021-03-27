Imports System.Data.SqlClient

Public Class FMain
    ' (c) 2015 - Darren Mark Hannay
    ReadOnly ConnectionString As String = "Initial Catalog=DMHStockv4;Data Source=(local);Persist Security Info=False;Integrated Security=true;"
    ReadOnly Connection As New SqlConnection(ConnectionString)
    Dim cmd As SqlCommand
    Dim duplicatecommand As SqlCommand
    Dim deletecommand As SqlCommand
    ''' <summary>
    ''' structire to hold printed page details
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    ''' <summary>
    ''' dictionary to hold printed page details, with index key
    ''' </summary>
    ''' <remarks></remarks>
    Private pages As Dictionary(Of Integer, pageDetails)

    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer

    ''' <summary>
    ''' this just loads some text values into the dgv
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub ShopsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopsToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Color.LightSkyBlue
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadShop()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppliersToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Color.LightSkyBlue
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadSuppliers()
    End Sub

    Private Sub PurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseOrdersToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Color.LightSkyBlue
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadPurchaseOrders()
    End Sub

    Private Sub WarehouseAdjustmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseAdjustmentsToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Color.LightSkyBlue
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadWarehouseAdjustment()
    End Sub

    Private Sub ShopDeliveriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopDeliveriesToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Color.LightSkyBlue
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadShopDel()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Color.LightSkyBlue
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadSales()
    End Sub

    Private Sub ShopAdjustmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopAdjustmentsToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Color.LightSkyBlue
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadShopAdjustment()
    End Sub

    Private Sub ShopTransfersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopTransfersToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Color.LightSkyBlue
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadShopTrans()
    End Sub

    Private Sub ReturnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnsToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Color.LightSkyBlue
        LoadReturns()
    End Sub

    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Color.LightSkyBlue
        AllStockToolStripMenuItem.BackColor = Nothing
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        txtOption.Text = "Stock"
        LoadStock()
    End Sub

    Private Sub AllStockMovementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllStockMovementsToolStripMenuItem.Click
        FCriteria.Label3.Text = "AllStock"
        FCriteria.Show()
    End Sub

    Private Sub DeliveriesByStockCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveriesByStockCodeToolStripMenuItem.Click
        FCriteria.Label3.Text = "ShopDeliveries"
        FCriteria.Show()
    End Sub

    Private Sub StockListByShopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockListByShopToolStripMenuItem.Click
        FCriteria.Label3.Text = "ShopStock1"
        FCriteria.Show()
    End Sub

    Private Sub StockListByStockCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockListByStockCodeToolStripMenuItem.Click
        FCriteria.Label3.Text = "ShopStock2"
        FCriteria.Show()
    End Sub

    Private Sub WarehouseStockListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseStockListToolStripMenuItem.Click
        ' ReportWarehouseStock.Show()
        FCriteria.Label3.Text = "WarehouseStock"
        FCriteria.Show()
    End Sub

    Private Sub TotalStockValuationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalStockValuationToolStripMenuItem.Click
        FCriteria.Label3.Text = "TotalValue"
        FCriteria.Show()
    End Sub

    Private Sub SalesHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesHistoryToolStripMenuItem.Click
        FCriteria.Label3.Text = "SalesHistory"
        FCriteria.Show()
    End Sub

    Private Sub SalesAnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesAnalysisToolStripMenuItem.Click
        FCriteria.Label3.Text = "SalesAnalysis"
        FCriteria.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        FSettings.ShowDialog()
    End Sub

    Private Sub AllStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllStockToolStripMenuItem.Click
        txtOption.Text = "Stock"
        ShopsToolStripMenuItem.BackColor = Nothing
        SettingsToolStripMenuItem.BackColor = Nothing
        StockToolStripMenuItem.BackColor = Nothing
        AllStockToolStripMenuItem.BackColor = Color.LightSkyBlue
        PurchaseOrdersToolStripMenuItem.BackColor = Nothing
        ShopTransfersToolStripMenuItem.BackColor = Nothing
        ShopAdjustmentsToolStripMenuItem.BackColor = Nothing
        WarehouseAdjustmentsToolStripMenuItem.BackColor = Nothing
        SuppliersToolStripMenuItem.BackColor = Nothing
        SalesToolStripMenuItem.BackColor = Nothing
        ShopDeliveriesToolStripMenuItem.BackColor = Nothing
        ReturnsToolStripMenuItem.BackColor = Nothing
        LoadStock2()
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        If txtOption.Text = "Shops" Then FShopsEntry.Show()
        If txtOption.Text = "Suppliers" Then FSuppliersEntry.Show()
        If txtOption.Text = "Shop Transfers" Then FShopTransfers.Show()
        If txtOption.Text = "Purchase Order" Then FDeliveriesIn.Show()
        If txtOption.Text = "Stock" Then FStock.Show()
        If txtOption.Text = "Warehouse Adjustments" Then FWarehouseAdjustments.Show()
        If txtOption.Text = "Shop deliveries" Then FShopDeliveries.Show()
        If txtOption.Text = "Sales" Then FUpdatedSales.Show()
        If txtOption.Text = "Shop Adjustments" Then FShopAdjustments.Show()
        If txtOption.Text = "Returns" Then FReturns.Show()
    End Sub

    Private Sub RecordToolStripButton_Click(sender As Object, e As EventArgs) Handles RecordToolStripButton.Click
        txtMode.Text = "OLD"
        If txtOption.Text = "Shops" Then FShopsEntry.Show()
        If txtOption.Text = "Suppliers" Then FSuppliersEntry.Show()
        If txtOption.Text = "Shop Transfers" Then FShopTransfers.Show()
        If txtOption.Text = "Purchase Order" Then FDeliveriesIn.Show()
        If txtOption.Text = "Stock" Then FStock.Show()
        If txtOption.Text = "Shop deliveries" Then FShopDeliveries.Show()
        If txtOption.Text = "Sales" Then FUpdatedSales.Show()
        If txtOption.Text = "Warehouse Adjustments" Or txtOption.Text = "Shop Adjustments" Then FAdjustments.Show()

    End Sub

    Private Sub DeleteToolStripButton_Click(sender As Object, e As EventArgs) Handles DeleteToolStripButton.Click
        Dim result2 As DialogResult = MessageBox.Show("Are you sure you wish to delete record",
                              "Delete Record",
                              MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Question)
        ' txtMode.Text = "DELETE"
        If result2 <> DialogResult.Yes Then Exit Sub
        If result2 = DialogResult.Yes And txtOption.Text = "Shops" Then deleteShop()
        If result2 = DialogResult.Yes And txtOption.Text = "Suppliers" Then deleteSupplier()
        If result2 = DialogResult.Yes And txtOption.Text = "Shop Transfers" Then deleteShopTransfers()
        If result2 = DialogResult.Yes And txtOption.Text = "Purchase Order" Then deletePurchaseOrder()
        If result2 = DialogResult.Yes And txtOption.Text = "Stock" Then deleteStock()
        If result2 = DialogResult.Yes And txtOption.Text = "Warehouse Adjustments" Then deleteWarehouseAdjustments()
        If result2 = DialogResult.Yes And txtOption.Text = "Shop deliveries" Then deleteShopDelivery()
        If result2 = DialogResult.Yes And txtOption.Text = "Sales" Then deleteShopSales()
        If result2 = DialogResult.Yes And txtOption.Text = "Shop Adjustments" Then deleteShopAdjustments()
        If result2 = DialogResult.Yes And txtOption.Text = "Returns" Then deleteReturns()
    End Sub

    Private Sub RefreshToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshToolStripButton.Click
        If txtOption.Text = "Shops" Then ShopsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Suppliers" Then SuppliersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop Transfers" Then ShopTransfersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Purchase Order" Then PurchaseOrdersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Stock" Then StockToolStripMenuItem.PerformClick()
        If txtOption.Text = "Warehouse Adjustments" Then WarehouseAdjustmentsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop deliveries" Then ShopDeliveriesToolStripMenuItem.PerformClick()
        If txtOption.Text = "Sales" Then SalesToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop Adjustments" Then ShopAdjustmentsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Returns" Then ReturnsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If txtOption.Text = "Shops" Then PrintShops() '1
        If txtOption.Text = "Suppliers" Then PrintSuppliers() '2
        If txtOption.Text = "Purchase Order" Then PrintPurchase() '4
        If txtOption.Text = "Stock" Then PrintStock() ' 3
        If txtOption.Text = "Shop deliveries" Then printShopDels()
        If txtOption.Text = "Sales" Then printSales()
    End Sub

    Private Sub ProveToolStripButton_Click(sender As Object, e As EventArgs) Handles ProveToolStripButton.Click

    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click
        FindInput.Visible = True
        menustripTextbox1.Visible = True
    End Sub

    Private Sub TransferToolStripButton_Click(sender As Object, e As EventArgs) Handles TransferToolStripButton.Click

    End Sub

    Private Sub CloseToolStripButton_Click(sender As Object, e As EventArgs) Handles CloseToolStripButton.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripButton_Click(sender As Object, e As EventArgs) Handles AboutToolStripButton.Click
        FAboutBox.Show()
    End Sub

    Private Sub FindInput_TextChanged(sender As Object, e As EventArgs) Handles FindInput.TextChanged
        If txtOption.Text = "Shops" Then Findshop() '1
        If txtOption.Text = "Suppliers" Then FindSuppliers() '2
        If txtOption.Text = "Shop Transfers" Then FindShopTransfer() '7
        If txtOption.Text = "Purchase Order" Then FindPurchaseOrder() '4
        If txtOption.Text = "Stock" Then FindStock() ' 3
        If txtOption.Text = "Shop deliveries" Then FindShopDelivery()
        If txtOption.Text = "Sales" Then FindSales()
    End Sub

    Private Sub FMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMode.Visible = False
        txtOption.Visible = False
        ToolStripTextBox1.Visible = False
        PrintToolStripButton.Visible = False
        TextBox1.Visible = False
        TextBox1.Text = "1"
        FindInput.Enabled = True
        DgvRecords.EnableHeadersVisualStyles = False
    End Sub


    Private Sub BorehamwoodStockListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorehamwoodStockListToolStripMenuItem.Click
        FCriteria.Label3.Text = "Borehamwood"
        FCriteria.Show()
    End Sub
    Private Sub LoadShop()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Text = "DMH Stock Master v2 [Shops]"
        txtOption.Text = "Shops"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShops", Connection)
            gridDataAdapter.Fill(data, "tblShops")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "tblShops"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.EnableHeadersVisualStyles = False
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'ShopRef
            DgvRecords.Columns.Item(0).HeaderText = "Shop Ref"
            DgvRecords.Columns.Item(0).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(1).HeaderText = "Shop Name"
            DgvRecords.Columns.Item(1).Width = "182"
            'Address1
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Address"
            DgvRecords.Columns.Item(2).Width = "182"
            'Address2
            DgvRecords.Columns.Item(3).Visible = False
            'Address3
            DgvRecords.Columns.Item(4).Visible = False
            'Address4
            DgvRecords.Columns.Item(5).Visible = False
            'PostCode
            DgvRecords.Columns.Item(6).Visible = False
            'Telephone
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Telephone"
            DgvRecords.Columns.Item(7).Width = "182"
            'Fax
            DgvRecords.Columns.Item(8).Visible = False
            'eMail
            DgvRecords.Columns.Item(9).Visible = False
            'ShopType
            DgvRecords.Columns.Item(10).HeaderText = "Type"
            DgvRecords.Columns.Item(10).Visible = True
            DgvRecords.Columns.Item(10).Width = "182"
            'Memo
            DgvRecords.Columns.Item(11).Visible = False
            'ContactName
            DgvRecords.Columns.Item(12).Visible = False
            'CreatedBy
            DgvRecords.Columns.Item(13).HeaderText = "Created By"
            DgvRecords.Columns.Item(13).Visible = True
            'CreatedDate
            DgvRecords.Columns.Item(14).HeaderText = "Created At"
            DgvRecords.Columns.Item(14).Visible = True
            ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadSuppliers()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Suppliers]"
        txtOption.Text = "Suppliers"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSuppliers", Connection)
            gridDataAdapter.Fill(data, "tblSuppliers")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "tblSuppliers"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.AutoResizeColumns()
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'SupplierRef
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Supplier Ref"
            DgvRecords.Columns.Item(0).Width = "182"
            'SupplierName
            DgvRecords.Columns.Item(1).HeaderText = "Supplier Name"
            DgvRecords.Columns.Item(1).Width = "182"
            'Address1
            DgvRecords.Columns.Item(2).HeaderText = "Address"
            DgvRecords.Columns.Item(2).Width = "182"
            'Address2
            DgvRecords.Columns.Item(3).Visible = False
            'Address3
            DgvRecords.Columns.Item(4).Visible = False
            'Address4
            DgvRecords.Columns.Item(5).Visible = False
            'PostCode
            DgvRecords.Columns.Item(6).Visible = False
            'ContactName
            DgvRecords.Columns.Item(7).HeaderText = "Contact Name"
            DgvRecords.Columns.Item(7).Width = "182"
            'Telephone
            DgvRecords.Columns.Item(8).HeaderText = "Telephone"
            DgvRecords.Columns.Item(8).Width = "182"
            'Fax
            DgvRecords.Columns.Item(9).Visible = False
            'eMail
            DgvRecords.Columns.Item(10).Visible = False
            'Memo
            DgvRecords.Columns.Item(11).Visible = False
            'WebSites
            DgvRecords.Columns.Item(12).Visible = False
            'Supplier.CreatedBy
            DgvRecords.Columns.Item(13).HeaderText = "Created By"
            DgvRecords.Columns.Item(13).Visible = False
            'Supplier.CreatedDate
            DgvRecords.Columns.Item(14).HeaderText = "Created At"
            DgvRecords.Columns.Item(14).Width = 130
            Connection.Close()
            ToolStripStatusLabel1.Text = "Suppliers"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadPurchaseOrders()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Purchase Order]"
        txtOption.Text = "Purchase Order"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * FROM tblDeliveries order by DeliveryDate desc", Connection)
            gridDataAdapter.Fill(data, "tblDeliveries")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "tblDeliveries"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.LightBlue
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.AutoResizeColumns()
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            ' Delivery ID
            DgvRecords.Columns(0).HeaderText = "Delivery ID"
            DgvRecords.Columns(0).Width = 50
            DgvRecords.Columns.Item(0).DefaultCellStyle.Format = "000000"
            DgvRecords.Columns(0).Visible = True
            ' Our Ref
            DgvRecords.Columns(1).HeaderText = "Our Ref"
            DgvRecords.Columns(1).Width = 120
            DgvRecords.Columns(1).Visible = True
            ' Supplier Ref
            DgvRecords.Columns(2).HeaderText = "Supplier Ref"
            DgvRecords.Columns(2).Width = 100
            DgvRecords.Columns(2).Visible = False
            ' Supplier Name
            DgvRecords.Columns(3).HeaderText = "Supplier Name"
            DgvRecords.Columns(3).Width = 160
            DgvRecords.Columns(3).Visible = True
            ' Location Ref
            DgvRecords.Columns(4).HeaderText = "Location Ref"
            DgvRecords.Columns(4).Width = 150
            DgvRecords.Columns(4).Visible = False
            ' Location Name
            DgvRecords.Columns(5).HeaderText = "Location Name"
            DgvRecords.Columns(5).Width = 160
            DgvRecords.Columns(5).Visible = True
            ' Stock Code
            DgvRecords.Columns(6).HeaderText = "Stock Code"
            DgvRecords.Columns(6).Width = "50"
            DgvRecords.Columns(6).Visible = False
            ' DQty Garments
            DgvRecords.Columns(7).HeaderText = "Garments"
            DgvRecords.Columns(7).Width = 70
            DgvRecords.Columns(7).Visible = True
            ' DQty Boxes
            DgvRecords.Columns(8).HeaderText = "Boxes"
            DgvRecords.Columns(8).Width = 70
            DgvRecords.Columns(8).Visible = False
            ' DQty Hangers
            DgvRecords.Columns(9).HeaderText = "Hangers"
            DgvRecords.Columns(9).Width = "50"
            DgvRecords.Columns(9).Visible = False
            ' Total Garments
            DgvRecords.Columns(10).HeaderText = "Total Garments"
            DgvRecords.Columns(10).Width = "50"
            DgvRecords.Columns(10).Visible = False
            ' Total Boxes
            DgvRecords.Columns(11).HeaderText = "Total Boxes"
            DgvRecords.Columns(11).Width = "50"
            DgvRecords.Columns(11).Visible = False
            ' Total Hangers
            DgvRecords.Columns(12).HeaderText = "Total Hangers"
            DgvRecords.Columns(12).Width = "50"
            DgvRecords.Columns(12).Visible = False
            ' Net Amount
            DgvRecords.Columns(13).HeaderText = "Net Amount"
            DgvRecords.Columns.Item(13).DefaultCellStyle.Format = "c"
            DgvRecords.Columns(13).Width = 70
            DgvRecords.Columns(13).Visible = True
            ' Delivery Charge
            DgvRecords.Columns(14).HeaderText = "Del. Charge"
            DgvRecords.Columns(14).Width = "50"
            DgvRecords.Columns(14).Visible = False
            ' Commission
            DgvRecords.Columns(15).HeaderText = "Commission"
            DgvRecords.Columns(15).Width = "50"
            DgvRecords.Columns(15).Visible = False
            ' Total Amount
            DgvRecords.Columns(16).HeaderText = "Total Amount"
            DgvRecords.Columns(16).Width = "50"
            DgvRecords.Columns(16).Visible = False
            ' Delivery Date
            DgvRecords.Columns(17).HeaderText = "Delivery Date"
            DgvRecords.Columns(17).Width = 90
            DgvRecords.Columns(17).Visible = True
            ' Delivery Type
            DgvRecords.Columns(18).HeaderText = "Delivery Type"
            DgvRecords.Columns(18).Width = "50"
            DgvRecords.Columns(18).Visible = False
            ' Confirmed Date
            DgvRecords.Columns(19).HeaderText = "Confirmed Date"
            DgvRecords.Columns(19).Width = "50"
            DgvRecords.Columns(19).Visible = False
            ' Notes
            DgvRecords.Columns(20).HeaderText = "Notes"
            DgvRecords.Columns(20).Width = "50"
            DgvRecords.Columns(20).Visible = False
            ' InvoiceNo
            DgvRecords.Columns(21).HeaderText = "Invoice"
            DgvRecords.Columns(21).Width = "50"
            DgvRecords.Columns(21).Visible = False
            ' Shipper
            DgvRecords.Columns(22).HeaderText = "Shipper"
            DgvRecords.Columns(22).Width = "50"
            DgvRecords.Columns(22).Visible = False
            ' ShipperInvoice
            DgvRecords.Columns(23).HeaderText = "Shipper Invoice"
            DgvRecords.Columns(23).Width = "50"
            DgvRecords.Columns(23).Visible = False
            ' Created By
            DgvRecords.Columns(24).HeaderText = "Created By"
            DgvRecords.Columns(24).Width = 80
            DgvRecords.Columns(24).Visible = False
            ' Created Date
            DgvRecords.Columns(25).HeaderText = "Created Date"
            DgvRecords.Columns(25).Width = 100
            DgvRecords.Columns(25).Visible = False
            Connection.Close()
            ToolStripStatusLabel1.Text = "Purchase Orders"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadStock()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Try
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblStock", Connection)
            gridDataAdapter.Fill(data, "tblStock")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "tblStock"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Text = "DMH Stock Master v2 [Stock]"
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.LightCoral
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockCode
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Stock Code"
            DgvRecords.Columns.Item(0).Width = "20"
            'SupplierRef
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Supplier Ref"
            DgvRecords.Columns.Item(1).Width = "10"
            'Dead Code
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Dead Code"
            DgvRecords.Columns.Item(2).Width = "30"
            DgvRecords.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "Amount Taken"
            DgvRecords.Columns.Item(3).Width = "10"
            DgvRecords.Columns.Item(3).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            DgvRecords.Columns.Item(4).Visible = False
            DgvRecords.Columns.Item(4).Width = "10"
            'CostValue
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Cost Value"
            DgvRecords.Columns.Item(5).Width = "12"
            DgvRecords.Columns.Item(4).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DgvRecords.Columns.Item(5).HeaderText = "Markup"
            DgvRecords.Columns.Item(6).Width = "12"
            DgvRecords.Columns.Item(5).DefaultCellStyle.Format = "p"
            'ZeroQty
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Zero Qty"
            DgvRecords.Columns.Item(7).DefaultCellStyle.Format = "Yes/No"
            'Stock.CreatedBy
            DgvRecords.Columns.Item(8).HeaderText = "Created By"
            DgvRecords.Columns.Item(8).Width = "12"
            'Stock.CreatedDate
            DgvRecords.Columns.Item(9).HeaderText = "Created At"
            DgvRecords.Columns.Item(9).Width = "12"
            DgvRecords.Columns.Item(9).DefaultCellStyle.Format = "dd/MM/yyyy"
            ToolStripStatusLabel1.Text = "Stock"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub

    Private Sub LoadStock2()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Try
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblStock ", Connection)
            gridDataAdapter.Fill(data, "tblStock")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "tblStock"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Text = "DMH Stock Master v2 [Stock]"
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockCode
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Stock Code"
            DgvRecords.Columns.Item(0).Width = "20"
            'SupplierRef
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Supplier Ref"
            DgvRecords.Columns.Item(1).Width = "10"
            'Dead Code
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Dead Code"
            DgvRecords.Columns.Item(2).Width = "30"
            DgvRecords.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "Amount Taken"
            DgvRecords.Columns.Item(3).Width = "10"
            DgvRecords.Columns.Item(3).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            DgvRecords.Columns.Item(4).Visible = False
            DgvRecords.Columns.Item(4).Width = "10"
            'CostValue
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Cost Value"
            DgvRecords.Columns.Item(5).Width = "12"
            DgvRecords.Columns.Item(5).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DgvRecords.Columns.Item(6).HeaderText = "Markup"
            DgvRecords.Columns.Item(6).Width = "12"
            DgvRecords.Columns.Item(6).DefaultCellStyle.Format = "p"
            'ZeroQty
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Zero Qty"
            DgvRecords.Columns.Item(7).DefaultCellStyle.Format = "Yes/No"
            'Stock.CreatedBy
            DgvRecords.Columns.Item(8).HeaderText = "Created By"
            DgvRecords.Columns.Item(8).Width = "12"
            'Stock.CreatedDate
            DgvRecords.Columns.Item(9).HeaderText = "Created At"
            DgvRecords.Columns.Item(9).Width = "12"
            DgvRecords.Columns.Item(9).DefaultCellStyle.Format = "dd/MM/yyyy"
            Connection.Close()
            ToolStripStatusLabel1.Text = "Stock"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadShopTrans()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Text = "DMH Stock Master v2 [Shop Transfers]"
        txtOption.Text = "Shop Transfers"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShopTransfers", Connection)
            gridDataAdapter.Fill(data, "tblShopTransfers")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "tblShopTransfers"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.AutoResizeColumns()
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'TransferID
            DgvRecords.Columns.Item(0).Visible = False
            'Reference
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "TF Note"
            DgvRecords.Columns.Item(1).Width = "100"
            'From Shop
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Date"
            DgvRecords.Columns.Item(2).Width = "100"
            'To Shop
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "From Shop Ref"
            DgvRecords.Columns.Item(3).Width = "100"
            'From Quantity
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "From Shop Name"
            DgvRecords.Columns.Item(4).Width = "200"
            'Movement Date
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "To Shop Ref"
            DgvRecords.Columns.Item(5).Width = "100"
            'Transfer Reference
            DgvRecords.Columns.Item(6).Visible = False
            DgvRecords.Columns.Item(6).HeaderText = "To Shop Name"
            DgvRecords.Columns.Item(6).Width = "182"
            'From Shop Ref
            DgvRecords.Columns.Item(6).Visible = False
            DgvRecords.Columns.Item(6).HeaderText = "From Shop Ref"
            DgvRecords.Columns.Item(6).Width = "182"
            'ToShopRef
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "From Quantity"
            DgvRecords.Columns.Item(7).Width = "182"
            'TotalQtyIn
            DgvRecords.Columns.Item(8).Visible = True
            DgvRecords.Columns.Item(8).HeaderText = "To Quantity"
            DgvRecords.Columns.Item(8).Width = "182"
            DgvRecords.Columns.Item(9).Visible = False
            DgvRecords.Columns.Item(10).Visible = False
            Connection.Close()
            ToolStripStatusLabel1.Text = "Shop Transfers"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadWarehouseAdjustment()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = False
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Warehouse Adjustment]"
        txtOption.Text = "Warehouse Adjustments"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryWarehouseAdjustments", Connection)
            gridDataAdapter.Fill(data, "qryWarehouseAdjustments")
            Connection.Open()
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryWarehouseAdjustments"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.AutoResizeColumns()
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockmovementID
            DgvRecords.Columns.Item(0).Visible = False
            DgvRecords.Columns.Item(0).HeaderText = "Stocmovement ID"
            DgvRecords.Columns.Item(0).Width = "182"
            'Reference
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Reference"
            DgvRecords.Columns.Item(1).Width = "182"
            'Location
            DgvRecords.Columns.Item(2).Visible = False
            DgvRecords.Columns.Item(2).HeaderText = "Date"
            DgvRecords.Columns.Item(2).Width = "182"
            'WarehouseName
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "Warehouse Name"
            DgvRecords.Columns.Item(3).Width = "182"
            'StockCode
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Stock Code"
            DgvRecords.Columns.Item(4).Width = "182"
            'Type
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Type"
            DgvRecords.Columns.Item(5).Width = "182"
            'Qty
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Qty"
            DgvRecords.Columns.Item(6).Width = "182"
            ' MovementDate
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Date"
            DgvRecords.Columns.Item(7).Width = "182"
            Connection.Close()
            ToolStripStatusLabel1.Text = "Warehouse Adjustments"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadShopDel()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Shop Deliveries]"
        txtOption.Text = "Shop deliveries"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShopDeliveries", Connection)
            gridDataAdapter.Fill(data, "tblShopDeliveries")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "tblShopDeliveries"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.AutoResizeColumns()
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'DeliveryID
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Delivery No"
            DgvRecords.Columns.Item(0).Width = "182"
            DgvRecords.Columns.Item(0).DefaultCellStyle.Format = "000000"
            'ShopRef
            DgvRecords.Columns.Item(1).Visible = False
            DgvRecords.Columns.Item(1).HeaderText = "Shop Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Shop"
            DgvRecords.Columns.Item(2).Width = "182"
            'WarehouseRef
            DgvRecords.Columns.Item(3).Visible = False
            DgvRecords.Columns.Item(3).HeaderText = "Warehouse Ref"
            DgvRecords.Columns.Item(3).Width = "182"
            'WarehouseName
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Warehouse"
            DgvRecords.Columns.Item(4).Width = "182"
            'Reference
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Reference"
            DgvRecords.Columns.Item(5).Width = "182"
            'TotalHangers
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Quantity"
            DgvRecords.Columns.Item(6).Width = "182"
            'DeliveryDate
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Delivery Date"
            DgvRecords.Columns.Item(7).Width = "182"
            'DeliveryType
            DgvRecords.Columns.Item(8).Visible = False
            DgvRecords.Columns.Item(8).HeaderText = "Created By"
            DgvRecords.Columns.Item(8).Width = "182"
            'ConfirmedDate
            DgvRecords.Columns.Item(9).Visible = False
            DgvRecords.Columns.Item(9).HeaderText = "Created Date"
            DgvRecords.Columns.Item(0).Width = "182"
            'Notes
            DgvRecords.Columns.Item(10).Visible = True
            DgvRecords.Columns.Item(10).HeaderText = "Notes"
            DgvRecords.Columns.Item(10).Width = "182"
            'CreatedBy
            DgvRecords.Columns.Item(11).Visible = False
            DgvRecords.Columns.Item(11).HeaderText = "Created By"
            DgvRecords.Columns.Item(11).Width = "182"
            'CreatedDate
            DgvRecords.Columns.Item(12).Visible = False
            DgvRecords.Columns.Item(12).HeaderText = "Created At"
            DgvRecords.Columns.Item(12).Width = "182"
            Connection.Close()
            ToolStripStatusLabel1.Text = "Shop Deliveries"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub

    Private Sub LoadSales()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = True
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Sales]"
        txtOption.Text = "Sales"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSales", Connection)
            gridDataAdapter.Fill(data, "tblSales")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "tblSales"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.AutoResizeColumns()
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'SalesID
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Sales ID"
            DgvRecords.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DgvRecords.Columns.Item(0).Width = "182"
            'ShopRef
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Shop Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Shop Name"
            DgvRecords.Columns.Item(2).Width = "182"
            'Reference
            DgvRecords.Columns.Item(3).Visible = False
            DgvRecords.Columns.Item(3).HeaderText = "Reference"
            DgvRecords.Columns.Item(3).Width = "182"
            'TransactionDate
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Date"
            DgvRecords.Columns.Item(4).Width = "182"
            'TotalQty
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Total Garments"
            DgvRecords.Columns.Item(5).Width = "182"
            'TotalValue
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Total Sales"
            DgvRecords.Columns.Item(6).Width = "182"
            DgvRecords.Columns.Item(6).DefaultCellStyle.Format = "c"
            'CreatedBy
            DgvRecords.Columns.Item(7).Visible = False
            DgvRecords.Columns.Item(7).HeaderText = "From ID"
            DgvRecords.Columns.Item(7).Width = "182"
            'CreatedDate
            DgvRecords.Columns.Item(8).Visible = False
            DgvRecords.Columns.Item(8).HeaderText = "To ID"
            DgvRecords.Columns.Item(8).Width = "182"
            Connection.Close()
            ToolStripStatusLabel1.Text = "Sales"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadShopAdjustment()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = False
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Shop Adjustments]"
        txtOption.Text = "Shop Adjustments"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryShopAdjustments", Connection)
            gridDataAdapter.Fill(data, "qryShopAdjustments")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryShopAdjustments"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.AutoResizeColumns()
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'StockmovementID
            DgvRecords.Columns.Item(0).Visible = False
            DgvRecords.Columns.Item(0).HeaderText = "Stocmovement ID"
            DgvRecords.Columns.Item(0).Width = "182"
            'Reference
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Reference"
            DgvRecords.Columns.Item(1).Width = "182"
            'Location
            DgvRecords.Columns.Item(2).Visible = False
            DgvRecords.Columns.Item(2).HeaderText = "Date"
            DgvRecords.Columns.Item(2).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "Shop Name"
            DgvRecords.Columns.Item(3).Width = "182"
            'StockCode
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Stock Code"
            DgvRecords.Columns.Item(4).Width = "182"
            'Type
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Type"
            DgvRecords.Columns.Item(5).Width = "182"
            'Qty
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Qty"
            DgvRecords.Columns.Item(6).Width = "182"
            ' MovementDate
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Date"
            DgvRecords.Columns.Item(7).Width = "182"
            ToolStripStatusLabel1.Text = "Shop Adjustments"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadReturns()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = False
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Returns]"
        txtOption.Text = "Returns"
        Try
            ' Create a DataSet
            Dim data As New DataSet With {
                .Locale = System.Globalization.CultureInfo.InvariantCulture
            }
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryReturns order by SMCreatedDate Desc", Connection)
            gridDataAdapter.Fill(data, "qryReturns")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryReturns"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.AutoResizeColumns()
            DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'TransferReference
            DgvRecords.Columns.Item(0).Visible = False
            'FromID
            DgvRecords.Columns.Item(2).Visible = False
            'Reference
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Reference"
            DgvRecords.Columns.Item(1).Width = "182"
            'ToID
            DgvRecords.Columns.Item(3).Visible = False
            DgvRecords.Columns.Item(4).Visible = True
            'FromShop
            DgvRecords.Columns.Item(4).HeaderText = "From Shop Name"
            DgvRecords.Columns.Item(4).Width = "182"
            'CreatedDate
            DgvRecords.Columns.Item(5).Visible = False
            'ToWarehouse
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "To Warehouse Name"
            DgvRecords.Columns.Item(6).Width = "182"
            'StockCode
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Stock Code"
            DgvRecords.Columns.Item(7).Width = "182"
            'MovementQty
            DgvRecords.Columns.Item(8).Visible = True
            DgvRecords.Columns.Item(8).HeaderText = "Quantity"
            DgvRecords.Columns.Item(8).Width = "182"
            'MovementDate
            DgvRecords.Columns.Item(9).Visible = True
            DgvRecords.Columns.Item(9).HeaderText = "Date"
            DgvRecords.Columns.Item(9).Width = "182"
            DgvRecords.Columns.Item(10).Visible = False
            DgvRecords.Columns.Item(11).Visible = False
            Connection.Close()
            ToolStripStatusLabel1.Text = "Returns"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub Findshop()
        If FindInput.Text = "" Then LoadShop()
        If FindInput.Text <> "" Then
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim ds As New DataSet
            Dim sql As String = "SELECT * FROM tblShops"
            Dim connection As New SqlConnection(ConnectionString)
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            connection.Open()
            dataadapter.Fill(ds, "tblShops")
            connection.Close()
            'Dim tables As DataTableCollection = data.Tables
            'data.Locale = System.Globalization.CultureInfo.InvariantCulture
            'Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShops", connection)
            'gridDataAdapter.Fill(data, "tblShops")
            'Dim view1 As New DataView(tables(0))
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            '  BindingSource1.DataSource = view1
            ' BindingSource1.Filter = "[ShopRef] = '" & FindInput.Text & "'"
            '  DgvRecords.DataSource = BindingSource1
            '  DgvRecords.Refresh()
            Dim dv As DataView
            dv = New DataView(ds.Tables(0), "ShopRef = '" & FindInput.Text & "'", "", DataViewRowState.CurrentRows)
            DgvRecords.DataSource = dv
            'ShopID
            DgvRecords.Columns.Item(0).Visible = False
            'ShopRef
            DgvRecords.Columns.Item(1).HeaderText = "Shop Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(2).HeaderText = "Shop Name"
            DgvRecords.Columns.Item(2).Width = "182"
            'Shop.Address1
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "Address"
            DgvRecords.Columns.Item(3).Width = "182"
            'Shop.Address2
            DgvRecords.Columns.Item(4).Visible = False
            'Shop.Address3
            DgvRecords.Columns.Item(5).Visible = False
            'Shop.Address4
            DgvRecords.Columns.Item(6).Visible = False
            'Shop.PostCode
            DgvRecords.Columns.Item(7).Visible = False
            'Shop.ContactName
            DgvRecords.Columns.Item(8).Visible = False
            DgvRecords.Columns.Item(8).HeaderText = "Contact Name"
            DgvRecords.Columns.Item(8).Width = "182"
            'Shop.Telephone
            DgvRecords.Columns.Item(9).Visible = False
            DgvRecords.Columns.Item(9).HeaderText = "Telephone"
            DgvRecords.Columns.Item(9).Width = "182"
            'Shop.Telephone2
            DgvRecords.Columns.Item(10).Visible = False
            'Shop.Fax
            DgvRecords.Columns.Item(11).Visible = False
            'Shop.eMail
            DgvRecords.Columns.Item(12).Visible = False
            'Shop.memo
            DgvRecords.Columns.Item(13).Visible = False
            'Shop.ShopType
            DgvRecords.Columns.Item(14).HeaderText = "Type"
            DgvRecords.Columns.Item(14).Width = "182"
            'Shop.Clearance
            DgvRecords.Columns.Item(15).HeaderText = "Clearance Shop"
            DgvRecords.Columns.Item(15).Width = "182"
            'Shop.CreatedBy
            DgvRecords.Columns.Item(16).HeaderText = "Created By"
            DgvRecords.Columns.Item(16).Width = "182"
            'Shop.CreatedDate
            DgvRecords.Columns.Item(17).HeaderText = "Created At"
            DgvRecords.Columns.Item(17).Width = "182"
        End If
    End Sub

    Private Sub FindSuppliers()
        If FindInput.Text = "" Then LoadSuppliers()
        If FindInput.Text <> "" Then
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblsuppliers", Connection)
            gridDataAdapter.Fill(data, "tblSuppliers")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            BindingSource1.Filter = "[SupplierRef] = '" & FindInput.Text & "'"
            DgvRecords.DataSource = BindingSource1
            DgvRecords.Refresh()
            'SupplierRef
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Supplier Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'SupplierName
            DgvRecords.Columns.Item(2).HeaderText = "Supplier Name"
            DgvRecords.Columns.Item(2).Width = "182"
            'Supplier.Address1
            DgvRecords.Columns.Item(3).HeaderText = "Address"
            DgvRecords.Columns.Item(3).Width = "182"
            'Supplier.Address2
            DgvRecords.Columns.Item(4).Visible = False
            'Supplier.Address3
            DgvRecords.Columns.Item(5).Visible = False
            'Supplier.Address4
            DgvRecords.Columns.Item(6).Visible = False
            'Supplier.PostCode
            DgvRecords.Columns.Item(7).Visible = False
            'Supplier.ContactName
            DgvRecords.Columns.Item(8).HeaderText = "Contact Name"
            DgvRecords.Columns.Item(8).Width = "182"
            'Supplier.Telephone
            DgvRecords.Columns.Item(9).HeaderText = "Telephone"
            DgvRecords.Columns.Item(9).Width = "182"
            'Supplier.Telephone2
            DgvRecords.Columns.Item(10).Visible = False
            'Supplier.Fax
            DgvRecords.Columns.Item(11).Visible = False
            'Supplier.eMail
            DgvRecords.Columns.Item(12).Visible = False
            'Supplier.memo
            DgvRecords.Columns.Item(13).Visible = False
            'Supplier.CreatedBy
            DgvRecords.Columns.Item(14).HeaderText = "Created By"
            DgvRecords.Columns.Item(14).Width = "182"
            'Supplier.CreatedDate
            DgvRecords.Columns.Item(15).HeaderText = "Created At"
            DgvRecords.Columns.Item(15).Width = "182"
        End If
    End Sub

    Private Sub FindStock()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryShowStock", Connection)
            gridDataAdapter.Fill(data, "qryShowStock")
            Dim view1 As New DataView(tables(0))
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[StockCode] LIKE '" & FindInput.Text & "%'"
            DgvRecords.DataSource = BindingSource1
            DgvRecords.Refresh()
            Dim dgv As New DataTable
            DgvRecords.DataSource = BindingSource1
            ' dgv.DefaultView.RowFilter = "StockCode LIKE '" & FindInput.Text & "%'"
            'StockID
            'DgvRecords.Columns.Item(0).Visible = False
            'DgvRecords.Columns.Item(0).Width = "10"
            'StockCode
            'DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Stock Code"
            '  DgvRecords.Columns.Item(0).Width = "20"
            'SupplierRef
            '  DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Supplier Ref"
            ' DgvRecords.Columns.Item(1).Width = "10"
            'Season
            ' DgvRecords.Columns.Item(2).Visible = False
            ' DgvRecords.Columns.Item(2).HeaderText = "Season"
            ' DgvRecords.Columns.Item(2).Width = "10"
            'Dead Code
            'DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Dead Code"
            ' DgvRecords.Columns.Item(2).Width = "30"
            ' DgvRecords.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'RemoveFromClearance
            DgvRecords.Columns.Item(3).Visible = False
            DgvRecords.Columns.Item(3).HeaderText = "Remove"
            ' DgvRecords.Columns.Item(4).Width = "10"
            ' DgvRecords.Columns.Item(4).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "Amount Taken"
            DgvRecords.Columns.Item(3).Width = "10"
            DgvRecords.Columns.Item(3).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            DgvRecords.Columns.Item(4).Visible = False
            DgvRecords.Columns.Item(4).Width = "10"
            'CostValue
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Cost Value"
            DgvRecords.Columns.Item(5).Width = "12"
            DgvRecords.Columns.Item(5).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DgvRecords.Columns.Item(6).HeaderText = "Markup"
            DgvRecords.Columns.Item(6).Width = "12"
            DgvRecords.Columns.Item(6).DefaultCellStyle.Format = "p"
            'ZeroQty
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Zero Qty"
            DgvRecords.Columns.Item(7).DefaultCellStyle.Format = "Yes/No"
            'Stock.CreatedBy
            DgvRecords.Columns.Item(8).HeaderText = "Created By"
            DgvRecords.Columns.Item(8).Width = "12"
            'Stock.CreatedDate
            DgvRecords.Columns.Item(9).HeaderText = "Created At"
            DgvRecords.Columns.Item(9).Width = "12"
            DgvRecords.Columns.Item(9).DefaultCellStyle.Format = "dd/MM/yyyy"
            '  connection.Close()
        End If
    End Sub

    Private Sub FindSales()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "ShopRef"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", Connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DgvRecords.DataSource = BindingSource1
            DgvRecords.Refresh()
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            Dim dgv As New DataTable
            DgvRecords.DataSource = BindingSource1
            'SalesID
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Sales ID"
            DgvRecords.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DgvRecords.Columns.Item(0).Width = "182"
            'ShopRef
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Shop Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Shop Name"
            DgvRecords.Columns.Item(2).Width = "182"
            'Reference
            DgvRecords.Columns.Item(3).Visible = False
            DgvRecords.Columns.Item(3).HeaderText = "Reference"
            DgvRecords.Columns.Item(3).Width = "182"
            'TransactionDate
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Date"
            DgvRecords.Columns.Item(4).Width = "182"
            'TotalQty
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Total Garments"
            DgvRecords.Columns.Item(5).Width = "182"
            'TotalValue
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Total Sales"
            DgvRecords.Columns.Item(6).Width = "182"
            'CreatedBy
            ' DgvRecords.Columns.Item(7).Visible = False
            'DgvRecords.Columns.Item(7).HeaderText = "From ID"
            'DgvRecords.Columns.Item(7).Width = "182"
            'CreatedDate
            'DgvRecords.Columns.Item(8).Visible = False
            ' DgvRecords.Columns.Item(8).HeaderText = "To ID"
            'DgvRecords.Columns.Item(8).Width = "182"
        End If
    End Sub

    Private Sub FindPurchaseOrder()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "SupplierRef"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryDeliveriesDisplay", Connection)
            gridDataAdapter.Fill(data, "qryDeliveriesDisplay")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[SupplierRef] LIKE '" & FindInput.Text & "%'"
            DgvRecords.DataSource = BindingSource1
            DgvRecords.Refresh()
            Dim dgv As New DataTable
            DgvRecords.DataSource = BindingSource1
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'tblDeliveries.DeliveryID
            DgvRecords.Columns.Item(0).Visible = True
            '   DgvRecords.Columns.Item(0).HeaderText = "Order Number"
            ' DgvRecords.Columns.Item(0).DefaultCellStyle.Format = "Number"
            DgvRecords.Columns.Item(0).Width = "182"
            'tblDeliveries.OurRef
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Our Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'tblDeliveries.SupplierRef
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Supplier Ref"
            DgvRecords.Columns.Item(2).Width = "182"
            'tblSuppliers.SupplierName
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "Supplier Name"
            DgvRecords.Columns.Item(3).Width = "182"
            'tblDeliveries.Season
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Season"
            DgvRecords.Columns.Item(4).Width = "182"
            'tblDeliveries.WarehouseRef
            DgvRecords.Columns.Item(5).Visible = False
            DgvRecords.Columns.Item(5).HeaderText = "Warehouse Ref"
            DgvRecords.Columns.Item(5).Width = "182"
            'tblDeliveries,TotalGarments
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Garments"
            DgvRecords.Columns.Item(6).Width = "182"
            'tblDeliveries.TotalBoxes 
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Boxes"
            DgvRecords.Columns.Item(7).Width = "182"
            'tblDeliveries.TotalHangers 
            DgvRecords.Columns.Item(8).Visible = True
            DgvRecords.Columns.Item(8).HeaderText = "Hangers"
            DgvRecords.Columns.Item(8).Width = "182"
            'tblDeliveries.NetAmount 
            DgvRecords.Columns.Item(9).Visible = True
            DgvRecords.Columns.Item(9).HeaderText = "Net Cost"
            DgvRecords.Columns.Item(9).Width = "182"
            'tblDeliveries.DeliveryCharge
            DgvRecords.Columns.Item(10).Visible = False
            DgvRecords.Columns.Item(10).HeaderText = "Delivery Charge"
            DgvRecords.Columns.Item(10).Width = "182"
            'tblDeliveries.Commission
            DgvRecords.Columns.Item(11).Visible = False
            DgvRecords.Columns.Item(11).HeaderText = "Commission"
            DgvRecords.Columns.Item(11).Width = "182"
            'tblDeliveries.GrossAmount
            DgvRecords.Columns.Item(12).Visible = False
            DgvRecords.Columns.Item(12).HeaderText = "Total Amount"
            DgvRecords.Columns.Item(12).Width = "182"
            'tblDeliveries.DeliveryDate
            DgvRecords.Columns.Item(13).Visible = True
            DgvRecords.Columns.Item(13).HeaderText = "Order Date"
            DgvRecords.Columns.Item(13).Width = "182"
            'tblDeliveries.DeliveryType
            DgvRecords.Columns.Item(14).Visible = False
            DgvRecords.Columns.Item(14).HeaderText = "Delivery Type"
            DgvRecords.Columns.Item(14).Width = "182"
            'tblDeliveries.ConfirmedDate
            DgvRecords.Columns.Item(15).Visible = False
            DgvRecords.Columns.Item(15).HeaderText = "Confirmed Date"
            DgvRecords.Columns.Item(15).Width = "182"
            'tblDeliveries.Notes
            DgvRecords.Columns.Item(16).Visible = False
            DgvRecords.Columns.Item(16).HeaderText = "Notes"
            DgvRecords.Columns.Item(16).Width = "182"
            'tblDeliveries.Invoice
            DgvRecords.Columns.Item(17).Visible = False
            DgvRecords.Columns.Item(17).HeaderText = "Invoice"
            DgvRecords.Columns.Item(17).Width = "182"
            'tblDeliveries.Shipper
            DgvRecords.Columns.Item(18).Visible = False
            DgvRecords.Columns.Item(18).HeaderText = "Shipper"
            DgvRecords.Columns.Item(18).Width = "182"
            'tblDeliveries.ShipperInvoice
            DgvRecords.Columns.Item(19).Visible = False
            DgvRecords.Columns.Item(19).HeaderText = "Shipper Invoice"
            DgvRecords.Columns.Item(19).Width = "182"
            'tblDeliveries.CreatedBy
            DgvRecords.Columns.Item(20).Visible = False
            DgvRecords.Columns.Item(20).HeaderText = "Created By"
            DgvRecords.Columns.Item(20).Width = "182"
            'tblDeliveries.CreatedDate 
            DgvRecords.Columns.Item(21).Visible = False
            DgvRecords.Columns.Item(21).HeaderText = "Created AT"
            DgvRecords.Columns.Item(21).Width = "182"
        End If
    End Sub

    Private Sub FindShopTransfer()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryShopTransferDisplayMain", Connection)
            gridDataAdapter.Fill(data, "qryShopTransferDisplayMain")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DgvRecords.DataSource = BindingSource1
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.Refresh()
            Dim dgv As New DataTable
            DgvRecords.DataSource = BindingSource1
            'tblShopTransfer.TransferID
            DgvRecords.Columns.Item(0).Visible = False
            DgvRecords.Columns.Item(0).HeaderText = "TransID Ref"
            DgvRecords.Columns.Item(0).Width = "182"
            'tblWarehouseTransfer.Reference
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "TF Note"
            DgvRecords.Columns.Item(1).Width = "182"
            'TransferDate
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Date"
            DgvRecords.Columns.Item(2).Width = "182"
            'ShopRef
            DgvRecords.Columns.Item(3).Visible = True
            DgvRecords.Columns.Item(3).HeaderText = "From Ref"
            DgvRecords.Columns.Item(3).Width = "182"
            'TotalQtyOut
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "From Shop"
            DgvRecords.Columns.Item(4).Width = "182"
            'CreatedBy
            DgvRecords.Columns.Item(9).Visible = False
            DgvRecords.Columns.Item(9).HeaderText = "Created By"
            DgvRecords.Columns.Item(9).Width = "182"
            'CreatedDate
            DgvRecords.Columns.Item(10).Visible = False
            DgvRecords.Columns.Item(10).HeaderText = "Created At"
            DgvRecords.Columns.Item(10).Width = "182"
            'ToShopRef
            DgvRecords.Columns.Item(7).Visible = True
            'DgvRecords.Columns.Item(7).HeaderText = "To Ref"
            DgvRecords.Columns.Item(7).Width = "182"
            'TotalQtyIn
            DgvRecords.Columns.Item(8).Visible = True
            DgvRecords.Columns.Item(8).HeaderText = "To Quantity"
            DgvRecords.Columns.Item(8).Width = "182"
        End If
    End Sub

    Private Sub FindShopDelivery()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryGridShopDelDisplay order by DeliveryID desc", Connection)
            gridDataAdapter.Fill(data, "qryGridShopDelDisplay")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DgvRecords.DataSource = BindingSource1
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.Refresh()
            Dim dgv As New DataTable
            DgvRecords.DataSource = BindingSource1
            'DeliveryID
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Reference"
            DgvRecords.Columns.Item(0).Width = "182"
            'ShopRef
            DgvRecords.Columns.Item(1).Visible = False
            DgvRecords.Columns.Item(1).HeaderText = "Shop Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Shop"
            DgvRecords.Columns.Item(2).Width = "182"
            'WarehouseRef
            DgvRecords.Columns.Item(3).Visible = False
            DgvRecords.Columns.Item(3).HeaderText = "Warehouse Ref"
            DgvRecords.Columns.Item(3).Width = "182"
            'WarehouseName
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Warehouse"
            DgvRecords.Columns.Item(4).Width = "182"
            'Reference
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Delivery No"
            DgvRecords.Columns.Item(5).Width = "182"
            'TotalHangers
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Quantity"
            DgvRecords.Columns.Item(6).Width = "182"
            'DeliveryDate
            DgvRecords.Columns.Item(7).Visible = True
            DgvRecords.Columns.Item(7).HeaderText = "Delivery Date"
            DgvRecords.Columns.Item(7).Width = "182"
            'DeliveryType
            DgvRecords.Columns.Item(8).Visible = False
            DgvRecords.Columns.Item(8).HeaderText = "Type"
            DgvRecords.Columns.Item(8).Width = "182"
            'ConfirmedDate
            DgvRecords.Columns.Item(9).Visible = False
            DgvRecords.Columns.Item(9).HeaderText = "Confirmed Date"
            DgvRecords.Columns.Item(0).Width = "182"
            'Notes
            DgvRecords.Columns.Item(10).Visible = True
            DgvRecords.Columns.Item(10).HeaderText = "Notes"
            DgvRecords.Columns.Item(10).Width = "182"
            'CreatedBy
            DgvRecords.Columns.Item(11).Visible = False
            DgvRecords.Columns.Item(11).HeaderText = "Created By"
            DgvRecords.Columns.Item(11).Width = "182"
            'CreatedDate
            DgvRecords.Columns.Item(12).Visible = False
            DgvRecords.Columns.Item(12).HeaderText = "Created At"
            DgvRecords.Columns.Item(12).Width = "182"
        End If
    End Sub

    Private Sub FindWarehouseAdjustment()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.menustripTextbox1.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", Connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DgvRecords.DataSource = BindingSource1
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.Refresh()
            Dim dgv As New DataTable
            DgvRecords.DataSource = BindingSource1
            'SalesID
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Sales ID"
            DgvRecords.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DgvRecords.Columns.Item(0).Width = "182"
            'ShopRef
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Shop Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Shop Name"
            DgvRecords.Columns.Item(2).Width = "182"
            'Reference
            DgvRecords.Columns.Item(3).Visible = False
            DgvRecords.Columns.Item(3).HeaderText = "Reference"
            DgvRecords.Columns.Item(3).Width = "182"
            'TransactionDate
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Date"
            DgvRecords.Columns.Item(4).Width = "182"
            'TotalQty
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Total Garments"
            DgvRecords.Columns.Item(5).Width = "182"
            'TotalValue
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Total Sales"
            DgvRecords.Columns.Item(6).Width = "182"
            'CreatedBy
            ' DgvRecords.Columns.Item(7).Visible = False
            'DgvRecords.Columns.Item(7).HeaderText = "From ID"
            'DgvRecords.Columns.Item(7).Width = "182"
            'CreatedDate
            'DgvRecords.Columns.Item(8).Visible = False
            ' DgvRecords.Columns.Item(8).HeaderText = "To ID"
            'DgvRecords.Columns.Item(8).Width = "182"
        End If
    End Sub

    Private Sub FindShopAdjustment()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.FindInput.Visible = True
            Me.menustripTextbox1.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", Connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DgvRecords.DataSource = BindingSource1
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DgvRecords.Refresh()
            Dim dgv As New DataTable
            DgvRecords.DataSource = BindingSource1
            'SalesID
            DgvRecords.Columns.Item(0).Visible = True
            DgvRecords.Columns.Item(0).HeaderText = "Sales ID"
            DgvRecords.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DgvRecords.Columns.Item(0).Width = "182"
            'ShopRef
            DgvRecords.Columns.Item(1).Visible = True
            DgvRecords.Columns.Item(1).HeaderText = "Shop Ref"
            DgvRecords.Columns.Item(1).Width = "182"
            'ShopName
            DgvRecords.Columns.Item(2).Visible = True
            DgvRecords.Columns.Item(2).HeaderText = "Shop Name"
            DgvRecords.Columns.Item(2).Width = "182"
            'Reference
            DgvRecords.Columns.Item(3).Visible = False
            DgvRecords.Columns.Item(3).HeaderText = "Reference"
            DgvRecords.Columns.Item(3).Width = "182"
            'TransactionDate
            DgvRecords.Columns.Item(4).Visible = True
            DgvRecords.Columns.Item(4).HeaderText = "Date"
            DgvRecords.Columns.Item(4).Width = "182"
            'TotalQty
            DgvRecords.Columns.Item(5).Visible = True
            DgvRecords.Columns.Item(5).HeaderText = "Total Garments"
            DgvRecords.Columns.Item(5).Width = "182"
            'TotalValue
            DgvRecords.Columns.Item(6).Visible = True
            DgvRecords.Columns.Item(6).HeaderText = "Total Sales"
            DgvRecords.Columns.Item(6).Width = "182"
            'CreatedBy
            ' DgvRecords.Columns.Item(7).Visible = False
            'DgvRecords.Columns.Item(7).HeaderText = "From ID"
            'DgvRecords.Columns.Item(7).Width = "182"
            'CreatedDate
            'DgvRecords.Columns.Item(8).Visible = False
            ' DgvRecords.Columns.Item(8).HeaderText = "To ID"
            'DgvRecords.Columns.Item(8).Width = "182"
        End If
    End Sub

    Private Sub StockUpdate()
        On Error GoTo errhand
        '  Dim selectsql As String = "SELECT * from tblStock order by StockCode"
        '  Dim stockcode As String
        '  Dim selectsales As String = "SELECT StockCode, SUM(SalesAmount / (1+(20/100)) AS SumOfSalesAmount from tblSalesLines Group By StockCode HAVING (StockCode ='" & stockcode & "')"
        'Dim selectdelivery As String = "SELECT StockCode,SUM(TotalItems) as SumOfDeliveredQty, SUM(NetAmount) AS SumOfNetAmount FROM tblDeliveries Group By StockCode HAVING (StockCode ='" & stockcode & "')"
        '        Dim pcmarkup As Decimal
        '       Dim amounttake As Decimal
        '      Dim costvalue As Decimal
        '     Dim updatestock As String = "UPDATE tblStock SET AmountTaken = @AmountTaken,DeliveredQtyHangers = @DeliveredQtyHangers, CostValue = @CostValue, PCMarkUp = @PCMarkUp Where StockCode='" & stockcode & "';"
errhand:
        ' MsgBox(Err.Description, vbCritical, Application.ProductName)
    End Sub

    Private Sub deleteShop()

        Dim conn As New SqlConnection(ConnectionString)
        Dim Delcmd As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblShops", Connection)
        griddataadpter.Fill(data, "tblshops")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(0, i).Value
        DgvRecords.DataSource = BindingSource1
        '  MessageBox.Show("Shop Record: " + CurrentID + " Has been deleted")
        Delcmd.Connection = conn
        Delcmd.Connection.Open()
        Delcmd.CommandType = CommandType.Text
        Delcmd.CommandText = "DELETE FROM tblShops WHERE ShopRef='" & CurrentID & "'"
        Delcmd.ExecuteNonQuery()
        Delcmd.Connection.Close()
        ShopsToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteSupplier()
        Dim conn As New SqlConnection(ConnectionString)
        Dim Delcmd As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblSuppliers", Connection)
        griddataadpter.Fill(data, "tblSuppliers")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(0, i).Value
        DgvRecords.DataSource = BindingSource1
        ' MessageBox.Show("Supplier Record: " + CurrentID + " Has been deleted")
        Delcmd.Connection = conn
        Delcmd.Connection.Open()
        Delcmd.CommandType = CommandType.Text
        Delcmd.CommandText = "DELETE FROM tblSuppliers WHERE SupplierRef='" & CurrentID & "'"
        Delcmd.ExecuteNonQuery()
        Delcmd.Connection.Close()
        SuppliersToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deletePurchaseOrder()
        Dim conn As New SqlConnection(ConnectionString)
        Dim deletecommand As New SqlCommand()
        Dim duplicatecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblDeliveries order by deliveryDate desc", Connection)
        griddataadpter.Fill(data, "tblDeliveries")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        Dim StockCode As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(0, i).Value
        StockCode = DgvRecords.Item(6, i).Value.ToString
        DgvRecords.DataSource = BindingSource1

        Try
            Dim queryResult As Integer
            duplicatecommand.Connection = conn
            duplicatecommand.Connection.Open()
            duplicatecommand.CommandType = CommandType.Text
            duplicatecommand.CommandText = " SELECT COUNT(*) as numRows From tblStockMovements WHERE SMstockcode = '" + StockCode + "' AND MovementType <> 'Delivery (W)'"
            queryResult = duplicatecommand.ExecuteNonQuery()
            duplicatecommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Stock Record :" + StockCode + " Has Other records Unable to delete Purchase Order ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error in database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        deletecommand.Connection = conn
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "DELETE FROM tblDeliveries WHERE DeliveriesID='" & CurrentID & "'"
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        deletecommand.Connection = conn
        deletecommand.Connection.Open()
        deletecommand.CommandType = CommandType.Text
        deletecommand.CommandText = "DELETE FROM tblStockmovements WHERE TransferReference='" & CurrentID & "' AND MovementType = 'Delivery (W)'"
        deletecommand.ExecuteNonQuery()
        deletecommand.Connection.Close()
        ' MessageBox.Show("Purchase Order " + CurrentID + " Has been deleted")
        PurchaseOrdersToolStripMenuItem.PerformClick()

    End Sub
    Private Sub deleteWarehouseAdjustments()
        Dim conn As New SqlConnection(ConnectionString)
        Dim DeleteCommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from qryWarehouseAdjustments", Connection)
        griddataadpter.Fill(data, "qryWarehouseAdjustments")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(0, i).Value
        DgvRecords.DataSource = BindingSource1
        MessageBox.Show(CurrentID)
        DeleteCommand.Connection = conn
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblStockmovements WHERE StockMovementID ='" & CurrentID & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        '   MessageBox.Show("Warehouse Adjustment " + CurrentID + " Has been deleted")
        WarehouseAdjustmentsToolStripMenuItem.PerformClick()

    End Sub
    Private Sub deleteShopDelivery()
        Dim conn As New SqlConnection(ConnectionString)
        Dim Delcmd2 As New SqlCommand()

        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblShopDeliveries", Connection)
        griddataadpter.Fill(data, "tblshopDeliveries")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        Dim DelNoteNumber As Integer
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(0, i).Value
        DgvRecords.DataSource = BindingSource1
        '  MessageBox.Show(CurrentID)
        DelNoteNumber = DgvRecords.Item(0, i).Value
        Delcmd2.Connection = Connection
        Delcmd2.Connection.Open()
        Delcmd2.CommandType = CommandType.Text
        Delcmd2.CommandText = "DELETE from tblStockMovements where TransferReference = '" + CurrentID + "' AND MovementType = 'Delivery (S)';DELETE from tblShopDeliveriesLines where SDeliveriesID = '" + CurrentID + "';DELETE from tblShopDeliveries where DeliveriesID = '" + CurrentID + "'"
        Delcmd2.ExecuteNonQuery()
        Delcmd2.Connection.Close()
        ' Delcmd2.Connection = connection
        ' Delcmd2.Connection.Open()
        ' Delcmd2.CommandType = CommandType.Text
        ' deletecommand.CommandText = ""
        ' deletecommand.ExecuteNonQuery()
        ' deletecommand.Connection.Close()
        ' deletecommand.Connection = connection
        ' deletecommand.Connection.Open()
        ' deletecommand.CommandType = CommandType.Text
        ' deletecommand.CommandText = ""
        ' deletecommand.ExecuteNonQuery()
        ' deletecommand.Connection.Close()
        ShopDeliveriesToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteShopAdjustments()
        Dim conn As New SqlConnection(ConnectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from qryShopAdjustments", Connection)
        griddataadpter.Fill(data, "qryShopAdjustments")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        'Dim reference As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(0, i).Value
        DgvRecords.DataSource = BindingSource1
        '  MessageBox.Show(CurrentID)
        Deletecommand.Connection = conn
        Deletecommand.Connection.Open()
        Deletecommand.CommandType = CommandType.Text
        Deletecommand.CommandText = "DELETE FROM tblStockmovements WHERE StockMovementID ='" & CurrentID & "'"
        Deletecommand.ExecuteNonQuery()
        Deletecommand.Connection.Close()
        '   MessageBox.Show("Shop Adjustment " + CurrentID + " Has been deleted")
        ShopAdjustmentsToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteShopSales()
        Dim conn As New SqlConnection(ConnectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblSales", Connection)
        griddataadpter.Fill(data, "tblsales")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(0, i).Value
        DgvRecords.DataSource = BindingSource1
        '  MessageBox.Show("Sales Record " + CurrentID + "Has been deleted")
        Deletecommand.CommandType = CommandType.Text
        Deletecommand.CommandText = "Delete From tblSalesLines where SalesID='" + CurrentID + "';Delete from tblStockmovements where MovementType='Sale' AND TransferReference='" + CurrentID + "';Delete from tblSales where SalesID='" + CurrentID.ToString + "';"
        Deletecommand.Connection = Connection
        Deletecommand.Connection.Close()
        Deletecommand.Connection.Open()
        Deletecommand.ExecuteNonQuery()
        Deletecommand.Connection.Close()
        SalesToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteShopTransfers()
        Dim conn As New SqlConnection(ConnectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblShopTransfers", Connection)
        griddataadpter.Fill(data, "tblshopTransfers")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(1, i).Value
        DgvRecords.DataSource = BindingSource1
        '  MessageBox.Show(CurrentID + " Has been deleted")
        Deletecommand.Connection = Connection
        Deletecommand.Connection.Open()
        Deletecommand.CommandType = CommandType.Text
        Deletecommand.CommandText = "DELETE from tblStockMovements where TransferReference = '" + CurrentID.ToString + "' AND MovementType='Shop Transfer';"
        Deletecommand.ExecuteNonQuery()
        Deletecommand.Connection.Close()
        Deletecommand.Connection = Connection
        Deletecommand.Connection.Open()
        Deletecommand.CommandType = CommandType.Text
        Deletecommand.CommandText = "DELETE from tblShopTransferLines where TransferID = '" + CurrentID.ToString + "'"
        Deletecommand.ExecuteNonQuery()
        Deletecommand.Connection.Close()
        Deletecommand.Connection = Connection
        Deletecommand.Connection.Open()
        Deletecommand.CommandType = CommandType.Text
        Deletecommand.CommandText = "DELETE from tblShopTransfers where TransferID = '" + CurrentID.ToString + "'"
        Deletecommand.ExecuteNonQuery()
        Deletecommand.Connection.Close()
        ShopTransfersToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteReturns()
        Dim conn As New SqlConnection(ConnectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from qryReturns", Connection)
        griddataadpter.Fill(data, "qryReturns")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        Dim reference As String
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(5, i).Value
        DgvRecords.DataSource = BindingSource1
        ' MessageBox.Show(CurrentID)

        reference = DgvRecords.Item(1, i).Value
        '     DateTimePicker1.Value = Main.DgvRecords.Item(9, i).Value
        Deletecommand.Connection = Connection
        Deletecommand.Connection.Open()
        Deletecommand.CommandType = CommandType.Text
        Deletecommand.CommandText = "DELETE from tblStockMovements where Reference = '" + CurrentID + "' AND MovementType = 'return'"
        Deletecommand.ExecuteNonQuery()
        Deletecommand.Connection.Close()
        Dim DeleteCommand2 As New SqlCommand
        DeleteCommand2.Connection = Connection
        DeleteCommand2.CommandType = CommandType.Text
        DeleteCommand2.CommandText = "DELETE from tblReturn where TFNote ='" + reference.ToString + "'"
        DeleteCommand2.Connection.Close()
        DeleteCommand2.Connection.Open()
        DeleteCommand2.ExecuteNonQuery()
        DeleteCommand2.Connection.Close()
        ReturnsToolStripMenuItem.PerformClick()
    End Sub
    Private Sub deleteStock()
        Dim conn As New SqlConnection(ConnectionString)
        Dim Deletecommand As New SqlCommand()
        Dim data As New DataSet()
        Dim tables As DataTableCollection = data.Tables
        Dim griddataadpter As New SqlDataAdapter("SELECT * from tblStock", Connection)
        griddataadpter.Fill(data, "tblstock")
        Dim view1 As New DataView(tables(0))
        Dim CurrentID As String
        BindingSource1.DataSource = view1
        Dim i As Integer
        i = DgvRecords.CurrentRow.Index
        CurrentID = DgvRecords.Item(0, i).Value
        DgvRecords.DataSource = BindingSource1
        MessageBox.Show(CurrentID)
        cmd.Connection = Connection
        cmd.Connection.Open()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM tblStock WHERE StockCode='" & CurrentID.ToString & "'"
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
        StockToolStripMenuItem.PerformClick()
    End Sub
    Private Sub PrintShops2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintShop", Connection)
            gridDataAdapter.Fill(data, "qryPrintShop")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryPrintShop"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.EnableHeadersVisualStyles = False
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DgvRecords.AutoResizeColumns()
            ' DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DgvRecords.Columns.Item(0).Width = 40
            DgvRecords.RowHeadersWidth = 50
            ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()

        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub PrintSuppliers2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintSuppliers", Connection)
            gridDataAdapter.Fill(data, "qryPrintSuppliers")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryPrintSuppliers"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.EnableHeadersVisualStyles = False
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DgvRecords.AutoResizeColumns()
            ' DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DgvRecords.Columns.Item(0).Width = 40
            DgvRecords.RowHeadersWidth = 50
            '    ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()
            '  PrintDocument1.Print()
            ' Dim ppd As New PrintPreviewDialog

            '   ppd.Document = PrintDocument1
            '  ppd.WindowState = FormWindowState.Maximized
            '  ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub PrintStock2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryStockvaluespc1", Connection)
            gridDataAdapter.Fill(data, "qryStockvaluespc1")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryStockvaluespc1"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.EnableHeadersVisualStyles = False
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DgvRecords.AutoResizeColumns()
            ' DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ' DgvRecords.Columns.Item(0).Width = 40
            DgvRecords.RowHeadersWidth = 50
            '  ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()
            '  PrintDocument1.Print()
            '   Dim ppd As New PrintPreviewDialog

            '  ppd.Document = PrintDocument1
            '  ppd.WindowState = FormWindowState.Maximized
            '  ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub PrintPurchase2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintPurchase", Connection)
            gridDataAdapter.Fill(data, "qryPrintPurchase")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryPrintPurchase"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.EnableHeadersVisualStyles = False
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DgvRecords.AutoResizeColumns()
            ' DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DgvRecords.Columns.Item(4).DefaultCellStyle.Format = "c"

            DgvRecords.Columns.Item(0).Width = 50
            DgvRecords.Columns.Item(3).Width = 50
            DgvRecords.RowHeadersWidth = 50
            ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()
            '  PrintDocument1.Print()
            '  Dim ppd As New PrintPreviewDialog

            '   ppd.Document = PrintDocument1
            '   ppd.WindowState = FormWindowState.Maximized
            '  ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub printShopDels2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintShopDelivery", Connection)
            gridDataAdapter.Fill(data, "qryPrintShopDelivery")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryPrintShopDelivery"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.EnableHeadersVisualStyles = False
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DgvRecords.AutoResizeColumns()
            ' DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DgvRecords.Columns.Item(0).Width = 50
            DgvRecords.Columns.Item(4).Width = 50
            DgvRecords.RowHeadersWidth = 50
            '  ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()
            '  PrintDocument1.Print()
            '  Dim ppd As New PrintPreviewDialog

            '  ppd.Document = PrintDocument1
            '  ppd.WindowState = FormWindowState.Maximized
            '  ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub PrintSalesGrid2()
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryPrintSalesGrid", Connection)
            gridDataAdapter.Fill(data, "qryPrintSalesGrid")
            DgvRecords.DataSource = data
            DgvRecords.DataMember = "qryPrintSalesGrid"
            DgvRecords.AutoGenerateColumns = True
            DgvRecords.EnableHeadersVisualStyles = False
            DgvRecords.GridColor = Color.Cornsilk
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None
            DgvRecords.BackgroundColor = Color.Black
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgvRecords.AllowUserToResizeColumns = False
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DgvRecords.AutoResizeColumns()
            ' DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DgvRecords.Columns.Item(0).Width = 40
            DgvRecords.Columns.Item(4).Width = 50
            DgvRecords.Columns.Item(1).Width = 50
            DgvRecords.RowHeadersWidth = 50
            'ToolStripStatusLabel1.Text = "Shops"
            ToolStripStatusLabel2.Text = DgvRecords.Rows.Count
            Connection.Close()
            '  PrintDocument1.Print()
            '   Dim ppd As New PrintPreviewDialog

            '  ppd.Document = PrintDocument1
            '  ppd.WindowState = FormWindowState.Maximized
            '   ppd.ShowDialog()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)

        End Try
    End Sub
    Private Sub printShops()
        FPrint.Text = "Print Shop Grid"
        FPrint.Show()
    End Sub
    Private Sub printSuppliers()
        FPrint.Text = "Print Suppliers Grid"
        FPrint.Show()
    End Sub
    Private Sub printStock()
        FPrint.Text = "Print Stock Grid"
        FPrint.Show()
    End Sub
    Private Sub printPurchase()
        FPrint.Text = "Print Purchase Order Grid"
        FPrint.Show()
    End Sub
    Private Sub printShopDels()
        FPrint.Text = "Print Shop Deliveries Grid"
        FPrint.Show()
    End Sub
    Private Sub printSales()
        FPrint.Text = "Print Shop Sales Grid"
        FPrint.Show()
    End Sub
End Class