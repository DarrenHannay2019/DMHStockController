using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public partial class FShopAdjustment : Form
    {
        public int UserID { get; set; } // to hold the user's UserID
        public string FormMode { get; set; }    // to set the mode of the form
        public DateTime OldDate { get; set; }
        public FShopAdjustment()
        {
            InitializeComponent();
        }

        private void FShopAdjustment_Load(object sender, EventArgs e)
        {
            LoadShopsIntoForm();

            if (FormMode == "New")
            {
                CmdOK.Text = "Save";
                this.Text = "New Shop Adjustment";
                DtpDate.Value = ClsUtils.GetSundayDate(DateTime.Now, 1);
            }
            else
            {
                CmdOK.Text = "OK";
                LoadData();
            }
        }

        private void DtpDate_Leave(object sender, EventArgs e)
        {

        }

        private void txtShopRef_Leave(object sender, EventArgs e)
        {
            txtShopRef.Text = ClsUtils.ChangeCase(txtShopRef.Text, 1);
            ClsShop shop = new ClsShop()
            {
                ShopRef = txtShopRef.Text.TrimEnd()
            };
            txtShopName.Text = shop.GetShopNameFromDB();
            LoadStockIntoForm();
        }

        private void txtStockCode_Leave(object sender, EventArgs e)
        {
            txtStockCode.Text = ClsUtils.ChangeCase(txtStockCode.Text, 1);
            ClsStock stock = new ClsStock();
            stock.StockCode = txtStockCode.Text.TrimEnd();
            stock.ShopRef = txtShopRef.Text.TrimEnd();
            if (txtShopName.TextLength == 0)
                txtCurrentHangers.Text = "0";
            else
                txtCurrentHangers.Text = stock.GetShopStockQty().ToString();
        }

        private void CmdAddToGrid_Click(object sender, EventArgs e)
        {
            int rownum;
            ClsStock stock = new ClsStock();
            stock.ShopRef = txtShopRef.Text.TrimEnd();
            stock.StockCode = txtStockCode.Text.TrimEnd();
            rownum = (int)dgvItems.Rows.Add();
            dgvItems.Rows[rownum].Cells[0].Value = txtStockCode.Text.TrimEnd();
            dgvItems.Rows[rownum].Cells[1].Value = cboType.Text.TrimEnd();
            dgvItems.Rows[rownum].Cells[2].Value = txtAdjustHangers.Text.TrimEnd();
            dgvItems.Rows[rownum].Cells[3].Value = stock.GetShopStockValue(Convert.ToDecimal(txtAdjustHangers.Text));
            Totals();
            txtAdjustHangers.Clear();
            txtCurrentHangers.Clear();
            txtStockCode.Clear();
        }

        private void CmdDeleteFromGrid_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvItems.SelectedRows)
            {
                dgvItems.Rows.RemoveAt(row.Index);
            }
            Totals();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            ClsShopAdjustmentHead adjustmentHead = new ClsShopAdjustmentHead();
            ClsShopAdjustmentLine adjustmentLine = new ClsShopAdjustmentLine();
            ClsLogs logs = new ClsLogs();
            // Header of both adjustments and log file
            adjustmentHead.ShopRef = txtShopRef.Text.TrimEnd();
            adjustmentHead.Reference = txtReference.Text.TrimEnd();
            adjustmentHead.TotalGainItems = Convert.ToInt32(txtTotalGain.Text.TrimEnd());
            adjustmentHead.TotalLossItems = Convert.ToInt32(txtTotalLoss.Text.TrimEnd());
            adjustmentHead.MovementDate = Convert.ToDateTime(DtpDate.Value);
            adjustmentHead.UserID = UserID;
            if (FormMode == "New")
            {
                adjustmentHead.SaveShopAdjustmentHead();
                adjustmentHead.ID = adjustmentHead.GetLastShopAdjustmentHead();
            }
            else
            {
                ClsLogs Dlogs = new ClsLogs();  // Delete old StockMovements Data from Table
                Dlogs.TransferReference = Convert.ToInt32(TxtSID.Text.TrimEnd());
                Dlogs.MovementDate = OldDate;
                Dlogs.MovementType = 6;
                Dlogs.DeleteFromStockMovemmentsTable();
                Dlogs.MovementType = 7;
                Dlogs.DeleteFromStockMovemmentsTable();
                adjustmentHead.ID = Convert.ToInt32(TxtSID.Text.TrimEnd());

                adjustmentHead.UpdateShopAdjustmentHead();
            }
            logs.TransferReference = adjustmentHead.ID;
            adjustmentLine.ID = adjustmentHead.ID;
            logs.LocationRef = adjustmentHead.ShopRef;
            for (int index = 0; index < dgvItems.Rows.Count; index++)
            {
                // Saving details to tblWarehouseAdjustmentLines Table
                adjustmentLine.StockCode = dgvItems.Rows[index].Cells[0].Value.ToString();
                adjustmentLine.SMovementType = dgvItems.Rows[index].Cells[1].Value.ToString();
                adjustmentLine.Qty = Convert.ToInt32(dgvItems.Rows[index].Cells[2].Value);
                adjustmentLine.Value = Convert.ToDecimal(dgvItems.Rows[index].Cells[3].Value);
                // Saving details to tblStockMovements Table
                logs.StockCode = adjustmentLine.StockCode;
                logs.LocationRef = adjustmentHead.ShopRef;
                logs.LocationType = 2;
                logs.SupplierRef = "N/A";
                if (adjustmentLine.SMovementType == "Loss")
                    logs.DeliveredQtyHangers = Convert.ToInt32(dgvItems.Rows[index].Cells[2].Value) * -1;
                else
                    logs.DeliveredQtyHangers = Convert.ToInt32(dgvItems.Rows[index].Cells[2].Value);
                logs.DeliveredQtyGarments = 0;
                logs.DeliveredQtyBoxes = 0;
                if (adjustmentLine.SMovementType == "Loss")
                    logs.MovementType = 7;
                else
                    logs.MovementType = 6;
                logs.MovementDate = adjustmentHead.MovementDate;
                logs.MovementValue = adjustmentLine.Value;
                logs.Reference = adjustmentHead.Reference;
                logs.UserID = UserID;
                // Save to the relevent data tables on each itteration of the Datagridview control             
                logs.SaveToStockMovementsTable();
                if (FormMode == "New")
                    adjustmentLine.SaveShopAdjustmentLine();
                else
                    adjustmentLine.UpdateShopAdjustmentLine();
            }
            Close();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            txtAdjustHangers.Clear();
            txtCurrentHangers.Clear();
            txtStockCode.Clear();
            txtTotalGain.Clear();
            txtTotalLoss.Clear();
            dgvItems.Rows.Clear();
            txtShopRef.Clear();
            txtShopName.Clear();
            txtReference.Clear();
            DtpDate.Value = ClsUtils.GetSundayDate(DateTime.Now, 1);
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }
        public void Totals()
        {
            int lngqtyhangers = 0;
            int lqtyhangers = 0;
            for (int i = 0; i < dgvItems.Rows.Count; i++)
            {
                if (dgvItems.Rows[i].Cells[1].Value.ToString() == "Loss")
                    lqtyhangers += Convert.ToInt32(dgvItems.Rows[i].Cells[2].Value);
                else
                    lngqtyhangers += Convert.ToInt32(dgvItems.Rows[i].Cells[2].Value);
            }
            txtTotalGain.Text = lngqtyhangers.ToString();
            txtTotalLoss.Text = lqtyhangers.ToString();
        }
        private void LoadShopsIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT ShopRef from tblShops", conn);
                adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtShopRef.AutoCompleteCustomSource = ACSC;
            txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void LoadStockIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT StockCode from qryShopStock WHERE LocationRef = @LocationRef", conn);
                adp.SelectCommand.Parameters.AddWithValue("@LocationRef", txtShopRef.Text);
                adp.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            txtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtStockCode.AutoCompleteCustomSource = ACSC;
            txtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void LoadData()
        {
            int ShopAdjustID = Convert.ToInt32(TxtSID.Text);
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable ShopAdjustHead = new DataTable();
                SqlDataAdapter ShopAdjustDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblShopAdjustments WHERE ShopAdjustmentID = @ShopAdjustmentID";
                    SelectCmd.Parameters.AddWithValue("@ShopAdjustmentID", ShopAdjustID);
                    ShopAdjustDataAdapter.SelectCommand = SelectCmd;
                    ShopAdjustDataAdapter.Fill(ShopAdjustHead);
                }
                txtShopRef.Text = ShopAdjustHead.Rows[0][1].ToString();
                ClsShop Shop = new ClsShop();
                Shop.ShopRef = txtShopRef.Text.TrimEnd();
                txtShopName.Text = Shop.GetShopNameFromDB();
                txtReference.Text = ShopAdjustHead.Rows[0][2].ToString();
                txtTotalGain.Text = ShopAdjustHead.Rows[0][4].ToString();
                txtTotalLoss.Text = ShopAdjustHead.Rows[0][3].ToString();
                DtpDate.Value = Convert.ToDateTime(ShopAdjustHead.Rows[0][5]);
                OldDate = DtpDate.Value;
            }
            dgvItems.Columns.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable ShopAdjustLine = new DataTable();
                SqlDataAdapter ShopAdjustLineDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode,MovementType,Qty,Value from tblShopAdjustmentLines WHERE ShopAdjustmentID = @ShopAdjustmentID";
                    SelectCmd.Parameters.AddWithValue("@ShopAdjustmentID", ShopAdjustID);
                    ShopAdjustLineDataAdapter.SelectCommand = SelectCmd;
                    ShopAdjustLineDataAdapter.Fill(ShopAdjustLine);
                    dgvItems.DataSource = ShopAdjustLine;
                    dgvItems.AutoGenerateColumns = true;
                    dgvItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    dgvItems.BackgroundColor = Color.LightCoral;
                    dgvItems.DefaultCellStyle.SelectionBackColor = Color.Red;
                    dgvItems.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                    dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvItems.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvItems.AllowUserToResizeColumns = false;
                    dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvItems.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                    dgvItems.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                    dgvItems.Columns[0].HeaderText = "Stock Code";
                    dgvItems.Columns[1].HeaderText = "Movement Type";
                    dgvItems.Columns[2].HeaderText = "Qty";
                    dgvItems.Columns[3].Visible = false;
                }
            }
        }
    }
}
