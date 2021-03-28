
namespace DMHStockControllerV5
{
    partial class FWarehouseAdjustment
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
            this.TxtRecordID = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.TxtTotalLoss = new System.Windows.Forms.Label();
            this.TxtTotalGain = new System.Windows.Forms.Label();
            this.LblTotalLoss = new System.Windows.Forms.Label();
            this.lblTotalGain = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmdRemoveFromGrid = new System.Windows.Forms.Button();
            this.CboType = new System.Windows.Forms.ComboBox();
            this.TxtAdjustHangers = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.CmdAddToGrid = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.TxtWarehouseName = new System.Windows.Forms.TextBox();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Label10 = new System.Windows.Forms.Label();
            this.CmdOK = new System.Windows.Forms.Button();
            this.TxtCurrentHangers = new System.Windows.Forms.TextBox();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.TxtWarehouseRef = new System.Windows.Forms.TextBox();
            this.TxtReference = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtStockCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtRecordID
            // 
            this.TxtRecordID.Location = new System.Drawing.Point(587, 53);
            this.TxtRecordID.Name = "TxtRecordID";
            this.TxtRecordID.Size = new System.Drawing.Size(54, 20);
            this.TxtRecordID.TabIndex = 69;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(519, 55);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(59, 13);
            this.Label6.TabIndex = 68;
            this.Label6.Text = "Record ID:";
            // 
            // TxtTotalLoss
            // 
            this.TxtTotalLoss.AutoSize = true;
            this.TxtTotalLoss.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TxtTotalLoss.Location = new System.Drawing.Point(348, 382);
            this.TxtTotalLoss.Name = "TxtTotalLoss";
            this.TxtTotalLoss.Size = new System.Drawing.Size(21, 15);
            this.TxtTotalLoss.TabIndex = 81;
            this.TxtTotalLoss.Text = "00";
            // 
            // TxtTotalGain
            // 
            this.TxtTotalGain.AutoSize = true;
            this.TxtTotalGain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TxtTotalGain.Location = new System.Drawing.Point(235, 382);
            this.TxtTotalGain.Name = "TxtTotalGain";
            this.TxtTotalGain.Size = new System.Drawing.Size(21, 15);
            this.TxtTotalGain.TabIndex = 79;
            this.TxtTotalGain.Text = "00";
            // 
            // LblTotalLoss
            // 
            this.LblTotalLoss.AutoSize = true;
            this.LblTotalLoss.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblTotalLoss.Location = new System.Drawing.Point(324, 367);
            this.LblTotalLoss.Name = "LblTotalLoss";
            this.LblTotalLoss.Size = new System.Drawing.Size(61, 15);
            this.LblTotalLoss.TabIndex = 80;
            this.LblTotalLoss.Text = "Total Loss:";
            // 
            // lblTotalGain
            // 
            this.lblTotalGain.AutoSize = true;
            this.lblTotalGain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalGain.Location = new System.Drawing.Point(220, 367);
            this.lblTotalGain.Name = "lblTotalGain";
            this.lblTotalGain.Size = new System.Drawing.Size(61, 15);
            this.lblTotalGain.TabIndex = 78;
            this.lblTotalGain.Text = "Total Gain:";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvItems.Location = new System.Drawing.Point(152, 151);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.Size = new System.Drawing.Size(499, 213);
            this.dgvItems.TabIndex = 83;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "StockCode";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Movement Type";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Qty";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Value";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // CmdRemoveFromGrid
            // 
            this.CmdRemoveFromGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdRemoveFromGrid.Location = new System.Drawing.Point(622, 110);
            this.CmdRemoveFromGrid.Name = "CmdRemoveFromGrid";
            this.CmdRemoveFromGrid.Size = new System.Drawing.Size(28, 33);
            this.CmdRemoveFromGrid.TabIndex = 63;
            this.CmdRemoveFromGrid.Text = "-";
            this.CmdRemoveFromGrid.UseVisualStyleBackColor = true;
            // 
            // CboType
            // 
            this.CboType.AutoCompleteCustomSource.AddRange(new string[] {
            "Gain",
            "Loss"});
            this.CboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboType.FormattingEnabled = true;
            this.CboType.Items.AddRange(new object[] {
            "Loss",
            "Gain"});
            this.CboType.Location = new System.Drawing.Point(335, 125);
            this.CboType.Name = "CboType";
            this.CboType.Size = new System.Drawing.Size(108, 21);
            this.CboType.TabIndex = 60;
            // 
            // TxtAdjustHangers
            // 
            this.TxtAdjustHangers.Location = new System.Drawing.Point(447, 125);
            this.TxtAdjustHangers.Name = "TxtAdjustHangers";
            this.TxtAdjustHangers.Size = new System.Drawing.Size(136, 20);
            this.TxtAdjustHangers.TabIndex = 61;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(450, 109);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(81, 13);
            this.Label8.TabIndex = 70;
            this.Label8.Text = "Adjustment Qty:";
            // 
            // CmdAddToGrid
            // 
            this.CmdAddToGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAddToGrid.Location = new System.Drawing.Point(587, 109);
            this.CmdAddToGrid.Name = "CmdAddToGrid";
            this.CmdAddToGrid.Size = new System.Drawing.Size(28, 34);
            this.CmdAddToGrid.TabIndex = 62;
            this.CmdAddToGrid.Text = "+";
            this.CmdAddToGrid.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(335, 109);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(89, 13);
            this.Label7.TabIndex = 71;
            this.Label7.Text = "Adjustment Type:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(322, 80);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(38, 13);
            this.Label5.TabIndex = 76;
            this.Label5.Text = "Name:";
            // 
            // TxtWarehouseName
            // 
            this.TxtWarehouseName.Enabled = false;
            this.TxtWarehouseName.Location = new System.Drawing.Point(368, 77);
            this.TxtWarehouseName.Name = "TxtWarehouseName";
            this.TxtWarehouseName.Size = new System.Drawing.Size(136, 20);
            this.TxtWarehouseName.TabIndex = 77;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Location = new System.Drawing.Point(195, 54);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(135, 20);
            this.DateTimePicker1.TabIndex = 56;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(155, 55);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(33, 13);
            this.Label10.TabIndex = 75;
            this.Label10.Text = "Date:";
            // 
            // CmdOK
            // 
            this.CmdOK.Location = new System.Drawing.Point(435, 370);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(65, 23);
            this.CmdOK.TabIndex = 64;
            this.CmdOK.Text = "Add";
            this.CmdOK.UseVisualStyleBackColor = true;
            // 
            // TxtCurrentHangers
            // 
            this.TxtCurrentHangers.Location = new System.Drawing.Point(258, 125);
            this.TxtCurrentHangers.Name = "TxtCurrentHangers";
            this.TxtCurrentHangers.Size = new System.Drawing.Size(72, 20);
            this.TxtCurrentHangers.TabIndex = 82;
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(585, 370);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(65, 23);
            this.CmdCancel.TabIndex = 66;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            // 
            // CmdClear
            // 
            this.CmdClear.Location = new System.Drawing.Point(513, 370);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.Size = new System.Drawing.Size(65, 23);
            this.CmdClear.TabIndex = 65;
            this.CmdClear.Text = "Clear";
            this.CmdClear.UseVisualStyleBackColor = true;
            // 
            // TxtWarehouseRef
            // 
            this.TxtWarehouseRef.Location = new System.Drawing.Point(250, 78);
            this.TxtWarehouseRef.MaxLength = 8;
            this.TxtWarehouseRef.Name = "TxtWarehouseRef";
            this.TxtWarehouseRef.Size = new System.Drawing.Size(63, 20);
            this.TxtWarehouseRef.TabIndex = 58;
            // 
            // TxtReference
            // 
            this.TxtReference.Location = new System.Drawing.Point(403, 53);
            this.TxtReference.MaxLength = 50;
            this.TxtReference.Name = "TxtReference";
            this.TxtReference.Size = new System.Drawing.Size(112, 20);
            this.TxtReference.TabIndex = 57;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(335, 55);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 13);
            this.Label1.TabIndex = 67;
            this.Label1.Text = "Reference:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(150, 80);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(85, 13);
            this.Label2.TabIndex = 74;
            this.Label2.Text = "Warehouse Ref:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(263, 109);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 13);
            this.Label4.TabIndex = 72;
            this.Label4.Text = "Current Qty:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(155, 109);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 73;
            this.Label3.Text = "Stock Code:";
            // 
            // TxtStockCode
            // 
            this.TxtStockCode.Location = new System.Drawing.Point(156, 125);
            this.TxtStockCode.MaxLength = 30;
            this.TxtStockCode.Name = "TxtStockCode";
            this.TxtStockCode.Size = new System.Drawing.Size(97, 20);
            this.TxtStockCode.TabIndex = 59;
            // 
            // FWarehouseAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtRecordID);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.TxtTotalLoss);
            this.Controls.Add(this.TxtTotalGain);
            this.Controls.Add(this.LblTotalLoss);
            this.Controls.Add(this.lblTotalGain);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.CmdRemoveFromGrid);
            this.Controls.Add(this.CboType);
            this.Controls.Add(this.TxtAdjustHangers);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.CmdAddToGrid);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.TxtWarehouseName);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.CmdOK);
            this.Controls.Add(this.TxtCurrentHangers);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.TxtWarehouseRef);
            this.Controls.Add(this.TxtReference);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TxtStockCode);
            this.Name = "FWarehouseAdjustment";
            this.Text = "FWarehouseAdjustment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TxtRecordID;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label TxtTotalLoss;
        internal System.Windows.Forms.Label TxtTotalGain;
        internal System.Windows.Forms.Label LblTotalLoss;
        internal System.Windows.Forms.Label lblTotalGain;
        internal System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.Button CmdRemoveFromGrid;
        internal System.Windows.Forms.ComboBox CboType;
        internal System.Windows.Forms.TextBox TxtAdjustHangers;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button CmdAddToGrid;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox TxtWarehouseName;
        internal System.Windows.Forms.DateTimePicker DateTimePicker1;
        internal System.Windows.Forms.Label Label10;
        public System.Windows.Forms.Button CmdOK;
        internal System.Windows.Forms.TextBox TxtCurrentHangers;
        internal System.Windows.Forms.Button CmdCancel;
        internal System.Windows.Forms.Button CmdClear;
        internal System.Windows.Forms.TextBox TxtWarehouseRef;
        internal System.Windows.Forms.TextBox TxtReference;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtStockCode;
    }
}