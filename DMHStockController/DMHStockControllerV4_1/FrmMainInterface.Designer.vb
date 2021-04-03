<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMainInterface
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.recordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.warehousesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.suppliersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.shopsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.currentStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.allStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.seasonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.warehouseFunctionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.purchaseOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.warehouseAdjustmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.warehouseTransfersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.warehouseReturnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.shopFunctionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.shopDeliveriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.shopAdjustmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.shopTransfersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.shopSalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.shopReturnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.reportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.totalValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.maintanaceFunctionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.settingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.menuStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 450)
        Me.SplitContainer1.SplitterDistance = 27
        Me.SplitContainer1.TabIndex = 1
        '
        'menuStrip1
        '
        Me.menuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.recordsToolStripMenuItem, Me.warehouseFunctionsToolStripMenuItem, Me.shopFunctionsToolStripMenuItem, Me.reportsToolStripMenuItem, Me.maintanaceFunctionsToolStripMenuItem, Me.exitToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(800, 28)
        Me.menuStrip1.TabIndex = 1
        Me.menuStrip1.Text = "menuStrip1"
        '
        'recordsToolStripMenuItem
        '
        Me.recordsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.warehousesToolStripMenuItem, Me.suppliersToolStripMenuItem, Me.shopsToolStripMenuItem, Me.currentStockToolStripMenuItem, Me.allStockToolStripMenuItem, Me.seasonsToolStripMenuItem})
        Me.recordsToolStripMenuItem.Name = "recordsToolStripMenuItem"
        Me.recordsToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.recordsToolStripMenuItem.Text = "Records"
        '
        'warehousesToolStripMenuItem
        '
        Me.warehousesToolStripMenuItem.Name = "warehousesToolStripMenuItem"
        Me.warehousesToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.warehousesToolStripMenuItem.Text = "Warehouses"
        '
        'suppliersToolStripMenuItem
        '
        Me.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem"
        Me.suppliersToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.suppliersToolStripMenuItem.Text = "Suppliers"
        '
        'shopsToolStripMenuItem
        '
        Me.shopsToolStripMenuItem.Name = "shopsToolStripMenuItem"
        Me.shopsToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.shopsToolStripMenuItem.Text = "Shops"
        '
        'currentStockToolStripMenuItem
        '
        Me.currentStockToolStripMenuItem.Name = "currentStockToolStripMenuItem"
        Me.currentStockToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.currentStockToolStripMenuItem.Text = "Current Stock"
        '
        'allStockToolStripMenuItem
        '
        Me.allStockToolStripMenuItem.Name = "allStockToolStripMenuItem"
        Me.allStockToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.allStockToolStripMenuItem.Text = "All Stock"
        '
        'seasonsToolStripMenuItem
        '
        Me.seasonsToolStripMenuItem.Name = "seasonsToolStripMenuItem"
        Me.seasonsToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.seasonsToolStripMenuItem.Text = "Seasons"
        '
        'warehouseFunctionsToolStripMenuItem
        '
        Me.warehouseFunctionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.purchaseOrdersToolStripMenuItem, Me.warehouseAdjustmentsToolStripMenuItem, Me.warehouseTransfersToolStripMenuItem, Me.warehouseReturnsToolStripMenuItem})
        Me.warehouseFunctionsToolStripMenuItem.Name = "warehouseFunctionsToolStripMenuItem"
        Me.warehouseFunctionsToolStripMenuItem.Size = New System.Drawing.Size(160, 24)
        Me.warehouseFunctionsToolStripMenuItem.Text = "Warehouse Functions"
        '
        'purchaseOrdersToolStripMenuItem
        '
        Me.purchaseOrdersToolStripMenuItem.Name = "purchaseOrdersToolStripMenuItem"
        Me.purchaseOrdersToolStripMenuItem.Size = New System.Drawing.Size(237, 24)
        Me.purchaseOrdersToolStripMenuItem.Text = "Purchase Orders"
        '
        'warehouseAdjustmentsToolStripMenuItem
        '
        Me.warehouseAdjustmentsToolStripMenuItem.Name = "warehouseAdjustmentsToolStripMenuItem"
        Me.warehouseAdjustmentsToolStripMenuItem.Size = New System.Drawing.Size(237, 24)
        Me.warehouseAdjustmentsToolStripMenuItem.Text = "Warehouse Adjustments"
        '
        'warehouseTransfersToolStripMenuItem
        '
        Me.warehouseTransfersToolStripMenuItem.Name = "warehouseTransfersToolStripMenuItem"
        Me.warehouseTransfersToolStripMenuItem.Size = New System.Drawing.Size(237, 24)
        Me.warehouseTransfersToolStripMenuItem.Text = "Warehouse Transfers"
        '
        'warehouseReturnsToolStripMenuItem
        '
        Me.warehouseReturnsToolStripMenuItem.Name = "warehouseReturnsToolStripMenuItem"
        Me.warehouseReturnsToolStripMenuItem.Size = New System.Drawing.Size(237, 24)
        Me.warehouseReturnsToolStripMenuItem.Text = "Warehouse Returns"
        '
        'shopFunctionsToolStripMenuItem
        '
        Me.shopFunctionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.shopDeliveriesToolStripMenuItem, Me.shopAdjustmentsToolStripMenuItem, Me.shopTransfersToolStripMenuItem, Me.shopSalesToolStripMenuItem, Me.shopReturnsToolStripMenuItem})
        Me.shopFunctionsToolStripMenuItem.Name = "shopFunctionsToolStripMenuItem"
        Me.shopFunctionsToolStripMenuItem.Size = New System.Drawing.Size(121, 24)
        Me.shopFunctionsToolStripMenuItem.Text = "Shop Functions"
        '
        'shopDeliveriesToolStripMenuItem
        '
        Me.shopDeliveriesToolStripMenuItem.Name = "shopDeliveriesToolStripMenuItem"
        Me.shopDeliveriesToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.shopDeliveriesToolStripMenuItem.Text = "Shop Deliveries"
        '
        'shopAdjustmentsToolStripMenuItem
        '
        Me.shopAdjustmentsToolStripMenuItem.Name = "shopAdjustmentsToolStripMenuItem"
        Me.shopAdjustmentsToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.shopAdjustmentsToolStripMenuItem.Text = "Shop Adjustments"
        '
        'shopTransfersToolStripMenuItem
        '
        Me.shopTransfersToolStripMenuItem.Name = "shopTransfersToolStripMenuItem"
        Me.shopTransfersToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.shopTransfersToolStripMenuItem.Text = "Shop Transfers"
        '
        'shopSalesToolStripMenuItem
        '
        Me.shopSalesToolStripMenuItem.Name = "shopSalesToolStripMenuItem"
        Me.shopSalesToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.shopSalesToolStripMenuItem.Text = "Shop Sales"
        '
        'shopReturnsToolStripMenuItem
        '
        Me.shopReturnsToolStripMenuItem.Name = "shopReturnsToolStripMenuItem"
        Me.shopReturnsToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.shopReturnsToolStripMenuItem.Text = "Shop Returns"
        '
        'reportsToolStripMenuItem
        '
        Me.reportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.totalValuationToolStripMenuItem})
        Me.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem"
        Me.reportsToolStripMenuItem.Size = New System.Drawing.Size(72, 24)
        Me.reportsToolStripMenuItem.Text = "Reports"
        '
        'totalValuationToolStripMenuItem
        '
        Me.totalValuationToolStripMenuItem.Name = "totalValuationToolStripMenuItem"
        Me.totalValuationToolStripMenuItem.Size = New System.Drawing.Size(177, 24)
        Me.totalValuationToolStripMenuItem.Text = "Total Valuation"
        '
        'maintanaceFunctionsToolStripMenuItem
        '
        Me.maintanaceFunctionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.settingsToolStripMenuItem})
        Me.maintanaceFunctionsToolStripMenuItem.Name = "maintanaceFunctionsToolStripMenuItem"
        Me.maintanaceFunctionsToolStripMenuItem.Size = New System.Drawing.Size(164, 24)
        Me.maintanaceFunctionsToolStripMenuItem.Text = "Maintanace Functions"
        '
        'settingsToolStripMenuItem
        '
        Me.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem"
        Me.settingsToolStripMenuItem.Size = New System.Drawing.Size(131, 24)
        Me.settingsToolStripMenuItem.Text = "Settings"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(45, 24)
        Me.exitToolStripMenuItem.Text = "Exit"
        '
        'FrmMainInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IsMdiContainer = True
        Me.Name = "FrmMainInterface"
        Me.Text = "StockMaster V4.1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Private WithEvents menuStrip1 As MenuStrip
    Private WithEvents recordsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents warehousesToolStripMenuItem As ToolStripMenuItem
    Private WithEvents suppliersToolStripMenuItem As ToolStripMenuItem
    Private WithEvents shopsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents currentStockToolStripMenuItem As ToolStripMenuItem
    Private WithEvents allStockToolStripMenuItem As ToolStripMenuItem
    Private WithEvents seasonsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents warehouseFunctionsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents purchaseOrdersToolStripMenuItem As ToolStripMenuItem
    Private WithEvents warehouseAdjustmentsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents warehouseTransfersToolStripMenuItem As ToolStripMenuItem
    Private WithEvents warehouseReturnsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents shopFunctionsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents shopDeliveriesToolStripMenuItem As ToolStripMenuItem
    Private WithEvents shopAdjustmentsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents shopTransfersToolStripMenuItem As ToolStripMenuItem
    Private WithEvents shopSalesToolStripMenuItem As ToolStripMenuItem
    Private WithEvents shopReturnsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents reportsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents totalValuationToolStripMenuItem As ToolStripMenuItem
    Private WithEvents maintanaceFunctionsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents settingsToolStripMenuItem As ToolStripMenuItem
    Private WithEvents exitToolStripMenuItem As ToolStripMenuItem
End Class
