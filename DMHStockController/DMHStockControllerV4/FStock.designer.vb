<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FStock
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim StockCodeLabel As System.Windows.Forms.Label
        Dim SupplierRefLabel As System.Windows.Forms.Label
        Dim DeadCodeLabel As System.Windows.Forms.Label
        Dim AmountTakenLabel As System.Windows.Forms.Label
        Dim CostValueLabel As System.Windows.Forms.Label
        Dim PCMarkUpLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FStock))
        Me.StockCodeTextBox = New System.Windows.Forms.TextBox()
        Me.SupplierRefTextBox = New System.Windows.Forms.TextBox()
        Me.DeadCodeCheckBox = New System.Windows.Forms.CheckBox()
        Me.AmountTakenTextBox = New System.Windows.Forms.TextBox()
        Me.CostValueTextBox = New System.Windows.Forms.TextBox()
        Me.PCMarkUpTextBox = New System.Windows.Forms.TextBox()
        Me.CmdOK = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        StockCodeLabel = New System.Windows.Forms.Label()
        SupplierRefLabel = New System.Windows.Forms.Label()
        DeadCodeLabel = New System.Windows.Forms.Label()
        AmountTakenLabel = New System.Windows.Forms.Label()
        CostValueLabel = New System.Windows.Forms.Label()
        PCMarkUpLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'StockCodeLabel
        '
        StockCodeLabel.AutoSize = True
        StockCodeLabel.Location = New System.Drawing.Point(32, 11)
        StockCodeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        StockCodeLabel.Name = "StockCodeLabel"
        StockCodeLabel.Size = New System.Drawing.Size(92, 16)
        StockCodeLabel.TabIndex = 8
        StockCodeLabel.Text = "Stock Code:"
        '
        'SupplierRefLabel
        '
        SupplierRefLabel.AutoSize = True
        SupplierRefLabel.Location = New System.Drawing.Point(28, 43)
        SupplierRefLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        SupplierRefLabel.Name = "SupplierRefLabel"
        SupplierRefLabel.Size = New System.Drawing.Size(98, 16)
        SupplierRefLabel.TabIndex = 9
        SupplierRefLabel.Text = "Supplier Ref:"
        '
        'DeadCodeLabel
        '
        DeadCodeLabel.AutoSize = True
        DeadCodeLabel.Location = New System.Drawing.Point(34, 78)
        DeadCodeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        DeadCodeLabel.Name = "DeadCodeLabel"
        DeadCodeLabel.Size = New System.Drawing.Size(91, 16)
        DeadCodeLabel.TabIndex = 10
        DeadCodeLabel.Text = "Dead Code:"
        '
        'AmountTakenLabel
        '
        AmountTakenLabel.AutoSize = True
        AmountTakenLabel.Location = New System.Drawing.Point(9, 108)
        AmountTakenLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        AmountTakenLabel.Name = "AmountTakenLabel"
        AmountTakenLabel.Size = New System.Drawing.Size(111, 16)
        AmountTakenLabel.TabIndex = 11
        AmountTakenLabel.Text = "Amount Taken:"
        '
        'CostValueLabel
        '
        CostValueLabel.AutoSize = True
        CostValueLabel.Location = New System.Drawing.Point(38, 142)
        CostValueLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CostValueLabel.Name = "CostValueLabel"
        CostValueLabel.Size = New System.Drawing.Size(87, 16)
        CostValueLabel.TabIndex = 12
        CostValueLabel.Text = "Cost Value:"
        '
        'PCMarkUpLabel
        '
        PCMarkUpLabel.AutoSize = True
        PCMarkUpLabel.Location = New System.Drawing.Point(32, 174)
        PCMarkUpLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        PCMarkUpLabel.Name = "PCMarkUpLabel"
        PCMarkUpLabel.Size = New System.Drawing.Size(90, 16)
        PCMarkUpLabel.TabIndex = 13
        PCMarkUpLabel.Text = "PCMark Up:"
        '
        'StockCodeTextBox
        '
        Me.StockCodeTextBox.Location = New System.Drawing.Point(165, 7)
        Me.StockCodeTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.StockCodeTextBox.MaxLength = 30
        Me.StockCodeTextBox.Name = "StockCodeTextBox"
        Me.StockCodeTextBox.Size = New System.Drawing.Size(246, 22)
        Me.StockCodeTextBox.TabIndex = 0
        '
        'SupplierRefTextBox
        '
        Me.SupplierRefTextBox.Location = New System.Drawing.Point(165, 39)
        Me.SupplierRefTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.SupplierRefTextBox.MaxLength = 8
        Me.SupplierRefTextBox.Name = "SupplierRefTextBox"
        Me.SupplierRefTextBox.Size = New System.Drawing.Size(246, 22)
        Me.SupplierRefTextBox.TabIndex = 1
        '
        'DeadCodeCheckBox
        '
        Me.DeadCodeCheckBox.Location = New System.Drawing.Point(165, 69)
        Me.DeadCodeCheckBox.Margin = New System.Windows.Forms.Padding(4)
        Me.DeadCodeCheckBox.Name = "DeadCodeCheckBox"
        Me.DeadCodeCheckBox.Size = New System.Drawing.Size(246, 30)
        Me.DeadCodeCheckBox.TabIndex = 2
        Me.DeadCodeCheckBox.UseVisualStyleBackColor = True
        '
        'AmountTakenTextBox
        '
        Me.AmountTakenTextBox.Location = New System.Drawing.Point(165, 105)
        Me.AmountTakenTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.AmountTakenTextBox.Name = "AmountTakenTextBox"
        Me.AmountTakenTextBox.Size = New System.Drawing.Size(246, 22)
        Me.AmountTakenTextBox.TabIndex = 3
        '
        'CostValueTextBox
        '
        Me.CostValueTextBox.Location = New System.Drawing.Point(165, 138)
        Me.CostValueTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.CostValueTextBox.Name = "CostValueTextBox"
        Me.CostValueTextBox.Size = New System.Drawing.Size(246, 22)
        Me.CostValueTextBox.TabIndex = 4
        '
        'PCMarkUpTextBox
        '
        Me.PCMarkUpTextBox.Location = New System.Drawing.Point(165, 170)
        Me.PCMarkUpTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PCMarkUpTextBox.Name = "PCMarkUpTextBox"
        Me.PCMarkUpTextBox.Size = New System.Drawing.Size(246, 22)
        Me.PCMarkUpTextBox.TabIndex = 5
        '
        'CmdOK
        '
        Me.CmdOK.Location = New System.Drawing.Point(165, 200)
        Me.CmdOK.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdOK.Name = "CmdOK"
        Me.CmdOK.Size = New System.Drawing.Size(112, 28)
        Me.CmdOK.TabIndex = 6
        Me.CmdOK.Text = "Button1"
        Me.CmdOK.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.Location = New System.Drawing.Point(299, 200)
        Me.CmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(112, 28)
        Me.CmdCancel.TabIndex = 7
        Me.CmdCancel.Text = "Cancel"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'FStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 241)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.CmdOK)
        Me.Controls.Add(StockCodeLabel)
        Me.Controls.Add(Me.StockCodeTextBox)
        Me.Controls.Add(SupplierRefLabel)
        Me.Controls.Add(Me.SupplierRefTextBox)
        Me.Controls.Add(DeadCodeLabel)
        Me.Controls.Add(Me.DeadCodeCheckBox)
        Me.Controls.Add(AmountTakenLabel)
        Me.Controls.Add(Me.AmountTakenTextBox)
        Me.Controls.Add(CostValueLabel)
        Me.Controls.Add(Me.CostValueTextBox)
        Me.Controls.Add(PCMarkUpLabel)
        Me.Controls.Add(Me.PCMarkUpTextBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FStock"
        Me.Text = "Stock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StockCodeTextBox As TextBox
    Friend WithEvents SupplierRefTextBox As TextBox
    Friend WithEvents DeadCodeCheckBox As CheckBox
    Friend WithEvents AmountTakenTextBox As TextBox
    Friend WithEvents CostValueTextBox As TextBox
    Friend WithEvents PCMarkUpTextBox As TextBox
    Friend WithEvents CmdOK As Button
    Friend WithEvents CmdCancel As Button
End Class
