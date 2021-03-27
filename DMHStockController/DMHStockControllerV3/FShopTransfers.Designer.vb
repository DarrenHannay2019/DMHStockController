<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FShopTransfers
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
        Me.txtFromShopType = New System.Windows.Forms.TextBox()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtToShopType = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvFromShops = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvShopStock = New System.Windows.Forms.DataGridView()
        Me.dgvToShops = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDeleteFromGrid = New System.Windows.Forms.Button()
        Me.cmdAddToGrid = New System.Windows.Forms.Button()
        Me.txtTotalTransferFrom = New System.Windows.Forms.TextBox()
        Me.txtTotalTransferTo = New System.Windows.Forms.TextBox()
        Me.txtTransferToQty = New System.Windows.Forms.TextBox()
        Me.txtTransferFromQty = New System.Windows.Forms.TextBox()
        Me.txtCurrentQty = New System.Windows.Forms.TextBox()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.txtToShopName = New System.Windows.Forms.TextBox()
        Me.txtToShopRef = New System.Windows.Forms.TextBox()
        Me.txtFromShopName = New System.Windows.Forms.TextBox()
        Me.txtFromShopRef = New System.Windows.Forms.TextBox()
        Me.txtTFNote = New System.Windows.Forms.TextBox()
        Me.cmdFindStock = New System.Windows.Forms.Button()
        Me.cmdFindShopTo = New System.Windows.Forms.Button()
        Me.cmdFindShopFrom = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        CType(Me.dgvFromShops, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShopStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvToShops, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFromShopType
        '
        Me.txtFromShopType.Location = New System.Drawing.Point(586, 31)
        Me.txtFromShopType.Name = "txtFromShopType"
        Me.txtFromShopType.Size = New System.Drawing.Size(100, 20)
        Me.txtFromShopType.TabIndex = 106
        Me.txtFromShopType.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Current Qty"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "From Qty"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "To Qty"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Stock Code"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'txtToShopType
        '
        Me.txtToShopType.Location = New System.Drawing.Point(586, 60)
        Me.txtToShopType.Name = "txtToShopType"
        Me.txtToShopType.Size = New System.Drawing.Size(100, 20)
        Me.txtToShopType.TabIndex = 105
        Me.txtToShopType.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(168, 353)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 104
        Me.TextBox4.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(168, 377)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 103
        Me.TextBox3.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(168, 401)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 102
        Me.TextBox2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(168, 425)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 101
        Me.TextBox1.Visible = False
        '
        'dgvFromShops
        '
        Me.dgvFromShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFromShops.Location = New System.Drawing.Point(264, 185)
        Me.dgvFromShops.Name = "dgvFromShops"
        Me.dgvFromShops.Size = New System.Drawing.Size(240, 150)
        Me.dgvFromShops.TabIndex = 98
        Me.dgvFromShops.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(368, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "Needs coding"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(362, 5)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(144, 20)
        Me.DateTimePicker1.TabIndex = 69
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(571, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Transfer To Qty:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(467, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Transfer From Qty:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(365, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Current Qty:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(119, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Stock Code:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(306, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(115, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "To Shop:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(115, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "From Shop"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "TF Note No:"
        '
        'dgvShopStock
        '
        Me.dgvShopStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShopStock.Location = New System.Drawing.Point(264, 185)
        Me.dgvShopStock.Name = "dgvShopStock"
        Me.dgvShopStock.Size = New System.Drawing.Size(240, 150)
        Me.dgvShopStock.TabIndex = 100
        Me.dgvShopStock.Visible = False
        '
        'dgvToShops
        '
        Me.dgvToShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvToShops.Location = New System.Drawing.Point(264, 185)
        Me.dgvToShops.Name = "dgvToShops"
        Me.dgvToShops.Size = New System.Drawing.Size(240, 150)
        Me.dgvToShops.TabIndex = 99
        Me.dgvToShops.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "SMTIID"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.DataGridView1.Location = New System.Drawing.Point(128, 201)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(549, 184)
        Me.DataGridView1.TabIndex = 88
        '
        'Column1
        '
        Me.Column1.HeaderText = "LineID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "TransferID"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "SMTOID"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'cmdDeleteFromGrid
        '
        Me.cmdDeleteFromGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteFromGrid.Location = New System.Drawing.Point(647, 167)
        Me.cmdDeleteFromGrid.Name = "cmdDeleteFromGrid"
        Me.cmdDeleteFromGrid.Size = New System.Drawing.Size(27, 23)
        Me.cmdDeleteFromGrid.TabIndex = 76
        Me.cmdDeleteFromGrid.Text = "-"
        Me.cmdDeleteFromGrid.UseVisualStyleBackColor = True
        '
        'cmdAddToGrid
        '
        Me.cmdAddToGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToGrid.Location = New System.Drawing.Point(608, 167)
        Me.cmdAddToGrid.Name = "cmdAddToGrid"
        Me.cmdAddToGrid.Size = New System.Drawing.Size(33, 23)
        Me.cmdAddToGrid.TabIndex = 75
        Me.cmdAddToGrid.Text = "+"
        Me.cmdAddToGrid.UseVisualStyleBackColor = True
        '
        'txtTotalTransferFrom
        '
        Me.txtTotalTransferFrom.Location = New System.Drawing.Point(440, 385)
        Me.txtTotalTransferFrom.Name = "txtTotalTransferFrom"
        Me.txtTotalTransferFrom.Size = New System.Drawing.Size(106, 20)
        Me.txtTotalTransferFrom.TabIndex = 96
        '
        'txtTotalTransferTo
        '
        Me.txtTotalTransferTo.Location = New System.Drawing.Point(552, 385)
        Me.txtTotalTransferTo.Name = "txtTotalTransferTo"
        Me.txtTotalTransferTo.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalTransferTo.TabIndex = 95
        '
        'txtTransferToQty
        '
        Me.txtTransferToQty.Location = New System.Drawing.Point(574, 141)
        Me.txtTransferToQty.Name = "txtTransferToQty"
        Me.txtTransferToQty.Size = New System.Drawing.Size(100, 20)
        Me.txtTransferToQty.TabIndex = 74
        '
        'txtTransferFromQty
        '
        Me.txtTransferFromQty.Location = New System.Drawing.Point(468, 141)
        Me.txtTransferFromQty.Name = "txtTransferFromQty"
        Me.txtTransferFromQty.Size = New System.Drawing.Size(100, 20)
        Me.txtTransferFromQty.TabIndex = 73
        '
        'txtCurrentQty
        '
        Me.txtCurrentQty.Location = New System.Drawing.Point(362, 141)
        Me.txtCurrentQty.Name = "txtCurrentQty"
        Me.txtCurrentQty.Size = New System.Drawing.Size(100, 20)
        Me.txtCurrentQty.TabIndex = 94
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(115, 141)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(204, 20)
        Me.txtStockCode.TabIndex = 72
        '
        'txtToShopName
        '
        Me.txtToShopName.Location = New System.Drawing.Point(292, 57)
        Me.txtToShopName.Name = "txtToShopName"
        Me.txtToShopName.Size = New System.Drawing.Size(236, 20)
        Me.txtToShopName.TabIndex = 93
        Me.txtToShopName.TabStop = False
        '
        'txtToShopRef
        '
        Me.txtToShopRef.Location = New System.Drawing.Point(187, 57)
        Me.txtToShopRef.Name = "txtToShopRef"
        Me.txtToShopRef.Size = New System.Drawing.Size(100, 20)
        Me.txtToShopRef.TabIndex = 71
        '
        'txtFromShopName
        '
        Me.txtFromShopName.Location = New System.Drawing.Point(293, 31)
        Me.txtFromShopName.Name = "txtFromShopName"
        Me.txtFromShopName.Size = New System.Drawing.Size(235, 20)
        Me.txtFromShopName.TabIndex = 92
        Me.txtFromShopName.TabStop = False
        '
        'txtFromShopRef
        '
        Me.txtFromShopRef.Location = New System.Drawing.Point(187, 31)
        Me.txtFromShopRef.Name = "txtFromShopRef"
        Me.txtFromShopRef.Size = New System.Drawing.Size(100, 20)
        Me.txtFromShopRef.TabIndex = 70
        '
        'txtTFNote
        '
        Me.txtTFNote.Location = New System.Drawing.Point(187, 5)
        Me.txtTFNote.Name = "txtTFNote"
        Me.txtTFNote.Size = New System.Drawing.Size(100, 20)
        Me.txtTFNote.TabIndex = 68
        '
        'cmdFindStock
        '
        Me.cmdFindStock.Location = New System.Drawing.Point(325, 138)
        Me.cmdFindStock.Name = "cmdFindStock"
        Me.cmdFindStock.Size = New System.Drawing.Size(31, 23)
        Me.cmdFindStock.TabIndex = 91
        Me.cmdFindStock.Text = "..."
        Me.cmdFindStock.UseVisualStyleBackColor = True
        '
        'cmdFindShopTo
        '
        Me.cmdFindShopTo.Location = New System.Drawing.Point(534, 58)
        Me.cmdFindShopTo.Name = "cmdFindShopTo"
        Me.cmdFindShopTo.Size = New System.Drawing.Size(24, 23)
        Me.cmdFindShopTo.TabIndex = 90
        Me.cmdFindShopTo.Text = "..."
        Me.cmdFindShopTo.UseVisualStyleBackColor = True
        '
        'cmdFindShopFrom
        '
        Me.cmdFindShopFrom.Location = New System.Drawing.Point(534, 29)
        Me.cmdFindShopFrom.Name = "cmdFindShopFrom"
        Me.cmdFindShopFrom.Size = New System.Drawing.Size(24, 23)
        Me.cmdFindShopFrom.TabIndex = 89
        Me.cmdFindShopFrom.Text = "..."
        Me.cmdFindShopFrom.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(588, 414)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 79
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(426, 414)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 77
        Me.cmdOK.Text = "Ok"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(507, 414)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 78
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'FShopTransfers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtFromShopType)
        Me.Controls.Add(Me.txtToShopType)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.dgvFromShops)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvShopStock)
        Me.Controls.Add(Me.dgvToShops)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdDeleteFromGrid)
        Me.Controls.Add(Me.cmdAddToGrid)
        Me.Controls.Add(Me.txtTotalTransferFrom)
        Me.Controls.Add(Me.txtTotalTransferTo)
        Me.Controls.Add(Me.txtTransferToQty)
        Me.Controls.Add(Me.txtTransferFromQty)
        Me.Controls.Add(Me.txtCurrentQty)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.txtToShopName)
        Me.Controls.Add(Me.txtToShopRef)
        Me.Controls.Add(Me.txtFromShopName)
        Me.Controls.Add(Me.txtFromShopRef)
        Me.Controls.Add(Me.txtTFNote)
        Me.Controls.Add(Me.cmdFindStock)
        Me.Controls.Add(Me.cmdFindShopTo)
        Me.Controls.Add(Me.cmdFindShopFrom)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "FShopTransfers"
        Me.Text = "FShopTransfers"
        CType(Me.dgvFromShops, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShopStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvToShops, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFromShopType As TextBox
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents txtToShopType As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents dgvFromShops As DataGridView
    Friend WithEvents Label9 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvShopStock As DataGridView
    Friend WithEvents dgvToShops As DataGridView
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents cmdDeleteFromGrid As Button
    Friend WithEvents cmdAddToGrid As Button
    Friend WithEvents txtTotalTransferFrom As TextBox
    Friend WithEvents txtTotalTransferTo As TextBox
    Friend WithEvents txtTransferToQty As TextBox
    Friend WithEvents txtTransferFromQty As TextBox
    Friend WithEvents txtCurrentQty As TextBox
    Friend WithEvents txtStockCode As TextBox
    Friend WithEvents txtToShopName As TextBox
    Friend WithEvents txtToShopRef As TextBox
    Friend WithEvents txtFromShopName As TextBox
    Friend WithEvents txtFromShopRef As TextBox
    Friend WithEvents txtTFNote As TextBox
    Friend WithEvents cmdFindStock As Button
    Friend WithEvents cmdFindShopTo As Button
    Friend WithEvents cmdFindShopFrom As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdCancel As Button
End Class
