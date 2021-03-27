<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FShopDeliveries
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.StockCodeDG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GarmentsDG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvStock = New System.Windows.Forms.DataGridView()
        Me.dgvShops = New System.Windows.Forms.DataGridView()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmdFindWarehouse = New System.Windows.Forms.Button()
        Me.cmdFindStockCode = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdFindSupplier = New System.Windows.Forms.Button()
        Me.cmdAddItem = New System.Windows.Forms.Button()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtQtyHangers = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtWarehouseRef = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtWarehouseName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtShopRef = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtShopName = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalGarments = New System.Windows.Forms.TextBox()
        Me.txtDelNoteNumber = New System.Windows.Forms.TextBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.cmdClearForm = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShops, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StockCodeDG, Me.GarmentsDG})
        Me.DataGridView1.Location = New System.Drawing.Point(317, 328)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(272, 176)
        Me.DataGridView1.TabIndex = 79
        '
        'StockCodeDG
        '
        Me.StockCodeDG.HeaderText = "Stock Code"
        Me.StockCodeDG.Name = "StockCodeDG"
        Me.StockCodeDG.ReadOnly = True
        '
        'GarmentsDG
        '
        Me.GarmentsDG.HeaderText = "Garments"
        Me.GarmentsDG.Name = "GarmentsDG"
        Me.GarmentsDG.ReadOnly = True
        '
        'dgvStock
        '
        Me.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStock.Location = New System.Drawing.Point(344, 344)
        Me.dgvStock.Name = "dgvStock"
        Me.dgvStock.Size = New System.Drawing.Size(240, 150)
        Me.dgvStock.TabIndex = 83
        Me.dgvStock.Visible = False
        '
        'dgvShops
        '
        Me.dgvShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShops.Location = New System.Drawing.Point(325, 344)
        Me.dgvShops.Name = "dgvShops"
        Me.dgvShops.Size = New System.Drawing.Size(240, 150)
        Me.dgvShops.TabIndex = 82
        Me.dgvShops.Visible = False
        '
        'TextBox24
        '
        Me.TextBox24.Location = New System.Drawing.Point(469, 512)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(100, 20)
        Me.TextBox24.TabIndex = 80
        Me.TextBox24.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label21.Location = New System.Drawing.Point(334, 278)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 74
        Me.Label21.Text = "Stock Code"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label22.Location = New System.Drawing.Point(453, 280)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 75
        Me.Label22.Text = "Qty Garments"
        '
        'cmdFindWarehouse
        '
        Me.cmdFindWarehouse.Location = New System.Drawing.Point(486, 220)
        Me.cmdFindWarehouse.Name = "cmdFindWarehouse"
        Me.cmdFindWarehouse.Size = New System.Drawing.Size(27, 23)
        Me.cmdFindWarehouse.TabIndex = 78
        Me.cmdFindWarehouse.Text = "..."
        Me.cmdFindWarehouse.UseVisualStyleBackColor = True
        Me.cmdFindWarehouse.Visible = False
        '
        'cmdFindStockCode
        '
        Me.cmdFindStockCode.Location = New System.Drawing.Point(413, 296)
        Me.cmdFindStockCode.Name = "cmdFindStockCode"
        Me.cmdFindStockCode.Size = New System.Drawing.Size(34, 23)
        Me.cmdFindStockCode.TabIndex = 81
        Me.cmdFindStockCode.Text = "..."
        Me.cmdFindStockCode.UseVisualStyleBackColor = True
        Me.cmdFindStockCode.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(541, 592)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Needs coding"
        Me.Label7.Visible = False
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(549, 296)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(24, 23)
        Me.cmdClear.TabIndex = 58
        Me.cmdClear.Text = "-"
        Me.cmdClear.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdFindSupplier
        '
        Me.cmdFindSupplier.Location = New System.Drawing.Point(490, 166)
        Me.cmdFindSupplier.Name = "cmdFindSupplier"
        Me.cmdFindSupplier.Size = New System.Drawing.Size(26, 23)
        Me.cmdFindSupplier.TabIndex = 77
        Me.cmdFindSupplier.Text = "..."
        Me.cmdFindSupplier.UseVisualStyleBackColor = True
        Me.cmdFindSupplier.Visible = False
        '
        'cmdAddItem
        '
        Me.cmdAddItem.Location = New System.Drawing.Point(525, 296)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(24, 23)
        Me.cmdAddItem.TabIndex = 57
        Me.cmdAddItem.Text = "+"
        Me.cmdAddItem.UseVisualStyleBackColor = True
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(327, 296)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(80, 20)
        Me.txtStockCode.TabIndex = 55
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label16.Location = New System.Drawing.Point(341, 176)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "Shop Ref:"
        '
        'txtQtyHangers
        '
        Me.txtQtyHangers.Location = New System.Drawing.Point(449, 298)
        Me.txtQtyHangers.Name = "txtQtyHangers"
        Me.txtQtyHangers.Size = New System.Drawing.Size(70, 20)
        Me.txtQtyHangers.TabIndex = 56
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(325, 200)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 70
        Me.Label17.Text = "Shop Name:"
        '
        'txtWarehouseRef
        '
        Me.txtWarehouseRef.Location = New System.Drawing.Point(405, 222)
        Me.txtWarehouseRef.Name = "txtWarehouseRef"
        Me.txtWarehouseRef.Size = New System.Drawing.Size(79, 20)
        Me.txtWarehouseRef.TabIndex = 59
        Me.txtWarehouseRef.Text = "Universal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(309, 584)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Deliveries into Shops"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(404, 107)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(126, 20)
        Me.DateTimePicker1.TabIndex = 52
        '
        'txtWarehouseName
        '
        Me.txtWarehouseName.Location = New System.Drawing.Point(404, 254)
        Me.txtWarehouseName.Name = "txtWarehouseName"
        Me.txtWarehouseName.Size = New System.Drawing.Size(169, 20)
        Me.txtWarehouseName.TabIndex = 76
        Me.txtWarehouseName.Text = "Universal Warehouse"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(373, 560)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Total Garments:"
        '
        'txtShopRef
        '
        Me.txtShopRef.Location = New System.Drawing.Point(405, 168)
        Me.txtShopRef.Name = "txtShopRef"
        Me.txtShopRef.Size = New System.Drawing.Size(79, 20)
        Me.txtShopRef.TabIndex = 54
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(429, 536)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 20)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Delivery Totals:"
        '
        'txtShopName
        '
        Me.txtShopName.Location = New System.Drawing.Point(405, 194)
        Me.txtShopName.Name = "txtShopName"
        Me.txtShopName.Size = New System.Drawing.Size(168, 20)
        Me.txtShopName.TabIndex = 73
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.Location = New System.Drawing.Point(309, 224)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 13)
        Me.Label18.TabIndex = 71
        Me.Label18.Text = "Warehouse Ref:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(306, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Delivery Note No:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(320, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Delivery Date:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(301, 256)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 72
        Me.Label20.Text = "Warehouse Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(334, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Reference:"
        '
        'txtTotalGarments
        '
        Me.txtTotalGarments.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTotalGarments.Location = New System.Drawing.Point(469, 560)
        Me.txtTotalGarments.Name = "txtTotalGarments"
        Me.txtTotalGarments.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalGarments.TabIndex = 61
        '
        'txtDelNoteNumber
        '
        Me.txtDelNoteNumber.Location = New System.Drawing.Point(408, 138)
        Me.txtDelNoteNumber.Name = "txtDelNoteNumber"
        Me.txtDelNoteNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtDelNoteNumber.TabIndex = 53
        '
        'txtReference
        '
        Me.txtReference.BackColor = System.Drawing.SystemColors.Window
        Me.txtReference.Enabled = False
        Me.txtReference.Location = New System.Drawing.Point(404, 76)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(100, 20)
        Me.txtReference.TabIndex = 60
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Location = New System.Drawing.Point(129, 529)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearForm.TabIndex = 86
        Me.cmdClearForm.Text = "Clear"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(129, 500)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 85
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(129, 471)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 84
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'FShopDeliveries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 680)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dgvStock)
        Me.Controls.Add(Me.dgvShops)
        Me.Controls.Add(Me.TextBox24)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cmdFindWarehouse)
        Me.Controls.Add(Me.cmdFindStockCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdFindSupplier)
        Me.Controls.Add(Me.cmdAddItem)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtQtyHangers)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtWarehouseRef)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.txtWarehouseName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtShopRef)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtShopName)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalGarments)
        Me.Controls.Add(Me.txtDelNoteNumber)
        Me.Controls.Add(Me.txtReference)
        Me.Name = "FShopDeliveries"
        Me.Text = "FShopDeliveries"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShops, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents StockCodeDG As DataGridViewTextBoxColumn
    Friend WithEvents GarmentsDG As DataGridViewTextBoxColumn
    Friend WithEvents dgvStock As DataGridView
    Friend WithEvents dgvShops As DataGridView
    Friend WithEvents TextBox24 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents cmdFindWarehouse As Button
    Friend WithEvents cmdFindStockCode As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdFindSupplier As Button
    Friend WithEvents cmdAddItem As Button
    Friend WithEvents txtStockCode As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtQtyHangers As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtWarehouseRef As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents txtWarehouseName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtShopRef As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtShopName As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotalGarments As TextBox
    Friend WithEvents txtDelNoteNumber As TextBox
    Friend WithEvents txtReference As TextBox
    Friend WithEvents cmdClearForm As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdAdd As Button
End Class
