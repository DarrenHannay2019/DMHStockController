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
    public partial class FShopDelivery : Form
    {
        public int UserID { get; set; } // to hold the user's UserID
        public string FormMode { get; set; }    // to set the mode of the form
        public DateTime OldDate { get; set; }
        public FShopDelivery()
        {
            InitializeComponent();
        }

        private void FShopDelivery_Load(object sender, EventArgs e)
        {
            LoadWarehouseIntoForm();
            LoadShopsIntoForm();
            if (FormMode == "New")
            {
                cmdAdd.Text = "Save";
                this.Text = "New Shop Delivery";
                DteDate.Value = ClsUtils.GetSundayDate(DateTime.Now, 1);
            }
            else
            {
                cmdAdd.Text = "OK";
                LoadData();
            }
        }

        private void DteDate_Leave(object sender, EventArgs e)
        {

        }

        private void txtShopRef_Leave(object sender, EventArgs e)
        {
            txtShopRef.Text = ClsShop.ChangeCase(txtShopRef.Text, 1);
            ClsShop Shop = new ClsShop()
            {
                ShopRef = txtShopRef.Text.TrimEnd()
            };
            txtShopName.Text = Shop.GetShopNameFromDB();
        }

        private void txtWarehouseRef_Leave(object sender, EventArgs e)
        {
            txtWarehouseRef.Text = ClsWarehouse.ChangeCase(txtWarehouseRef.Text, 1);
            ClsWarehouse warehouse = new ClsWarehouse()
            {
                WarehouseRef = txtWarehouseRef.Text.TrimEnd()
            };
            txtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
            LoadStockIntoForm();
        }

        private void txtStockCode_Leave(object sender, EventArgs e)
        {
            if (txtStockCode.TextLength != 0)
            {
                txtStockCode.Text = ClsUtils.ChangeCase(txtStockCode.Text, 1);
                ClsStock stock = new ClsStock();
                stock.StockCode = txtStockCode.Text.TrimEnd();
                stock.WarehouseRef = txtWarehouseRef.Text.TrimEnd();
                txtQty.Text = stock.GetWarehouseStockQty().ToString();
            }
            else
            { }
        }

        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            int rownum;
            rownum = (int)DgvRecords.Rows.Add();
            DgvRecords.Rows[rownum].Cells[0].Value = txtStockCode.Text.TrimEnd();
            DgvRecords.Rows[rownum].Cells[1].Value = txtQtyHangers.Text.TrimEnd();
            Totals();
            txtQtyHangers.Clear();
            txtQty.Clear();
            txtStockCode.Clear();
            txtStockCode.Select();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvRecords.SelectedRows)
            {
                DgvRecords.Rows.RemoveAt(row.Index);
            }
            Totals();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ClsShopDeliveryHead deliveryHead = new ClsShopDeliveryHead();
            ClsShopDeliveryLine deliveryLine = new ClsShopDeliveryLine();
            ClsLogs logs = new ClsLogs();
            // Header of both adjustments and log file
            deliveryHead.WarehouseRef = txtWarehouseRef.Text.TrimEnd();
            deliveryHead.Reference = txtReference.Text.TrimEnd();
            deliveryHead.ShopRef = txtShopRef.Text.TrimEnd();
            deliveryHead.TotalItems = Convert.ToInt32(txtTotalGarments.Text.TrimEnd());
            deliveryHead.MovementDate = Convert.ToDateTime(DteDate.Value.ToString());
            deliveryHead.UserID = UserID;
            if (FormMode == "New")
            {
                deliveryHead.SaveShopDeliveryHead();
                deliveryHead.ShopDelID = deliveryHead.GetLastShopDelivery();
            }
            else
            {
                ClsLogs Dlogs = new ClsLogs();  // Delete old StockMovements Data from Table
                Dlogs.TransferReference = Convert.ToInt32(txtDelNoteNumber.Text.TrimEnd());
                Dlogs.MovementDate = OldDate;
                Dlogs.MovementType = 3;
                Dlogs.DeleteFromStockMovemmentsTable();
                deliveryHead.ShopDelID = Convert.ToInt32(txtDelNoteNumber.Text.TrimEnd());
                deliveryHead.UpdateShopDeliveryHead();
            }
            logs.TransferReference = deliveryHead.ShopDelID;
            deliveryLine.ShopDelID = deliveryHead.ShopDelID;
            logs.MovementDate = deliveryHead.MovementDate;
            logs.Reference = "Shop Delivery";
            logs.UserID = UserID;
            logs.SupplierRef = "NULL";
            logs.StringMovementType = "Shop Return Item";
            for (int index = 0; index < DgvRecords.Rows.Count; index++)
            {
                deliveryLine.StockCode = DgvRecords.Rows[index].Cells[0].Value.ToString();
                logs.StockCode = deliveryLine.StockCode;
                deliveryLine.Qty = Convert.ToInt32(DgvRecords.Rows[index].Cells[1].Value);
                if (FormMode == "New")
                {
                    logs.LocationRef = deliveryHead.WarehouseRef;
                    logs.LocationType = 1;
                    logs.MovementType = 3;
                    logs.Qty = deliveryLine.Qty * -1;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                    deliveryLine.SaveShopDeliveryLine();
                    logs.LocationType = 2;
                    logs.MovementType = 3;
                    logs.LocationRef = deliveryHead.ShopRef;
                    logs.Qty = deliveryLine.Qty;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                }
                else
                {
                    logs.LocationRef = deliveryHead.WarehouseRef;
                    logs.LocationType = 1;
                    logs.MovementType = 3;
                    logs.Qty = deliveryLine.Qty * -1;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                    deliveryLine.UpdateShopDeliveryLine();
                    logs.LocationType = 2;
                    logs.MovementType = 3;
                    logs.LocationRef = deliveryHead.ShopRef;
                    logs.Qty = deliveryLine.Qty;
                    logs.DeliveredQtyHangers = logs.Qty;
                    logs.SaveToStockMovementsTable();
                }
            }
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void cmdClearForm_Click(object sender, EventArgs e)
        {
            txtDelNoteNumber.Clear();
            txtQty.Clear();
            txtQtyHangers.Clear();
            txtTotalGarments.Clear();
            txtStockCode.Clear();
            DgvRecords.Rows.Clear();
            txtWarehouseRef.Clear();
            txtWarehouseName.Clear();
            txtShopRef.Clear();
            txtShopName.Clear();
            txtReference.Clear();
            DteDate.Value = ClsUtils.GetSundayDate(DateTime.Now, 1);
        }

        private void DgvRecords_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

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
            txtWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtWarehouseRef.AutoCompleteCustomSource = ACSC;
            txtWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
                adp.SelectCommand = new SqlCommand("SELECT StockCode from qryWarehouseStock WHERE LocationRef = @LocationRef", conn);
                adp.SelectCommand.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text);
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
        public void Totals()
        {
            int lngqtyhangers = 0;

            for (int i = 0; i < DgvRecords.Rows.Count; i++)
            {
                lngqtyhangers += Convert.ToInt32(DgvRecords.Rows[i].Cells[1].Value);
            }
            txtTotalGarments.Text = lngqtyhangers.ToString();
            Deliverlabel.Text = DgvRecords.Rows.Count.ToString();

        }
        private void LoadData()
        {
            int SHDelID = Convert.ToInt32(txtDelNoteNumber.Text.TrimEnd());
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable ShopDeliveryHead = new DataTable();
                SqlDataAdapter ShopDeliveryDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblShopDeliveries WHERE ShopDeliveryID = @ShopDeliveryID";
                    SelectCmd.Parameters.AddWithValue("@ShopDeliveryID", SHDelID);
                    ShopDeliveryDataAdapter.SelectCommand = SelectCmd;
                    ShopDeliveryDataAdapter.Fill(ShopDeliveryHead);
                }
                txtShopRef.Text = ShopDeliveryHead.Rows[0][1].ToString();
                ClsShop shop = new ClsShop();
                shop.ShopRef = txtShopRef.Text.TrimEnd();
                txtShopName.Text = shop.GetShopNameFromDB();
                ClsWarehouse warehouse = new ClsWarehouse();
                txtWarehouseRef.Text = ShopDeliveryHead.Rows[0][2].ToString();
                warehouse.WarehouseRef = txtWarehouseRef.Text.TrimEnd();
                txtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
                txtReference.Text = ShopDeliveryHead.Rows[0][3].ToString();
                txtTotalGarments.Text = ShopDeliveryHead.Rows[0][4].ToString();
                DteDate.Value = Convert.ToDateTime(ShopDeliveryHead.Rows[0][5]);
                OldDate = DteDate.Value;
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
                    SelectCmd.CommandText = "SELECT StockCode,DeliveredQty from tblShopDeliveryLines WHERE ShopDeliveryID = @ShopDeliveryID";
                    SelectCmd.Parameters.AddWithValue("@ShopDeliveryID", SHDelID);
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
                    DgvRecords.Columns[1].HeaderText = "Delivered Qty";

                }
            }
        }
    }
}
