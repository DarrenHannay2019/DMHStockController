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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FShopTransfers))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtTransferID = New System.Windows.Forms.TextBox()
        Me.DgvRecords = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdDeleteFromGrid = New System.Windows.Forms.Button()
        Me.CmdAddToGrid = New System.Windows.Forms.Button()
        Me.txtTotalTransferTo = New System.Windows.Forms.TextBox()
        Me.TxtTransferFromQty = New System.Windows.Forms.TextBox()
        Me.TxtCurrentQty = New System.Windows.Forms.TextBox()
        Me.TxtStockCode = New System.Windows.Forms.TextBox()
        Me.txtToShopName = New System.Windows.Forms.TextBox()
        Me.TxtToShopRef = New System.Windows.Forms.TextBox()
        Me.txtFromShopName = New System.Windows.Forms.TextBox()
        Me.TxtFromShopRef = New System.Windows.Forms.TextBox()
        Me.TxtTFNote = New System.Windows.Forms.TextBox()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdOK = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.DtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 10)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Record Number"
        '
        'TxtTransferID
        '
        Me.TxtTransferID.Location = New System.Drawing.Point(154, 7)
        Me.TxtTransferID.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTransferID.Name = "TxtTransferID"
        Me.TxtTransferID.Size = New System.Drawing.Size(148, 22)
        Me.TxtTransferID.TabIndex = 14
        '
        'DgvRecords
        '
        Me.DgvRecords.AllowUserToAddRows = False
        Me.DgvRecords.AllowUserToDeleteRows = False
        Me.DgvRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.DgvRecords.Location = New System.Drawing.Point(30, 250)
        Me.DgvRecords.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvRecords.Name = "DgvRecords"
        Me.DgvRecords.Size = New System.Drawing.Size(414, 231)
        Me.DgvRecords.TabIndex = 8
        '
        'Column1
        '
        Me.Column1.HeaderText = "LineID"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "TransferID"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "SMTOID"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "SMTIID"
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.FillWeight = 162.2788!
        Me.Column5.HeaderText = "Stock Code"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.FillWeight = 61.57903!
        Me.Column6.HeaderText = "Current Qty"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.FillWeight = 76.14214!
        Me.Column7.HeaderText = "Qty"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "To Qty"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'CmdDeleteFromGrid
        '
        Me.CmdDeleteFromGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDeleteFromGrid.Location = New System.Drawing.Point(368, 214)
        Me.CmdDeleteFromGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdDeleteFromGrid.Name = "CmdDeleteFromGrid"
        Me.CmdDeleteFromGrid.Size = New System.Drawing.Size(40, 28)
        Me.CmdDeleteFromGrid.TabIndex = 7
        Me.CmdDeleteFromGrid.Text = "-"
        Me.CmdDeleteFromGrid.UseVisualStyleBackColor = True
        '
        'CmdAddToGrid
        '
        Me.CmdAddToGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAddToGrid.Location = New System.Drawing.Point(310, 214)
        Me.CmdAddToGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdAddToGrid.Name = "CmdAddToGrid"
        Me.CmdAddToGrid.Size = New System.Drawing.Size(50, 28)
        Me.CmdAddToGrid.TabIndex = 6
        Me.CmdAddToGrid.Text = "+"
        Me.CmdAddToGrid.UseVisualStyleBackColor = True
        '
        'txtTotalTransferTo
        '
        Me.txtTotalTransferTo.Location = New System.Drawing.Point(372, 489)
        Me.txtTotalTransferTo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalTransferTo.Name = "txtTotalTransferTo"
        Me.txtTotalTransferTo.Size = New System.Drawing.Size(72, 22)
        Me.txtTotalTransferTo.TabIndex = 24
        '
        'TxtTransferFromQty
        '
        Me.TxtTransferFromQty.Location = New System.Drawing.Point(154, 217)
        Me.TxtTransferFromQty.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTransferFromQty.Name = "TxtTransferFromQty"
        Me.TxtTransferFromQty.Size = New System.Drawing.Size(148, 22)
        Me.TxtTransferFromQty.TabIndex = 5
        '
        'TxtCurrentQty
        '
        Me.TxtCurrentQty.Location = New System.Drawing.Point(154, 187)
        Me.TxtCurrentQty.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCurrentQty.Name = "TxtCurrentQty"
        Me.TxtCurrentQty.Size = New System.Drawing.Size(148, 22)
        Me.TxtCurrentQty.TabIndex = 22
        '
        'TxtStockCode
        '
        Me.TxtStockCode.Location = New System.Drawing.Point(154, 157)
        Me.TxtStockCode.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtStockCode.MaxLength = 30
        Me.TxtStockCode.Name = "TxtStockCode"
        Me.TxtStockCode.Size = New System.Drawing.Size(148, 22)
        Me.TxtStockCode.TabIndex = 4
        '
        'txtToShopName
        '
        Me.txtToShopName.Location = New System.Drawing.Point(230, 127)
        Me.txtToShopName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtToShopName.Name = "txtToShopName"
        Me.txtToShopName.Size = New System.Drawing.Size(230, 22)
        Me.txtToShopName.TabIndex = 17
        Me.txtToShopName.TabStop = False
        '
        'TxtToShopRef
        '
        Me.TxtToShopRef.Location = New System.Drawing.Point(154, 127)
        Me.TxtToShopRef.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtToShopRef.MaxLength = 8
        Me.TxtToShopRef.Name = "TxtToShopRef"
        Me.TxtToShopRef.Size = New System.Drawing.Size(68, 22)
        Me.TxtToShopRef.TabIndex = 3
        '
        'txtFromShopName
        '
        Me.txtFromShopName.Location = New System.Drawing.Point(230, 97)
        Me.txtFromShopName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFromShopName.Name = "txtFromShopName"
        Me.txtFromShopName.Size = New System.Drawing.Size(230, 22)
        Me.txtFromShopName.TabIndex = 16
        Me.txtFromShopName.TabStop = False
        '
        'TxtFromShopRef
        '
        Me.TxtFromShopRef.Location = New System.Drawing.Point(154, 97)
        Me.TxtFromShopRef.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFromShopRef.MaxLength = 8
        Me.TxtFromShopRef.Name = "TxtFromShopRef"
        Me.TxtFromShopRef.Size = New System.Drawing.Size(68, 22)
        Me.TxtFromShopRef.TabIndex = 2
        '
        'TxtTFNote
        '
        Me.TxtTFNote.Location = New System.Drawing.Point(154, 67)
        Me.TxtTFNote.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTFNote.MaxLength = 30
        Me.TxtTFNote.Name = "TxtTFNote"
        Me.TxtTFNote.Size = New System.Drawing.Size(148, 22)
        Me.TxtTFNote.TabIndex = 1
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(332, 519)
        Me.CmdClear.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 28)
        Me.CmdClear.TabIndex = 11
        Me.CmdClear.Text = "Clear"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdOK
        '
        Me.CmdOK.Location = New System.Drawing.Point(88, 519)
        Me.CmdOK.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdOK.Name = "CmdOK"
        Me.CmdOK.Size = New System.Drawing.Size(112, 28)
        Me.CmdOK.TabIndex = 9
        Me.CmdOK.Text = "Ok"
        Me.CmdOK.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.Location = New System.Drawing.Point(210, 519)
        Me.CmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(112, 28)
        Me.CmdCancel.TabIndex = 10
        Me.CmdCancel.Text = "Cancel"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'DtpDate
        '
        Me.DtpDate.Location = New System.Drawing.Point(154, 37)
        Me.DtpDate.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpDate.Name = "DtpDate"
        Me.DtpDate.Size = New System.Drawing.Size(290, 22)
        Me.DtpDate.TabIndex = 0
        Me.DtpDate.Value = New Date(2017, 9, 1, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(24, 220)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Transfer Qty:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 190)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Current Qty:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(29, 163)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Stock Code:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(76, 37)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(50, 130)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "To Shop:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(38, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "From Shop"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 67)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "TF Note No:"
        '
        'FShopTransfers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 555)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtTransferID)
        Me.Controls.Add(Me.DgvRecords)
        Me.Controls.Add(Me.CmdDeleteFromGrid)
        Me.Controls.Add(Me.CmdAddToGrid)
        Me.Controls.Add(Me.txtTotalTransferTo)
        Me.Controls.Add(Me.TxtTransferFromQty)
        Me.Controls.Add(Me.TxtCurrentQty)
        Me.Controls.Add(Me.TxtStockCode)
        Me.Controls.Add(Me.txtToShopName)
        Me.Controls.Add(Me.TxtToShopRef)
        Me.Controls.Add(Me.txtFromShopName)
        Me.Controls.Add(Me.TxtFromShopRef)
        Me.Controls.Add(Me.TxtTFNote)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdOK)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.DtpDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FShopTransfers"
        Me.Text = "Shop Transfers"
        CType(Me.DgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents TxtTransferID As TextBox
    Friend WithEvents DgvRecords As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents CmdDeleteFromGrid As Button
    Friend WithEvents CmdAddToGrid As Button
    Friend WithEvents txtTotalTransferTo As TextBox
    Friend WithEvents TxtTransferFromQty As TextBox
    Friend WithEvents TxtCurrentQty As TextBox
    Friend WithEvents TxtStockCode As TextBox
    Friend WithEvents txtToShopName As TextBox
    Friend WithEvents TxtToShopRef As TextBox
    Friend WithEvents txtFromShopName As TextBox
    Friend WithEvents TxtFromShopRef As TextBox
    Friend WithEvents TxtTFNote As TextBox
    Friend WithEvents CmdClear As Button
    Friend WithEvents CmdOK As Button
    Friend WithEvents CmdCancel As Button
    Friend WithEvents DtpDate As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
