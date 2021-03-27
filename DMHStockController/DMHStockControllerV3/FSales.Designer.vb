<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSales
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
        Me.components = New System.ComponentModel.Container()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSoldToDate = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCurrentQty = New System.Windows.Forms.TextBox()
        Me.txtDelivered = New System.Windows.Forms.TextBox()
        Me.cmdClearGrid = New System.Windows.Forms.Button()
        Me.cmdAddToGrid = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNetSale = New System.Windows.Forms.TextBox()
        Me.chkShowAll = New System.Windows.Forms.CheckBox()
        Me.cmdFindStock = New System.Windows.Forms.Button()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cmdFindShop = New System.Windows.Forms.Button()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.txtTotalDelivered = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalSold = New System.Windows.Forms.TextBox()
        Me.txtTotalCurrQty = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtShopRef = New System.Windows.Forms.TextBox()
        Me.txtTotalGarments = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.txtNet = New System.Windows.Forms.TextBox()
        Me.txtVATRate = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtSalesID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "qrySalesGrid"
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(232, 96)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(88, 21)
        Me.ComboBox1.TabIndex = 74
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(440, 82)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(28, 13)
        Me.Label20.TabIndex = 120
        Me.Label20.Text = "Sold"
        Me.Label20.Visible = False
        '
        'txtSoldToDate
        '
        Me.txtSoldToDate.Location = New System.Drawing.Point(440, 96)
        Me.txtSoldToDate.Name = "txtSoldToDate"
        Me.txtSoldToDate.Size = New System.Drawing.Size(56, 20)
        Me.txtSoldToDate.TabIndex = 119
        Me.txtSoldToDate.TabStop = False
        Me.txtSoldToDate.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(353, 82)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 118
        Me.Label19.Text = "Delivered"
        Me.Label19.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(509, 82)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 117
        Me.Label18.Text = "Current Qty"
        Me.Label18.Visible = False
        '
        'txtCurrentQty
        '
        Me.txtCurrentQty.Location = New System.Drawing.Point(509, 96)
        Me.txtCurrentQty.Name = "txtCurrentQty"
        Me.txtCurrentQty.Size = New System.Drawing.Size(87, 20)
        Me.txtCurrentQty.TabIndex = 116
        Me.txtCurrentQty.TabStop = False
        '
        'txtDelivered
        '
        Me.txtDelivered.Location = New System.Drawing.Point(353, 96)
        Me.txtDelivered.Name = "txtDelivered"
        Me.txtDelivered.Size = New System.Drawing.Size(75, 20)
        Me.txtDelivered.TabIndex = 115
        Me.txtDelivered.TabStop = False
        Me.txtDelivered.Text = "0"
        Me.txtDelivered.Visible = False
        '
        'cmdClearGrid
        '
        Me.cmdClearGrid.Location = New System.Drawing.Point(824, 151)
        Me.cmdClearGrid.Name = "cmdClearGrid"
        Me.cmdClearGrid.Size = New System.Drawing.Size(75, 24)
        Me.cmdClearGrid.TabIndex = 78
        Me.cmdClearGrid.Text = "Clear"
        Me.cmdClearGrid.UseVisualStyleBackColor = True
        '
        'cmdAddToGrid
        '
        Me.cmdAddToGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.cmdAddToGrid.Location = New System.Drawing.Point(824, 211)
        Me.cmdAddToGrid.Name = "cmdAddToGrid"
        Me.cmdAddToGrid.Size = New System.Drawing.Size(75, 24)
        Me.cmdAddToGrid.TabIndex = 77
        Me.cmdAddToGrid.Text = "Add"
        Me.cmdAddToGrid.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label17.Location = New System.Drawing.Point(424, 7)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(224, 24)
        Me.Label17.TabIndex = 114
        '
        'txtNetSale
        '
        Me.txtNetSale.Location = New System.Drawing.Point(694, 96)
        Me.txtNetSale.Name = "txtNetSale"
        Me.txtNetSale.Size = New System.Drawing.Size(92, 20)
        Me.txtNetSale.TabIndex = 76
        Me.txtNetSale.Visible = False
        '
        'chkShowAll
        '
        Me.chkShowAll.AutoSize = True
        Me.chkShowAll.Location = New System.Drawing.Point(432, 39)
        Me.chkShowAll.Name = "chkShowAll"
        Me.chkShowAll.Size = New System.Drawing.Size(67, 17)
        Me.chkShowAll.TabIndex = 95
        Me.chkShowAll.Text = "Show All"
        Me.chkShowAll.UseVisualStyleBackColor = True
        '
        'cmdFindStock
        '
        Me.cmdFindStock.Location = New System.Drawing.Point(840, 241)
        Me.cmdFindStock.Name = "cmdFindStock"
        Me.cmdFindStock.Size = New System.Drawing.Size(24, 24)
        Me.cmdFindStock.TabIndex = 93
        Me.cmdFindStock.Text = "..."
        Me.cmdFindStock.UseVisualStyleBackColor = True
        Me.cmdFindStock.Visible = False
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(605, 96)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(83, 20)
        Me.txtQty.TabIndex = 75
        Me.txtQty.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(694, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Net Sale:"
        Me.Label14.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(40, 327)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(152, 13)
        Me.Label16.TabIndex = 113
        Me.Label16.Text = "Needs View and Totals coding"
        Me.Label16.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(605, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Quantity"
        Me.Label13.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(190, 113)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 112
        Me.Label15.Text = "%"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(223, 147)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(554, 150)
        Me.DataGridView1.TabIndex = 84
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(105, 43)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(119, 20)
        Me.DateTimePicker1.TabIndex = 79
        '
        'cmdFindShop
        '
        Me.cmdFindShop.Location = New System.Drawing.Point(840, 181)
        Me.cmdFindShop.Name = "cmdFindShop"
        Me.cmdFindShop.Size = New System.Drawing.Size(24, 24)
        Me.cmdFindShop.TabIndex = 111
        Me.cmdFindShop.Text = "..."
        Me.cmdFindShop.UseVisualStyleBackColor = True
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(232, 96)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(88, 20)
        Me.txtStockCode.TabIndex = 89
        Me.txtStockCode.TabStop = False
        Me.txtStockCode.Visible = False
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(555, 362)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 83
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'txtTotalDelivered
        '
        Me.txtTotalDelivered.Enabled = False
        Me.txtTotalDelivered.Location = New System.Drawing.Point(336, 303)
        Me.txtTotalDelivered.Name = "txtTotalDelivered"
        Me.txtTotalDelivered.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalDelivered.TabIndex = 90
        Me.txtTotalDelivered.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(232, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 86
        Me.Label12.Text = "Stock Code:"
        Me.Label12.Visible = False
        '
        'txtTotalSold
        '
        Me.txtTotalSold.Enabled = False
        Me.txtTotalSold.Location = New System.Drawing.Point(424, 303)
        Me.txtTotalSold.Name = "txtTotalSold"
        Me.txtTotalSold.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalSold.TabIndex = 91
        Me.txtTotalSold.Visible = False
        '
        'txtTotalCurrQty
        '
        Me.txtTotalCurrQty.Enabled = False
        Me.txtTotalCurrQty.Location = New System.Drawing.Point(512, 303)
        Me.txtTotalCurrQty.Name = "txtTotalCurrQty"
        Me.txtTotalCurrQty.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalCurrQty.TabIndex = 92
        Me.txtTotalCurrQty.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(474, 362)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 82
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(393, 362)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 81
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtShopRef
        '
        Me.txtShopRef.Location = New System.Drawing.Point(312, 7)
        Me.txtShopRef.Name = "txtShopRef"
        Me.txtShopRef.Size = New System.Drawing.Size(88, 20)
        Me.txtShopRef.TabIndex = 73
        '
        'txtTotalGarments
        '
        Me.txtTotalGarments.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtTotalGarments.Location = New System.Drawing.Point(105, 293)
        Me.txtTotalGarments.Name = "txtTotalGarments"
        Me.txtTotalGarments.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalGarments.TabIndex = 110
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(256, 303)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 85
        Me.Label11.Text = "Totals:"
        Me.Label11.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtTotal.Location = New System.Drawing.Point(105, 241)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 109
        Me.txtTotal.TabStop = False
        '
        'txtVAT
        '
        Me.txtVAT.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtVAT.Location = New System.Drawing.Point(105, 215)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(100, 20)
        Me.txtVAT.TabIndex = 108
        Me.txtVAT.TabStop = False
        '
        'txtNet
        '
        Me.txtNet.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtNet.Location = New System.Drawing.Point(105, 189)
        Me.txtNet.Name = "txtNet"
        Me.txtNet.Size = New System.Drawing.Size(100, 20)
        Me.txtNet.TabIndex = 107
        Me.txtNet.TabStop = False
        '
        'txtVATRate
        '
        Me.txtVATRate.Location = New System.Drawing.Point(105, 111)
        Me.txtVATRate.Name = "txtVATRate"
        Me.txtVATRate.Size = New System.Drawing.Size(79, 20)
        Me.txtVATRate.TabIndex = 80
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TextBox2.Location = New System.Drawing.Point(105, 75)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 106
        Me.TextBox2.TabStop = False
        '
        'txtSalesID
        '
        Me.txtSalesID.BackColor = System.Drawing.Color.White
        Me.txtSalesID.Location = New System.Drawing.Point(105, 11)
        Me.txtSalesID.Name = "txtSalesID"
        Me.txtSalesID.Size = New System.Drawing.Size(100, 20)
        Me.txtSalesID.TabIndex = 105
        Me.txtSalesID.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label10.Location = New System.Drawing.Point(248, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 104
        Me.Label10.Text = "Shop Ref:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "Total Garments:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 102
        Me.Label8.Text = "Total:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "VAT:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "Net:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(48, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 20)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Sales Totals:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "VAT Rate:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Reference:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Transaction Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Sales ID:"
        '
        'FSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 450)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtSoldToDate)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtCurrentQty)
        Me.Controls.Add(Me.txtDelivered)
        Me.Controls.Add(Me.cmdClearGrid)
        Me.Controls.Add(Me.cmdAddToGrid)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtNetSale)
        Me.Controls.Add(Me.chkShowAll)
        Me.Controls.Add(Me.cmdFindStock)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.cmdFindShop)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.txtTotalDelivered)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTotalSold)
        Me.Controls.Add(Me.txtTotalCurrQty)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtShopRef)
        Me.Controls.Add(Me.txtTotalGarments)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtVAT)
        Me.Controls.Add(Me.txtNet)
        Me.Controls.Add(Me.txtVATRate)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.txtSalesID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FSales"
        Me.Text = "FSales"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtSoldToDate As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCurrentQty As TextBox
    Friend WithEvents txtDelivered As TextBox
    Friend WithEvents cmdClearGrid As Button
    Friend WithEvents cmdAddToGrid As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNetSale As TextBox
    Friend WithEvents chkShowAll As CheckBox
    Friend WithEvents cmdFindStock As Button
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents cmdFindShop As Button
    Friend WithEvents txtStockCode As TextBox
    Friend WithEvents cmdClear As Button
    Friend WithEvents txtTotalDelivered As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTotalSold As TextBox
    Friend WithEvents txtTotalCurrQty As TextBox
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOK As Button
    Friend WithEvents txtShopRef As TextBox
    Friend WithEvents txtTotalGarments As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtVAT As TextBox
    Friend WithEvents txtNet As TextBox
    Friend WithEvents txtVATRate As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents txtSalesID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
