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
    public partial class FWarehouseAdjustment : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        public DateTime OldDate { get; set; }
        public FWarehouseAdjustment()
        {
            InitializeComponent();
        }

        private void FWarehouseAdjustment_Load(object sender, EventArgs e)
        {
            LoadWarehouseIntoForm();
            if (FormMode == "New")
            {
                CmdOK.Text = "Save";
                this.Text = "New Warehouse Adjustments";
                DateTimePicker1.Value = ClsUtils.GetSundayDate(DateTime.Now, 1);
            }
            else
            {
                CmdOK.Text = "OK";
                LoadData();
            }
        }

        private void CmdAddToGrid_Click(object sender, EventArgs e)
        {
            int rownum;
            ClsStock stock = new ClsStock();
            stock.WarehouseRef = TxtWarehouseRef.Text.TrimEnd();
            stock.StockCode = TxtStockCode.Text.TrimEnd();
            rownum = (int)dgvItems.Rows.Add();
            dgvItems.Rows[rownum].Cells[0].Value = TxtStockCode.Text.TrimEnd();
            dgvItems.Rows[rownum].Cells[1].Value = CboType.Text.TrimEnd();
            dgvItems.Rows[rownum].Cells[2].Value = TxtAdjustHangers.Text.TrimEnd();
            dgvItems.Rows[rownum].Cells[3].Value = stock.GetStockValueQty(Convert.ToDecimal(TxtAdjustHangers.Text));
            Totals();
            TxtAdjustHangers.Clear();
            TxtCurrentHangers.Clear();
            TxtStockCode.Clear();
        }

        private void CmdRemoveFromGrid_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvItems.SelectedRows)
            {
                dgvItems.Rows.RemoveAt(row.Index);
            }
            Totals();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            if (FormMode == "New")
            {
                SaveToDb();
            }
            else
            {
                UpdateToDb();
            }
            this.Close();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            TxtAdjustHangers.Clear();
            TxtCurrentHangers.Clear();
            TxtStockCode.Clear();
            TxtTotalGain.Text = "00";
            TxtTotalLoss.Text = "00";
            dgvItems.Rows.Clear();
            TxtWarehouseRef.Clear();
            TxtWarehouseName.Clear();
            TxtReference.Clear();
            DateTimePicker1.Value = ClsUtils.GetSundayDate(DateTime.Now, 1);
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void DateTimePicker1_Leave(object sender, EventArgs e)
        {

        }

        private void TxtWarehouseRef_Leave(object sender, EventArgs e)
        {
            TxtWarehouseRef.Text = ClsWarehouse.ChangeCase(TxtWarehouseRef.Text, 1);
            ClsWarehouse warehouse = new ClsWarehouse()
            {
                WarehouseRef = TxtWarehouseRef.Text.TrimEnd()
            };
            TxtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
            LoadStockIntoForm();
        }

        private void TxtStockCode_Leave(object sender, EventArgs e)
        {
            TxtStockCode.Text = ClsUtils.ChangeCase(TxtStockCode.Text, 1);
            ClsStock stock = new ClsStock();
            stock.StockCode = TxtStockCode.Text.TrimEnd();
            stock.SupplierRef = TxtWarehouseRef.Text.TrimEnd();
            if (TxtWarehouseName.TextLength == 0)
                TxtCurrentHangers.Text = "0";
            else
                TxtCurrentHangers.Text = stock.GetWarehouseStockQty().ToString();
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Totals();
        }
        private void LoadWarehouseIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT WarehouseRef from tblWarehouses", conn);
                adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            TxtWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtWarehouseRef.AutoCompleteCustomSource = ACSC;
            TxtWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void LoadStockIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT StockCode from qryWarehouseStock WHERE LocationRef = @LocationRef", conn);
                adp.SelectCommand.Parameters.AddWithValue("@LocationRef", TxtWarehouseRef.Text.TrimEnd());
                adp.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            TxtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtStockCode.AutoCompleteCustomSource = ACSC;
            TxtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            TxtTotalGain.Text = lngqtyhangers.ToString();
            TxtTotalLoss.Text = lqtyhangers.ToString();

        }
        private void LoadData()
        {
            int WarehouseAdjustID = Convert.ToInt32(TxtRecordID.Text.TrimEnd());
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable WarehouseAdjustHead = new DataTable();
                SqlDataAdapter WarehouseAdjustDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblWarehouseAdjustments WHERE WarehouseAdjustmentID = @WarehouseAdjustmentID";
                    SelectCmd.Parameters.AddWithValue("@WarehouseAdjustmentID", WarehouseAdjustID);
                    WarehouseAdjustDataAdapter.SelectCommand = SelectCmd;
                    WarehouseAdjustDataAdapter.Fill(WarehouseAdjustHead);
                }
                TxtWarehouseRef.Text = WarehouseAdjustHead.Rows[0][1].ToString();
                ClsWarehouse warehouse = new ClsWarehouse();
                warehouse.WarehouseRef = TxtWarehouseRef.Text.TrimEnd();
                TxtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
                TxtReference.Text = WarehouseAdjustHead.Rows[0][2].ToString();
                TxtTotalGain.Text = WarehouseAdjustHead.Rows[0][4].ToString();
                TxtTotalLoss.Text = WarehouseAdjustHead.Rows[0][3].ToString();
                DateTimePicker1.Value = Convert.ToDateTime(WarehouseAdjustHead.Rows[0][5]);
                OldDate = DateTimePicker1.Value;
            }
            dgvItems.Columns.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable WarehouseAdjustLine = new DataTable();
                SqlDataAdapter WarehouseAdjustLineDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode,MovementType,Qty,Value from tblWarehouseAdjustmentsLines WHERE WarehouseAdjustmentID = @WarehouseAdjustmentID";
                    SelectCmd.Parameters.AddWithValue("@WarehouseAdjustmentID", WarehouseAdjustID);
                    WarehouseAdjustLineDataAdapter.SelectCommand = SelectCmd;
                    WarehouseAdjustLineDataAdapter.Fill(WarehouseAdjustLine);
                    dgvItems.DataSource = WarehouseAdjustLine;
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
        private void SaveToDb()
        {
            ClsWarehouseAdjustmentHead adjustmentHead = new ClsWarehouseAdjustmentHead();
            int SavedID;
            // Header of both adjustments and log file
            adjustmentHead.WarehouseRef = TxtWarehouseRef.Text.TrimEnd();
            adjustmentHead.Reference = TxtReference.Text.TrimEnd();
            adjustmentHead.TotalGainItems = Convert.ToInt32(TxtTotalGain.Text.TrimEnd());
            adjustmentHead.TotalLossItems = Convert.ToInt32(TxtTotalLoss.Text.TrimEnd());
            adjustmentHead.MovementDate = Convert.ToDateTime(DateTimePicker1.Value);
            adjustmentHead.UserID = UserID;
            adjustmentHead.SaveWarehouseAdjustmentHeadToDB();
            SavedID = adjustmentHead.GetLastWarehouseAdjustmentHead();
            ClsWarehouseAdjustmentLine adjustmentLine = new ClsWarehouseAdjustmentLine();
            ClsLogs logs = new ClsLogs();  // Save To system Log and StockMovements Table
            logs.TransferReference = SavedID;
            adjustmentLine.WarehouseAdjustmentID = SavedID;
            logs.LocationRef = adjustmentHead.WarehouseRef;
            for (int index = 0; index < dgvItems.Rows.Count; index++)
            {
                // Saving details to tblWarehouseAdjustmentLines Table
                adjustmentLine.StockCode = dgvItems.Rows[index].Cells[0].Value.ToString();
                adjustmentLine.SMovementType = dgvItems.Rows[index].Cells[1].Value.ToString();
                adjustmentLine.Qty = Convert.ToInt32(dgvItems.Rows[index].Cells[2].Value);
                adjustmentLine.Value = Convert.ToDecimal(dgvItems.Rows[index].Cells[3].Value);
                // Saving details to tblStockMovements Table
                logs.StockCode = adjustmentLine.StockCode;
                logs.LocationRef = adjustmentHead.WarehouseRef;
                logs.LocationType = 1;
                logs.Reference = "Warehouse Adjustment Item";
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
                adjustmentLine.SaveWarehouseAdjustmentLineToDB();
            }
        }
        private void UpdateToDb()
        {
            ClsWarehouseAdjustmentHead adjustmentHead = new ClsWarehouseAdjustmentHead();
            ClsLogs logs = new ClsLogs();  // Delete old StockMovements Data from Table
            logs.TransferReference = Convert.ToInt32(TxtRecordID.Text.TrimEnd());
            // Header of both adjustments and log file
            adjustmentHead.WarehouseRef = TxtWarehouseRef.Text.TrimEnd();
            adjustmentHead.Reference = TxtReference.Text.TrimEnd();
            adjustmentHead.TotalGainItems = Convert.ToInt32(TxtTotalGain.Text.TrimEnd());
            adjustmentHead.TotalLossItems = Convert.ToInt32(TxtTotalLoss.Text.TrimEnd());
            adjustmentHead.MovementDate = Convert.ToDateTime(DateTimePicker1.Value);
            logs.MovementDate = OldDate;
            logs.MovementType = 6;
            logs.DeleteFromStockMovemmentsTable();
            logs.MovementType = 7;
            logs.DeleteFromStockMovemmentsTable();
            adjustmentHead.WarehouseAdjustmentID = Convert.ToInt32(TxtRecordID.Text.TrimEnd());
            adjustmentHead.UpdateWarehouseAdjustmentHeadInDB();
            ClsWarehouseAdjustmentLine adjustmentLine = new ClsWarehouseAdjustmentLine();
            // Save To system Log and StockMovements Table
            adjustmentLine.WarehouseAdjustmentID = logs.TransferReference;
            logs.LocationRef = adjustmentHead.WarehouseRef;
            for (int index = 0; index < dgvItems.Rows.Count; index++)
            {
                // Saving details to tblWarehouseAdjustmentLines Table
                adjustmentLine.StockCode = dgvItems.Rows[index].Cells[0].Value.ToString();
                adjustmentLine.SMovementType = dgvItems.Rows[index].Cells[1].Value.ToString();
                adjustmentLine.Qty = Convert.ToInt32(dgvItems.Rows[index].Cells[2].Value);
                adjustmentLine.Value = Convert.ToDecimal(dgvItems.Rows[index].Cells[3].Value);
                // Saving details to tblStockMovements Table
                logs.StockCode = adjustmentLine.StockCode;
                logs.LocationRef = adjustmentHead.WarehouseRef;
                logs.Reference = "Warehouse Adjustment Item";
                logs.LocationType = 1;
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
                adjustmentLine.UpdateWarehouseAdjustmentLineInDB();
            }
        }
    }
}
