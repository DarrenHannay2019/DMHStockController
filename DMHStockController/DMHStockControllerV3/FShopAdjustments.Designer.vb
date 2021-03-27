<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FShopAdjustments
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
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtfromshoptype = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.UnitPrices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MovementDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransToQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransFromQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FromShopRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stockCodeCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.txtAdjustmentQty = New System.Windows.Forms.TextBox()
        Me.txtCurrentQty = New System.Windows.Forms.TextBox()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.txtShopName = New System.Windows.Forms.TextBox()
        Me.txtShopRef = New System.Windows.Forms.TextBox()
        Me.txtReferemce = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtfromshoptype
        '
        Me.txtfromshoptype.Location = New System.Drawing.Point(497, 30)
        Me.txtfromshoptype.Name = "txtfromshoptype"
        Me.txtfromshoptype.Size = New System.Drawing.Size(100, 20)
        Me.txtfromshoptype.TabIndex = 114
        Me.txtfromshoptype.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(125, 417)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView2.TabIndex = 111
        Me.DataGridView2.Visible = False
        '
        'UnitPrices
        '
        Me.UnitPrices.HeaderText = "UnitPrices"
        Me.UnitPrices.Name = "UnitPrices"
        Me.UnitPrices.ReadOnly = True
        Me.UnitPrices.Visible = False
        '
        'MovementDate
        '
        Me.MovementDate.HeaderText = "Movement Date"
        Me.MovementDate.Name = "MovementDate"
        Me.MovementDate.ReadOnly = True
        Me.MovementDate.Visible = False
        '
        'TransToQty
        '
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "N0"
        DataGridViewCellStyle37.NullValue = Nothing
        Me.TransToQty.DefaultCellStyle = DataGridViewCellStyle37
        Me.TransToQty.HeaderText = "Adjustment Qty"
        Me.TransToQty.Name = "TransToQty"
        Me.TransToQty.ReadOnly = True
        Me.TransToQty.Width = 120
        '
        'TransFromQty
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle38.NullValue = Nothing
        Me.TransFromQty.DefaultCellStyle = DataGridViewCellStyle38
        Me.TransFromQty.HeaderText = "Adjustment Type"
        Me.TransFromQty.Name = "TransFromQty"
        Me.TransFromQty.ReadOnly = True
        Me.TransFromQty.Width = 120
        '
        'CurrentQty
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle39.Format = "N0"
        DataGridViewCellStyle39.NullValue = Nothing
        Me.CurrentQty.DefaultCellStyle = DataGridViewCellStyle39
        Me.CurrentQty.HeaderText = "Current Qty"
        Me.CurrentQty.Name = "CurrentQty"
        Me.CurrentQty.ReadOnly = True
        Me.CurrentQty.Width = 150
        '
        'FromShopRef
        '
        Me.FromShopRef.HeaderText = "From Shop"
        Me.FromShopRef.Name = "FromShopRef"
        Me.FromShopRef.ReadOnly = True
        Me.FromShopRef.Visible = False
        '
        'stockCodeCol
        '
        Me.stockCodeCol.HeaderText = "Stock Code"
        Me.stockCodeCol.Name = "stockCodeCol"
        Me.stockCodeCol.ReadOnly = True
        Me.stockCodeCol.Width = 150
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(58, 430)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView3.TabIndex = 113
        Me.DataGridView3.Visible = False
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Gain", "Loss"})
        Me.cboType.Location = New System.Drawing.Point(338, 124)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(97, 21)
        Me.cboType.TabIndex = 92
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(322, 34)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(144, 20)
        Me.DateTimePicker1.TabIndex = 89
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(441, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Adjustment Qty:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(338, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Adjustment Type:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(265, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Current Qty:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "Stock Code:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Shop:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Adjustment Ref:"
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(577, 124)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(27, 23)
        Me.Button8.TabIndex = 95
        Me.Button8.Text = "-"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(547, 124)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(27, 23)
        Me.Button7.TabIndex = 94
        Me.Button7.Text = "+"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'txtAdjustmentQty
        '
        Me.txtAdjustmentQty.Location = New System.Drawing.Point(441, 124)
        Me.txtAdjustmentQty.Name = "txtAdjustmentQty"
        Me.txtAdjustmentQty.Size = New System.Drawing.Size(100, 20)
        Me.txtAdjustmentQty.TabIndex = 93
        '
        'txtCurrentQty
        '
        Me.txtCurrentQty.Location = New System.Drawing.Point(268, 124)
        Me.txtCurrentQty.Name = "txtCurrentQty"
        Me.txtCurrentQty.Size = New System.Drawing.Size(66, 20)
        Me.txtCurrentQty.TabIndex = 110
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(48, 124)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(177, 20)
        Me.txtStockCode.TabIndex = 91
        '
        'txtShopName
        '
        Me.txtShopName.Location = New System.Drawing.Point(268, 73)
        Me.txtShopName.Name = "txtShopName"
        Me.txtShopName.Size = New System.Drawing.Size(235, 20)
        Me.txtShopName.TabIndex = 109
        '
        'txtShopRef
        '
        Me.txtShopRef.Location = New System.Drawing.Point(137, 73)
        Me.txtShopRef.Name = "txtShopRef"
        Me.txtShopRef.Size = New System.Drawing.Size(100, 20)
        Me.txtShopRef.TabIndex = 90
        '
        'txtReferemce
        '
        Me.txtReferemce.Location = New System.Drawing.Point(137, 34)
        Me.txtReferemce.Name = "txtReferemce"
        Me.txtReferemce.Size = New System.Drawing.Size(100, 20)
        Me.txtReferemce.TabIndex = 88
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(231, 124)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(31, 23)
        Me.Button6.TabIndex = 108
        Me.Button6.Text = "..."
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(238, 73)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(24, 23)
        Me.Button4.TabIndex = 107
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(522, 318)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 98
        Me.Button3.Text = "Clear"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(441, 318)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 97
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(360, 318)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 96
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stockCodeCol, Me.FromShopRef, Me.CurrentQty, Me.TransFromQty, Me.TransToQty, Me.MovementDate, Me.UnitPrices})
        Me.DataGridView1.Location = New System.Drawing.Point(43, 162)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(555, 150)
        Me.DataGridView1.TabIndex = 106
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(299, 215)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 20)
        Me.TextBox1.TabIndex = 112
        Me.TextBox1.Visible = False
        '
        'FShopAdjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 675)
        Me.Controls.Add(Me.txtfromshoptype)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.txtAdjustmentQty)
        Me.Controls.Add(Me.txtCurrentQty)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.txtShopName)
        Me.Controls.Add(Me.txtShopRef)
        Me.Controls.Add(Me.txtReferemce)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "FShopAdjustments"
        Me.Text = "FShopAdjustments"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtfromshoptype As TextBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents UnitPrices As DataGridViewTextBoxColumn
    Friend WithEvents MovementDate As DataGridViewTextBoxColumn
    Friend WithEvents TransToQty As DataGridViewTextBoxColumn
    Friend WithEvents TransFromQty As DataGridViewTextBoxColumn
    Friend WithEvents CurrentQty As DataGridViewTextBoxColumn
    Friend WithEvents FromShopRef As DataGridViewTextBoxColumn
    Friend WithEvents stockCodeCol As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents cboType As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents txtAdjustmentQty As TextBox
    Friend WithEvents txtCurrentQty As TextBox
    Friend WithEvents txtStockCode As TextBox
    Friend WithEvents txtShopName As TextBox
    Friend WithEvents txtShopRef As TextBox
    Friend WithEvents txtReferemce As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox1 As TextBox
End Class
