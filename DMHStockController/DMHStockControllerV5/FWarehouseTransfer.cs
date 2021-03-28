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
    public partial class FWarehouseTransfer : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        public DateTime OldDate { get; set; }
        public FWarehouseTransfer()
        {
            InitializeComponent();
        }

        private void FWarehouseTransfer_Load(object sender, EventArgs e)
        {
            LoadWarehousesIntoForm_FromBox();
            if (FormMode == "New")
            {
                CmdOK.Text = "Save";
                this.Text = "New Warehouse Transfer";
                DtpDate.Value = ClsUtils.GetSundayDate(DateTime.Now, 1);
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
            rownum = (int)DgvRecords.Rows.Add();
            DgvRecords.Rows[rownum].Cells[0].Value = TxtStockCode.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[1].Value = TxtCurrQtyGarments.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[2].Value = TxtCurrQtyBoxes.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[3].Value = TxtCurrQtyHangers.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[4].Value = TxtToQtyGarments.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[5].Value = TxtToQtyBoxes.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[6].Value = TxtToQtyHangers.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[7].Value = TxtQtyToTransfer.Text.TrimEnd();
            TxtStockCode.Clear();
            TxtCurrQtyGarments.Clear();
            TxtCurrQtyBoxes.Clear();
            TxtCurrQtyHangers.Clear();
            TxtToQtyGarments.Clear();
            TxtToQtyBoxes.Clear();
            TxtToQtyHangers.Clear();
            TxtQtyToTransfer.Clear();
            Totals();
        }

        private void CmdDeleteFromGrid_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvRecords.SelectedRows)
            {
                DgvRecords.Rows.RemoveAt(row.Index);
            }
            Totals();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            // Saving / updating the master table into the database
            if (FormMode == "New")
            {
                SaveToDb();
            }
            else
            {
                ClsLogs Dlogs = new ClsLogs
                {
                    TransferReference = Convert.ToInt32(TxtTransferID.Text),
                    MovementDate = OldDate,
                    MovementType = 2
                };  // Delete old StockMovements details for current transfer
                Dlogs.DeleteFromStockMovemmentsTable();
                UpdateToDb();
            }
            this.Close();
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            TxtInHangers.Clear();
            txtFromWarehouseName.Clear();
            TxtFromWarehouseRef.Clear();
            TxtToWarehouseRef.Clear();
            txtToWarehouseName.Clear();
            TxtStockCode.Clear();
            TxtTFNote.Clear();
            TxtStockCode.Clear();
            TxtCurrQtyGarments.Clear();
            TxtCurrQtyBoxes.Clear();
            TxtCurrQtyHangers.Clear();
            TxtToQtyGarments.Clear();
            TxtToQtyBoxes.Clear();
            TxtToQtyHangers.Clear();
            TxtQtyToTransfer.Clear();
            DgvRecords.Rows.Clear();
            DtpDate.Value = ClsUtils.GetSundayDate(DateTime.Now, 1);
            Totals();
        }

        private void TxtToWarehouseRef_Leave(object sender, EventArgs e)
        {
            TxtToWarehouseRef.Text = ClsUtils.ChangeCase(TxtToWarehouseRef.Text, 1);
            ClsWarehouse warehouse = new ClsWarehouse()
            {
                WarehouseRef = TxtToWarehouseRef.Text.TrimEnd()
            };
            txtToWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
        }

        private void TxtFromWarehouseRef_Leave(object sender, EventArgs e)
        {
            TxtFromWarehouseRef.Text = ClsUtils.ChangeCase(TxtFromWarehouseRef.Text, 1);
            ClsWarehouse warehouse = new ClsWarehouse()
            {
                WarehouseRef = TxtFromWarehouseRef.Text.TrimEnd()
            };
            txtFromWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
            LoadWarehouseIntoForm_ToBox();
            LoadStockIntoForm();
        }

        private void TxtStockCode_Leave(object sender, EventArgs e)
        {
            if (TxtStockCode.TextLength != 0)
            {
                TxtStockCode.Text = ClsUtils.ChangeCase(TxtStockCode.Text, 1);
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ClsUtils.GetConnString(1);
                    conn.Open();
                    DataTable WarehouseTransferStock = new DataTable();
                    SqlDataAdapter WarehouseTransferDataAdapter = new SqlDataAdapter();
                    using (SqlCommand SelectCmd = new SqlCommand())
                    {
                        SelectCmd.Connection = conn;
                        SelectCmd.CommandText = "SELECT Hangers,Boxes,Garments from qryWarehouseTransferStock WHERE StockCode = @StockCode AND LocationRef = @LocationRef";
                        SelectCmd.Parameters.AddWithValue("@StockCode", TxtStockCode.Text.TrimEnd());
                        SelectCmd.Parameters.AddWithValue("@LocationRef", TxtFromWarehouseRef.Text.TrimEnd());
                        WarehouseTransferDataAdapter.SelectCommand = SelectCmd;
                        WarehouseTransferDataAdapter.Fill(WarehouseTransferStock);
                    }
                    TxtCurrQtyHangers.Text = WarehouseTransferStock.Rows[0][0].ToString();
                    TxtCurrQtyBoxes.Text = WarehouseTransferStock.Rows[0][1].ToString();
                    TxtCurrQtyGarments.Text = WarehouseTransferStock.Rows[0][2].ToString();
                }
            }
            else
            { }
        }

        private void DtpDate_Leave(object sender, EventArgs e)
        {
            DtpDate.Value = ClsUtils.GetSundayDate(DtpDate.Value, 1);
        }
        private void LoadWarehousesIntoForm_FromBox()
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
            TxtFromWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtFromWarehouseRef.AutoCompleteCustomSource = ACSC;
            TxtFromWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void LoadWarehouseIntoForm_ToBox()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT WarehouseRef from tblWarehouses WHERE WarehouseRef !='" + TxtFromWarehouseRef.Text.TrimEnd() + "'", conn);
                adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            TxtToWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtToWarehouseRef.AutoCompleteCustomSource = ACSC;
            TxtToWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
                adp.SelectCommand.Parameters.AddWithValue("@LocationRef", TxtFromWarehouseRef.Text);
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
            int TOQtyGarments = 0;
            int TOQtyBoxes = 0;
            int TOQtyHangers = 0;
            int TIQtyHangers = 0;
            for (int i = 0; i < DgvRecords.Rows.Count; i++)
            {
                TOQtyGarments += Convert.ToInt32(DgvRecords.Rows[i].Cells[4].Value);
                TOQtyBoxes += Convert.ToInt32(DgvRecords.Rows[i].Cells[5].Value);
                TOQtyHangers += Convert.ToInt32(DgvRecords.Rows[i].Cells[6].Value);
                TIQtyHangers += Convert.ToInt32(DgvRecords.Rows[i].Cells[7].Value);
            }
            TxtOutGarments.Text = TOQtyGarments.ToString();
            TxtOutBoxes.Text = TOQtyBoxes.ToString();
            TxtOutHangers.Text = TOQtyHangers.ToString();
            TxtInHangers.Text = TIQtyHangers.ToString();
        }
        private void SaveToDb()
        {
            int SavedID = 0;
            // Transfer Head
            ClsWarehouseTransferHead transferHead = new ClsWarehouseTransferHead();
            transferHead.Reference = TxtTFNote.Text.TrimEnd();
            transferHead.MovementDate = Convert.ToDateTime(DtpDate.Value);
            transferHead.WarehouseRef = TxtFromWarehouseRef.Text.TrimEnd();
            transferHead.ToWarehouseRef = TxtToWarehouseRef.Text.TrimEnd();
            transferHead.DeliveredQtyGarments = Convert.ToInt32(TxtOutGarments.Text.TrimEnd());
            transferHead.DeliveredQtyBoxes = Convert.ToInt32(TxtOutBoxes.Text.TrimEnd());
            transferHead.DeliveredQtyHangers = Convert.ToInt32(TxtOutHangers.Text.TrimEnd());
            transferHead.Qty = Convert.ToInt32(TxtInHangers.Text.TrimEnd());
            transferHead.UserID = UserID;
            transferHead.SaveWarehouseTransferHead();
            SavedID = transferHead.GetLastWarehouseTransferHeadFromDB();
            // Transfer Lines
            ClsWarehouseTransferLine transferLine = new ClsWarehouseTransferLine();
            ClsLogs logs = new ClsLogs();
            transferLine.WarehouseTransferID = SavedID;
            logs.LocationType = 1;
            logs.MovementType = 2;
            logs.SupplierRef = "N/A";
            logs.MovementDate = transferHead.MovementDate;
            logs.MovementValue = 0.0m;
            logs.TransferReference = SavedID;
            logs.Reference = "Warehouse Transfer - " + TxtTFNote.Text.TrimEnd();
            logs.UserID = transferHead.UserID;
            for (int index = 0; index < DgvRecords.Rows.Count; index++)
            {
                // Save to tblWarehouseTransfer
                transferLine.StockCode = DgvRecords.Rows[index].Cells[0].Value.ToString();
                transferLine.CurrQtyGarments = Convert.ToInt32(DgvRecords.Rows[index].Cells[1].Value);
                transferLine.CurrQtyBoxes = Convert.ToInt32(DgvRecords.Rows[index].Cells[2].Value);
                transferLine.CurrQtyHangers = Convert.ToInt32(DgvRecords.Rows[index].Cells[3].Value);
                transferLine.TOQtyGarments = Convert.ToInt32(DgvRecords.Rows[index].Cells[4].Value);
                transferLine.TOQtyBoxes = Convert.ToInt32(DgvRecords.Rows[index].Cells[5].Value);
                transferLine.TOQtyHangers = Convert.ToInt32(DgvRecords.Rows[index].Cells[6].Value);
                transferLine.TIQty = Convert.ToInt32(DgvRecords.Rows[index].Cells[7].Value);
                transferLine.UpdateWarehouseTransferLineInDB();
                // Transfer Out of the location
                logs.StockCode = transferLine.StockCode;
                logs.LocationRef = transferHead.WarehouseRef;
                logs.DeliveredQtyHangers = transferLine.TOQtyHangers * -1;
                logs.DeliveredQtyBoxes = transferLine.TOQtyBoxes * -1;
                logs.DeliveredQtyGarments = transferLine.TOQtyGarments * -1;
                logs.SaveToStockMovementsTable();
                // Transfer In To the Location
                logs.StockCode = transferLine.StockCode;
                logs.LocationRef = transferHead.ToWarehouseRef;
                logs.DeliveredQtyHangers = transferLine.TIQty;
                logs.DeliveredQtyBoxes = 0;
                logs.DeliveredQtyGarments = 0;
                logs.SaveToStockMovementsTable();
            }
        }
        private void UpdateToDb()
        {
            ClsWarehouseTransferLine transferLine = new ClsWarehouseTransferLine();
            ClsWarehouseTransferHead transferHead = new ClsWarehouseTransferHead();
            ClsLogs logs = new ClsLogs();
            // Remove the old Records from the table.
            logs.MovementType = 2;
            logs.TransferReference = Convert.ToInt32(TxtTransferID.Text.TrimEnd());
            logs.MovementDate = OldDate;
            logs.DeleteFromStockMovemmentsTable();
            // Update the Warehouse Transfer Head Table
            transferHead.WarehouseTransferID = Convert.ToInt32(TxtTransferID.Text);
            transferHead.Reference = TxtTFNote.Text.TrimEnd();
            transferHead.MovementDate = Convert.ToDateTime(DtpDate.Value);
            transferHead.WarehouseRef = TxtFromWarehouseRef.Text.TrimEnd();
            transferHead.ToWarehouseRef = TxtToWarehouseRef.Text.TrimEnd();
            transferHead.DeliveredQtyGarments = Convert.ToInt32(TxtOutGarments.Text.TrimEnd());
            transferHead.DeliveredQtyBoxes = Convert.ToInt32(TxtOutBoxes.Text.TrimEnd());
            transferHead.DeliveredQtyHangers = Convert.ToInt32(TxtOutHangers.Text.TrimEnd());
            transferHead.Qty = Convert.ToInt32(TxtInHangers.Text.TrimEnd());
            transferHead.UpdateWarehouseTransferHead();
            // Update the Warehouse Lines Table
            transferLine.WarehouseTransferID = transferHead.WarehouseTransferID;
            logs.LocationType = 1;
            logs.MovementType = 1;
            logs.SupplierRef = "N/A";
            logs.MovementDate = transferHead.MovementDate;
            logs.MovementValue = 0.0m;
            logs.TransferReference = transferHead.WarehouseTransferID;
            logs.Reference = "Warehouse Transfer - " + TxtTFNote.Text.TrimEnd();
            logs.UserID = transferHead.UserID;
            for (int index = 0; index < DgvRecords.Rows.Count; index++)
            {
                // Save to tblWarehouseTransfer
                transferLine.StockCode = DgvRecords.Rows[index].Cells[0].Value.ToString();
                transferLine.CurrQtyGarments = Convert.ToInt32(DgvRecords.Rows[index].Cells[1].Value = TxtCurrQtyGarments.Text.TrimEnd());
                transferLine.CurrQtyBoxes = Convert.ToInt32(DgvRecords.Rows[index].Cells[2].Value = TxtCurrQtyBoxes.Text.TrimEnd());
                transferLine.CurrQtyHangers = Convert.ToInt32(DgvRecords.Rows[index].Cells[3].Value = TxtCurrQtyHangers.Text.TrimEnd());
                transferLine.TOQtyGarments = Convert.ToInt32(DgvRecords.Rows[index].Cells[4].Value = TxtToQtyGarments.Text.TrimEnd());
                transferLine.TOQtyBoxes = Convert.ToInt32(DgvRecords.Rows[index].Cells[5].Value = TxtToQtyBoxes.Text.TrimEnd());
                transferLine.TOQtyHangers = Convert.ToInt32(DgvRecords.Rows[index].Cells[6].Value = TxtToQtyHangers.Text.TrimEnd());
                transferLine.TIQty = Convert.ToInt32(DgvRecords.Rows[index].Cells[7].Value = TxtQtyToTransfer.Text.TrimEnd());
                transferLine.UpdateWarehouseTransferLineInDB();
                // Transfer Out of the location
                logs.StockCode = transferLine.StockCode;
                logs.LocationRef = transferHead.WarehouseRef;
                logs.DeliveredQtyHangers = transferLine.TOQtyHangers * -1;
                logs.DeliveredQtyBoxes = transferLine.TOQtyBoxes * -1;
                logs.DeliveredQtyGarments = transferLine.TOQtyGarments * -1;
                logs.SaveToStockMovementsTable();
                // Transfer In To the Location
                logs.StockCode = transferLine.StockCode;
                logs.LocationRef = transferHead.ToWarehouseRef;
                logs.DeliveredQtyHangers = transferLine.TIQty;
                logs.DeliveredQtyBoxes = 0;
                logs.DeliveredQtyGarments = 0;
                logs.SaveToStockMovementsTable();
            }
        }
        private void LoadData()
        {
            int WarehouseTransferID = Convert.ToInt32(TxtTransferID.Text.TrimEnd());
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable WarehouseTransferHead = new DataTable();
                SqlDataAdapter WarehouseTransferDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblWarehouseTransfers WHERE WarehouseTransferID = @WarehouseTransferID";
                    SelectCmd.Parameters.AddWithValue("@WarehouseTransferID", WarehouseTransferID);
                    WarehouseTransferDataAdapter.SelectCommand = SelectCmd;
                    WarehouseTransferDataAdapter.Fill(WarehouseTransferHead);
                }
                TxtTFNote.Text = WarehouseTransferHead.Rows[0][1].ToString();
                DtpDate.Value = Convert.ToDateTime(WarehouseTransferHead.Rows[0][2]);
                OldDate = DtpDate.Value;
                TxtFromWarehouseRef.Text = WarehouseTransferHead.Rows[0][3].ToString();
                ClsWarehouse warehouse = new ClsWarehouse();
                warehouse.WarehouseRef = TxtFromWarehouseRef.Text.TrimEnd();
                txtFromWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
                TxtToWarehouseRef.Text = WarehouseTransferHead.Rows[0][4].ToString();
                warehouse.WarehouseRef = TxtToWarehouseRef.Text.TrimEnd();
                txtToWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
                TxtToQtyGarments.Text = WarehouseTransferHead.Rows[0][5].ToString();
                TxtToQtyBoxes.Text = WarehouseTransferHead.Rows[0][6].ToString();
                TxtToQtyHangers.Text = WarehouseTransferHead.Rows[0][7].ToString();
                TxtInHangers.Text = WarehouseTransferHead.Rows[0][8].ToString();
            }
            DgvRecords.Columns.Clear();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable WarehouseAdjustLine = new DataTable();
                SqlDataAdapter WarehouseAdjustLineDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode, CurrentQtyGarments, CurrentQtyBoxes, CurrentQtyHangers, TOQtyGarments, TOQtyBoxes, TIQtyHangers, TOQtyHangers from tblWarehouseTransferLines WHERE WarehouseTransferID = @WarehouseTransferID";
                    SelectCmd.Parameters.AddWithValue("@WarehouseTransferID", WarehouseTransferID);
                    WarehouseAdjustLineDataAdapter.SelectCommand = SelectCmd;
                    WarehouseAdjustLineDataAdapter.Fill(WarehouseAdjustLine);
                    DgvRecords.DataSource = WarehouseAdjustLine;
                    DgvRecords.AutoGenerateColumns = true;
                    DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    DgvRecords.BackgroundColor = Color.LightCoral;
                    DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Red;
                    DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                    DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DgvRecords.AllowUserToResizeColumns = false;
                    DgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                    DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                    DgvRecords.Columns[0].HeaderText = "Stock Code";
                    DgvRecords.Columns[1].HeaderText = "Current Qty Garments";
                    DgvRecords.Columns[2].HeaderText = "Current Qty Boxes";
                    DgvRecords.Columns[3].HeaderText = "Current Qty Hangers";
                    DgvRecords.Columns[4].HeaderText = "Transfer Qty Garments";
                    DgvRecords.Columns[5].HeaderText = "Transfer Qty Boxes";
                    DgvRecords.Columns[6].HeaderText = "Transfer Qty Garments";
                    DgvRecords.Columns[7].HeaderText = "Transfer In";
                }
            }
        }
    }
}
