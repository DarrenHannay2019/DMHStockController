
namespace DMHStockControllerV5
{
    partial class FShopReturn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReturnID = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtShopName = new System.Windows.Forms.TextBox();
            this.txtCurrentQty = new System.Windows.Forms.TextBox();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.txtShopRef = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdClearGrid = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalItems = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.txtTransferQty = new System.Windows.Forms.TextBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.txtWarehouseRef = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.DgvRecords = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(486, 591);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(140, 38);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(83, 44);
            this.txtReference.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtReference.MaxLength = 50;
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(184, 20);
            this.txtReference.TabIndex = 1;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(277, 79);
            this.Label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(38, 13);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Name:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 143);
            this.Label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 13);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Current Qty:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 111);
            this.Label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Stock Code:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(18, 83);
            this.Label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(55, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Shop Ref:";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(336, 591);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(140, 38);
            this.cmdOK.TabIndex = 13;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtReturnID);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.DtpDate);
            this.GroupBox1.Controls.Add(this.txtShopName);
            this.GroupBox1.Controls.Add(this.txtCurrentQty);
            this.GroupBox1.Controls.Add(this.txtStockCode);
            this.GroupBox1.Controls.Add(this.txtShopRef);
            this.GroupBox1.Controls.Add(this.txtReference);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(100, 18);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.GroupBox1.Size = new System.Drawing.Size(676, 171);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Current";
            // 
            // txtReturnID
            // 
            this.txtReturnID.Enabled = false;
            this.txtReturnID.Location = new System.Drawing.Point(83, 12);
            this.txtReturnID.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtReturnID.Name = "txtReturnID";
            this.txtReturnID.Size = new System.Drawing.Size(184, 20);
            this.txtReturnID.TabIndex = 4;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(23, 19);
            this.Label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(50, 13);
            this.Label11.TabIndex = 9;
            this.Label11.Text = "ReturnID";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(282, 19);
            this.Label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(33, 13);
            this.Label9.TabIndex = 5;
            this.Label9.Text = "Date:";
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd-MM-yyyy";
            this.DtpDate.Location = new System.Drawing.Point(325, 13);
            this.DtpDate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(249, 20);
            this.DtpDate.TabIndex = 0;
            this.DtpDate.Value = new System.DateTime(2016, 2, 7, 0, 0, 0, 0);
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(325, 76);
            this.txtShopName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.Size = new System.Drawing.Size(340, 20);
            this.txtShopName.TabIndex = 7;
            this.txtShopName.TabStop = false;
            // 
            // txtCurrentQty
            // 
            this.txtCurrentQty.Location = new System.Drawing.Point(83, 140);
            this.txtCurrentQty.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtCurrentQty.Name = "txtCurrentQty";
            this.txtCurrentQty.Size = new System.Drawing.Size(184, 20);
            this.txtCurrentQty.TabIndex = 14;
            // 
            // txtStockCode
            // 
            this.txtStockCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStockCode.Location = new System.Drawing.Point(83, 108);
            this.txtStockCode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtStockCode.MaxLength = 30;
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(184, 20);
            this.txtStockCode.TabIndex = 3;
            // 
            // txtShopRef
            // 
            this.txtShopRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShopRef.Location = new System.Drawing.Point(83, 76);
            this.txtShopRef.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtShopRef.MaxLength = 8;
            this.txtShopRef.Name = "txtShopRef";
            this.txtShopRef.Size = new System.Drawing.Size(184, 20);
            this.txtShopRef.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 47);
            this.Label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Reference:";
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(1232, 199);
            this.CheckBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(115, 17);
            this.CheckBox1.TabIndex = 11;
            this.CheckBox1.Text = "Return To Supplier";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.Visible = false;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(10, 32);
            this.Label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(85, 13);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Warehouse Ref:";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Value";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            this.Column5.Width = 125;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(636, 591);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(140, 38);
            this.cmdClear.TabIndex = 15;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            // 
            // cmdClearGrid
            // 
            this.cmdClearGrid.Location = new System.Drawing.Point(310, 88);
            this.cmdClearGrid.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdClearGrid.Name = "cmdClearGrid";
            this.cmdClearGrid.Size = new System.Drawing.Size(74, 38);
            this.cmdClearGrid.TabIndex = 3;
            this.cmdClearGrid.Text = "Delete All";
            this.cmdClearGrid.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtTotalItems);
            this.GroupBox2.Controls.Add(this.cmdClearGrid);
            this.GroupBox2.Controls.Add(this.Label10);
            this.GroupBox2.Controls.Add(this.cmdAdd);
            this.GroupBox2.Controls.Add(this.txtTransferQty);
            this.GroupBox2.Controls.Add(this.txtWarehouseName);
            this.GroupBox2.Controls.Add(this.txtWarehouseRef);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.DgvRecords);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Location = new System.Drawing.Point(97, 201);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.GroupBox2.Size = new System.Drawing.Size(679, 378);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Return To:";
            // 
            // txtTotalItems
            // 
            this.txtTotalItems.Location = new System.Drawing.Point(495, 275);
            this.txtTotalItems.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTotalItems.Name = "txtTotalItems";
            this.txtTotalItems.Size = new System.Drawing.Size(108, 20);
            this.txtTotalItems.TabIndex = 10;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(495, 256);
            this.Label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(62, 13);
            this.Label10.TabIndex = 9;
            this.Label10.Text = "Total Items:";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(229, 89);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(71, 36);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // txtTransferQty
            // 
            this.txtTransferQty.Location = new System.Drawing.Point(105, 89);
            this.txtTransferQty.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTransferQty.Name = "txtTransferQty";
            this.txtTransferQty.Size = new System.Drawing.Size(114, 20);
            this.txtTransferQty.TabIndex = 1;
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.Location = new System.Drawing.Point(105, 57);
            this.txtWarehouseName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(380, 20);
            this.txtWarehouseName.TabIndex = 7;
            this.txtWarehouseName.TabStop = false;
            // 
            // txtWarehouseRef
            // 
            this.txtWarehouseRef.Location = new System.Drawing.Point(105, 25);
            this.txtWarehouseRef.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtWarehouseRef.MaxLength = 8;
            this.txtWarehouseRef.Name = "txtWarehouseRef";
            this.txtWarehouseRef.Size = new System.Drawing.Size(114, 20);
            this.txtWarehouseRef.TabIndex = 0;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(27, 90);
            this.Label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(68, 13);
            this.Label8.TabIndex = 6;
            this.Label8.Text = "Transfer Qty:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(57, 60);
            this.Label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(38, 13);
            this.Label7.TabIndex = 5;
            this.Label7.Text = "Name:";
            // 
            // DgvRecords
            // 
            this.DgvRecords.AllowUserToAddRows = false;
            this.DgvRecords.AllowUserToDeleteRows = false;
            this.DgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            this.DgvRecords.Location = new System.Drawing.Point(10, 138);
            this.DgvRecords.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.DgvRecords.Name = "DgvRecords";
            this.DgvRecords.RowHeadersWidth = 51;
            this.DgvRecords.Size = new System.Drawing.Size(475, 223);
            this.DgvRecords.TabIndex = 8;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Stock Code";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Qty";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // FShopReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 644);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.GroupBox2);
            this.Name = "FShopReturn";
            this.Text = "FShopReturn";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.TextBox txtReference;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtReturnID;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.DateTimePicker DtpDate;
        internal System.Windows.Forms.TextBox txtShopName;
        internal System.Windows.Forms.TextBox txtCurrentQty;
        internal System.Windows.Forms.TextBox txtStockCode;
        internal System.Windows.Forms.TextBox txtShopRef;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.Button cmdClear;
        internal System.Windows.Forms.Button cmdClearGrid;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtTotalItems;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Button cmdAdd;
        internal System.Windows.Forms.TextBox txtTransferQty;
        internal System.Windows.Forms.TextBox txtWarehouseName;
        internal System.Windows.Forms.TextBox txtWarehouseRef;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.DataGridView DgvRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}