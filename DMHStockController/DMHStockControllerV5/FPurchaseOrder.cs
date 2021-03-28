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
    public partial class FPurchaseOrder : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        private DateTime OldDate { get; set; }
        public FPurchaseOrder()
        {
            InitializeComponent();
        }
        private void TotalCalc()
        {
            int boxes = 0;
            int garments = 0;
            int hangers = 0;
            decimal NetCost = 0.0m;
            decimal GrossAmount;
            for (int i = 0; i < DgvItems.Rows.Count; i++)
            {
                boxes += Convert.ToInt16(DgvItems.Rows[i].Cells[2].Value);
                garments += Convert.ToInt16(DgvItems.Rows[i].Cells[1].Value);
                hangers += Convert.ToInt16(DgvItems.Rows[i].Cells[3].Value);
                NetCost += Convert.ToDecimal(DgvItems.Rows[i].Cells[4].Value);
            }
            TxtTotalBoxes.Text = boxes.ToString();
            TxtTotalGarments.Text = garments.ToString();
            TxtTotalHangers.Text = hangers.ToString();
            TxtTotalNet.Text = NetCost.ToString();

            GrossAmount = (Convert.ToDecimal(TxtTotalNet.Text) + Convert.ToDecimal(TxtCommission.Text) + Convert.ToDecimal(TxtDeliveryCharges.Text) + Convert.ToDecimal(TxtVATAmount.Text));
            TxtTotalOrderPrice.Text = GrossAmount.ToString();
        }
        private void LoadData()
        {
            TxtTotalNet.Clear();
            TxtCommission.Clear();
            TxtDeliveryCharges.Clear();
            TxtTotalOrderPrice.Clear();
            DgvItems.Columns.Clear();
            int PurchaseID;
            PurchaseID = Convert.ToInt32(TxtOrderID.Text.TrimEnd());
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable PurchaseHead = new DataTable();
                SqlDataAdapter PurchaseDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblPurchaseOrders WHERE PurchaseOrderID = @PurchaseOrderID";
                    SelectCmd.Parameters.AddWithValue("@PurchaseOrderID", PurchaseID);
                    PurchaseDataAdapter.SelectCommand = SelectCmd;
                    PurchaseDataAdapter.Fill(PurchaseHead);
                }
                TxtOurRef.Text = PurchaseHead.Rows[0][1].ToString();
                TxtSupplierRef.Text = PurchaseHead.Rows[0][2].ToString();
                ClsSupplier supplier = new ClsSupplier
                {
                    SupplierRef = TxtSupplierRef.Text
                };
                TxtSupplierName.Text = supplier.GetSupplierNameFromDB();
                TxtWarehouseRef.Text = PurchaseHead.Rows[0][3].ToString();
                ClsWarehouse warehouse = new ClsWarehouse
                {
                    WarehouseRef = TxtWarehouseRef.Text
                };
                TxtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
                CboSeasonName.Text = PurchaseHead.Rows[0][4].ToString();
                TxtTotalGarments.Text = PurchaseHead.Rows[0][5].ToString();
                TxtTotalBoxes.Text = PurchaseHead.Rows[0][6].ToString();
                TxtTotalHangers.Text = PurchaseHead.Rows[0][7].ToString();
                TxtTotalNet.Text = PurchaseHead.Rows[0][8].ToString();
                TxtDeliveryCharges.Text = PurchaseHead.Rows[0][9].ToString();
                TxtCommission.Text = PurchaseHead.Rows[0][10].ToString();
                TxtVATAmount.Text = PurchaseHead.Rows[0][11].ToString();
                TxtTotalOrderPrice.Text = PurchaseHead.Rows[0][12].ToString();
                OldDate = Convert.ToDateTime(PurchaseHead.Rows[0][13].ToString());
                DteMovementDate.Value = OldDate;
                TxtNotes.Text = PurchaseHead.Rows[0][15].ToString();
                TxtSuppliersInvoiceNumber.Text = PurchaseHead.Rows[0][16].ToString();
                TxtShipperName.Text = PurchaseHead.Rows[0][17].ToString();
                TxtShipperInvoiceNumber.Text = PurchaseHead.Rows[0][18].ToString();
            }
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable PurchaseLines = new DataTable();
                SqlDataAdapter PurchaseLinesDA = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode,DeliveredQtyGarments,DeliveredQtyBoxes,DeliveredQtyHangers,LineAmount FROM tblPurchaseOrderLines WHERE PurchaseOrderID = @PurchaseOrderID";
                    SelectCmd.Parameters.AddWithValue("@PurchaseOrderID", PurchaseID);
                    PurchaseLinesDA.SelectCommand = SelectCmd;
                    PurchaseLinesDA.Fill(PurchaseLines);
                }
                DgvItems.DataSource = PurchaseLines;
                DgvItems.AutoGenerateColumns = true;
                DgvItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
                DgvItems.BackgroundColor = Color.LightCoral;
                DgvItems.DefaultCellStyle.SelectionBackColor = Color.Red;
                DgvItems.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                DgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                DgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DgvItems.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DgvItems.AllowUserToResizeColumns = false;
                DgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvItems.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                DgvItems.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                DgvItems.Columns[0].HeaderText = "Stock Code";
                DgvItems.Columns[1].HeaderText = "Garments";
                DgvItems.Columns[2].HeaderText = "Boxes";
                DgvItems.Columns[3].HeaderText = "Hangers";
                DgvItems.Columns[4].HeaderText = "Value";
                DgvItems.Columns[4].DefaultCellStyle.Format = "C2";
            }
        }
        private void LoadWarehousesIntoForm()
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
                adp.SelectCommand = new SqlCommand("SELECT StockCode from tblStock", conn);
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
        private void LoadSupplierIntoForm()
        {
            AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand("SELECT SupplierRef from tblSuppliers", conn);
                adp.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ACSC.Add(Convert.ToString(row[0]));
                }
            }
            TxtSupplierRef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtSupplierRef.AutoCompleteCustomSource = ACSC;
            TxtSupplierRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void GetAllSeasonData()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = ClsUtils.GetConnString(1)
            };
            conn.Open();
            SqlCommand SelectCmd = new SqlCommand
            {
                CommandText = "SELECT SeasonName from tblSeasons",
                Connection = conn
            };
            SqlDataReader dataReader;
            dataReader = SelectCmd.ExecuteReader();
            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    CboSeasonName.Items.Add(dataReader.GetString(i));
                }
            }
            dataReader.Close();
            conn.Close();
        }

        private void CmdAddToGrid_Click(object sender, EventArgs e)
        {
            int rownum;
            rownum = (int)DgvItems.Rows.Add();
            DgvItems.Rows[rownum].Cells[0].Value = TxtStockCode.Text.TrimEnd();
            DgvItems.Rows[rownum].Cells[1].Value = TxtQtyGarments.Text.TrimEnd();
            DgvItems.Rows[rownum].Cells[2].Value = TxtQtyBoxes.Text.TrimEnd();
            DgvItems.Rows[rownum].Cells[3].Value = TxtQtyHangers.Text.TrimEnd();
            decimal tempvalues;
            tempvalues = Convert.ToDecimal(TxtNetCostLine.Text.TrimEnd());
            DgvItems.Rows[rownum].Cells[4].Value = tempvalues.ToString();
            TxtQtyBoxes.Clear();
            TxtQtyGarments.Clear();
            TxtStockCode.Clear();
            TxtQtyHangers.Clear();
            TxtNetCostLine.Clear();
            TotalCalc();
        }

        private void CmdDeleteFromGrid_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvItems.SelectedRows)
            {
                DgvItems.Rows.RemoveAt(row.Index);
            }
            TotalCalc();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ClsPurchaseOrderHead orderHead = new ClsPurchaseOrderHead
            {
                OurRef = TxtOurRef.Text.TrimEnd(),
                SupplierRef = TxtSupplierRef.Text.TrimEnd(),
                WarehouseRef = TxtWarehouseRef.Text.TrimEnd(),
                TotalHangers = Convert.ToInt32(TxtTotalHangers.Text.TrimEnd()),
                TotalBoxes = Convert.ToInt32(TxtTotalBoxes.Text.TrimEnd()),
                TotalGarments = Convert.ToInt32(TxtTotalGarments.Text.TrimEnd()),
                NetAmount = Convert.ToDecimal(TxtTotalNet.Text.TrimEnd()),
                Commission = Convert.ToDecimal(TxtCommission.Text.TrimEnd()),
                DeliveryCharge = Convert.ToDecimal(TxtDeliveryCharges.Text.TrimEnd()),
                VATAmount = Convert.ToDecimal(TxtVATAmount.Text.TrimEnd()),
                TotalAmount = Convert.ToDecimal(TxtTotalOrderPrice.Text.TrimEnd()),
                MovementDate = Convert.ToDateTime(DteMovementDate.Value),
                DeliveryType = "Direct To Warehouse",
                SupplierInvoice = TxtSuppliersInvoiceNumber.Text.TrimEnd(),
                SeasonName = CboSeasonName.Text.TrimEnd(),
                Memo = TxtNotes.Text.TrimEnd(),
                Shipper = TxtShipperName.Text.TrimEnd(),
                ShipperInvoice = TxtShipperInvoiceNumber.Text.TrimEnd(),
                UserID = UserID
            };

            if (FormMode == "New")
            {
                orderHead.SaveToPurchaseOrderHeadToDB();
                TxtOrderID.Text = Convert.ToString(orderHead.GetLastPurchaseOrderHead());
                for (int index = 0; index < DgvItems.Rows.Count; index++)
                {
                    ClsPurchaseOrderLine orderLine = new ClsPurchaseOrderLine
                    {
                        PurchaseOrderID = Convert.ToInt32(TxtOrderID.Text),
                        StockCode = DgvItems.Rows[index].Cells[0].Value.ToString(),
                        DeliveredQtyGarments = Convert.ToInt32(DgvItems.Rows[index].Cells[1].Value),
                        DeliveredQtyBoxes = Convert.ToInt32(DgvItems.Rows[index].Cells[2].Value),
                        DeliveredQtyHangers = Convert.ToInt32(DgvItems.Rows[index].Cells[3].Value),
                        LineAmount = Convert.ToDecimal(DgvItems.Rows[index].Cells[4].Value)
                    };
                    ClsLogs logs = new ClsLogs
                    {
                        StockCode = orderLine.StockCode,
                        LocationRef = orderHead.WarehouseRef,
                        LocationType = 1,
                        SupplierRef = orderHead.SupplierRef,
                        DeliveredQtyHangers = orderLine.DeliveredQtyHangers,
                        DeliveredQtyBoxes = orderLine.DeliveredQtyBoxes,
                        DeliveredQtyGarments = orderLine.DeliveredQtyGarments,
                        MovementType = 1,
                        MovementDate = orderHead.MovementDate,
                        MovementValue = orderLine.LineAmount,
                        Reference = "Purchase Order Item",
                        TransferReference = orderLine.PurchaseOrderID,
                        UserID = orderHead.UserID
                    };
                    logs.Reference += logs.StockCode;
                    if (FormMode == "New")
                    {
                        ClsStock stock = new ClsStock();
                        logs.SaveToStockMovementsTable();
                        if (orderLine.SaveToPurchaseOrderLinetbl() == true)
                        {
                            stock.StockCode = orderLine.StockCode;
                            if (stock.CheckStockCodeSave() == 0)
                            {
                                stock.StockCode = orderLine.StockCode;
                                stock.SupplierRef = orderHead.SupplierRef;
                                stock.SeasonName = orderHead.SeasonName;
                                stock.DeadCode = false;
                                stock.CostValue = orderLine.LineAmount;
                                stock.DeliveredQtyBoxes = orderLine.DeliveredQtyBoxes;
                                stock.DeliveredQtyGarments = orderLine.DeliveredQtyGarments;
                                stock.DeliveredQtyHangers = orderLine.DeliveredQtyHangers;
                                stock.AmountTaken = 0.00m;
                                stock.PCMarkUp = -1.00m;
                                stock.ZeroQty = false;
                                stock.UserID = UserID;
                                stock.SaveStockCodeToDB();
                            }
                        }
                        else
                        {
                            stock.UpdateCostValue();
                            stock.UpdateDeliveredQtyBoxesValue();
                            stock.UpdateDeliveredQtyGarmentsValue();
                            stock.UpdateDeliveredQtyHangersValue();
                        }
                    }
                }
            }
            else
            {
                orderHead.PurchaseOrderID = Convert.ToInt32(TxtOrderID.Text);
                orderHead.UpdateToPurchaseOrderHeadInDB();
                ClsLogs dlogs = new ClsLogs
                {
                    TransferReference = orderHead.PurchaseOrderID,
                    MovementDate = OldDate,
                    MovementType = 1
                };
                dlogs.DeleteFromStockMovemmentsTable();
                for (int index = 0; index < DgvItems.Rows.Count; index++)
                {
                    ClsPurchaseOrderLine orderLine = new ClsPurchaseOrderLine
                    {
                        PurchaseOrderID = Convert.ToInt32(TxtOrderID.Text),
                        StockCode = DgvItems.Rows[index].Cells[0].Value.ToString(),
                        DeliveredQtyGarments = Convert.ToInt32(DgvItems.Rows[index].Cells[1].Value),
                        DeliveredQtyBoxes = Convert.ToInt32(DgvItems.Rows[index].Cells[2].Value),
                        DeliveredQtyHangers = Convert.ToInt32(DgvItems.Rows[index].Cells[3].Value),
                        LineAmount = Convert.ToDecimal(DgvItems.Rows[index].Cells[4].Value)
                    };
                    ClsLogs logs = new ClsLogs
                    {
                        StockCode = orderLine.StockCode,
                        LocationRef = orderHead.WarehouseRef,
                        LocationType = 1,
                        SupplierRef = orderHead.SupplierRef,
                        DeliveredQtyHangers = orderLine.DeliveredQtyHangers,
                        DeliveredQtyBoxes = orderLine.DeliveredQtyBoxes,
                        DeliveredQtyGarments = orderLine.DeliveredQtyGarments,
                        MovementType = 1,
                        MovementDate = orderHead.MovementDate,
                        MovementValue = orderLine.LineAmount,
                        Reference = "Purchase Order Item",
                        TransferReference = orderLine.PurchaseOrderID,
                        UserID = orderHead.UserID
                    };
                    logs.Reference += logs.StockCode;
                    ClsStock stock = new ClsStock();
                    stock.UpdateCostValue();
                    stock.UpdateDeliveredQtyBoxesValue();
                    stock.UpdateDeliveredQtyGarmentsValue();
                    stock.UpdateDeliveredQtyHangersValue();
                }
            }
            this.Close();   // close the form
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void TxtWarehouseRef_Leave(object sender, EventArgs e)
        {
            TxtWarehouseRef.Text = ClsUtils.ChangeCase(TxtWarehouseRef.Text, 1);
            ClsWarehouse warehouse = new ClsWarehouse()
            {
                WarehouseRef = TxtWarehouseRef.Text
            };
            TxtWarehouseName.Text = warehouse.GetWarehouseNameFromDB();
        }

        private void FPurchaseOrder_Load(object sender, EventArgs e)
        {
            GetAllSeasonData();
            LoadWarehousesIntoForm();
            LoadSupplierIntoForm();
            LoadStockIntoForm();
            if (FormMode == "New")
            {
                cmdOK.Text = "Save";
                DteMovementDate.Value = ClsUtils.GetSundayDate(DateTime.Now, 0);
            }
            else
            {
                cmdOK.Text = "OK";
                LoadData();
            }
        }

        private void DgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TotalCalc();    // calculate all totals
        }

        private void TxtSupplierRef_Leave(object sender, EventArgs e)
        {
            TxtSupplierRef.Text = ClsUtils.ChangeCase(TxtSupplierRef.Text, 1);
            ClsSupplier supplier = new ClsSupplier()
            {
                SupplierRef = TxtSupplierRef.Text
            };
            TxtSupplierName.Text = supplier.GetSupplierNameFromDB();
        }

        private void TxtOurRef_Leave(object sender, EventArgs e)
        {
            TxtOurRef.Text = ClsUtils.ChangeCase(TxtOurRef.Text, 1);
        }

        private void TxtNotes_Leave(object sender, EventArgs e)
        {
            TxtNotes.Text = ClsUtils.ChangeCase(TxtNotes.Text, 0);
        }

        private void TxtStockCode_Leave(object sender, EventArgs e)
        {
            TxtStockCode.Text = ClsUtils.ChangeCase(TxtStockCode.Text.TrimEnd(), 1);
            ClsStock stock = new ClsStock
            {
                StockCode = TxtStockCode.Text.TrimEnd()
            };
            if (stock.CheckStockCodeSave() != 0)
            {
                MessageBox.Show("Already StockCode in Database");
            }
            else
            { }
        }

        private void TxtShipperName_Leave(object sender, EventArgs e)
        {
            TxtShipperName.Text = ClsUtils.ChangeCase(TxtShipperName.Text, 0);
        }

        private void TxtDeliveryCharges_Leave(object sender, EventArgs e)
        {
            TotalCalc();    // Calculate all values
        }

        private void TxtCommission_Leave(object sender, EventArgs e)
        {
            TotalCalc();    // Calculate all values
        }

        private void TxtVATAmount_Leave(object sender, EventArgs e)
        {
            TotalCalc();    // Calculate all values
        }
    }
}
