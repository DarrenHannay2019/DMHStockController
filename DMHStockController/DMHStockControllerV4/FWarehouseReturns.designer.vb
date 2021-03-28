<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FWarehouseReturns
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FWarehouseReturns))
        Me.txtTotalItems = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtRecordNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtFWarehouseName = New System.Windows.Forms.TextBox()
        Me.txtCurrentQty = New System.Windows.Forms.TextBox()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.txtFWarehouseRef = New System.Windows.Forms.TextBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdClearGrid = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.txtTransferQty = New System.Windows.Forms.TextBox()
        Me.txtTWarehouseName = New System.Windows.Forms.TextBox()
        Me.txtTWarehouseRef = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.DgvRecords = New System.Windows.Forms.DataGridView()
        Me.TRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTransQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.values = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Location = New System.Drawing.Point(300, 532)
        Me.txtTotalItems.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.Size = New System.Drawing.Size(148, 22)
        Me.txtTotalItems.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(198, 532)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Total Items:"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(338, 564)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(112, 28)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(472, 564)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 28)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtRecordNo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DtpDate)
        Me.GroupBox1.Controls.Add(Me.txtFWarehouseName)
        Me.GroupBox1.Controls.Add(Me.txtCurrentQty)
        Me.GroupBox1.Controls.Add(Me.txtStockCode)
        Me.GroupBox1.Controls.Add(Me.txtFWarehouseRef)
        Me.GroupBox1.Controls.Add(Me.txtReference)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(663, 186)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current"
        '
        'TxtRecordNo
        '
        Me.TxtRecordNo.Enabled = False
        Me.TxtRecordNo.Location = New System.Drawing.Point(440, 23)
        Me.TxtRecordNo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRecordNo.Name = "TxtRecordNo"
        Me.TxtRecordNo.Size = New System.Drawing.Size(103, 22)
        Me.TxtRecordNo.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(346, 26)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "RecordID:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(56, 27)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Date:"
        '
        'DtpDate
        '
        Me.DtpDate.CustomFormat = "dd-MM-yyyy"
        Me.DtpDate.Location = New System.Drawing.Point(122, 23)
        Me.DtpDate.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpDate.Name = "DtpDate"
        Me.DtpDate.Size = New System.Drawing.Size(200, 22)
        Me.DtpDate.TabIndex = 0
        Me.DtpDate.Value = New Date(2016, 2, 7, 0, 0, 0, 0)
        '
        'txtFWarehouseName
        '
        Me.txtFWarehouseName.Enabled = False
        Me.txtFWarehouseName.Location = New System.Drawing.Point(366, 87)
        Me.txtFWarehouseName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFWarehouseName.Name = "txtFWarehouseName"
        Me.txtFWarehouseName.Size = New System.Drawing.Size(274, 22)
        Me.txtFWarehouseName.TabIndex = 10
        Me.txtFWarehouseName.TabStop = False
        '
        'txtCurrentQty
        '
        Me.txtCurrentQty.Location = New System.Drawing.Point(141, 154)
        Me.txtCurrentQty.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurrentQty.Name = "txtCurrentQty"
        Me.txtCurrentQty.Size = New System.Drawing.Size(148, 22)
        Me.txtCurrentQty.TabIndex = 11
        '
        'txtStockCode
        '
        Me.txtStockCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStockCode.Location = New System.Drawing.Point(141, 122)
        Me.txtStockCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStockCode.MaxLength = 30
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(148, 22)
        Me.txtStockCode.TabIndex = 2
        '
        'txtFWarehouseRef
        '
        Me.txtFWarehouseRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFWarehouseRef.Enabled = False
        Me.txtFWarehouseRef.Location = New System.Drawing.Point(141, 87)
        Me.txtFWarehouseRef.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFWarehouseRef.MaxLength = 8
        Me.txtFWarehouseRef.Name = "txtFWarehouseRef"
        Me.txtFWarehouseRef.Size = New System.Drawing.Size(148, 22)
        Me.txtFWarehouseRef.TabIndex = 7
        '
        'txtReference
        '
        Me.txtReference.Location = New System.Drawing.Point(141, 55)
        Me.txtReference.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReference.MaxLength = 50
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(148, 22)
        Me.txtReference.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(300, 91)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 158)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Current Qty:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 130)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Stock Code:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 92)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Warehouse Ref:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Reference:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdClearGrid)
        Me.GroupBox2.Controls.Add(Me.cmdAdd)
        Me.GroupBox2.Controls.Add(Me.txtTransferQty)
        Me.GroupBox2.Controls.Add(Me.txtTWarehouseName)
        Me.GroupBox2.Controls.Add(Me.txtTWarehouseRef)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 208)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(663, 124)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Return To:"
        '
        'cmdClearGrid
        '
        Me.cmdClearGrid.Location = New System.Drawing.Point(468, 87)
        Me.cmdClearGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClearGrid.Name = "cmdClearGrid"
        Me.cmdClearGrid.Size = New System.Drawing.Size(112, 28)
        Me.cmdClearGrid.TabIndex = 3
        Me.cmdClearGrid.Text = "Delete All"
        Me.cmdClearGrid.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(346, 87)
        Me.cmdAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(112, 28)
        Me.cmdAdd.TabIndex = 2
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtTransferQty
        '
        Me.txtTransferQty.Location = New System.Drawing.Point(184, 87)
        Me.txtTransferQty.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTransferQty.Name = "txtTransferQty"
        Me.txtTransferQty.Size = New System.Drawing.Size(148, 22)
        Me.txtTransferQty.TabIndex = 1
        '
        'txtTWarehouseName
        '
        Me.txtTWarehouseName.Enabled = False
        Me.txtTWarehouseName.Location = New System.Drawing.Point(183, 55)
        Me.txtTWarehouseName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTWarehouseName.Name = "txtTWarehouseName"
        Me.txtTWarehouseName.Size = New System.Drawing.Size(439, 22)
        Me.txtTWarehouseName.TabIndex = 6
        Me.txtTWarehouseName.TabStop = False
        '
        'txtTWarehouseRef
        '
        Me.txtTWarehouseRef.Enabled = False
        Me.txtTWarehouseRef.Location = New System.Drawing.Point(183, 23)
        Me.txtTWarehouseRef.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTWarehouseRef.MaxLength = 8
        Me.txtTWarehouseRef.Name = "txtTWarehouseRef"
        Me.txtTWarehouseRef.Size = New System.Drawing.Size(148, 22)
        Me.txtTWarehouseRef.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(72, 84)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Transfer Qty:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(117, 55)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Warehouse Ref:"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(594, 564)
        Me.cmdClear.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(112, 28)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'DgvRecords
        '
        Me.DgvRecords.AllowUserToAddRows = False
        Me.DgvRecords.AllowUserToDeleteRows = False
        Me.DgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TRef, Me.Ref, Me.colStockCode, Me.colTransQty, Me.values})
        Me.DgvRecords.Location = New System.Drawing.Point(18, 340)
        Me.DgvRecords.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvRecords.Name = "DgvRecords"
        Me.DgvRecords.Size = New System.Drawing.Size(624, 185)
        Me.DgvRecords.TabIndex = 5
        '
        'TRef
        '
        Me.TRef.HeaderText = "Tref"
        Me.TRef.Name = "TRef"
        Me.TRef.Visible = False
        '
        'Ref
        '
        Me.Ref.HeaderText = "Ref"
        Me.Ref.Name = "Ref"
        Me.Ref.Visible = False
        '
        'colStockCode
        '
        Me.colStockCode.HeaderText = "Stock Code"
        Me.colStockCode.Name = "colStockCode"
        Me.colStockCode.Width = 150
        '
        'colTransQty
        '
        Me.colTransQty.HeaderText = "Qty"
        Me.colTransQty.Name = "colTransQty"
        '
        'values
        '
        Me.values.HeaderText = "Value"
        Me.values.Name = "values"
        Me.values.Visible = False
        '
        'FWarehouseReturns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 606)
        Me.Controls.Add(Me.txtTotalItems)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.DgvRecords)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FWarehouseReturns"
        Me.Text = "Warehouse Returns"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTotalItems As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents DtpDate As DateTimePicker
    Friend WithEvents txtFWarehouseName As TextBox
    Friend WithEvents txtCurrentQty As TextBox
    Friend WithEvents txtStockCode As TextBox
    Friend WithEvents txtFWarehouseRef As TextBox
    Friend WithEvents txtReference As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdClearGrid As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents txtTransferQty As TextBox
    Friend WithEvents txtTWarehouseName As TextBox
    Friend WithEvents txtTWarehouseRef As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents DgvRecords As DataGridView
    Friend WithEvents TxtRecordNo As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TRef As DataGridViewTextBoxColumn
    Friend WithEvents Ref As DataGridViewTextBoxColumn
    Friend WithEvents colStockCode As DataGridViewTextBoxColumn
    Friend WithEvents colTransQty As DataGridViewTextBoxColumn
    Friend WithEvents values As DataGridViewTextBoxColumn
End Class
