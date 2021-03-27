<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FStock
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
        Dim CreatedDateLabel As System.Windows.Forms.Label
        Dim StockCodeLabel As System.Windows.Forms.Label
        Dim SupplierRefLabel As System.Windows.Forms.Label
        Dim DeadCodeLabel As System.Windows.Forms.Label
        Dim AmountTakenLabel As System.Windows.Forms.Label
        Dim DeliveredQtyHangersLabel As System.Windows.Forms.Label
        Dim CostValueLabel As System.Windows.Forms.Label
        Dim PCMarkUpLabel As System.Windows.Forms.Label
        Dim ZeroQtyLabel As System.Windows.Forms.Label
        Dim CreatedByLabel As System.Windows.Forms.Label
        Me.CreatedByTextBox = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.StockCodeTextBox = New System.Windows.Forms.TextBox()
        Me.SupplierRefTextBox = New System.Windows.Forms.TextBox()
        Me.DeadCodeCheckBox = New System.Windows.Forms.CheckBox()
        Me.AmountTakenTextBox = New System.Windows.Forms.TextBox()
        Me.DeliveredQtyHangersTextBox = New System.Windows.Forms.TextBox()
        Me.CostValueTextBox = New System.Windows.Forms.TextBox()
        Me.PCMarkUpTextBox = New System.Windows.Forms.TextBox()
        Me.ZeroQtyCheckBox = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdFindSupplier = New System.Windows.Forms.Button()
        CreatedDateLabel = New System.Windows.Forms.Label()
        StockCodeLabel = New System.Windows.Forms.Label()
        SupplierRefLabel = New System.Windows.Forms.Label()
        DeadCodeLabel = New System.Windows.Forms.Label()
        AmountTakenLabel = New System.Windows.Forms.Label()
        DeliveredQtyHangersLabel = New System.Windows.Forms.Label()
        CostValueLabel = New System.Windows.Forms.Label()
        PCMarkUpLabel = New System.Windows.Forms.Label()
        ZeroQtyLabel = New System.Windows.Forms.Label()
        CreatedByLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CreatedByTextBox
        '
        Me.CreatedByTextBox.Enabled = False
        Me.CreatedByTextBox.Location = New System.Drawing.Point(343, 294)
        Me.CreatedByTextBox.Name = "CreatedByTextBox"
        Me.CreatedByTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CreatedByTextBox.TabIndex = 107
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(343, 320)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 109
        '
        'CreatedDateLabel
        '
        CreatedDateLabel.AutoSize = True
        CreatedDateLabel.Location = New System.Drawing.Point(264, 326)
        CreatedDateLabel.Name = "CreatedDateLabel"
        CreatedDateLabel.Size = New System.Drawing.Size(73, 13)
        CreatedDateLabel.TabIndex = 108
        CreatedDateLabel.Text = "Created Date:"
        '
        'StockCodeLabel
        '
        StockCodeLabel.AutoSize = True
        StockCodeLabel.Location = New System.Drawing.Point(272, 84)
        StockCodeLabel.Name = "StockCodeLabel"
        StockCodeLabel.Size = New System.Drawing.Size(66, 13)
        StockCodeLabel.TabIndex = 98
        StockCodeLabel.Text = "Stock Code:"
        '
        'StockCodeTextBox
        '
        Me.StockCodeTextBox.Location = New System.Drawing.Point(344, 81)
        Me.StockCodeTextBox.Name = "StockCodeTextBox"
        Me.StockCodeTextBox.Size = New System.Drawing.Size(200, 20)
        Me.StockCodeTextBox.TabIndex = 86
        '
        'SupplierRefLabel
        '
        SupplierRefLabel.AutoSize = True
        SupplierRefLabel.Location = New System.Drawing.Point(270, 110)
        SupplierRefLabel.Name = "SupplierRefLabel"
        SupplierRefLabel.Size = New System.Drawing.Size(68, 13)
        SupplierRefLabel.TabIndex = 99
        SupplierRefLabel.Text = "Supplier Ref:"
        '
        'SupplierRefTextBox
        '
        Me.SupplierRefTextBox.Location = New System.Drawing.Point(344, 107)
        Me.SupplierRefTextBox.Name = "SupplierRefTextBox"
        Me.SupplierRefTextBox.Size = New System.Drawing.Size(200, 20)
        Me.SupplierRefTextBox.TabIndex = 87
        '
        'DeadCodeLabel
        '
        DeadCodeLabel.AutoSize = True
        DeadCodeLabel.Location = New System.Drawing.Point(274, 138)
        DeadCodeLabel.Name = "DeadCodeLabel"
        DeadCodeLabel.Size = New System.Drawing.Size(64, 13)
        DeadCodeLabel.TabIndex = 100
        DeadCodeLabel.Text = "Dead Code:"
        '
        'DeadCodeCheckBox
        '
        Me.DeadCodeCheckBox.Location = New System.Drawing.Point(344, 133)
        Me.DeadCodeCheckBox.Name = "DeadCodeCheckBox"
        Me.DeadCodeCheckBox.Size = New System.Drawing.Size(200, 24)
        Me.DeadCodeCheckBox.TabIndex = 93
        Me.DeadCodeCheckBox.UseVisualStyleBackColor = True
        '
        'AmountTakenLabel
        '
        AmountTakenLabel.AutoSize = True
        AmountTakenLabel.Location = New System.Drawing.Point(257, 163)
        AmountTakenLabel.Name = "AmountTakenLabel"
        AmountTakenLabel.Size = New System.Drawing.Size(80, 13)
        AmountTakenLabel.TabIndex = 101
        AmountTakenLabel.Text = "Amount Taken:"
        '
        'AmountTakenTextBox
        '
        Me.AmountTakenTextBox.Location = New System.Drawing.Point(343, 160)
        Me.AmountTakenTextBox.Name = "AmountTakenTextBox"
        Me.AmountTakenTextBox.Size = New System.Drawing.Size(200, 20)
        Me.AmountTakenTextBox.TabIndex = 88
        '
        'DeliveredQtyHangersLabel
        '
        DeliveredQtyHangersLabel.AutoSize = True
        DeliveredQtyHangersLabel.Location = New System.Drawing.Point(220, 272)
        DeliveredQtyHangersLabel.Name = "DeliveredQtyHangersLabel"
        DeliveredQtyHangersLabel.Size = New System.Drawing.Size(117, 13)
        DeliveredQtyHangersLabel.TabIndex = 102
        DeliveredQtyHangersLabel.Text = "Delivered Qty Hangers:"
        '
        'DeliveredQtyHangersTextBox
        '
        Me.DeliveredQtyHangersTextBox.Location = New System.Drawing.Point(343, 269)
        Me.DeliveredQtyHangersTextBox.Name = "DeliveredQtyHangersTextBox"
        Me.DeliveredQtyHangersTextBox.Size = New System.Drawing.Size(200, 20)
        Me.DeliveredQtyHangersTextBox.TabIndex = 91
        '
        'CostValueLabel
        '
        CostValueLabel.AutoSize = True
        CostValueLabel.Location = New System.Drawing.Point(276, 190)
        CostValueLabel.Name = "CostValueLabel"
        CostValueLabel.Size = New System.Drawing.Size(61, 13)
        CostValueLabel.TabIndex = 103
        CostValueLabel.Text = "Cost Value:"
        '
        'CostValueTextBox
        '
        Me.CostValueTextBox.Location = New System.Drawing.Point(343, 187)
        Me.CostValueTextBox.Name = "CostValueTextBox"
        Me.CostValueTextBox.Size = New System.Drawing.Size(200, 20)
        Me.CostValueTextBox.TabIndex = 89
        '
        'PCMarkUpLabel
        '
        PCMarkUpLabel.AutoSize = True
        PCMarkUpLabel.Location = New System.Drawing.Point(272, 216)
        PCMarkUpLabel.Name = "PCMarkUpLabel"
        PCMarkUpLabel.Size = New System.Drawing.Size(65, 13)
        PCMarkUpLabel.TabIndex = 104
        PCMarkUpLabel.Text = "PCMark Up:"
        '
        'PCMarkUpTextBox
        '
        Me.PCMarkUpTextBox.Location = New System.Drawing.Point(343, 213)
        Me.PCMarkUpTextBox.Name = "PCMarkUpTextBox"
        Me.PCMarkUpTextBox.Size = New System.Drawing.Size(200, 20)
        Me.PCMarkUpTextBox.TabIndex = 90
        '
        'ZeroQtyLabel
        '
        ZeroQtyLabel.AutoSize = True
        ZeroQtyLabel.Location = New System.Drawing.Point(286, 244)
        ZeroQtyLabel.Name = "ZeroQtyLabel"
        ZeroQtyLabel.Size = New System.Drawing.Size(51, 13)
        ZeroQtyLabel.TabIndex = 105
        ZeroQtyLabel.Text = "Zero Qty:"
        '
        'ZeroQtyCheckBox
        '
        Me.ZeroQtyCheckBox.Location = New System.Drawing.Point(343, 239)
        Me.ZeroQtyCheckBox.Name = "ZeroQtyCheckBox"
        Me.ZeroQtyCheckBox.Size = New System.Drawing.Size(200, 24)
        Me.ZeroQtyCheckBox.TabIndex = 92
        Me.ZeroQtyCheckBox.UseVisualStyleBackColor = True
        '
        'CreatedByLabel
        '
        CreatedByLabel.AutoSize = True
        CreatedByLabel.Location = New System.Drawing.Point(275, 297)
        CreatedByLabel.Name = "CreatedByLabel"
        CreatedByLabel.Size = New System.Drawing.Size(62, 13)
        CreatedByLabel.TabIndex = 106
        CreatedByLabel.Text = "Created By:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(399, 347)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 95
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(480, 347)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(59, 23)
        Me.cmdCancel.TabIndex = 96
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(324, 347)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(69, 23)
        Me.cmdAdd.TabIndex = 94
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdFindSupplier
        '
        Me.cmdFindSupplier.Location = New System.Drawing.Point(550, 104)
        Me.cmdFindSupplier.Name = "cmdFindSupplier"
        Me.cmdFindSupplier.Size = New System.Drawing.Size(31, 23)
        Me.cmdFindSupplier.TabIndex = 97
        Me.cmdFindSupplier.Text = "..."
        Me.cmdFindSupplier.UseVisualStyleBackColor = True
        '
        'FStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CreatedByTextBox)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(CreatedDateLabel)
        Me.Controls.Add(StockCodeLabel)
        Me.Controls.Add(Me.StockCodeTextBox)
        Me.Controls.Add(SupplierRefLabel)
        Me.Controls.Add(Me.SupplierRefTextBox)
        Me.Controls.Add(DeadCodeLabel)
        Me.Controls.Add(Me.DeadCodeCheckBox)
        Me.Controls.Add(AmountTakenLabel)
        Me.Controls.Add(Me.AmountTakenTextBox)
        Me.Controls.Add(DeliveredQtyHangersLabel)
        Me.Controls.Add(Me.DeliveredQtyHangersTextBox)
        Me.Controls.Add(CostValueLabel)
        Me.Controls.Add(Me.CostValueTextBox)
        Me.Controls.Add(PCMarkUpLabel)
        Me.Controls.Add(Me.PCMarkUpTextBox)
        Me.Controls.Add(ZeroQtyLabel)
        Me.Controls.Add(Me.ZeroQtyCheckBox)
        Me.Controls.Add(CreatedByLabel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdFindSupplier)
        Me.Name = "FStock"
        Me.Text = "FStock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CreatedByTextBox As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents StockCodeTextBox As TextBox
    Friend WithEvents SupplierRefTextBox As TextBox
    Friend WithEvents DeadCodeCheckBox As CheckBox
    Friend WithEvents AmountTakenTextBox As TextBox
    Friend WithEvents DeliveredQtyHangersTextBox As TextBox
    Friend WithEvents CostValueTextBox As TextBox
    Friend WithEvents PCMarkUpTextBox As TextBox
    Friend WithEvents ZeroQtyCheckBox As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents cmdFindSupplier As Button
End Class
