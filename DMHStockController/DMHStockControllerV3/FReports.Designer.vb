<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FReports
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Deliveries By Stock Code")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock List By Shop")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock List By Stock Code")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Total Stock Valuation")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("All Stock Movements")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Warehouse Stock List")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stock", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales History")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Analysis")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9})
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSeasons = New System.Windows.Forms.ComboBox()
        Me.cboStockDesc = New System.Windows.Forms.ComboBox()
        Me.cboStockAsc = New System.Windows.Forms.ComboBox()
        Me.cboSupplierDesc = New System.Windows.Forms.ComboBox()
        Me.cboSupplierAsc = New System.Windows.Forms.ComboBox()
        Me.cboShopDesc = New System.Windows.Forms.ComboBox()
        Me.cboShopAsc = New System.Windows.Forms.ComboBox()
        Me.cboWarehouseDes = New System.Windows.Forms.ComboBox()
        Me.cboWarehouseAsc = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.twvReports = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(290, 409)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Needs coding"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(591, 397)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 75
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(510, 397)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 74
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(429, 397)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton2.Location = New System.Drawing.Point(544, 127)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton2.TabIndex = 72
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Concessions"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(483, 127)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton1.TabIndex = 71
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Shops"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(414, 354)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Season:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(414, 271)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Stock Range:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(414, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "Supplier Range:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(635, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = ")"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(474, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "("
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(414, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Shop Range:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(414, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Warehouse Range:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(414, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Date Range:"
        '
        'cboSeasons
        '
        Me.cboSeasons.FormattingEnabled = True
        Me.cboSeasons.Location = New System.Drawing.Point(417, 370)
        Me.cboSeasons.Name = "cboSeasons"
        Me.cboSeasons.Size = New System.Drawing.Size(248, 21)
        Me.cboSeasons.TabIndex = 62
        '
        'cboStockDesc
        '
        Me.cboStockDesc.FormattingEnabled = True
        Me.cboStockDesc.Location = New System.Drawing.Point(417, 314)
        Me.cboStockDesc.Name = "cboStockDesc"
        Me.cboStockDesc.Size = New System.Drawing.Size(248, 21)
        Me.cboStockDesc.TabIndex = 61
        '
        'cboStockAsc
        '
        Me.cboStockAsc.FormattingEnabled = True
        Me.cboStockAsc.Location = New System.Drawing.Point(417, 287)
        Me.cboStockAsc.Name = "cboStockAsc"
        Me.cboStockAsc.Size = New System.Drawing.Size(248, 21)
        Me.cboStockAsc.TabIndex = 60
        '
        'cboSupplierDesc
        '
        Me.cboSupplierDesc.FormattingEnabled = True
        Me.cboSupplierDesc.Location = New System.Drawing.Point(417, 235)
        Me.cboSupplierDesc.Name = "cboSupplierDesc"
        Me.cboSupplierDesc.Size = New System.Drawing.Size(248, 21)
        Me.cboSupplierDesc.TabIndex = 59
        '
        'cboSupplierAsc
        '
        Me.cboSupplierAsc.FormattingEnabled = True
        Me.cboSupplierAsc.Location = New System.Drawing.Point(417, 208)
        Me.cboSupplierAsc.Name = "cboSupplierAsc"
        Me.cboSupplierAsc.Size = New System.Drawing.Size(248, 21)
        Me.cboSupplierAsc.TabIndex = 58
        '
        'cboShopDesc
        '
        Me.cboShopDesc.FormattingEnabled = True
        Me.cboShopDesc.Location = New System.Drawing.Point(544, 147)
        Me.cboShopDesc.Name = "cboShopDesc"
        Me.cboShopDesc.Size = New System.Drawing.Size(121, 21)
        Me.cboShopDesc.TabIndex = 57
        '
        'cboShopAsc
        '
        Me.cboShopAsc.FormattingEnabled = True
        Me.cboShopAsc.Location = New System.Drawing.Point(417, 147)
        Me.cboShopAsc.Name = "cboShopAsc"
        Me.cboShopAsc.Size = New System.Drawing.Size(121, 21)
        Me.cboShopAsc.TabIndex = 56
        '
        'cboWarehouseDes
        '
        Me.cboWarehouseDes.FormattingEnabled = True
        Me.cboWarehouseDes.Location = New System.Drawing.Point(544, 95)
        Me.cboWarehouseDes.Name = "cboWarehouseDes"
        Me.cboWarehouseDes.Size = New System.Drawing.Size(121, 21)
        Me.cboWarehouseDes.TabIndex = 55
        '
        'cboWarehouseAsc
        '
        Me.cboWarehouseAsc.FormattingEnabled = True
        Me.cboWarehouseAsc.Location = New System.Drawing.Point(417, 95)
        Me.cboWarehouseAsc.Name = "cboWarehouseAsc"
        Me.cboWarehouseAsc.Size = New System.Drawing.Size(121, 21)
        Me.cboWarehouseAsc.TabIndex = 54
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarMonthBackground = System.Drawing.SystemColors.Menu
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(544, 46)
        Me.DateTimePicker2.MaxDate = New Date(2045, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker2.TabIndex = 53
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Menu
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(417, 46)
        Me.DateTimePicker1.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker1.TabIndex = 52
        '
        'twvReports
        '
        Me.twvReports.FullRowSelect = True
        Me.twvReports.Location = New System.Drawing.Point(134, 29)
        Me.twvReports.Name = "twvReports"
        TreeNode1.Name = "Node6"
        TreeNode1.Text = "Deliveries By Stock Code"
        TreeNode2.Name = "Node7"
        TreeNode2.Text = "Stock List By Shop"
        TreeNode3.Name = "Node8"
        TreeNode3.Text = "Stock List By Stock Code"
        TreeNode4.Name = "Node9"
        TreeNode4.Text = "Total Stock Valuation"
        TreeNode5.Name = "Node10"
        TreeNode5.Text = "All Stock Movements"
        TreeNode6.Name = "Node11"
        TreeNode6.Text = "Warehouse Stock List"
        TreeNode7.Name = "Node1"
        TreeNode7.Text = "Stock"
        TreeNode8.Name = "Node12"
        TreeNode8.Text = "Sales History"
        TreeNode9.Name = "Node13"
        TreeNode9.Text = "Sales Analysis"
        TreeNode10.Name = "Node2"
        TreeNode10.Text = "Sales"
        Me.twvReports.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode10})
        Me.twvReports.Size = New System.Drawing.Size(262, 362)
        Me.twvReports.TabIndex = 51
        '
        'FReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSeasons)
        Me.Controls.Add(Me.cboStockDesc)
        Me.Controls.Add(Me.cboStockAsc)
        Me.Controls.Add(Me.cboSupplierDesc)
        Me.Controls.Add(Me.cboSupplierAsc)
        Me.Controls.Add(Me.cboShopDesc)
        Me.Controls.Add(Me.cboShopAsc)
        Me.Controls.Add(Me.cboWarehouseDes)
        Me.Controls.Add(Me.cboWarehouseAsc)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.twvReports)
        Me.Name = "FReports"
        Me.Text = "FReports"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSeasons As ComboBox
    Friend WithEvents cboStockDesc As ComboBox
    Friend WithEvents cboStockAsc As ComboBox
    Friend WithEvents cboSupplierDesc As ComboBox
    Friend WithEvents cboSupplierAsc As ComboBox
    Friend WithEvents cboShopDesc As ComboBox
    Friend WithEvents cboShopAsc As ComboBox
    Friend WithEvents cboWarehouseDes As ComboBox
    Friend WithEvents cboWarehouseAsc As ComboBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents twvReports As TreeView
End Class
