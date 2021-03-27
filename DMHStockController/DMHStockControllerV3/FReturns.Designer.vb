<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FReturns
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
        Me.txtWarehouseName = New System.Windows.Forms.TextBox()
        Me.txtLocationType1 = New System.Windows.Forms.TextBox()
        Me.txtMovementType = New System.Windows.Forms.TextBox()
        Me.txtBoxes = New System.Windows.Forms.TextBox()
        Me.txtMovementBoxes = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cmdFindStock = New System.Windows.Forms.Button()
        Me.cmdFindShop = New System.Windows.Forms.Button()
        Me.txtShopName = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCurrentQty = New System.Windows.Forms.TextBox()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.txtShopRef = New System.Windows.Forms.TextBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblTransRef = New System.Windows.Forms.Label()
        Me.cmdFindWarehouse = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLocationType2 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTransferQty = New System.Windows.Forms.TextBox()
        Me.txtWarehouseRef = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtWarehouseName
        '
        Me.txtWarehouseName.Location = New System.Drawing.Point(122, 56)
        Me.txtWarehouseName.Name = "txtWarehouseName"
        Me.txtWarehouseName.Size = New System.Drawing.Size(294, 20)
        Me.txtWarehouseName.TabIndex = 40
        Me.txtWarehouseName.TabStop = False
        '
        'txtLocationType1
        '
        Me.txtLocationType1.Location = New System.Drawing.Point(293, 113)
        Me.txtLocationType1.Name = "txtLocationType1"
        Me.txtLocationType1.Size = New System.Drawing.Size(100, 20)
        Me.txtLocationType1.TabIndex = 60
        Me.txtLocationType1.Text = "3"
        Me.txtLocationType1.Visible = False
        '
        'txtMovementType
        '
        Me.txtMovementType.Location = New System.Drawing.Point(399, 105)
        Me.txtMovementType.Name = "txtMovementType"
        Me.txtMovementType.Size = New System.Drawing.Size(100, 20)
        Me.txtMovementType.TabIndex = 60
        Me.txtMovementType.TabStop = False
        Me.txtMovementType.Text = "9"
        Me.txtMovementType.Visible = False
        Me.txtMovementType.WordWrap = False
        '
        'txtBoxes
        '
        Me.txtBoxes.Location = New System.Drawing.Point(293, 89)
        Me.txtBoxes.Name = "txtBoxes"
        Me.txtBoxes.Size = New System.Drawing.Size(100, 20)
        Me.txtBoxes.TabIndex = 50
        Me.txtBoxes.Text = "0"
        Me.txtBoxes.Visible = False
        '
        'txtMovementBoxes
        '
        Me.txtMovementBoxes.Location = New System.Drawing.Point(399, 89)
        Me.txtMovementBoxes.Name = "txtMovementBoxes"
        Me.txtMovementBoxes.Size = New System.Drawing.Size(100, 20)
        Me.txtMovementBoxes.TabIndex = 70
        Me.txtMovementBoxes.Text = "0"
        Me.txtMovementBoxes.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(271, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Date:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MM-yyyy"
        Me.DateTimePicker1.Location = New System.Drawing.Point(364, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(135, 20)
        Me.DateTimePicker1.TabIndex = 12
        Me.DateTimePicker1.Value = New Date(2016, 2, 7, 0, 0, 0, 0)
        '
        'cmdFindStock
        '
        Me.cmdFindStock.Location = New System.Drawing.Point(228, 76)
        Me.cmdFindStock.Name = "cmdFindStock"
        Me.cmdFindStock.Size = New System.Drawing.Size(25, 23)
        Me.cmdFindStock.TabIndex = 110
        Me.cmdFindStock.TabStop = False
        Me.cmdFindStock.Text = "..."
        Me.cmdFindStock.UseVisualStyleBackColor = True
        '
        'cmdFindShop
        '
        Me.cmdFindShop.Location = New System.Drawing.Point(228, 47)
        Me.cmdFindShop.Name = "cmdFindShop"
        Me.cmdFindShop.Size = New System.Drawing.Size(25, 23)
        Me.cmdFindShop.TabIndex = 100
        Me.cmdFindShop.TabStop = False
        Me.cmdFindShop.Text = "..."
        Me.cmdFindShop.UseVisualStyleBackColor = True
        '
        'txtShopName
        '
        Me.txtShopName.Location = New System.Drawing.Point(315, 52)
        Me.txtShopName.Name = "txtShopName"
        Me.txtShopName.Size = New System.Drawing.Size(184, 20)
        Me.txtShopName.TabIndex = 90
        Me.txtShopName.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(367, 376)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLocationType1)
        Me.GroupBox1.Controls.Add(Me.txtMovementType)
        Me.GroupBox1.Controls.Add(Me.txtBoxes)
        Me.GroupBox1.Controls.Add(Me.txtMovementBoxes)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.cmdFindStock)
        Me.GroupBox1.Controls.Add(Me.cmdFindShop)
        Me.GroupBox1.Controls.Add(Me.txtShopName)
        Me.GroupBox1.Controls.Add(Me.txtCurrentQty)
        Me.GroupBox1.Controls.Add(Me.txtStockCode)
        Me.GroupBox1.Controls.Add(Me.txtShopRef)
        Me.GroupBox1.Controls.Add(Me.txtReference)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 172)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current"
        '
        'txtCurrentQty
        '
        Me.txtCurrentQty.Location = New System.Drawing.Point(122, 102)
        Me.txtCurrentQty.Name = "txtCurrentQty"
        Me.txtCurrentQty.Size = New System.Drawing.Size(100, 20)
        Me.txtCurrentQty.TabIndex = 4
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(122, 76)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(100, 20)
        Me.txtStockCode.TabIndex = 2
        '
        'txtShopRef
        '
        Me.txtShopRef.Location = New System.Drawing.Point(122, 48)
        Me.txtShopRef.Name = "txtShopRef"
        Me.txtShopRef.Size = New System.Drawing.Size(100, 20)
        Me.txtShopRef.TabIndex = 1
        '
        'txtReference
        '
        Me.txtReference.Location = New System.Drawing.Point(122, 19)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(100, 20)
        Me.txtReference.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(271, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Current Qty:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Stock Code:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Shop Ref:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reference:"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(749, 466)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView2.TabIndex = 5
        Me.DataGridView2.Visible = False
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(749, 143)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView3.TabIndex = 6
        Me.DataGridView3.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(749, 310)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView1.TabIndex = 4
        Me.DataGridView1.Visible = False
        '
        'lblTransRef
        '
        Me.lblTransRef.AutoSize = True
        Me.lblTransRef.Location = New System.Drawing.Point(352, 24)
        Me.lblTransRef.Name = "lblTransRef"
        Me.lblTransRef.Size = New System.Drawing.Size(45, 13)
        Me.lblTransRef.TabIndex = 111
        Me.lblTransRef.Text = "Label11"
        Me.lblTransRef.Visible = False
        '
        'cmdFindWarehouse
        '
        Me.cmdFindWarehouse.Location = New System.Drawing.Point(228, 29)
        Me.cmdFindWarehouse.Name = "cmdFindWarehouse"
        Me.cmdFindWarehouse.Size = New System.Drawing.Size(25, 23)
        Me.cmdFindWarehouse.TabIndex = 120
        Me.cmdFindWarehouse.Text = "..."
        Me.cmdFindWarehouse.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(195, 377)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Needs coding"
        Me.Label10.Visible = False
        '
        'txtLocationType2
        '
        Me.txtLocationType2.Location = New System.Drawing.Point(89, 378)
        Me.txtLocationType2.Name = "txtLocationType2"
        Me.txtLocationType2.Size = New System.Drawing.Size(100, 20)
        Me.txtLocationType2.TabIndex = 17
        Me.txtLocationType2.Text = "2"
        Me.txtLocationType2.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTransRef)
        Me.GroupBox2.Controls.Add(Me.cmdFindWarehouse)
        Me.GroupBox2.Controls.Add(Me.txtTransferQty)
        Me.GroupBox2.Controls.Add(Me.txtWarehouseName)
        Me.GroupBox2.Controls.Add(Me.txtWarehouseRef)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 192)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 176)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Return To:"
        '
        'txtTransferQty
        '
        Me.txtTransferQty.Location = New System.Drawing.Point(122, 81)
        Me.txtTransferQty.Name = "txtTransferQty"
        Me.txtTransferQty.Size = New System.Drawing.Size(100, 20)
        Me.txtTransferQty.TabIndex = 1
        '
        'txtWarehouseRef
        '
        Me.txtWarehouseRef.Location = New System.Drawing.Point(122, 29)
        Me.txtWarehouseRef.Name = "txtWarehouseRef"
        Me.txtWarehouseRef.Size = New System.Drawing.Size(100, 20)
        Me.txtWarehouseRef.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Transfer Qty:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Warehouse Ref:"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(448, 376)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(277, 376)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 14
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'FReturns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 742)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtLocationType2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Name = "FReturns"
        Me.Text = "FReturns"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtWarehouseName As TextBox
    Friend WithEvents txtLocationType1 As TextBox
    Friend WithEvents txtMovementType As TextBox
    Friend WithEvents txtBoxes As TextBox
    Friend WithEvents txtMovementBoxes As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents cmdFindStock As Button
    Friend WithEvents cmdFindShop As Button
    Friend WithEvents txtShopName As TextBox
    Friend WithEvents cmdCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtCurrentQty As TextBox
    Friend WithEvents txtStockCode As TextBox
    Friend WithEvents txtShopRef As TextBox
    Friend WithEvents txtReference As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblTransRef As Label
    Friend WithEvents cmdFindWarehouse As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtLocationType2 As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtTransferQty As TextBox
    Friend WithEvents txtWarehouseRef As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdOK As Button
End Class
