<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPurchaseOrders
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
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.txtWarehouseName = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtQtyGarments = New System.Windows.Forms.TextBox()
        Me.cmdFindWarehouse = New System.Windows.Forms.Button()
        Me.cmdFindStockCode = New System.Windows.Forms.Button()
        Me.DGVStock = New System.Windows.Forms.DataGridView()
        Me.DGVSupplier = New System.Windows.Forms.DataGridView()
        Me.cmdFindSupplier = New System.Windows.Forms.Button()
        Me.txtNetCost = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DGVWarehouse = New System.Windows.Forms.DataGridView()
        Me.txtOurRef = New System.Windows.Forms.TextBox()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.txtSupplierInv = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.txtShipper = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtShipperInv = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtOrderID = New System.Windows.Forms.TextBox()
        Me.txtTotalGarments = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtCommission = New System.Windows.Forms.TextBox()
        Me.txtDelCharges = New System.Windows.Forms.TextBox()
        Me.txtTotalNet = New System.Windows.Forms.TextBox()
        Me.txtWarehouseRef = New System.Windows.Forms.TextBox()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.txtSupplierRef = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DGVStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVWarehouse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox2.Location = New System.Drawing.Point(485, 167)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox2.TabIndex = 151
        Me.CheckBox2.Text = "Consessions"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'txtWarehouseName
        '
        Me.txtWarehouseName.Location = New System.Drawing.Point(456, 260)
        Me.txtWarehouseName.Name = "txtWarehouseName"
        Me.txtWarehouseName.Size = New System.Drawing.Size(104, 20)
        Me.txtWarehouseName.TabIndex = 142
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox1.Location = New System.Drawing.Point(370, 167)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(98, 17)
        Me.CheckBox1.TabIndex = 150
        Me.CheckBox1.Text = "Direct To Shop"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtQtyGarments
        '
        Me.txtQtyGarments.Location = New System.Drawing.Point(456, 356)
        Me.txtQtyGarments.Name = "txtQtyGarments"
        Me.txtQtyGarments.Size = New System.Drawing.Size(104, 20)
        Me.txtQtyGarments.TabIndex = 115
        '
        'cmdFindWarehouse
        '
        Me.cmdFindWarehouse.Location = New System.Drawing.Point(566, 239)
        Me.cmdFindWarehouse.Name = "cmdFindWarehouse"
        Me.cmdFindWarehouse.Size = New System.Drawing.Size(27, 23)
        Me.cmdFindWarehouse.TabIndex = 126
        Me.cmdFindWarehouse.Text = "..."
        Me.cmdFindWarehouse.UseVisualStyleBackColor = True
        '
        'cmdFindStockCode
        '
        Me.cmdFindStockCode.Location = New System.Drawing.Point(566, 333)
        Me.cmdFindStockCode.Name = "cmdFindStockCode"
        Me.cmdFindStockCode.Size = New System.Drawing.Size(27, 23)
        Me.cmdFindStockCode.TabIndex = 129
        Me.cmdFindStockCode.Text = "..."
        Me.cmdFindStockCode.UseVisualStyleBackColor = True
        Me.cmdFindStockCode.Visible = False
        '
        'DGVStock
        '
        Me.DGVStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVStock.Location = New System.Drawing.Point(168, 497)
        Me.DGVStock.Name = "DGVStock"
        Me.DGVStock.Size = New System.Drawing.Size(240, 150)
        Me.DGVStock.TabIndex = 127
        Me.DGVStock.Visible = False
        '
        'DGVSupplier
        '
        Me.DGVSupplier.AllowUserToAddRows = False
        Me.DGVSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSupplier.Location = New System.Drawing.Point(216, 535)
        Me.DGVSupplier.Name = "DGVSupplier"
        Me.DGVSupplier.RowHeadersVisible = False
        Me.DGVSupplier.Size = New System.Drawing.Size(208, 166)
        Me.DGVSupplier.TabIndex = 128
        Me.DGVSupplier.Visible = False
        '
        'cmdFindSupplier
        '
        Me.cmdFindSupplier.Location = New System.Drawing.Point(566, 190)
        Me.cmdFindSupplier.Name = "cmdFindSupplier"
        Me.cmdFindSupplier.Size = New System.Drawing.Size(27, 23)
        Me.cmdFindSupplier.TabIndex = 125
        Me.cmdFindSupplier.Text = "..."
        Me.cmdFindSupplier.UseVisualStyleBackColor = True
        '
        'txtNetCost
        '
        Me.txtNetCost.Location = New System.Drawing.Point(456, 380)
        Me.txtNetCost.Name = "txtNetCost"
        Me.txtNetCost.Size = New System.Drawing.Size(104, 20)
        Me.txtNetCost.TabIndex = 116
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label16.Location = New System.Drawing.Point(361, 194)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 13)
        Me.Label16.TabIndex = 121
        Me.Label16.Text = "Supplier Ref:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label25.Location = New System.Drawing.Point(361, 377)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(48, 13)
        Me.Label25.TabIndex = 109
        Me.Label25.Text = "Net Cost"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(361, 215)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 13)
        Me.Label17.TabIndex = 122
        Me.Label17.Text = "Supplier Name:"
        '
        'DGVWarehouse
        '
        Me.DGVWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVWarehouse.Location = New System.Drawing.Point(258, 551)
        Me.DGVWarehouse.Name = "DGVWarehouse"
        Me.DGVWarehouse.Size = New System.Drawing.Size(240, 150)
        Me.DGVWarehouse.TabIndex = 147
        Me.DGVWarehouse.Visible = False
        '
        'txtOurRef
        '
        Me.txtOurRef.Location = New System.Drawing.Point(456, 284)
        Me.txtOurRef.Name = "txtOurRef"
        Me.txtOurRef.Size = New System.Drawing.Size(104, 20)
        Me.txtOurRef.TabIndex = 108
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(456, 335)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(104, 20)
        Me.txtStockCode.TabIndex = 114
        '
        'txtSupplierInv
        '
        Me.txtSupplierInv.Location = New System.Drawing.Point(706, 266)
        Me.txtSupplierInv.Name = "txtSupplierInv"
        Me.txtSupplierInv.Size = New System.Drawing.Size(121, 20)
        Me.txtSupplierInv.TabIndex = 113
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(361, 312)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(75, 13)
        Me.Label26.TabIndex = 148
        Me.Label26.Text = "Delivery Type:"
        Me.Label26.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label22.Location = New System.Drawing.Point(361, 359)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 105
        Me.Label22.Text = "Qty Garments"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label21.Location = New System.Drawing.Point(361, 338)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 103
        Me.Label21.Text = "Stock Code"
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Expected", "Confirmed"})
        Me.cboType.Location = New System.Drawing.Point(456, 308)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(104, 21)
        Me.cboType.TabIndex = 111
        Me.cboType.Visible = False
        '
        'txtShipper
        '
        Me.txtShipper.Location = New System.Drawing.Point(706, 218)
        Me.txtShipper.Name = "txtShipper"
        Me.txtShipper.Size = New System.Drawing.Size(121, 20)
        Me.txtShipper.TabIndex = 110
        '
        'cmdOK
        '
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(650, 472)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 119
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtShipperInv
        '
        Me.txtShipperInv.Location = New System.Drawing.Point(706, 242)
        Me.txtShipperInv.Name = "txtShipperInv"
        Me.txtShipperInv.Size = New System.Drawing.Size(121, 20)
        Me.txtShipperInv.TabIndex = 112
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.Location = New System.Drawing.Point(361, 242)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 13)
        Me.Label18.TabIndex = 123
        Me.Label18.Text = "Warehouse Ref:"
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(730, 472)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 120
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(706, 170)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker1.TabIndex = 106
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label20.Location = New System.Drawing.Point(361, 263)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 124
        Me.Label20.Text = "Warehouse Name:"
        '
        'txtOrderID
        '
        Me.txtOrderID.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtOrderID.Location = New System.Drawing.Point(706, 194)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.Size = New System.Drawing.Size(121, 20)
        Me.txtOrderID.TabIndex = 146
        '
        'txtTotalGarments
        '
        Me.txtTotalGarments.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtTotalGarments.Location = New System.Drawing.Point(706, 438)
        Me.txtTotalGarments.Name = "txtTotalGarments"
        Me.txtTotalGarments.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalGarments.TabIndex = 145
        Me.txtTotalGarments.Text = "0"
        Me.txtTotalGarments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtTotal.Location = New System.Drawing.Point(706, 407)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 144
        Me.txtTotal.Text = "£0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCommission
        '
        Me.txtCommission.Location = New System.Drawing.Point(706, 383)
        Me.txtCommission.Name = "txtCommission"
        Me.txtCommission.Size = New System.Drawing.Size(100, 20)
        Me.txtCommission.TabIndex = 118
        Me.txtCommission.Text = "£0.00"
        Me.txtCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDelCharges
        '
        Me.txtDelCharges.Location = New System.Drawing.Point(706, 357)
        Me.txtDelCharges.Name = "txtDelCharges"
        Me.txtDelCharges.Size = New System.Drawing.Size(100, 20)
        Me.txtDelCharges.TabIndex = 117
        Me.txtDelCharges.Text = "£0.00"
        Me.txtDelCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNet
        '
        Me.txtTotalNet.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtTotalNet.Location = New System.Drawing.Point(706, 328)
        Me.txtTotalNet.Name = "txtTotalNet"
        Me.txtTotalNet.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalNet.TabIndex = 143
        Me.txtTotalNet.Text = "£0.00"
        Me.txtTotalNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWarehouseRef
        '
        Me.txtWarehouseRef.Location = New System.Drawing.Point(456, 239)
        Me.txtWarehouseRef.Name = "txtWarehouseRef"
        Me.txtWarehouseRef.Size = New System.Drawing.Size(104, 20)
        Me.txtWarehouseRef.TabIndex = 107
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Location = New System.Drawing.Point(456, 212)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(104, 20)
        Me.txtSupplierName.TabIndex = 149
        '
        'txtSupplierRef
        '
        Me.txtSupplierRef.Location = New System.Drawing.Point(456, 191)
        Me.txtSupplierRef.Name = "txtSupplierRef"
        Me.txtSupplierRef.Size = New System.Drawing.Size(104, 20)
        Me.txtSupplierRef.TabIndex = 104
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.Location = New System.Drawing.Point(595, 173)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 141
        Me.Label15.Text = "Order Date:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label13.Location = New System.Drawing.Point(595, 197)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 140
        Me.Label13.Text = "Order No:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(618, 441)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 139
        Me.Label10.Text = "Total Garments:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(666, 414)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 138
        Me.Label9.Text = "Total:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(635, 387)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "Commission:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(610, 363)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "Delivery Charges:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(673, 335)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Net:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(693, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 20)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Order Totals:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(595, 269)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Suppliers Invoice No:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(595, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Shipper Invoice No:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(361, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Our Ref:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(595, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Shipper:"
        '
        'FPurchaseOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 759)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.txtWarehouseName)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txtQtyGarments)
        Me.Controls.Add(Me.cmdFindWarehouse)
        Me.Controls.Add(Me.cmdFindStockCode)
        Me.Controls.Add(Me.DGVStock)
        Me.Controls.Add(Me.DGVSupplier)
        Me.Controls.Add(Me.cmdFindSupplier)
        Me.Controls.Add(Me.txtNetCost)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.DGVWarehouse)
        Me.Controls.Add(Me.txtOurRef)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.txtSupplierInv)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.txtShipper)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtShipperInv)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtOrderID)
        Me.Controls.Add(Me.txtTotalGarments)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtCommission)
        Me.Controls.Add(Me.txtDelCharges)
        Me.Controls.Add(Me.txtTotalNet)
        Me.Controls.Add(Me.txtWarehouseRef)
        Me.Controls.Add(Me.txtSupplierName)
        Me.Controls.Add(Me.txtSupplierRef)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FPurchaseOrders"
        Me.Text = "FPurchaseOrders"
        CType(Me.DGVStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVWarehouse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents txtWarehouseName As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtQtyGarments As TextBox
    Friend WithEvents cmdFindWarehouse As Button
    Friend WithEvents cmdFindStockCode As Button
    Friend WithEvents DGVStock As DataGridView
    Friend WithEvents DGVSupplier As DataGridView
    Friend WithEvents cmdFindSupplier As Button
    Friend WithEvents txtNetCost As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents DGVWarehouse As DataGridView
    Friend WithEvents txtOurRef As TextBox
    Friend WithEvents txtStockCode As TextBox
    Friend WithEvents txtSupplierInv As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents cboType As ComboBox
    Friend WithEvents txtShipper As TextBox
    Friend WithEvents cmdOK As Button
    Friend WithEvents txtShipperInv As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents txtOrderID As TextBox
    Friend WithEvents txtTotalGarments As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtCommission As TextBox
    Friend WithEvents txtDelCharges As TextBox
    Friend WithEvents txtTotalNet As TextBox
    Friend WithEvents txtWarehouseRef As TextBox
    Friend WithEvents txtSupplierName As TextBox
    Friend WithEvents txtSupplierRef As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
