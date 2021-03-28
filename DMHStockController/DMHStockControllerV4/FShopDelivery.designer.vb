<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FShopDelivery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FShopDelivery))
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.StockCodeDG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GarmentsDG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValueCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdClearForm = New System.Windows.Forms.Button()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.txtWarehouseRef = New System.Windows.Forms.TextBox()
        Me.cmdAddItem = New System.Windows.Forms.Button()
        Me.txtQtyHangers = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
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
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Deliverlabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtQty
        '
        Me.txtQty.Enabled = False
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.ForeColor = System.Drawing.Color.Red
        Me.txtQty.Location = New System.Drawing.Point(180, 191)
        Me.txtQty.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(115, 22)
        Me.txtQty.TabIndex = 23
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StockCodeDG, Me.GarmentsDG, Me.ValueCol})
        Me.DataGridView1.Location = New System.Drawing.Point(21, 258)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(409, 252)
        Me.DataGridView1.TabIndex = 25
        '
        'StockCodeDG
        '
        Me.StockCodeDG.HeaderText = "Stock Code"
        Me.StockCodeDG.Name = "StockCodeDG"
        '
        'GarmentsDG
        '
        Me.GarmentsDG.HeaderText = "Garments"
        Me.GarmentsDG.Name = "GarmentsDG"
        '
        'ValueCol
        '
        Me.ValueCol.HeaderText = "Value"
        Me.ValueCol.Name = "ValueCol"
        Me.ValueCol.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(176, 171)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 16)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Warehouse Qty"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label21.Location = New System.Drawing.Point(21, 171)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 16)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Stock Code"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label22.Location = New System.Drawing.Point(302, 171)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 16)
        Me.Label22.TabIndex = 24
        Me.Label22.Text = "Delivery Qty"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(374, 221)
        Me.cmdClear.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(36, 28)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "-"
        Me.cmdClear.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Location = New System.Drawing.Point(318, 568)
        Me.cmdClearForm.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(112, 28)
        Me.cmdClearForm.TabIndex = 9
        Me.cmdClearForm.Text = "Clear"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(21, 191)
        Me.txtStockCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStockCode.MaxLength = 30
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(149, 22)
        Me.txtStockCode.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label16.Location = New System.Drawing.Point(18, 59)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 16)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Shop Ref:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(141, 59)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 16)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Shop Name:"
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(74, 568)
        Me.cmdAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(112, 28)
        Me.cmdAdd.TabIndex = 7
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtWarehouseRef
        '
        Me.txtWarehouseRef.Enabled = False
        Me.txtWarehouseRef.Location = New System.Drawing.Point(21, 127)
        Me.txtWarehouseRef.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWarehouseRef.Name = "txtWarehouseRef"
        Me.txtWarehouseRef.Size = New System.Drawing.Size(84, 22)
        Me.txtWarehouseRef.TabIndex = 14
        Me.txtWarehouseRef.Text = "UNI"
        '
        'cmdAddItem
        '
        Me.cmdAddItem.Location = New System.Drawing.Point(338, 221)
        Me.cmdAddItem.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(36, 28)
        Me.cmdAddItem.TabIndex = 5
        Me.cmdAddItem.Text = "+"
        Me.cmdAddItem.UseVisualStyleBackColor = True
        '
        'txtQtyHangers
        '
        Me.txtQtyHangers.Location = New System.Drawing.Point(306, 191)
        Me.txtQtyHangers.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQtyHangers.Name = "txtQtyHangers"
        Me.txtQtyHangers.Size = New System.Drawing.Size(103, 22)
        Me.txtQtyHangers.TabIndex = 4
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(196, 568)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 28)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(117, 31)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(133, 22)
        Me.DateTimePicker1.TabIndex = 0
        '
        'txtWarehouseName
        '
        Me.txtWarehouseName.Enabled = False
        Me.txtWarehouseName.Location = New System.Drawing.Point(113, 127)
        Me.txtWarehouseName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWarehouseName.Name = "txtWarehouseName"
        Me.txtWarehouseName.Size = New System.Drawing.Size(252, 22)
        Me.txtWarehouseName.TabIndex = 20
        Me.txtWarehouseName.Text = "Universal Warehouse"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(66, 543)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Total Garments:"
        '
        'txtShopRef
        '
        Me.txtShopRef.Location = New System.Drawing.Point(24, 79)
        Me.txtShopRef.Margin = New System.Windows.Forms.Padding(4)
        Me.txtShopRef.MaxLength = 8
        Me.txtShopRef.Name = "txtShopRef"
        Me.txtShopRef.Size = New System.Drawing.Size(81, 22)
        Me.txtShopRef.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(173, 514)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Delivery Total:"
        '
        'txtShopName
        '
        Me.txtShopName.Location = New System.Drawing.Point(113, 79)
        Me.txtShopName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtShopName.Name = "txtShopName"
        Me.txtShopName.Size = New System.Drawing.Size(293, 22)
        Me.txtShopName.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.Location = New System.Drawing.Point(20, 107)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 16)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "Warehouse Ref:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(254, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Delivery Note No:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(113, 7)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Delivery Date:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(147, 107)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(136, 16)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Warehouse Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Record No:"
        '
        'txtTotalGarments
        '
        Me.txtTotalGarments.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTotalGarments.Location = New System.Drawing.Point(270, 538)
        Me.txtTotalGarments.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalGarments.Name = "txtTotalGarments"
        Me.txtTotalGarments.Size = New System.Drawing.Size(148, 22)
        Me.txtTotalGarments.TabIndex = 28
        '
        'txtDelNoteNumber
        '
        Me.txtDelNoteNumber.Location = New System.Drawing.Point(21, 31)
        Me.txtDelNoteNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDelNoteNumber.Name = "txtDelNoteNumber"
        Me.txtDelNoteNumber.Size = New System.Drawing.Size(84, 22)
        Me.txtDelNoteNumber.TabIndex = 11
        '
        'txtReference
        '
        Me.txtReference.BackColor = System.Drawing.SystemColors.Window
        Me.txtReference.Location = New System.Drawing.Point(258, 31)
        Me.txtReference.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReference.MaxLength = 90
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(148, 22)
        Me.txtReference.TabIndex = 1
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(97, 17)
        Me.ToolStripStatusLabel1.Text = "Delivery Lines :    "
        '
        'Deliverlabel
        '
        Me.Deliverlabel.Name = "Deliverlabel"
        Me.Deliverlabel.Size = New System.Drawing.Size(120, 17)
        Me.Deliverlabel.Text = "ToolStripStatusLabel2"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.Deliverlabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 618)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(446, 22)
        Me.StatusStrip1.TabIndex = 29
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'FShopDelivery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 640)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtWarehouseRef)
        Me.Controls.Add(Me.cmdAddItem)
        Me.Controls.Add(Me.txtQtyHangers)
        Me.Controls.Add(Me.cmdCancel)
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
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FShopDelivery"
        Me.Text = "Shop Delivery"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtQty As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents StockCodeDG As DataGridViewTextBoxColumn
    Friend WithEvents GarmentsDG As DataGridViewTextBoxColumn
    Friend WithEvents ValueCol As DataGridViewTextBoxColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdClearForm As Button
    Friend WithEvents txtStockCode As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents cmdAdd As Button
    Friend WithEvents txtWarehouseRef As TextBox
    Friend WithEvents cmdAddItem As Button
    Friend WithEvents txtQtyHangers As TextBox
    Friend WithEvents cmdCancel As Button
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
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Deliverlabel As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
End Class
