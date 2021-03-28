Public Class FMain

    Private Sub WarehousesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehousesToolStripMenuItem.Click
        FGridWarehouses.MdiParent = Me
        FGridWarehouses.Show()
        SplitContainer1.Panel2.Controls.Add(FGridWarehouses)
        FGridWarehouses.Dock = DockStyle.Fill
        FGridWarehouses.BringToFront()
    End Sub

    Private Sub ShopsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopsToolStripMenuItem.Click
        FGridShops.MdiParent = Me
        FGridShops.Show()
        SplitContainer1.Panel2.Controls.Add(FGridShops)
        FGridShops.Dock = DockStyle.Fill
        FGridShops.BringToFront()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppliersToolStripMenuItem.Click
        FGridSuppliers.MdiParent = Me
        FGridSuppliers.Show()
        SplitContainer1.Panel2.Controls.Add(FGridSuppliers)
        FGridSuppliers.Dock = DockStyle.Fill
        FGridSuppliers.BringToFront()
    End Sub

    Private Sub OrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdersToolStripMenuItem.Click
        FGridPOrders.MdiParent = Me
        FGridPOrders.Show()
        SplitContainer1.Panel2.Controls.Add(FGridPOrders)
        FGridPOrders.Dock = DockStyle.Fill
        FGridPOrders.BringToFront()
    End Sub

    Private Sub WHAdjustsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WHAdjustsToolStripMenuItem.Click
        FGridWHAdjust.MdiParent = Me
        FGridWHAdjust.Show()
        SplitContainer1.Panel2.Controls.Add(FGridWHAdjust)
        FGridWHAdjust.Dock = DockStyle.Fill
        FGridWHAdjust.BringToFront()
    End Sub

    Private Sub WHReturnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WHReturnsToolStripMenuItem.Click
        FGridWHReturns.MdiParent = Me
        FGridWHReturns.Show()
        SplitContainer1.Panel2.Controls.Add(FGridWHReturns)
        FGridWHReturns.Dock = DockStyle.Fill
        FGridWHReturns.BringToFront()
    End Sub

    Private Sub DeliveriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveriesToolStripMenuItem.Click
        FGridShopDel.MdiParent = Me
        FGridShopDel.Show()
        SplitContainer1.Panel2.Controls.Add(FGridShopDel)
        FGridShopDel.Dock = DockStyle.Fill
        FGridShopDel.BringToFront()
    End Sub

    Private Sub ShopAdjustsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopAdjustsToolStripMenuItem.Click
        FGridSHAdjust.MdiParent = Me
        FGridSHAdjust.Show()
        SplitContainer1.Panel2.Controls.Add(FGridSHAdjust)
        FGridSHAdjust.Dock = DockStyle.Fill
        FGridSHAdjust.BringToFront()
    End Sub

    Private Sub ShopTransfersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopTransfersToolStripMenuItem.Click
        FGridSHTransfers.MdiParent = Me
        FGridSHTransfers.Show()
        SplitContainer1.Panel2.Controls.Add(FGridSHTransfers)
        FGridSHTransfers.Dock = DockStyle.Fill
        FGridSHTransfers.BringToFront()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        FGridShopSales.MdiParent = Me
        FGridShopSales.Show()
        SplitContainer1.Panel2.Controls.Add(FGridShopSales)
        FGridShopSales.Dock = DockStyle.Fill
        FGridShopSales.BringToFront()
    End Sub

    Private Sub ShopReturnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopReturnsToolStripMenuItem.Click
        FGridSHReturns.MdiParent = Me
        FGridSHReturns.Show()
        SplitContainer1.Panel2.Controls.Add(FGridSHReturns)
        FGridSHReturns.Dock = DockStyle.Fill
        FGridSHReturns.BringToFront()
    End Sub

    Private Sub NewStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewStockToolStripMenuItem.Click
        FGridCurrentStock.MdiParent = Me
        FGridCurrentStock.Show()
        SplitContainer1.Panel2.Controls.Add(FGridCurrentStock)
        FGridCurrentStock.Dock = DockStyle.Fill
        FGridCurrentStock.BringToFront()
    End Sub

    Private Sub AllStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllStockToolStripMenuItem.Click
        FGridAllStock.MdiParent = Me
        FGridAllStock.Show()
        SplitContainer1.Panel2.Controls.Add(FGridAllStock)
        FGridAllStock.Dock = DockStyle.Fill
        FGridAllStock.BringToFront()
    End Sub

    Private Sub AllStockMovementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllStockMovementsToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "AllStock"
            .Text = "All Stock Movements Report"
            .Show()
        End With
    End Sub

    Private Sub ShopDeliveriesByStockCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShopDeliveriesByStockCodeToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "ShopDel"
            .Text = "Shop Deliveries Report"
            .Show()
        End With
    End Sub

    Private Sub BorehamwoodStockListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorehamwoodStockListToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "Bore"
            .Text = "Borehamwood Stock List Report"
            .Show()
        End With
    End Sub

    Private Sub StockListByShopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockListByShopToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "StockList1"
            .Text = "Stock List by Shop Report"
            .Show()
        End With
    End Sub

    Private Sub StockListByStockCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockListByStockCodeToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "StockList2"
            .Text = "Stock List By Stock Code Report"
            .Show()
        End With
    End Sub

    Private Sub WarehouseStockListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseStockListToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "Warehouse"
            .Text = "Warehouse Stock List Report"
            .Show()
        End With
    End Sub

    Private Sub TotalStockValuationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalStockValuationToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "TotalValue"
            .Text = "Total Stock Valuation Report"
            .Show()
        End With
    End Sub

    Private Sub SalesHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesHistoryToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "SalesHistory"
            .Text = "Sales History Report"
            .Show()
        End With
    End Sub

    Private Sub SalesAnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesAnalysisToolStripMenuItem.Click
        Dim Rep As New FReportCriteria()
        With Rep
            .Label3.Text = "SalesAnalysis"
            .Text = "Sales Analysis Report"
            .Show()
        End With
    End Sub

    Private Sub MovementTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovementTypesToolStripMenuItem.Click
        FGridMoveTypes.Show()
        FGridMoveTypes.MdiParent = Me
        SplitContainer1.Panel2.Controls.Add(FGridMoveTypes)
        FGridMoveTypes.Dock = DockStyle.Fill
        FGridMoveTypes.BringToFront()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        FSettings.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub FMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        WarehousesToolStripMenuItem.Visible = False
        WHReturnsToolStripMenuItem.Visible = False
    End Sub

    Private Sub TotalSalesPerWeekToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalSalesPerWeekToolStripMenuItem.Click
        FGridSalesTotals.Show()
        FGridSalesTotals.MdiParent = Me
        SplitContainer1.Panel2.Controls.Add(FGridSalesTotals)
        FGridSalesTotals.Dock = DockStyle.Fill
        FGridSalesTotals.BringToFront()
    End Sub

    Private Sub EnterBarcodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnterBarcodesToolStripMenuItem.Click
        FGridBarcode.Show()
        FGridBarcode.MdiParent = Me
        SplitContainer1.Panel2.Controls.Add(FGridBarcode)
        FGridBarcode.Dock = DockStyle.Fill
        FGridBarcode.BringToFront()
    End Sub
End Class