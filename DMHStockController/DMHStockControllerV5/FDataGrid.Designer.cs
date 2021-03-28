
namespace DMHStockControllerV5
{
    partial class FDataGrid
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
            this.components = new System.ComponentModel.Container();
            this.TsbFind = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsbNew = new System.Windows.Forms.ToolStripButton();
            this.TsbRecord = new System.Windows.Forms.ToolStripButton();
            this.TsbDelete = new System.Windows.Forms.ToolStripButton();
            this.TsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.TsbPrint = new System.Windows.Forms.ToolStripButton();
            this.TSBBalances = new System.Windows.Forms.ToolStripButton();
            this.TsbClose = new System.Windows.Forms.ToolStripButton();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.DgvRecords = new System.Windows.Forms.DataGridView();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSSLFunction = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // TsbFind
            // 
            this.TsbFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbFind.Name = "TsbFind";
            this.TsbFind.Size = new System.Drawing.Size(41, 55);
            this.TsbFind.Text = "Find";
            this.TsbFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbFind.Click += new System.EventHandler(this.TsbFind_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbNew,
            this.TsbRecord,
            this.TsbDelete,
            this.TsbRefresh,
            this.TsbPrint,
            this.TsbFind,
            this.TSBBalances,
            this.TsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 58);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsbNew
            // 
            this.TsbNew.AutoSize = false;
            this.TsbNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbNew.Name = "TsbNew";
            this.TsbNew.Size = new System.Drawing.Size(43, 55);
            this.TsbNew.Text = "New";
            this.TsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbNew.Click += new System.EventHandler(this.TsbNew_Click);
            // 
            // TsbRecord
            // 
            this.TsbRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsbRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbRecord.Name = "TsbRecord";
            this.TsbRecord.Size = new System.Drawing.Size(61, 55);
            this.TsbRecord.Text = "Record";
            this.TsbRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbRecord.Click += new System.EventHandler(this.TsbRecord_Click);
            // 
            // TsbDelete
            // 
            this.TsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbDelete.Name = "TsbDelete";
            this.TsbDelete.Size = new System.Drawing.Size(56, 55);
            this.TsbDelete.Text = "Delete";
            this.TsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbDelete.Click += new System.EventHandler(this.TsbDelete_Click);
            // 
            // TsbRefresh
            // 
            this.TsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbRefresh.Name = "TsbRefresh";
            this.TsbRefresh.Size = new System.Drawing.Size(63, 55);
            this.TsbRefresh.Text = "Refresh";
            this.TsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbRefresh.Click += new System.EventHandler(this.TsbRefresh_Click);
            // 
            // TsbPrint
            // 
            this.TsbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbPrint.Name = "TsbPrint";
            this.TsbPrint.Size = new System.Drawing.Size(45, 55);
            this.TsbPrint.Text = "Print";
            this.TsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbPrint.Visible = false;
            this.TsbPrint.Click += new System.EventHandler(this.TsbPrint_Click);
            // 
            // TSBBalances
            // 
            this.TSBBalances.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSBBalances.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBBalances.Name = "TSBBalances";
            this.TSBBalances.Size = new System.Drawing.Size(71, 55);
            this.TSBBalances.Text = "Balances";
            this.TSBBalances.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBBalances.Visible = false;
            this.TSBBalances.Click += new System.EventHandler(this.TSBBalances_Click);
            // 
            // TsbClose
            // 
            this.TsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbClose.Name = "TsbClose";
            this.TsbClose.Size = new System.Drawing.Size(49, 55);
            this.TsbClose.Text = "Close";
            this.TsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbClose.Click += new System.EventHandler(this.TsbClose_Click);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer2);
            this.SplitContainer1.Size = new System.Drawing.Size(800, 450);
            this.SplitContainer1.SplitterDistance = 71;
            this.SplitContainer1.TabIndex = 3;
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.DgvRecords);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.StatusStrip1);
            this.SplitContainer2.Size = new System.Drawing.Size(800, 375);
            this.SplitContainer2.SplitterDistance = 337;
            this.SplitContainer2.TabIndex = 0;
            // 
            // DgvRecords
            // 
            this.DgvRecords.AllowUserToAddRows = false;
            this.DgvRecords.AllowUserToDeleteRows = false;
            this.DgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRecords.Location = new System.Drawing.Point(0, 0);
            this.DgvRecords.Name = "DgvRecords";
            this.DgvRecords.ReadOnly = true;
            this.DgvRecords.RowHeadersWidth = 51;
            this.DgvRecords.Size = new System.Drawing.Size(800, 337);
            this.DgvRecords.TabIndex = 0;
            this.DgvRecords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRecords_CellDoubleClick);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSLFunction,
            this.TSSCount,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 12);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(800, 22);
            this.StatusStrip1.TabIndex = 0;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // TSSLFunction
            // 
            this.TSSLFunction.Name = "TSSLFunction";
            this.TSSLFunction.Size = new System.Drawing.Size(71, 17);
            this.TSSLFunction.Text = "Warehouses";
            // 
            // TSSCount
            // 
            this.TSSCount.Name = "TSSCount";
            this.TSSCount.Size = new System.Drawing.Size(31, 17);
            this.TSSCount.Text = "0000";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(49, 17);
            this.ToolStripStatusLabel3.Text = "Records";
            // 
            // FDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "FDataGrid";
            this.Text = "FDataGrid";
            this.Load += new System.EventHandler(this.FDataGrid_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            this.SplitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRecords)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.BindingSource BindingSource1;
        private System.Windows.Forms.ToolStripButton TsbFind;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsbNew;
        private System.Windows.Forms.ToolStripButton TsbRecord;
        private System.Windows.Forms.ToolStripButton TsbDelete;
        public System.Windows.Forms.ToolStripButton TsbRefresh;
        private System.Windows.Forms.ToolStripButton TsbPrint;
        private System.Windows.Forms.ToolStripButton TSBBalances;
        private System.Windows.Forms.ToolStripButton TsbClose;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        public System.Windows.Forms.SplitContainer SplitContainer2;
        internal System.Windows.Forms.DataGridView DgvRecords;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel TSSLFunction;
        internal System.Windows.Forms.ToolStripStatusLabel TSSCount;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
    }
}