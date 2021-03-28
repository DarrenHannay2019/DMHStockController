
namespace DMHStockControllerV5
{
    partial class FStock
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
            System.Windows.Forms.Label StockCodeLabel;
            System.Windows.Forms.Label SupplierRefLabel;
            System.Windows.Forms.Label DeadCodeLabel;
            System.Windows.Forms.Label AmountTakenLabel;
            System.Windows.Forms.Label CostValueLabel;
            System.Windows.Forms.Label PCMarkUpLabel;
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DgvLocationQty = new System.Windows.Forms.DataGridView();
            this.TxtDelHangersQty = new System.Windows.Forms.TextBox();
            this.TxtDelGarmentsQty = new System.Windows.Forms.TextBox();
            this.TxtDelBoxesQty = new System.Windows.Forms.TextBox();
            this.TxtPcMarkUp = new System.Windows.Forms.TextBox();
            this.TxtCostValue = new System.Windows.Forms.TextBox();
            this.TxtAmountTaken = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CboSeason = new System.Windows.Forms.ComboBox();
            this.TxtSupplierRef = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkZeroQty = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtStockCode = new System.Windows.Forms.TextBox();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdOK = new System.Windows.Forms.Button();
            this.ChkDeadCode = new System.Windows.Forms.CheckBox();
            StockCodeLabel = new System.Windows.Forms.Label();
            SupplierRefLabel = new System.Windows.Forms.Label();
            DeadCodeLabel = new System.Windows.Forms.Label();
            AmountTakenLabel = new System.Windows.Forms.Label();
            CostValueLabel = new System.Windows.Forms.Label();
            PCMarkUpLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocationQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 124;
            this.label7.Text = "Hangers:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 123;
            this.label6.Text = "Location Stock Levels";
            // 
            // DgvLocationQty
            // 
            this.DgvLocationQty.AllowUserToAddRows = false;
            this.DgvLocationQty.AllowUserToDeleteRows = false;
            this.DgvLocationQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLocationQty.Location = new System.Drawing.Point(398, 111);
            this.DgvLocationQty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvLocationQty.Name = "DgvLocationQty";
            this.DgvLocationQty.ReadOnly = true;
            this.DgvLocationQty.RowHeadersWidth = 62;
            this.DgvLocationQty.Size = new System.Drawing.Size(261, 223);
            this.DgvLocationQty.TabIndex = 122;
            // 
            // TxtDelHangersQty
            // 
            this.TxtDelHangersQty.Location = new System.Drawing.Point(241, 278);
            this.TxtDelHangersQty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDelHangersQty.Name = "TxtDelHangersQty";
            this.TxtDelHangersQty.Size = new System.Drawing.Size(73, 20);
            this.TxtDelHangersQty.TabIndex = 121;
            // 
            // TxtDelGarmentsQty
            // 
            this.TxtDelGarmentsQty.Location = new System.Drawing.Point(243, 348);
            this.TxtDelGarmentsQty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDelGarmentsQty.Name = "TxtDelGarmentsQty";
            this.TxtDelGarmentsQty.Size = new System.Drawing.Size(71, 20);
            this.TxtDelGarmentsQty.TabIndex = 120;
            // 
            // TxtDelBoxesQty
            // 
            this.TxtDelBoxesQty.Location = new System.Drawing.Point(241, 314);
            this.TxtDelBoxesQty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDelBoxesQty.Name = "TxtDelBoxesQty";
            this.TxtDelBoxesQty.Size = new System.Drawing.Size(73, 20);
            this.TxtDelBoxesQty.TabIndex = 119;
            // 
            // TxtPcMarkUp
            // 
            this.TxtPcMarkUp.Location = new System.Drawing.Point(228, 230);
            this.TxtPcMarkUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtPcMarkUp.Name = "TxtPcMarkUp";
            this.TxtPcMarkUp.Size = new System.Drawing.Size(110, 20);
            this.TxtPcMarkUp.TabIndex = 118;
            // 
            // TxtCostValue
            // 
            this.TxtCostValue.Location = new System.Drawing.Point(228, 178);
            this.TxtCostValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtCostValue.Name = "TxtCostValue";
            this.TxtCostValue.Size = new System.Drawing.Size(110, 20);
            this.TxtCostValue.TabIndex = 117;
            // 
            // TxtAmountTaken
            // 
            this.TxtAmountTaken.Location = new System.Drawing.Point(228, 204);
            this.TxtAmountTaken.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtAmountTaken.Name = "TxtAmountTaken";
            this.TxtAmountTaken.Size = new System.Drawing.Size(110, 20);
            this.TxtAmountTaken.TabIndex = 116;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 350);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 115;
            this.label5.Text = "Garments:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 316);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 114;
            this.label4.Text = "Boxes:";
            // 
            // CboSeason
            // 
            this.CboSeason.FormattingEnabled = true;
            this.CboSeason.Location = new System.Drawing.Point(228, 131);
            this.CboSeason.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CboSeason.Name = "CboSeason";
            this.CboSeason.Size = new System.Drawing.Size(162, 21);
            this.CboSeason.TabIndex = 113;
            // 
            // TxtSupplierRef
            // 
            this.TxtSupplierRef.Location = new System.Drawing.Point(228, 105);
            this.TxtSupplierRef.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSupplierRef.Name = "TxtSupplierRef";
            this.TxtSupplierRef.Size = new System.Drawing.Size(162, 20);
            this.TxtSupplierRef.TabIndex = 112;
            this.TxtSupplierRef.Leave += new System.EventHandler(this.TxtSupplierRef_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 111;
            this.label3.Text = "Zero Qty:";
            // 
            // ChkZeroQty
            // 
            this.ChkZeroQty.AutoSize = true;
            this.ChkZeroQty.Location = new System.Drawing.Point(339, 158);
            this.ChkZeroQty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChkZeroQty.Name = "ChkZeroQty";
            this.ChkZeroQty.Size = new System.Drawing.Size(15, 14);
            this.ChkZeroQty.TabIndex = 110;
            this.ChkZeroQty.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 253);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Delivered Qty:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Season:";
            // 
            // TxtStockCode
            // 
            this.TxtStockCode.Location = new System.Drawing.Point(228, 79);
            this.TxtStockCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtStockCode.Name = "TxtStockCode";
            this.TxtStockCode.Size = new System.Drawing.Size(162, 20);
            this.TxtStockCode.TabIndex = 107;
            this.TxtStockCode.Leave += new System.EventHandler(this.TxtStockCode_Leave);
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(596, 342);
            this.CmdCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(63, 30);
            this.CmdCancel.TabIndex = 100;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // CmdOK
            // 
            this.CmdOK.Location = new System.Drawing.Point(525, 341);
            this.CmdOK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(61, 30);
            this.CmdOK.TabIndex = 99;
            this.CmdOK.Text = "Button1";
            this.CmdOK.UseVisualStyleBackColor = true;
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // StockCodeLabel
            // 
            StockCodeLabel.AutoSize = true;
            StockCodeLabel.Location = new System.Drawing.Point(155, 80);
            StockCodeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            StockCodeLabel.Name = "StockCodeLabel";
            StockCodeLabel.Size = new System.Drawing.Size(66, 13);
            StockCodeLabel.TabIndex = 101;
            StockCodeLabel.Text = "Stock Code:";
            // 
            // SupplierRefLabel
            // 
            SupplierRefLabel.AutoSize = true;
            SupplierRefLabel.Location = new System.Drawing.Point(153, 108);
            SupplierRefLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            SupplierRefLabel.Name = "SupplierRefLabel";
            SupplierRefLabel.Size = new System.Drawing.Size(68, 13);
            SupplierRefLabel.TabIndex = 102;
            SupplierRefLabel.Text = "Supplier Ref:";
            // 
            // DeadCodeLabel
            // 
            DeadCodeLabel.AutoSize = true;
            DeadCodeLabel.Location = new System.Drawing.Point(157, 159);
            DeadCodeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            DeadCodeLabel.Name = "DeadCodeLabel";
            DeadCodeLabel.Size = new System.Drawing.Size(64, 13);
            DeadCodeLabel.TabIndex = 103;
            DeadCodeLabel.Text = "Dead Code:";
            // 
            // ChkDeadCode
            // 
            this.ChkDeadCode.Location = new System.Drawing.Point(228, 149);
            this.ChkDeadCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ChkDeadCode.Name = "ChkDeadCode";
            this.ChkDeadCode.Size = new System.Drawing.Size(35, 33);
            this.ChkDeadCode.TabIndex = 98;
            this.ChkDeadCode.UseVisualStyleBackColor = true;
            // 
            // AmountTakenLabel
            // 
            AmountTakenLabel.AutoSize = true;
            AmountTakenLabel.Location = new System.Drawing.Point(141, 204);
            AmountTakenLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            AmountTakenLabel.Name = "AmountTakenLabel";
            AmountTakenLabel.Size = new System.Drawing.Size(80, 13);
            AmountTakenLabel.TabIndex = 104;
            AmountTakenLabel.Text = "Amount Taken:";
            // 
            // CostValueLabel
            // 
            CostValueLabel.AutoSize = true;
            CostValueLabel.Location = new System.Drawing.Point(160, 178);
            CostValueLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            CostValueLabel.Name = "CostValueLabel";
            CostValueLabel.Size = new System.Drawing.Size(61, 13);
            CostValueLabel.TabIndex = 105;
            CostValueLabel.Text = "Cost Value:";
            // 
            // PCMarkUpLabel
            // 
            PCMarkUpLabel.AutoSize = true;
            PCMarkUpLabel.Location = new System.Drawing.Point(156, 233);
            PCMarkUpLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            PCMarkUpLabel.Name = "PCMarkUpLabel";
            PCMarkUpLabel.Size = new System.Drawing.Size(65, 13);
            PCMarkUpLabel.TabIndex = 106;
            PCMarkUpLabel.Text = "PCMark Up:";
            // 
            // FStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DgvLocationQty);
            this.Controls.Add(this.TxtDelHangersQty);
            this.Controls.Add(this.TxtDelGarmentsQty);
            this.Controls.Add(this.TxtDelBoxesQty);
            this.Controls.Add(this.TxtPcMarkUp);
            this.Controls.Add(this.TxtCostValue);
            this.Controls.Add(this.TxtAmountTaken);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CboSeason);
            this.Controls.Add(this.TxtSupplierRef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChkZeroQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtStockCode);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdOK);
            this.Controls.Add(StockCodeLabel);
            this.Controls.Add(SupplierRefLabel);
            this.Controls.Add(DeadCodeLabel);
            this.Controls.Add(this.ChkDeadCode);
            this.Controls.Add(AmountTakenLabel);
            this.Controls.Add(CostValueLabel);
            this.Controls.Add(PCMarkUpLabel);
            this.Name = "FStock";
            this.Text = "FStock";
            this.Load += new System.EventHandler(this.FStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocationQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DgvLocationQty;
        private System.Windows.Forms.TextBox TxtDelHangersQty;
        private System.Windows.Forms.TextBox TxtDelGarmentsQty;
        private System.Windows.Forms.TextBox TxtDelBoxesQty;
        private System.Windows.Forms.TextBox TxtPcMarkUp;
        private System.Windows.Forms.TextBox TxtCostValue;
        private System.Windows.Forms.TextBox TxtAmountTaken;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CboSeason;
        private System.Windows.Forms.TextBox TxtSupplierRef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkZeroQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TxtStockCode;
        internal System.Windows.Forms.Button CmdCancel;
        internal System.Windows.Forms.Button CmdOK;
        internal System.Windows.Forms.CheckBox ChkDeadCode;
    }
}