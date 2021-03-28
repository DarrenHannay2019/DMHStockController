
namespace DMHStockControllerV5
{
    partial class FShopTransfer
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
            this.Label9 = new System.Windows.Forms.Label();
            this.TxtTransferID = new System.Windows.Forms.TextBox();
            this.DgvRecords = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmdDeleteFromGrid = new System.Windows.Forms.Button();
            this.CmdAddToGrid = new System.Windows.Forms.Button();
            this.txtTotalTransferTo = new System.Windows.Forms.TextBox();
            this.TxtTransferFromQty = new System.Windows.Forms.TextBox();
            this.TxtCurrentQty = new System.Windows.Forms.TextBox();
            this.TxtStockCode = new System.Windows.Forms.TextBox();
            this.txtToShopName = new System.Windows.Forms.TextBox();
            this.TxtToShopRef = new System.Windows.Forms.TextBox();
            this.txtFromShopName = new System.Windows.Forms.TextBox();
            this.TxtFromShopRef = new System.Windows.Forms.TextBox();
            this.TxtTFNote = new System.Windows.Forms.TextBox();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdOK = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(176, 87);
            this.Label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(82, 13);
            this.Label9.TabIndex = 87;
            this.Label9.Text = "Record Number";
            // 
            // TxtTransferID
            // 
            this.TxtTransferID.Location = new System.Drawing.Point(268, 84);
            this.TxtTransferID.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtTransferID.Name = "TxtTransferID";
            this.TxtTransferID.Size = new System.Drawing.Size(184, 20);
            this.TxtTransferID.TabIndex = 89;
            // 
            // DgvRecords
            // 
            this.DgvRecords.AllowUserToAddRows = false;
            this.DgvRecords.AllowUserToDeleteRows = false;
            this.DgvRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvRecords.ColumnHeadersHeight = 29;
            this.DgvRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.DgvRecords.Location = new System.Drawing.Point(179, 416);
            this.DgvRecords.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.DgvRecords.Name = "DgvRecords";
            this.DgvRecords.RowHeadersWidth = 51;
            this.DgvRecords.Size = new System.Drawing.Size(479, 318);
            this.DgvRecords.TabIndex = 83;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 162.2788F;
            this.Column5.HeaderText = "Stock Code";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.FillWeight = 61.57903F;
            this.Column6.HeaderText = "Current Qty";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.FillWeight = 76.14214F;
            this.Column7.HeaderText = "Qty";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "To Qty";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // CmdDeleteFromGrid
            // 
            this.CmdDeleteFromGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDeleteFromGrid.Location = new System.Drawing.Point(535, 369);
            this.CmdDeleteFromGrid.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CmdDeleteFromGrid.Name = "CmdDeleteFromGrid";
            this.CmdDeleteFromGrid.Size = new System.Drawing.Size(50, 38);
            this.CmdDeleteFromGrid.TabIndex = 82;
            this.CmdDeleteFromGrid.Text = "-";
            this.CmdDeleteFromGrid.UseVisualStyleBackColor = true;
            // 
            // CmdAddToGrid
            // 
            this.CmdAddToGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAddToGrid.Location = new System.Drawing.Point(463, 369);
            this.CmdAddToGrid.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CmdAddToGrid.Name = "CmdAddToGrid";
            this.CmdAddToGrid.Size = new System.Drawing.Size(62, 38);
            this.CmdAddToGrid.TabIndex = 81;
            this.CmdAddToGrid.Text = "+";
            this.CmdAddToGrid.UseVisualStyleBackColor = true;
            // 
            // txtTotalTransferTo
            // 
            this.txtTotalTransferTo.Location = new System.Drawing.Point(569, 746);
            this.txtTotalTransferTo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTotalTransferTo.Name = "txtTotalTransferTo";
            this.txtTotalTransferTo.Size = new System.Drawing.Size(89, 20);
            this.txtTotalTransferTo.TabIndex = 99;
            // 
            // TxtTransferFromQty
            // 
            this.TxtTransferFromQty.Location = new System.Drawing.Point(268, 373);
            this.TxtTransferFromQty.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtTransferFromQty.Name = "TxtTransferFromQty";
            this.TxtTransferFromQty.Size = new System.Drawing.Size(184, 20);
            this.TxtTransferFromQty.TabIndex = 80;
            // 
            // TxtCurrentQty
            // 
            this.TxtCurrentQty.Location = new System.Drawing.Point(268, 332);
            this.TxtCurrentQty.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtCurrentQty.Name = "TxtCurrentQty";
            this.TxtCurrentQty.Size = new System.Drawing.Size(184, 20);
            this.TxtCurrentQty.TabIndex = 97;
            // 
            // TxtStockCode
            // 
            this.TxtStockCode.Location = new System.Drawing.Point(268, 290);
            this.TxtStockCode.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtStockCode.MaxLength = 30;
            this.TxtStockCode.Name = "TxtStockCode";
            this.TxtStockCode.Size = new System.Drawing.Size(184, 20);
            this.TxtStockCode.TabIndex = 79;
            // 
            // txtToShopName
            // 
            this.txtToShopName.Location = new System.Drawing.Point(363, 249);
            this.txtToShopName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtToShopName.Name = "txtToShopName";
            this.txtToShopName.Size = new System.Drawing.Size(266, 20);
            this.txtToShopName.TabIndex = 92;
            this.txtToShopName.TabStop = false;
            // 
            // TxtToShopRef
            // 
            this.TxtToShopRef.Location = new System.Drawing.Point(268, 249);
            this.TxtToShopRef.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtToShopRef.MaxLength = 8;
            this.TxtToShopRef.Name = "TxtToShopRef";
            this.TxtToShopRef.Size = new System.Drawing.Size(84, 20);
            this.TxtToShopRef.TabIndex = 78;
            // 
            // txtFromShopName
            // 
            this.txtFromShopName.Location = new System.Drawing.Point(363, 208);
            this.txtFromShopName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtFromShopName.Name = "txtFromShopName";
            this.txtFromShopName.Size = new System.Drawing.Size(266, 20);
            this.txtFromShopName.TabIndex = 91;
            this.txtFromShopName.TabStop = false;
            // 
            // TxtFromShopRef
            // 
            this.TxtFromShopRef.Location = new System.Drawing.Point(268, 208);
            this.TxtFromShopRef.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtFromShopRef.MaxLength = 8;
            this.TxtFromShopRef.Name = "TxtFromShopRef";
            this.TxtFromShopRef.Size = new System.Drawing.Size(84, 20);
            this.TxtFromShopRef.TabIndex = 77;
            // 
            // TxtTFNote
            // 
            this.TxtTFNote.Location = new System.Drawing.Point(268, 167);
            this.TxtTFNote.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.TxtTFNote.MaxLength = 30;
            this.TxtTFNote.Name = "TxtTFNote";
            this.TxtTFNote.Size = new System.Drawing.Size(184, 20);
            this.TxtTFNote.TabIndex = 76;
            // 
            // CmdClear
            // 
            this.CmdClear.Location = new System.Drawing.Point(548, 787);
            this.CmdClear.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.Size = new System.Drawing.Size(140, 38);
            this.CmdClear.TabIndex = 86;
            this.CmdClear.Text = "Clear";
            this.CmdClear.UseVisualStyleBackColor = true;
            // 
            // CmdOK
            // 
            this.CmdOK.Location = new System.Drawing.Point(248, 787);
            this.CmdOK.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(140, 38);
            this.CmdOK.TabIndex = 84;
            this.CmdOK.Text = "Ok";
            this.CmdOK.UseVisualStyleBackColor = true;
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(398, 787);
            this.CmdCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(140, 38);
            this.CmdCancel.TabIndex = 85;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            // 
            // DtpDate
            // 
            this.DtpDate.Location = new System.Drawing.Point(268, 126);
            this.DtpDate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(362, 20);
            this.DtpDate.TabIndex = 75;
            this.DtpDate.Value = new System.DateTime(2017, 9, 1, 0, 0, 0, 0);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label7.Location = new System.Drawing.Point(190, 376);
            this.Label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(68, 13);
            this.Label7.TabIndex = 98;
            this.Label7.Text = "Transfer Qty:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(195, 335);
            this.Label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(63, 13);
            this.Label6.TabIndex = 96;
            this.Label6.Text = "Current Qty:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label5.Location = new System.Drawing.Point(192, 298);
            this.Label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(66, 13);
            this.Label5.TabIndex = 95;
            this.Label5.Text = "Stock Code:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label4.Location = new System.Drawing.Point(225, 125);
            this.Label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(33, 13);
            this.Label4.TabIndex = 90;
            this.Label4.Text = "Date:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label3.Location = new System.Drawing.Point(207, 252);
            this.Label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(51, 13);
            this.Label3.TabIndex = 94;
            this.Label3.Text = "To Shop:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label2.Location = new System.Drawing.Point(200, 211);
            this.Label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(58, 13);
            this.Label2.TabIndex = 93;
            this.Label2.Text = "From Shop";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(192, 166);
            this.Label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(66, 13);
            this.Label1.TabIndex = 88;
            this.Label1.Text = "TF Note No:";
            // 
            // FShopTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 908);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.TxtTransferID);
            this.Controls.Add(this.DgvRecords);
            this.Controls.Add(this.CmdDeleteFromGrid);
            this.Controls.Add(this.CmdAddToGrid);
            this.Controls.Add(this.txtTotalTransferTo);
            this.Controls.Add(this.TxtTransferFromQty);
            this.Controls.Add(this.TxtCurrentQty);
            this.Controls.Add(this.TxtStockCode);
            this.Controls.Add(this.txtToShopName);
            this.Controls.Add(this.TxtToShopRef);
            this.Controls.Add(this.txtFromShopName);
            this.Controls.Add(this.TxtFromShopRef);
            this.Controls.Add(this.TxtTFNote);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdOK);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.DtpDate);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "FShopTransfer";
            this.Text = "FShopTransfer";
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox TxtTransferID;
        internal System.Windows.Forms.DataGridView DgvRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        internal System.Windows.Forms.Button CmdDeleteFromGrid;
        internal System.Windows.Forms.Button CmdAddToGrid;
        internal System.Windows.Forms.TextBox txtTotalTransferTo;
        internal System.Windows.Forms.TextBox TxtTransferFromQty;
        internal System.Windows.Forms.TextBox TxtCurrentQty;
        internal System.Windows.Forms.TextBox TxtStockCode;
        internal System.Windows.Forms.TextBox txtToShopName;
        internal System.Windows.Forms.TextBox TxtToShopRef;
        internal System.Windows.Forms.TextBox txtFromShopName;
        internal System.Windows.Forms.TextBox TxtFromShopRef;
        internal System.Windows.Forms.TextBox TxtTFNote;
        internal System.Windows.Forms.Button CmdClear;
        internal System.Windows.Forms.Button CmdOK;
        internal System.Windows.Forms.Button CmdCancel;
        internal System.Windows.Forms.DateTimePicker DtpDate;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}