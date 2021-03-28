<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMain))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.WarehousesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShopsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuppliersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WHAdjustsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WHReturnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeliveriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShopAdjustsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShopTransfersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShopReturnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllStockMovementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShopDeliveriesByStockCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorehamwoodStockListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockListByShopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockListByStockCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WarehouseStockListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalStockValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesAnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovementTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalSalesPerWeekToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnterBarcodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1061, 688)
        Me.SplitContainer1.SplitterDistance = 151
        Me.SplitContainer1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WarehousesToolStripMenuItem, Me.ShopsToolStripMenuItem, Me.SuppliersToolStripMenuItem, Me.OrdersToolStripMenuItem, Me.WHAdjustsToolStripMenuItem, Me.WHReturnsToolStripMenuItem, Me.DeliveriesToolStripMenuItem, Me.ShopAdjustsToolStripMenuItem, Me.ShopTransfersToolStripMenuItem, Me.SalesToolStripMenuItem, Me.ShopReturnsToolStripMenuItem, Me.NewStockToolStripMenuItem, Me.AllStockToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ExitToolStripMenuItem, Me.EnterBarcodesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(132, 688)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'WarehousesToolStripMenuItem
        '
        Me.WarehousesToolStripMenuItem.Name = "WarehousesToolStripMenuItem"
        Me.WarehousesToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.WarehousesToolStripMenuItem.Text = "Warehouses"
        '
        'ShopsToolStripMenuItem
        '
        Me.ShopsToolStripMenuItem.Name = "ShopsToolStripMenuItem"
        Me.ShopsToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.ShopsToolStripMenuItem.Text = "Shops"
        '
        'SuppliersToolStripMenuItem
        '
        Me.SuppliersToolStripMenuItem.Name = "SuppliersToolStripMenuItem"
        Me.SuppliersToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.SuppliersToolStripMenuItem.Text = "Suppliers"
        '
        'OrdersToolStripMenuItem
        '
        Me.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem"
        Me.OrdersToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.OrdersToolStripMenuItem.Text = "Orders"
        '
        'WHAdjustsToolStripMenuItem
        '
        Me.WHAdjustsToolStripMenuItem.Name = "WHAdjustsToolStripMenuItem"
        Me.WHAdjustsToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.WHAdjustsToolStripMenuItem.Text = "WH Adjusts"
        '
        'WHReturnsToolStripMenuItem
        '
        Me.WHReturnsToolStripMenuItem.Name = "WHReturnsToolStripMenuItem"
        Me.WHReturnsToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.WHReturnsToolStripMenuItem.Text = "WH Returns"
        Me.WHReturnsToolStripMenuItem.Visible = False
        '
        'DeliveriesToolStripMenuItem
        '
        Me.DeliveriesToolStripMenuItem.Name = "DeliveriesToolStripMenuItem"
        Me.DeliveriesToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.DeliveriesToolStripMenuItem.Text = "Deliveries"
        '
        'ShopAdjustsToolStripMenuItem
        '
        Me.ShopAdjustsToolStripMenuItem.Name = "ShopAdjustsToolStripMenuItem"
        Me.ShopAdjustsToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.ShopAdjustsToolStripMenuItem.Text = "SH Adjusts"
        '
        'ShopTransfersToolStripMenuItem
        '
        Me.ShopTransfersToolStripMenuItem.Name = "ShopTransfersToolStripMenuItem"
        Me.ShopTransfersToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.ShopTransfersToolStripMenuItem.Text = "SH Transfers"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.SalesToolStripMenuItem.Text = "Sales"
        '
        'ShopReturnsToolStripMenuItem
        '
        Me.ShopReturnsToolStripMenuItem.Name = "ShopReturnsToolStripMenuItem"
        Me.ShopReturnsToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.ShopReturnsToolStripMenuItem.Text = "Shop Returns"
        '
        'NewStockToolStripMenuItem
        '
        Me.NewStockToolStripMenuItem.Name = "NewStockToolStripMenuItem"
        Me.NewStockToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.NewStockToolStripMenuItem.Text = "New Stock"
        '
        'AllStockToolStripMenuItem
        '
        Me.AllStockToolStripMenuItem.Name = "AllStockToolStripMenuItem"
        Me.AllStockToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.AllStockToolStripMenuItem.Text = "All Stock"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllStockMovementsToolStripMenuItem, Me.ShopDeliveriesByStockCodeToolStripMenuItem, Me.BorehamwoodStockListToolStripMenuItem, Me.StockListByShopToolStripMenuItem, Me.StockListByStockCodeToolStripMenuItem, Me.WarehouseStockListToolStripMenuItem, Me.TotalStockValuationToolStripMenuItem, Me.SalesHistoryToolStripMenuItem, Me.SalesAnalysisToolStripMenuItem, Me.MovementTypesToolStripMenuItem, Me.TotalSalesPerWeekToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'AllStockMovementsToolStripMenuItem
        '
        Me.AllStockMovementsToolStripMenuItem.Name = "AllStockMovementsToolStripMenuItem"
        Me.AllStockMovementsToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.AllStockMovementsToolStripMenuItem.Text = "All Stock Movements"
        '
        'ShopDeliveriesByStockCodeToolStripMenuItem
        '
        Me.ShopDeliveriesByStockCodeToolStripMenuItem.Name = "ShopDeliveriesByStockCodeToolStripMenuItem"
        Me.ShopDeliveriesByStockCodeToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.ShopDeliveriesByStockCodeToolStripMenuItem.Text = "Shop Deliveries by Stock Code"
        '
        'BorehamwoodStockListToolStripMenuItem
        '
        Me.BorehamwoodStockListToolStripMenuItem.Name = "BorehamwoodStockListToolStripMenuItem"
        Me.BorehamwoodStockListToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.BorehamwoodStockListToolStripMenuItem.Text = "Borehamwood Stock List"
        '
        'StockListByShopToolStripMenuItem
        '
        Me.StockListByShopToolStripMenuItem.Name = "StockListByShopToolStripMenuItem"
        Me.StockListByShopToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.StockListByShopToolStripMenuItem.Text = "Stock List By Shop"
        '
        'StockListByStockCodeToolStripMenuItem
        '
        Me.StockListByStockCodeToolStripMenuItem.Name = "StockListByStockCodeToolStripMenuItem"
        Me.StockListByStockCodeToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.StockListByStockCodeToolStripMenuItem.Text = "Stock List By Stock Code"
        '
        'WarehouseStockListToolStripMenuItem
        '
        Me.WarehouseStockListToolStripMenuItem.Name = "WarehouseStockListToolStripMenuItem"
        Me.WarehouseStockListToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.WarehouseStockListToolStripMenuItem.Text = "Warehouse Stock List"
        '
        'TotalStockValuationToolStripMenuItem
        '
        Me.TotalStockValuationToolStripMenuItem.Name = "TotalStockValuationToolStripMenuItem"
        Me.TotalStockValuationToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.TotalStockValuationToolStripMenuItem.Text = "Total Stock Valuation"
        '
        'SalesHistoryToolStripMenuItem
        '
        Me.SalesHistoryToolStripMenuItem.Name = "SalesHistoryToolStripMenuItem"
        Me.SalesHistoryToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.SalesHistoryToolStripMenuItem.Text = "Sales History"
        '
        'SalesAnalysisToolStripMenuItem
        '
        Me.SalesAnalysisToolStripMenuItem.Name = "SalesAnalysisToolStripMenuItem"
        Me.SalesAnalysisToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.SalesAnalysisToolStripMenuItem.Text = "Sales Analysis"
        '
        'MovementTypesToolStripMenuItem
        '
        Me.MovementTypesToolStripMenuItem.Name = "MovementTypesToolStripMenuItem"
        Me.MovementTypesToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.MovementTypesToolStripMenuItem.Text = "Movement Types"
        '
        'TotalSalesPerWeekToolStripMenuItem
        '
        Me.TotalSalesPerWeekToolStripMenuItem.Name = "TotalSalesPerWeekToolStripMenuItem"
        Me.TotalSalesPerWeekToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.TotalSalesPerWeekToolStripMenuItem.Text = "Total Sales Per Week"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EnterBarcodesToolStripMenuItem
        '
        Me.EnterBarcodesToolStripMenuItem.Name = "EnterBarcodesToolStripMenuItem"
        Me.EnterBarcodesToolStripMenuItem.Size = New System.Drawing.Size(125, 21)
        Me.EnterBarcodesToolStripMenuItem.Text = "Enter Barcodes"
        Me.EnterBarcodesToolStripMenuItem.Visible = False
        '
        'FMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SandyBrown
        Me.ClientSize = New System.Drawing.Size(1061, 688)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FMain"
        Me.Text = "DMHStockMgr"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents WarehousesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShopsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SuppliersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WHAdjustsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WHReturnsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeliveriesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShopAdjustsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShopTransfersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShopReturnsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewStockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllStockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllStockMovementsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShopDeliveriesByStockCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BorehamwoodStockListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockListByShopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockListByStockCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WarehouseStockListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TotalStockValuationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesHistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesAnalysisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovementTypesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TotalSalesPerWeekToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnterBarcodesToolStripMenuItem As ToolStripMenuItem
End Class
