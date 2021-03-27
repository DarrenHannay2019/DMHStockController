Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class Form1
    Dim ConnectionString As String = "Initial Catalog=DMHStockv1;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim Connection As New SqlConnection(ConnectionString)
    Dim Cmd As SqlCommand

    Private Sub WarehouseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseToolStripMenuItem.Click
        LoadWarehouse()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppliersToolStripMenuItem.Click
        LoadSuppliers()
    End Sub

    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click
        LoadStock()
    End Sub

    Private Sub SeasonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeasonToolStripMenuItem.Click
        LoadSeason()
    End Sub

    Private Sub ShopsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopsToolStripMenuItem.Click
        LoadShop()
    End Sub

    Private Sub WarehouseAdjustmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseAdjustmentToolStripMenuItem.Click
        LoadWarehouseAdjustment()
    End Sub

    Private Sub DeliveriesIntoShopsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveriesIntoShopsToolStripMenuItem.Click
        LoadShopDel()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        LoadSales()
    End Sub

    Private Sub RefundsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefundsToolStripMenuItem.Click
        LoadRefunds()
    End Sub

    Private Sub ShopAdjustmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopAdjustmentsToolStripMenuItem.Click
        LoadShopAdjustment()
    End Sub

    Private Sub ShopTransfersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopTransfersToolStripMenuItem.Click
        LoadShopTrans()
    End Sub

    Private Sub ReturnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnsToolStripMenuItem.Click
        LoadReturns()
    End Sub

    Private Sub UserProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserProfileToolStripMenuItem.Click
        LoadUserProfile()
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        LoadEmployees()
    End Sub

    Private Sub PurgeRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurgeRecordsToolStripMenuItem.Click

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        FChgPwd.ShowDialog()
    End Sub

    Private Sub ShowAllStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllStockToolStripMenuItem.Click

    End Sub

    Private Sub AllStockMovementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllStockMovementsToolStripMenuItem.Click

    End Sub

    Private Sub DeliveriesByStockCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveriesByStockCodeToolStripMenuItem.Click

    End Sub

    Private Sub StockListByBranchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockListByBranchToolStripMenuItem.Click

    End Sub

    Private Sub StockListByStockCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockListByStockCodeToolStripMenuItem.Click

    End Sub

    Private Sub WarehouseStockListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseStockListToolStripMenuItem.Click

    End Sub

    Private Sub TotalStockValuationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalStockValuationToolStripMenuItem.Click

    End Sub

    Private Sub SalesHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesHistoryToolStripMenuItem.Click

    End Sub

    Private Sub SalesAnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesAnalysisToolStripMenuItem.Click

    End Sub

    Private Sub WarehouseTransfersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseTransfersToolStripMenuItem.Click

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' DataGridView1.RowHeadersWidth = CInt(DataGridView1.RowHeadersWidth * 1.35)
        ShowAllStockToolStripMenuItem.Visible = False
        If FLoginForm.UsernameTextBox.Text <> "admin" Or FLoginForm.UsernameTextBox.Text <> "test" Then userSetup()
        If FLoginForm.UsernameTextBox.Text = "admin" Then adminsetup()
        If FLoginForm.UsernameTextBox.Text = "test" Then develsetup()
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        txtMode.Text = "NEW"
        If txtOption.Text = "Shops" Then ShopsEntry.Show()
        If txtOption.Text = "Seasons" Then Seasons.Show()
        If txtOption.Text = "Profile" Then Profile.Show()
        If txtOption.Text = "Suppliers" Then SuppliersEntry.Show()
        If txtOption.Text = "Warehouses" Then Warehouse.Show()
        If txtOption.Text = "Shop Transfers" Then ShopTransfers.Show()
        If txtOption.Text = "Purchase Order" Then DeliveriesIn.Show()
        If txtOption.Text = "Stock" Then Stock.Show()
        If txtOption.Text = "Warehouse Transfers" Then WarehouseTransfer.Show()
        If txtOption.Text = "Warehouse Adjustments" Then WarehouseAdjustments.Show()
        If txtOption.Text = "Shop deliveries" Then ShopDeliveries.Show()
        If txtOption.Text = "Sales" Then Sales.Show()
        If txtOption.Text = "Refunds" Then Refunds.Show()
        If txtOption.Text = "Shop Adjustments" Then ShopAdjustments.Show()
        If txtOption.Text = "Returns" Then Returns.Show()
        If txtOption.Text = "Employee" Then Employee.Show()
    End Sub

    Private Sub RecordToolStripButton_Click(sender As Object, e As EventArgs) Handles RecordToolStripButton.Click
        'If DataGridView1.SelectedRows = False Or DataGridView1.SelectedCells = False Then MsgBox("Please Select a row to view", MsgBoxStyle.Information, Application.ProductName)
        txtMode.Text = "OLD"
        If txtOption.Text = "Shops" Then ShopsEntry.Show()
        If txtOption.Text = "Seasons" Then Seasons.Show()
        If txtOption.Text = "Profile" Then Profile.Show()
        If txtOption.Text = "Suppliers" Then SuppliersEntry.Show()
        If txtOption.Text = "Warehouses" Then Warehouse.Show()
        If txtOption.Text = "Shop Transfers" Then ShopTransfers.Show()
        If txtOption.Text = "Purchase Order" Then DeliveriesIn.Show()
        If txtOption.Text = "Stock" Then Stock.Show()
        If txtOption.Text = "Warehouse Transfers" Then WarehouseTransfer.Show()
        If txtOption.Text = "Warehouse Adjustments" Then WarehouseAdjustments.Show()
        If txtOption.Text = "Shop deliveries" Then ShopDeliveries.Show()
        If txtOption.Text = "Sales" Then Sales.Show()
        If txtOption.Text = "Refunds" Then Refunds.Show()
        If txtOption.Text = "Shop Adjustments" Then ShopAdjustments.Show()
        If txtOption.Text = "Returns" Then Returns.Show()
        If txtOption.Text = "Employee" Then Employee.Show()
    End Sub

    Private Sub DeleteToolStripButton_Click(sender As Object, e As EventArgs) Handles DeleteToolStripButton.Click
        txtMode.Text = "DELETE"
        If txtOption.Text = "Shops" Then ShopsEntry.Show()
        If txtOption.Text = "Seasons" Then Seasons.Show()
        If txtOption.Text = "Profile" Then Profile.Show()
        If txtOption.Text = "Suppliers" Then SuppliersEntry.Show()
        If txtOption.Text = "Warehouses" Then Warehouse.Show()
        If txtOption.Text = "Shop Transfers" Then ShopTransfers.Show()
        If txtOption.Text = "Purchase Order" Then DeliveriesIn.Show()
        If txtOption.Text = "Stock" Then Stock.Show()
        If txtOption.Text = "Warehouse Transfers" Then WarehouseTransfer.Show()
        If txtOption.Text = "Warehouse Adjustments" Then WarehouseAdjustments.Show()
        If txtOption.Text = "Shop deliveries" Then ShopDeliveries.Show()
        If txtOption.Text = "Sales" Then Sales.Show()
        If txtOption.Text = "Refunds" Then Refunds.Show()
        If txtOption.Text = "Shop Adjustments" Then ShopAdjustments.Show()
        If txtOption.Text = "Returns" Then Returns.Show()
        If txtOption.Text = "Employee" Then Employee.Show()
    End Sub

    Private Sub RefreshToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshToolStripButton.Click
        If txtOption.Text = "Shops" Then ShopsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Seasons" Then SeasonToolStripMenuItem.PerformClick()
        If txtOption.Text = "Profile" Then UserProfileToolStripMenuItem.PerformClick()
        If txtOption.Text = "Suppliers" Then SuppliersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Warehouses" Then WarehouseToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop Transfers" Then ShopTransfersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Purchase Order" Then PurchaseOrdersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Stock" Then StockToolStripMenuItem.PerformClick()
        If txtOption.Text = "Warehouse Transfers" Then WarehouseTransfersToolStripMenuItem.PerformClick()
        If txtOption.Text = "Warehouse Adjustments" Then WarehouseAdjustmentToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop deliveries" Then DeliveriesIntoShopsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Sales" Then SalesToolStripMenuItem.PerformClick()
        If txtOption.Text = "Refunds" Then RefundsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Shop Adjustments" Then ShopAdjustmentsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Returns" Then ReturnsToolStripMenuItem.PerformClick()
        If txtOption.Text = "Employee" Then EmployeeToolStripMenuItem.PerformClick()
    End Sub

    Private Sub FindToolStripButton_Click(sender As Object, e As EventArgs) Handles FindToolStripButton.Click

    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click

    End Sub

    Private Sub ProveToolStripButton_Click(sender As Object, e As EventArgs) Handles ProveToolStripButton.Click

    End Sub

    Private Sub TransferToolStripButton_Click(sender As Object, e As EventArgs) Handles TransferToolStripButton.Click

    End Sub

    Private Sub CloseToolStripButton_Click(sender As Object, e As EventArgs) Handles CloseToolStripButton.Click
        Close()
    End Sub

    Private Sub AboutToolStripButton_Click(sender As Object, e As EventArgs) Handles AboutToolStripButton.Click
        FAboutBox.ShowDialog()
    End Sub

    Private Sub PurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseOrdersToolStripMenuItem.Click
        LoadPurchaseOrders()
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintDocument1.Print()
    End Sub

    Private Sub FindInput_TextChanged(sender As Object, e As EventArgs) Handles FindInput.TextChanged
        If txtOption.Text = "Shops" Then Find_Shop() '1
        If txtOption.Text = "Seasons" Then Find_Season()
        If txtOption.Text = "Profile" Then Find_Profile()
        If txtOption.Text = "Suppliers" Then Find_Suppliers() '2
        If txtOption.Text = "Warehouses" Then Find_Warehouse()
        If txtOption.Text = "Shop Transfers" Then Find_Shop_Transfer() '7
        If txtOption.Text = "Purchase Order" Then Find_Purchase_Order() '4
        If txtOption.Text = "Stock" Then Find_Stock() ' 3
        If txtOption.Text = "Warehouse Transfers" Then Find_Warehouse_Transfer()
        If txtOption.Text = "Warehouse Adjustments" Then Find_Warehouse_Adjustment()
        If txtOption.Text = "Shop deliveries" Then Find_Shop_Delivery()
        If txtOption.Text = "Sales" Then Find_Sales()
        If txtOption.Text = "Refunds" Then Find_Refunds()
        If txtOption.Text = "Shop Adjustments" Then Find_Shop_Adjustment()
        If txtOption.Text = "Returns" Then Find_Returns()
        If txtOption.Text = "Employee" Then Find_Employee()
    End Sub

    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure

    Private pages As Dictionary(Of Integer, pageDetails)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer

    Private Sub develsetup()
        UserNameToolStripMenuItem.Visible = True
        txtMode.Visible = True
        txtOption.Visible = True
        ToolStripTextBox1.Visible = True
        PurgeRecordsToolStripMenuItem.Visible = True
        WarehouseToolStripMenuItem.Visible = True
    End Sub

    Private Sub adminsetup()
        txtMode.Visible = False
        txtOption.Visible = False
        ToolStripTextBox1.Visible = False
        PrintToolStripButton.Visible = False
        PurgeRecordsToolStripMenuItem.Visible = True
        UserNameToolStripMenuItem.Visible = False
        WarehouseToolStripMenuItem.Visible = True
        WarehouseTransfersToolStripMenuItem.Visible = True
        FindInput.Visible = False
        ToolStripTextBox2.Visible = False
    End Sub

    Private Sub userSetup()
        txtMode.Visible = False
        txtOption.Visible = False
        ToolStripTextBox1.Visible = False
        PurgeRecordsToolStripMenuItem.Visible = False
        UserNameToolStripMenuItem.Visible = False
        WarehouseToolStripMenuItem.Visible = False
        WarehouseTransfersToolStripMenuItem.Visible = False
        RefundsToolStripMenuItem.Visible = False
        PrintToolStripButton.Visible = False
        FindInput.Visible = False
        ToolStripTextBox2.Visible = False
        SeasonToolStripMenuItem.Visible = False
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        ''this removes the printed page margins
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)
        PrintDocument1.DefaultPageSettings.Landscape = True
        Dim xCustomSize As New PaperSize("A4", 3580, 2480)
        PrintDocument1.DefaultPageSettings.PaperSize = xCustomSize
        pages = New Dictionary(Of Integer, pageDetails)
        Dim maxWidth As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 2
        Dim maxHeight As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 4 + Label1.Height
        Dim pageCounter As Integer = 0
        pages.Add(pageCounter, New pageDetails)
        Dim columnCounter As Integer = 0
        Dim columnSum As Integer = DataGridView1.RowHeadersWidth
        For c As Integer = 0 To DataGridView1.Columns.Count - 1
            If columnSum + DataGridView1.Columns(c).Width < maxWidth Then
                columnSum += DataGridView1.Columns(c).Width
                columnCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                columnSum = DataGridView1.RowHeadersWidth + DataGridView1.Columns(c).Width
                columnCounter = 1
                pageCounter += 1
                pages.Add(pageCounter, New pageDetails With {.startCol = c})
            End If
            If c = DataGridView1.Columns.Count - 1 Then
                If pages(pageCounter).columns = 0 Then
                    pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                End If
            End If
        Next
        maxPagesWide = pages.Keys.Max + 1
        pageCounter = 0
        Dim rowCounter As Integer = 0
        Dim rowSum As Integer = DataGridView1.ColumnHeadersHeight
        For r As Integer = 0 To DataGridView1.Rows.Count - 2
            If rowSum + DataGridView1.Rows(r).Height < maxHeight Then
                rowSum += DataGridView1.Rows(r).Height
                rowCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow}
                For x As Integer = 1 To maxPagesWide - 1
                    pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow}
                Next
                pageCounter += maxPagesWide
                For x As Integer = 0 To maxPagesWide - 1
                    pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = r})
                Next
                rowSum = DataGridView1.ColumnHeadersHeight + DataGridView1.Rows(r).Height
                rowCounter = 1
            End If
            If r = DataGridView1.Rows.Count - 2 Then
                For x As Integer = 0 To maxPagesWide - 1
                    If pages(pageCounter + x).rows = 0 Then
                        pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow}
                    End If
                Next
            End If
        Next
        maxPagesTall = pages.Count \ maxPagesWide
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim rect As New Rectangle(20, 20, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Label1.Height)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString(Label1.Text, Label1.Font, Brushes.Black, rect, sf)
        sf.Alignment = StringAlignment.Near
        Dim startX As Integer = 50
        Dim startY As Integer = rect.Bottom
        Static startPage As Integer = 0
        For p As Integer = startPage To pages.Count - 1
            Dim cell As New Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.ColumnHeadersHeight)
            e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            e.Graphics.DrawRectangle(Pens.Black, cell)
            startY += DataGridView1.ColumnHeadersHeight
            For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                cell = New Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.Rows(r).Height)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)
                e.Graphics.DrawString(DataGridView1.Rows(r).HeaderCell.Value, DataGridView1.Font, Brushes.Black, cell, sf)
                startY += DataGridView1.Rows(r).Height
            Next
            startX += cell.Width
            startY = rect.Bottom
            For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.ColumnHeadersHeight)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)
                e.Graphics.DrawString(DataGridView1.Columns(c).HeaderCell.Value, DataGridView1.Font, Brushes.Black, cell, sf)
                startX += DataGridView1.Columns(c).Width
            Next
            startY = rect.Bottom + DataGridView1.ColumnHeadersHeight
            For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                startX = 50 + DataGridView1.RowHeadersWidth
                For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                    cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.Rows(r).Height)
                    e.Graphics.DrawRectangle(Pens.Black, cell)
                    e.Graphics.DrawString(DataGridView1(c, r).Value.ToString, DataGridView1.Font, Brushes.Black, cell, sf)
                    startX += DataGridView1.Columns(c).Width
                Next
                startY += DataGridView1.Rows(r).Height
            Next
            If p <> pages.Count - 1 Then
                startPage = p + 1
                e.HasMorePages = True
                Return
            Else
                startPage = 0
            End If
        Next
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
        ShowAllStockToolStripMenuItem.Visible = True
        Try

            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryStockSales ", Connection)
            gridDataAdapter.Fill(data, "qryStockSales")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryStockSales"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Text = "DMH Stock Master v2 [Stock]"
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockCode
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(0).Width = "20"
            'SupplierRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(1).Width = "10"
            'Dead Code
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Dead Code"
            DataGridView1.Columns.Item(2).Width = "30"
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Amount Taken"
            DataGridView1.Columns.Item(3).Width = "10"
            DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            DataGridView1.Columns.Item(4).Visible = False
            DataGridView1.Columns.Item(4).Width = "10"
            'CostValue
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Cost Value"
            DataGridView1.Columns.Item(5).Width = "12"
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DataGridView1.Columns.Item(6).HeaderText = "Markup"
            DataGridView1.Columns.Item(6).Width = "12"
            DataGridView1.Columns.Item(6).DefaultCellStyle.Format = "p"
            'ZeroQty
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Zero Qty"
            DataGridView1.Columns.Item(7).DefaultCellStyle.Format = "Yes/No"
            'Stock.CreatedBy
            DataGridView1.Columns.Item(8).HeaderText = "Created By"
            DataGridView1.Columns.Item(8).Width = "12"
            'Stock.CreatedDate
            DataGridView1.Columns.Item(9).HeaderText = "Created At"
            DataGridView1.Columns.Item(9).Width = "12"
            DataGridView1.Columns.Item(9).DefaultCellStyle.Format = "dd/MM/yyyy"
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
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblStock ", Connection)
            gridDataAdapter.Fill(data, "tblStock")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblStock"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Text = "DMH Stock Master v2 [Stock]"
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockCode
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(0).Width = "20"
            'SupplierRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(1).Width = "10"
            'Dead Code
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Dead Code"
            DataGridView1.Columns.Item(2).Width = "30"
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Amount Taken"
            DataGridView1.Columns.Item(3).Width = "10"
            DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            DataGridView1.Columns.Item(4).Visible = False
            DataGridView1.Columns.Item(4).Width = "10"
            'CostValue
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Cost Value"
            DataGridView1.Columns.Item(5).Width = "12"
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DataGridView1.Columns.Item(6).HeaderText = "Markup"
            DataGridView1.Columns.Item(6).Width = "12"
            DataGridView1.Columns.Item(6).DefaultCellStyle.Format = "p"
            'ZeroQty
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Zero Qty"
            DataGridView1.Columns.Item(7).DefaultCellStyle.Format = "Yes/No"
            'Stock.CreatedBy
            DataGridView1.Columns.Item(8).HeaderText = "Created By"
            DataGridView1.Columns.Item(8).Width = "12"
            'Stock.CreatedDate
            DataGridView1.Columns.Item(9).HeaderText = "Created At"
            DataGridView1.Columns.Item(9).Width = "12"
            DataGridView1.Columns.Item(9).DefaultCellStyle.Format = "dd/MM/yyyy"
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
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
        Me.Text = "DMH Stock Master v2 [Shops]"
        txtOption.Text = "Shops"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShops", Connection)
            gridDataAdapter.Fill(data, "tblShops")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblShops"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'ShopRef
            DataGridView1.Columns.Item(0).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(1).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(1).Width = "182"
            'Shop.Address1
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Address"
            DataGridView1.Columns.Item(2).Width = "182"
            'Shop.Address2
            DataGridView1.Columns.Item(3).Visible = False
            'Shop.Address3
            DataGridView1.Columns.Item(4).Visible = False
            'Shop.Address4
            DataGridView1.Columns.Item(5).Visible = False
            'Shop.PostCode
            DataGridView1.Columns.Item(6).Visible = False
            'Shop.ContactName
            DataGridView1.Columns.Item(7).Visible = False
            DataGridView1.Columns.Item(8).Width = "182"
            'Shop.Telephone
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Telephone"
            DataGridView1.Columns.Item(9).Width = "182"
            'Shop.Telephone2
            DataGridView1.Columns.Item(9).Visible = False
            'Shop.Fax
            DataGridView1.Columns.Item(10).Visible = False
            'Shop.eMail
            DataGridView1.Columns.Item(11).Visible = False
            'Shop.ShopType
            DataGridView1.Columns.Item(12).HeaderText = "Type"
            DataGridView1.Columns.Item(14).Width = "182"
            'Shop.CreatedBy
            DataGridView1.Columns.Item(13).HeaderText = "Created By"
            'Shop.CreatedDate
            DataGridView1.Columns.Item(14).HeaderText = "Created At"
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadSeason()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        'Me.Text = "DMH Stock Master v2 [Returns]"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSeasons", Connection)
            gridDataAdapter.Fill(data, "tblSeasons")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblSeasons"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Season ID"
            DataGridView1.Columns.Item(1).HeaderText = "Season Name"
            DataGridView1.Columns.Item(1).Width = "322"
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadUserProfile()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [User Profiles]"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblProfile", Connection)
            gridDataAdapter.Fill(data, "tblProfile")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblProfile"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(1).HeaderText = "Description"
            DataGridView1.Columns.Item(1).Width = "822"
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
        '  Me.Text = "Suppliers"
        Me.Text = "DMH Stock Master v2 [Suppliers]"
        txtOption.Text = "Suppliers"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSuppliers", Connection)
            gridDataAdapter.Fill(data, "tblSuppliers")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblSuppliers"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'SupplierRef
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(0).Width = "182"
            'SupplierName
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Name"
            DataGridView1.Columns.Item(1).Width = "182"
            'Supplier.Address1
            DataGridView1.Columns.Item(2).HeaderText = "Address"
            DataGridView1.Columns.Item(2).Width = "182"
            'Supplier.Address2
            DataGridView1.Columns.Item(3).Visible = False
            'Supplier.Address3
            DataGridView1.Columns.Item(4).Visible = False
            'Supplier.Address4
            DataGridView1.Columns.Item(5).Visible = False
            'Supplier.PostCode
            DataGridView1.Columns.Item(6).Visible = False
            'Supplier.ContactName
            DataGridView1.Columns.Item(7).HeaderText = "Contact Name"
            DataGridView1.Columns.Item(7).Width = "182"
            'Supplier.Telephone
            DataGridView1.Columns.Item(8).HeaderText = "Telephone"
            DataGridView1.Columns.Item(8).Width = "182"
            'Supplier.Telephone2
            DataGridView1.Columns.Item(9).Visible = False
            'Supplier.Fax
            DataGridView1.Columns.Item(10).Visible = False
            'Supplier.eMail
            DataGridView1.Columns.Item(11).Visible = False
            'Supplier.memo
            DataGridView1.Columns.Item(12).Visible = False
            'Supplier.CreatedBy
            DataGridView1.Columns.Item(13).HeaderText = "Created By"
            DataGridView1.Columns.Item(13).Width = "182"
            'Supplier.CreatedDate
            DataGridView1.Columns.Item(14).HeaderText = "Created At"
            DataGridView1.Columns.Item(14).Width = "182"
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadWarehouse()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        '  Me.Text = "Warehouses"
        Me.Text = "DMH Stock Master v2 [Warehouses]"
        txtOption.Text = "Warehouses"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblWarehouses", Connection)
            gridDataAdapter.Fill(data, "tblWarehouses")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblWarehouses"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'WarehouseRef
            ' DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Warehouse Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'WarehouseName
            DataGridView1.Columns.Item(2).HeaderText = "Warehouse Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Warehouse.Address1
            DataGridView1.Columns.Item(3).HeaderText = "Address"
            DataGridView1.Columns.Item(3).Width = "182"
            'Warehouse.Address2
            DataGridView1.Columns.Item(4).Visible = False
            'Warehouse.Address3
            DataGridView1.Columns.Item(5).Visible = False
            'Warehouse.Address4
            DataGridView1.Columns.Item(6).Visible = False
            'Warehouse.PostCode
            DataGridView1.Columns.Item(7).Visible = False
            'Warehouse.ContactName
            DataGridView1.Columns.Item(8).HeaderText = "Contact Name"
            DataGridView1.Columns.Item(8).Width = "182"
            'Warehouse.Telephone
            DataGridView1.Columns.Item(9).HeaderText = "Telephone"
            DataGridView1.Columns.Item(9).Width = "182"
            'Warehouse.Telephone2
            DataGridView1.Columns.Item(10).Visible = False
            'Warehouse.Fax
            DataGridView1.Columns.Item(11).Visible = False
            'Warehouse.eMail
            DataGridView1.Columns.Item(12).Visible = False
            'Warehouse.memo
            DataGridView1.Columns.Item(13).Visible = False
            'Warehouse.WarehouseType
            DataGridView1.Columns.Item(14).HeaderText = "Type"
            DataGridView1.Columns.Item(14).Width = "182"
            'Warehouse.Default
            DataGridView1.Columns.Item(15).Visible = False
            DataGridView1.Columns.Item(15).HeaderText = "Default"
            DataGridView1.Columns.Item(15).Width = "182"
            'Warehouse.CreatedBy
            'DataGridView1.Columns.Item(16).HeaderText = "Created By"
            ' DataGridView1.Columns.Item(16).Width = "182"
            'Warehouse.CreatedDate
            '  DataGridView1.Columns.Item(17).HeaderText = "Created At"
            ' DataGridView1.Columns.Item(17).Width = "182"
            Connection.Close()
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
        'Me.Text = "Shop Transfers"
        Me.Text = "DMH Stock Master v2 [Shop Transfers]"
        txtOption.Text = "Shop Transfers"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShopTransfers", Connection)
            gridDataAdapter.Fill(data, "tblShopTransfers")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblShopTransfers"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'TransferID
            DataGridView1.Columns.Item(0).Visible = False
            'Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "TF Note"
            DataGridView1.Columns.Item(1).Width = "100"
            'From Shop
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Date"
            DataGridView1.Columns.Item(2).Width = "100"
            'To Shop
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "From Shop Ref"
            DataGridView1.Columns.Item(3).Width = "100"
            'From Quantity
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "From Shop Name"
            DataGridView1.Columns.Item(4).Width = "200"
            'Movement Date
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "To Shop Ref"
            DataGridView1.Columns.Item(5).Width = "100"
            'Transfer Reference
            'DataGridView1.Columns.Item(6).Visible = False
            DataGridView1.Columns.Item(6).HeaderText = "To Shop Name"
            DataGridView1.Columns.Item(6).Width = "182"
            'From Shop Ref
            DataGridView1.Columns.Item(6).Visible = False
            DataGridView1.Columns.Item(6).HeaderText = "From Shop Ref"
            DataGridView1.Columns.Item(6).Width = "182"
            'ToShopRef
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "From Quantity"
            DataGridView1.Columns.Item(7).Width = "182"
            'TotalQtyIn
            DataGridView1.Columns.Item(8).Visible = True
            DataGridView1.Columns.Item(8).HeaderText = "To Quantity"
            DataGridView1.Columns.Item(8).Width = "182"
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(10).Visible = False
            Connection.Close()
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
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * FROM tblDeliveries", Connection)
            gridDataAdapter.Fill(data, "tblDeliveries")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblDeliveries"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.Columns(0).HeaderText = "Delivery ID"
            DataGridView1.Columns(1).HeaderText = "Our Ref"
            DataGridView1.Columns(2).HeaderText = "Supplier Ref"
            DataGridView1.Columns(3).HeaderText = "Supplier Name"
            DataGridView1.Columns(4).HeaderText = "Location Ref"
            DataGridView1.Columns(5).HeaderText = "Location Name"
            DataGridView1.Columns(6).HeaderText = "Stock Code"
            DataGridView1.Columns(7).HeaderText = "Total items"
            DataGridView1.Columns(11).HeaderText = "Total Amount"
            DataGridView1.Columns.Item(11).DefaultCellStyle.Format = "c"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DataGridView1.Columns(7).Visible = True
            DataGridView1.Columns(8).Visible = False
            DataGridView1.Columns(9).Visible = False
            DataGridView1.Columns(10).Visible = False
            DataGridView1.Columns(12).Visible = False
            DataGridView1.Columns(13).Visible = False
            DataGridView1.Columns(14).Visible = False
            DataGridView1.Columns(15).HeaderText = "Delivery Date"
            DataGridView1.Columns(16).HeaderText = "Created By"
            DataGridView1.Columns(17).HeaderText = "Date Created"
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadWarehouseTrans()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Stock]"
        txtOption.Text = "Warehouse Transfers"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblWarehouseTransfer", Connection)
            gridDataAdapter.Fill(data, "tblWarehouseTransfer")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblWarehouseTransfer"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'tblWarehouseTransfer.UniqueID
            DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(0).HeaderText = "TransID Ref"
            DataGridView1.Columns.Item(0).Width = "182"
            'tblWarehouseTransfer.Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Reference"
            DataGridView1.Columns.Item(1).Width = "182"
            'FromWHID
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "From Warehouse"
            DataGridView1.Columns.Item(2).Width = "182"
            'ToWHID
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "To Warehouse"
            DataGridView1.Columns.Item(3).Width = "182"
            'StockCode
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(4).Width = "182"
            'FromQtyHangers
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Qty / Value"
            DataGridView1.Columns.Item(5).Width = "182"
            'FromQtyBoxes
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Qty Boxes"
            DataGridView1.Columns.Item(6).Width = "182"
            'ToQtyHangers
            DataGridView1.Columns.Item(7).Visible = False
            DataGridView1.Columns.Item(7).HeaderText = "To Qty Hangers"
            DataGridView1.Columns.Item(7).Width = "182"
            'ToQtyBoxes
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "To Qty Boxes"
            DataGridView1.Columns.Item(8).Width = "182"
            'ToActual
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "To Actual"
            DataGridView1.Columns.Item(9).Width = "182"
            'MovementDate
            DataGridView1.Columns.Item(10).Visible = True
            DataGridView1.Columns.Item(10).HeaderText = "Date"
            DataGridView1.Columns.Item(10).Width = "182"
            'DeliveryID
            DataGridView1.Columns.Item(11).Visible = False
            DataGridView1.Columns.Item(11).HeaderText = "Delivery ID"
            DataGridView1.Columns.Item(11).Width = "182"
            'FromID
            DataGridView1.Columns.Item(12).Visible = False
            DataGridView1.Columns.Item(12).HeaderText = "From ID"
            DataGridView1.Columns.Item(12).Width = "182"
            'ToID
            DataGridView1.Columns.Item(13).Visible = False
            DataGridView1.Columns.Item(13).HeaderText = "To ID"
            DataGridView1.Columns.Item(13).Width = "182"
            Connection.Close()
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
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryWarehouseAdjustments", Connection)
            gridDataAdapter.Fill(data, "qryWarehouseAdjustments")
            Connection.Open()
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryWarehouseAdjustments"
            DataGridView1.AutoGenerateColumns = True
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'StockmovementID
            DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(0).HeaderText = "Stocmovement ID"
            DataGridView1.Columns.Item(0).Width = "182"
            'Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Reference"
            DataGridView1.Columns.Item(1).Width = "182"
            'Location
            DataGridView1.Columns.Item(2).Visible = False
            DataGridView1.Columns.Item(2).HeaderText = "Date"
            DataGridView1.Columns.Item(2).Width = "182"
            'WarehouseName
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Warehouse Name"
            DataGridView1.Columns.Item(3).Width = "182"
            'StockCode
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(4).Width = "182"
            'Type
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Type"
            DataGridView1.Columns.Item(5).Width = "182"
            'Qty
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Qty"
            DataGridView1.Columns.Item(6).Width = "182"
            ' MovementDate
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Date"
            DataGridView1.Columns.Item(7).Width = "182"
            Connection.Close()
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
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblShopDeliveries", Connection)
            gridDataAdapter.Fill(data, "tblShopDeliveries")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblShopDeliveries"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'DeliveryID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Reference"
            DataGridView1.Columns.Item(0).Width = "182"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "000000"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = False
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop"
            DataGridView1.Columns.Item(2).Width = "182"
            'WarehouseRef
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Warehouse Ref"
            DataGridView1.Columns.Item(3).Width = "182"
            'WarehouseName
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Warehouse"
            DataGridView1.Columns.Item(4).Width = "182"
            'Reference
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Delivery No"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalHangers
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Quantity"
            DataGridView1.Columns.Item(6).Width = "182"
            'DeliveryDate
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Delivery Date"
            DataGridView1.Columns.Item(7).Width = "182"
            'DeliveryType
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "Created By"
            DataGridView1.Columns.Item(8).Width = "182"
            'ConfirmedDate
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Created Date"
            DataGridView1.Columns.Item(0).Width = "182"
            'Notes
            DataGridView1.Columns.Item(10).Visible = True
            DataGridView1.Columns.Item(10).HeaderText = "Notes"
            DataGridView1.Columns.Item(10).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(11).Visible = False
            DataGridView1.Columns.Item(11).HeaderText = "Created By"
            DataGridView1.Columns.Item(11).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(12).Visible = False
            DataGridView1.Columns.Item(12).HeaderText = "Created At"
            DataGridView1.Columns.Item(12).Width = "182"
            Connection.Close()
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
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblSales", Connection)
            gridDataAdapter.Fill(data, "tblSales")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblSales"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Sales ID"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Reference"
            DataGridView1.Columns.Item(3).Width = "182"
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).Width = "182"
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Sales"
            DataGridView1.Columns.Item(6).Width = "182"
            DataGridView1.Columns.Item(6).DefaultCellStyle.Format = "c"
            'CreatedBy
            DataGridView1.Columns.Item(7).Visible = False
            DataGridView1.Columns.Item(7).HeaderText = "From ID"
            DataGridView1.Columns.Item(7).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "To ID"
            DataGridView1.Columns.Item(8).Width = "182"
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadRefunds()
        txtOption.Text = "Refunds"
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Refunds]"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryRefunds", Connection)
            gridDataAdapter.Fill(data, "qryRefunds")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryRefunds"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Refunds ID"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Reference"
            DataGridView1.Columns.Item(3).Width = "182"
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).Width = "182"
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Value"
            DataGridView1.Columns.Item(6).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(7).Visible = False
            DataGridView1.Columns.Item(7).HeaderText = "From ID"
            DataGridView1.Columns.Item(7).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "To ID"
            DataGridView1.Columns.Item(8).Width = "182"
            Connection.Close()
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
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryShopAdjustments", Connection)
            gridDataAdapter.Fill(data, "qryShopAdjustments")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "qryShopAdjustments"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'StockmovementID
            DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(0).HeaderText = "Stocmovement ID"
            DataGridView1.Columns.Item(0).Width = "182"
            'Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Reference"
            DataGridView1.Columns.Item(1).Width = "182"
            'Location
            DataGridView1.Columns.Item(2).Visible = False
            DataGridView1.Columns.Item(2).HeaderText = "Date"
            DataGridView1.Columns.Item(2).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(3).Width = "182"
            'StockCode
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(4).Width = "182"
            'Type
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Type"
            DataGridView1.Columns.Item(5).Width = "182"
            'Qty
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Qty"
            DataGridView1.Columns.Item(6).Width = "182"
            ' MovementDate
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Date"
            DataGridView1.Columns.Item(7).Width = "182"
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
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblReturn order by CreatedDate Desc", Connection)
            gridDataAdapter.Fill(data, "tblReturn")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblReturn"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'TransferReference
            DataGridView1.Columns.Item(0).Visible = False
            'FromID
            DataGridView1.Columns.Item(2).Visible = False
            'Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Reference"
            DataGridView1.Columns.Item(1).Width = "182"
            'ToID
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(4).Visible = True
            'FromShop
            DataGridView1.Columns.Item(4).HeaderText = "From Shop Name"
            DataGridView1.Columns.Item(4).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(5).Visible = False
            'ToWarehouse
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "To Warehouse Name"
            DataGridView1.Columns.Item(6).Width = "182"
            'StockCode
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(7).Width = "182"
            'MovementQty
            DataGridView1.Columns.Item(8).Visible = True
            DataGridView1.Columns.Item(8).HeaderText = "Quantity"
            DataGridView1.Columns.Item(8).Width = "182"
            'MovementDate
            DataGridView1.Columns.Item(9).Visible = True
            DataGridView1.Columns.Item(9).HeaderText = "Date"
            DataGridView1.Columns.Item(9).Width = "182"
            DataGridView1.Columns.Item(10).Visible = False
            DataGridView1.Columns.Item(11).Visible = False
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub LoadEmployees()
        NewToolStripButton.Visible = True
        RecordToolStripButton.Visible = True
        DeleteToolStripButton.Visible = True
        FindToolStripButton.Visible = False
        CloseToolStripButton.Visible = True
        RefreshToolStripButton.Visible = True
        PrintToolStripButton.Visible = False
        ProveToolStripButton.Visible = False
        TransferToolStripButton.Visible = False
        AboutToolStripButton.Visible = True
        Me.Text = "DMH Stock Master v2 [Employees]"
        txtOption.Text = "Employee"
        Try
            ' Create a DataSet
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblEmployees WHERE LoginCode <> 'Admin' ", Connection)
            gridDataAdapter.Fill(data, "tblEmployees")
            DataGridView1.DataSource = data
            DataGridView1.DataMember = "tblEmployees"
            DataGridView1.AutoGenerateColumns = True
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.Columns.Item(4).Visible = False
            Connection.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub Find_Shop()
        If FindInput.Text = "" Then LoadShop()
        If FindInput.Text <> "" Then
            Me.ToolStripTextBox2.Visible = True
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
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            '  BindingSource1.DataSource = view1
            ' BindingSource1.Filter = "[ShopRef] = '" & FindInput.Text & "'"
            '  DataGridView1.DataSource = BindingSource1
            '  DataGridView1.Refresh()
            Dim dv As DataView
            dv = New DataView(ds.Tables(0), "ShopRef = '" & FindInput.Text & "'", "", DataViewRowState.CurrentRows)
            DataGridView1.DataSource = dv
            'ShopID
            DataGridView1.Columns.Item(0).Visible = False
            'ShopRef
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Shop.Address1
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Address"
            DataGridView1.Columns.Item(3).Width = "182"
            'Shop.Address2
            DataGridView1.Columns.Item(4).Visible = False
            'Shop.Address3
            DataGridView1.Columns.Item(5).Visible = False
            'Shop.Address4
            DataGridView1.Columns.Item(6).Visible = False
            'Shop.PostCode
            DataGridView1.Columns.Item(7).Visible = False
            'Shop.ContactName
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "Contact Name"
            DataGridView1.Columns.Item(8).Width = "182"
            'Shop.Telephone
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Telephone"
            DataGridView1.Columns.Item(9).Width = "182"
            'Shop.Telephone2
            DataGridView1.Columns.Item(10).Visible = False
            'Shop.Fax
            DataGridView1.Columns.Item(11).Visible = False
            'Shop.eMail
            DataGridView1.Columns.Item(12).Visible = False
            'Shop.memo
            DataGridView1.Columns.Item(13).Visible = False
            'Shop.ShopType
            DataGridView1.Columns.Item(14).HeaderText = "Type"
            DataGridView1.Columns.Item(14).Width = "182"
            'Shop.Clearance
            DataGridView1.Columns.Item(15).HeaderText = "Clearance Shop"
            DataGridView1.Columns.Item(15).Width = "182"
            'Shop.CreatedBy
            DataGridView1.Columns.Item(16).HeaderText = "Created By"
            DataGridView1.Columns.Item(16).Width = "182"
            'Shop.CreatedDate
            DataGridView1.Columns.Item(17).HeaderText = "Created At"
            DataGridView1.Columns.Item(17).Width = "182"
        End If
    End Sub

    Private Sub Find_Suppliers()
        If FindInput.Text = "" Then LoadSuppliers()
        If FindInput.Text <> "" Then
            Me.ToolStripTextBox2.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from tblsuppliers", Connection)
            gridDataAdapter.Fill(data, "tblSuppliers")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            BindingSource1.Filter = "[SupplierRef] = '" & FindInput.Text & "'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()
            'SupplierRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'SupplierName
            DataGridView1.Columns.Item(2).HeaderText = "Supplier Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Supplier.Address1
            DataGridView1.Columns.Item(3).HeaderText = "Address"
            DataGridView1.Columns.Item(3).Width = "182"
            'Supplier.Address2
            DataGridView1.Columns.Item(4).Visible = False
            'Supplier.Address3
            DataGridView1.Columns.Item(5).Visible = False
            'Supplier.Address4
            DataGridView1.Columns.Item(6).Visible = False
            'Supplier.PostCode
            DataGridView1.Columns.Item(7).Visible = False
            'Supplier.ContactName
            DataGridView1.Columns.Item(8).HeaderText = "Contact Name"
            DataGridView1.Columns.Item(8).Width = "182"
            'Supplier.Telephone
            DataGridView1.Columns.Item(9).HeaderText = "Telephone"
            DataGridView1.Columns.Item(9).Width = "182"
            'Supplier.Telephone2
            DataGridView1.Columns.Item(10).Visible = False
            'Supplier.Fax
            DataGridView1.Columns.Item(11).Visible = False
            'Supplier.eMail
            DataGridView1.Columns.Item(12).Visible = False
            'Supplier.memo
            DataGridView1.Columns.Item(13).Visible = False
            'Supplier.CreatedBy
            DataGridView1.Columns.Item(14).HeaderText = "Created By"
            DataGridView1.Columns.Item(14).Width = "182"
            'Supplier.CreatedDate
            DataGridView1.Columns.Item(15).HeaderText = "Created At"
            DataGridView1.Columns.Item(15).Width = "182"
        End If
    End Sub

    Private Sub Find_Stock()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.ToolStripTextBox2.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryShowStock", Connection)
            gridDataAdapter.Fill(data, "qryShowStock")
            Dim view1 As New DataView(tables(0))
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[StockCode] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            ' dgv.DefaultView.RowFilter = "StockCode LIKE '" & FindInput.Text & "%'"
            'StockID
            'DataGridView1.Columns.Item(0).Visible = False
            'DataGridView1.Columns.Item(0).Width = "10"
            'StockCode
            'DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
            '  DataGridView1.Columns.Item(0).Width = "20"
            'SupplierRef
            '  DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            ' DataGridView1.Columns.Item(1).Width = "10"
            'Season
            ' DataGridView1.Columns.Item(2).Visible = False
            ' DataGridView1.Columns.Item(2).HeaderText = "Season"
            ' DataGridView1.Columns.Item(2).Width = "10"
            'Dead Code
            'DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Dead Code"
            ' DataGridView1.Columns.Item(2).Width = "30"
            ' DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'RemoveFromClearance
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Remove"
            ' DataGridView1.Columns.Item(4).Width = "10"
            ' DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Amount Taken"
            DataGridView1.Columns.Item(3).Width = "10"
            DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "c"
            'DeliveredQtyHangers
            DataGridView1.Columns.Item(4).Visible = False
            DataGridView1.Columns.Item(4).Width = "10"
            'CostValue
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Cost Value"
            DataGridView1.Columns.Item(5).Width = "12"
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DataGridView1.Columns.Item(6).HeaderText = "Markup"
            DataGridView1.Columns.Item(6).Width = "12"
            DataGridView1.Columns.Item(6).DefaultCellStyle.Format = "p"
            'ZeroQty
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Zero Qty"
            DataGridView1.Columns.Item(7).DefaultCellStyle.Format = "Yes/No"
            'Stock.CreatedBy
            DataGridView1.Columns.Item(8).HeaderText = "Created By"
            DataGridView1.Columns.Item(8).Width = "12"
            'Stock.CreatedDate
            DataGridView1.Columns.Item(9).HeaderText = "Created At"
            DataGridView1.Columns.Item(9).Width = "12"
            DataGridView1.Columns.Item(9).DefaultCellStyle.Format = "dd/MM/yyyy"
            '  connection.Close()
        End If
    End Sub

    Private Sub Find_Sales()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.ToolStripTextBox2.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", Connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Sales ID"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Reference"
            DataGridView1.Columns.Item(3).Width = "182"
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).Width = "182"
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Sales"
            DataGridView1.Columns.Item(6).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(7).Visible = False
            DataGridView1.Columns.Item(7).HeaderText = "From ID"
            DataGridView1.Columns.Item(7).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "To ID"
            DataGridView1.Columns.Item(8).Width = "182"
        End If
    End Sub

    Private Sub Find_Purchase_Order()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.ToolStripTextBox2.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryDeliveriesDisplay", Connection)
            gridDataAdapter.Fill(data, "qryDeliveriesDisplay")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[SupplierRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            'tblDeliveries.DeliveryID
            DataGridView1.Columns.Item(0).Visible = True
            '   DataGridView1.Columns.Item(0).HeaderText = "Order Number"
            ' DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "Number"
            DataGridView1.Columns.Item(0).Width = "182"
            'tblDeliveries.OurRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Our Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'tblDeliveries.SupplierRef
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(2).Width = "182"
            'tblSuppliers.SupplierName
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Supplier Name"
            DataGridView1.Columns.Item(3).Width = "182"
            'tblDeliveries.Season
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Season"
            DataGridView1.Columns.Item(4).Width = "182"
            'tblDeliveries.WarehouseRef
            DataGridView1.Columns.Item(5).Visible = False
            DataGridView1.Columns.Item(5).HeaderText = "Warehouse Ref"
            DataGridView1.Columns.Item(5).Width = "182"
            'tblDeliveries,TotalGarments
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Garments"
            DataGridView1.Columns.Item(6).Width = "182"
            'tblDeliveries.TotalBoxes 
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Boxes"
            DataGridView1.Columns.Item(7).Width = "182"
            'tblDeliveries.TotalHangers 
            DataGridView1.Columns.Item(8).Visible = True
            DataGridView1.Columns.Item(8).HeaderText = "Hangers"
            DataGridView1.Columns.Item(8).Width = "182"
            'tblDeliveries.NetAmount 
            DataGridView1.Columns.Item(9).Visible = True
            DataGridView1.Columns.Item(9).HeaderText = "Net Cost"
            DataGridView1.Columns.Item(9).Width = "182"
            'tblDeliveries.DeliveryCharge
            DataGridView1.Columns.Item(10).Visible = False
            DataGridView1.Columns.Item(10).HeaderText = "Delivery Charge"
            DataGridView1.Columns.Item(10).Width = "182"
            'tblDeliveries.Commission
            DataGridView1.Columns.Item(11).Visible = False
            DataGridView1.Columns.Item(11).HeaderText = "Commission"
            DataGridView1.Columns.Item(11).Width = "182"
            'tblDeliveries.GrossAmount
            DataGridView1.Columns.Item(12).Visible = False
            DataGridView1.Columns.Item(12).HeaderText = "Total Amount"
            DataGridView1.Columns.Item(12).Width = "182"
            'tblDeliveries.DeliveryDate
            DataGridView1.Columns.Item(13).Visible = True
            DataGridView1.Columns.Item(13).HeaderText = "Order Date"
            DataGridView1.Columns.Item(13).Width = "182"
            'tblDeliveries.DeliveryType
            DataGridView1.Columns.Item(14).Visible = False
            DataGridView1.Columns.Item(14).HeaderText = "Delivery Type"
            DataGridView1.Columns.Item(14).Width = "182"
            'tblDeliveries.ConfirmedDate
            DataGridView1.Columns.Item(15).Visible = False
            DataGridView1.Columns.Item(15).HeaderText = "Confirmed Date"
            DataGridView1.Columns.Item(15).Width = "182"
            'tblDeliveries.Notes
            DataGridView1.Columns.Item(16).Visible = False
            DataGridView1.Columns.Item(16).HeaderText = "Notes"
            DataGridView1.Columns.Item(16).Width = "182"
            'tblDeliveries.Invoice
            DataGridView1.Columns.Item(17).Visible = False
            DataGridView1.Columns.Item(17).HeaderText = "Invoice"
            DataGridView1.Columns.Item(17).Width = "182"
            'tblDeliveries.Shipper
            DataGridView1.Columns.Item(18).Visible = False
            DataGridView1.Columns.Item(18).HeaderText = "Shipper"
            DataGridView1.Columns.Item(18).Width = "182"
            'tblDeliveries.ShipperInvoice
            DataGridView1.Columns.Item(19).Visible = False
            DataGridView1.Columns.Item(19).HeaderText = "Shipper Invoice"
            DataGridView1.Columns.Item(19).Width = "182"
            'tblDeliveries.CreatedBy
            DataGridView1.Columns.Item(20).Visible = False
            DataGridView1.Columns.Item(20).HeaderText = "Created By"
            DataGridView1.Columns.Item(20).Width = "182"
            'tblDeliveries.CreatedDate 
            DataGridView1.Columns.Item(21).Visible = False
            DataGridView1.Columns.Item(21).HeaderText = "Created AT"
            DataGridView1.Columns.Item(21).Width = "182"
        End If
    End Sub

    Private Sub Find_Shop_Transfer()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.ToolStripTextBox2.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryShopTransferDisplayMain", Connection)
            gridDataAdapter.Fill(data, "qryShopTransferDisplayMain")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'tblShopTransfer.TransferID
            DataGridView1.Columns.Item(0).Visible = False
            DataGridView1.Columns.Item(0).HeaderText = "TransID Ref"
            DataGridView1.Columns.Item(0).Width = "182"
            'tblWarehouseTransfer.Reference
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "TF Note"
            DataGridView1.Columns.Item(1).Width = "182"
            'TransferDate
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Date"
            DataGridView1.Columns.Item(2).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "From Ref"
            DataGridView1.Columns.Item(3).Width = "182"
            'TotalQtyOut
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "From Shop"
            DataGridView1.Columns.Item(4).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Created By"
            DataGridView1.Columns.Item(9).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(10).Visible = False
            DataGridView1.Columns.Item(10).HeaderText = "Created At"
            DataGridView1.Columns.Item(10).Width = "182"
            'ToShopRef
            DataGridView1.Columns.Item(7).Visible = True
            'DataGridView1.Columns.Item(7).HeaderText = "To Ref"
            DataGridView1.Columns.Item(7).Width = "182"
            'TotalQtyIn
            DataGridView1.Columns.Item(8).Visible = True
            DataGridView1.Columns.Item(8).HeaderText = "To Quantity"
            DataGridView1.Columns.Item(8).Width = "182"
        End If
    End Sub

    Private Sub Find_Shop_Delivery()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.ToolStripTextBox2.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qryGridShopDelDisplay order by DeliveryID desc", Connection)
            gridDataAdapter.Fill(data, "qryGridShopDelDisplay")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'DeliveryID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Reference"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = False
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop"
            DataGridView1.Columns.Item(2).Width = "182"
            'WarehouseRef
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Warehouse Ref"
            DataGridView1.Columns.Item(3).Width = "182"
            'WarehouseName
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Warehouse"
            DataGridView1.Columns.Item(4).Width = "182"
            'Reference
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Delivery No"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalHangers
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Quantity"
            DataGridView1.Columns.Item(6).Width = "182"
            'DeliveryDate
            DataGridView1.Columns.Item(7).Visible = True
            DataGridView1.Columns.Item(7).HeaderText = "Delivery Date"
            DataGridView1.Columns.Item(7).Width = "182"
            'DeliveryType
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "Type"
            DataGridView1.Columns.Item(8).Width = "182"
            'ConfirmedDate
            DataGridView1.Columns.Item(9).Visible = False
            DataGridView1.Columns.Item(9).HeaderText = "Confirmed Date"
            DataGridView1.Columns.Item(0).Width = "182"
            'Notes
            DataGridView1.Columns.Item(10).Visible = True
            DataGridView1.Columns.Item(10).HeaderText = "Notes"
            DataGridView1.Columns.Item(10).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(11).Visible = False
            DataGridView1.Columns.Item(11).HeaderText = "Created By"
            DataGridView1.Columns.Item(11).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(12).Visible = False
            DataGridView1.Columns.Item(12).HeaderText = "Created At"
            DataGridView1.Columns.Item(12).Width = "182"
        End If
    End Sub

    Private Sub Find_Warehouse_Adjustment()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.ToolStripTextBox2.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", Connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Sales ID"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Reference"
            DataGridView1.Columns.Item(3).Width = "182"
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).Width = "182"
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Sales"
            DataGridView1.Columns.Item(6).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(7).Visible = False
            DataGridView1.Columns.Item(7).HeaderText = "From ID"
            DataGridView1.Columns.Item(7).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "To ID"
            DataGridView1.Columns.Item(8).Width = "182"
        End If
    End Sub

    Private Sub Find_Shop_Adjustment()
        If FindInput.Text = "" Then LoadStock()
        If FindInput.Text <> "" Then
            Dim filterfield As String = "StockCode"
            Me.ToolStripTextBox2.Visible = True
            Me.FindInput.Visible = True
            Dim data As New DataSet()
            Dim tables As DataTableCollection = data.Tables
            data.Locale = System.Globalization.CultureInfo.InvariantCulture
            Dim gridDataAdapter As New SqlDataAdapter("SELECT * from qrySales", Connection)
            gridDataAdapter.Fill(data, "qrySales")
            Dim view1 As New DataView(tables(0))
            BindingSource1.DataSource = view1
            BindingSource1.Filter = "[ShopRef] LIKE '" & FindInput.Text & "%'"
            DataGridView1.DataSource = BindingSource1
            DataGridView1.GridColor = Color.Cornsilk
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.BackgroundColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            DataGridView1.Refresh()
            Dim dgv As New DataTable
            DataGridView1.DataSource = BindingSource1
            'SalesID
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Sales ID"
            DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "0000"
            DataGridView1.Columns.Item(0).Width = "182"
            'ShopRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Shop Ref"
            DataGridView1.Columns.Item(1).Width = "182"
            'ShopName
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Shop Name"
            DataGridView1.Columns.Item(2).Width = "182"
            'Reference
            DataGridView1.Columns.Item(3).Visible = False
            DataGridView1.Columns.Item(3).HeaderText = "Reference"
            DataGridView1.Columns.Item(3).Width = "182"
            'TransactionDate
            DataGridView1.Columns.Item(4).Visible = True
            DataGridView1.Columns.Item(4).HeaderText = "Date"
            DataGridView1.Columns.Item(4).Width = "182"
            'TotalQty
            DataGridView1.Columns.Item(5).Visible = True
            DataGridView1.Columns.Item(5).HeaderText = "Total Garments"
            DataGridView1.Columns.Item(5).Width = "182"
            'TotalValue
            DataGridView1.Columns.Item(6).Visible = True
            DataGridView1.Columns.Item(6).HeaderText = "Total Sales"
            DataGridView1.Columns.Item(6).Width = "182"
            'CreatedBy
            DataGridView1.Columns.Item(7).Visible = False
            DataGridView1.Columns.Item(7).HeaderText = "From ID"
            DataGridView1.Columns.Item(7).Width = "182"
            'CreatedDate
            DataGridView1.Columns.Item(8).Visible = False
            DataGridView1.Columns.Item(8).HeaderText = "To ID"
            DataGridView1.Columns.Item(8).Width = "182"
        End If
    End Sub
    Private Sub Find_Season()

    End Sub
    Private Sub Find_Profile()

    End Sub
    Private Sub Find_Warehouse()

    End Sub
    Private Sub Find_Warehouse_Transfer()

    End Sub
    Private Sub Find_Refunds()

    End Sub
    Private Sub Find_Returns()

    End Sub
    Private Sub Find_Employee()

    End Sub
End Class