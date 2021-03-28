using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public partial class FDataGrid : Form
    {
        public int UserID { get; set; }
        public int FunctionID { get; set; }
        private string SqlCmdString { get; set; }
        public FDataGrid()
        {
            InitializeComponent();
        }

        private void FDataGrid_Load(object sender, EventArgs e)
        {
            LoadData(); // loads the data from the database
            SetupStyleGrid();   // sets up the style of the form
            CustomiseDataGrid();    // changes titles and widths
        }

        private void TsbNew_Click(object sender, EventArgs e)
        {
            if (FunctionID == 1)
            {
                ClsWarehouse warehouse = new ClsWarehouse
                {
                    UserID = UserID
                };
                warehouse.LoadNewRecord();
            }
            if (FunctionID == 2)
            {
                ClsSupplier supplier = new ClsSupplier
                {
                    UserID = UserID
                };
                supplier.LoadNewRecord();
            }
            if (FunctionID == 3)
            {
                ClsShop shop = new ClsShop
                {
                    UserID = UserID
                };
                shop.LoadNewRecord();
            }
            if (FunctionID == 4)
            {
                ClsStock stock = new ClsStock
                {
                    UserID = UserID
                };
                stock.LoadNewRecord();
            }
            if (FunctionID == 5)
            {
                ClsStock stock = new ClsStock
                {
                    UserID = UserID
                };
                stock.LoadNewRecord();
            }
            if (FunctionID == 6)
            {
                ClsSeason season = new ClsSeason();
                season.LoadNewRecord();
            }
            if (FunctionID == 7)
            {
                ClsPurchaseOrder purchaseOrder = new ClsPurchaseOrder
                {
                    UserID = UserID
                };
                purchaseOrder.LoadNewPurchaseOrder();
            }
            if (FunctionID == 8)
            {
                ClsWarehouseAdjustment warehouseAdjustment = new ClsWarehouseAdjustment
                {
                    UserID = UserID
                };
                warehouseAdjustment.LoadNewWarehouseAdjustment();
            }
            if (FunctionID == 9)
            {
                ClsWarehouseTransfer warehouseTransfer = new ClsWarehouseTransfer
                {
                    UserID = UserID
                };
                warehouseTransfer.LoadNewRecord();
            }
            if (FunctionID == 10)
            {
                ClsWarehouseReturn warehouseReturn = new ClsWarehouseReturn
                {
                    UserID = UserID
                };
                warehouseReturn.LoadNewForm();
            }
            if (FunctionID == 11)
            {
                ClsShopDelivery shopDelivery = new ClsShopDelivery
                {
                    UserID = UserID
                };
                shopDelivery.LoadNewForm();
            }
            if (FunctionID == 12)
            {
                ClsShopAdjustment shopAdjustment = new ClsShopAdjustment
                {
                    UserID = UserID
                };
                shopAdjustment.LoadNewForm();
            }
            if (FunctionID == 13)
            {
                ClsShopTransfer shopTransfer = new ClsShopTransfer
                {
                    UserID = UserID
                };
                shopTransfer.LoadNewForm();
            }
            if (FunctionID == 14)
            {
                ClsShopSale shopSale = new ClsShopSale
                {
                    UserID = UserID
                };
                shopSale.LoadNewForm();
            }
            if (FunctionID == 15)
            {
                ClsShopReturn shopReturn = new ClsShopReturn
                {
                    UserID = UserID
                };
                shopReturn.LoadNewForm();
            }
            // Refresh the data grid
            TsbRefresh.PerformClick();
        }

        private void TsbRecord_Click(object sender, EventArgs e)
        {
            // get the selected row and the value of the first column
            int SelectId;
            SelectId = DgvRecords.CurrentRow.Index;
            string CellValue;
            CellValue = DgvRecords.Rows[SelectId].Cells[0].Value.ToString();
            if (FunctionID == 1)
            {
                ClsWarehouse warehouse = new ClsWarehouse
                {
                    WarehouseRef = CellValue,
                    UserID = UserID
                };
                warehouse.LoadSelectedWarehouse();
            }
            if (FunctionID == 2)
            {
                ClsSupplier supplier = new ClsSupplier
                {
                    SupplierRef = CellValue,
                    UserID = UserID
                };
                supplier.LoadSelectedSupplier();
            }
            if (FunctionID == 3)
            {
                ClsShop shop = new ClsShop
                {
                    ShopRef = CellValue,
                    UserID = UserID
                };
                shop.LoadSelectedShop();
            }
            if (FunctionID == 4)
            {
                ClsStock stock = new ClsStock
                {
                    StockCode = CellValue,
                    UserID = UserID
                };
                stock.LoadSelectedStockRecord();
            }
            if (FunctionID == 5)
            {
                ClsStock stock = new ClsStock
                {
                    StockCode = CellValue,
                    UserID = UserID
                };
                stock.LoadSelectedStockRecord();
            }
            if (FunctionID == 6)
            {
                ClsSeason season = new ClsSeason
                {
                    SeasonID = Convert.ToInt32(CellValue)
                };
                season.LoadSelectedSeason();
            }
            if (FunctionID == 7)
            {
                ClsPurchaseOrder purchaseOrder = new ClsPurchaseOrder
                {
                    PurchaseOrderID = Convert.ToInt32(CellValue)
                };
                purchaseOrder.LoadSelectedPurchaseOrder();
            }
            if (FunctionID == 8)
            {
                ClsWarehouseAdjustment warehouseAdjustment = new ClsWarehouseAdjustment
                {
                    WarehouseAdjustmentID = Convert.ToInt32(CellValue)
                };
                warehouseAdjustment.LoadSelectedWarehouseAdjustment();
            }
            if (FunctionID == 9)
            {
                ClsWarehouseTransfer warehouseTransfer = new ClsWarehouseTransfer
                {
                    UserID = UserID,
                    WarehouseTransferID = Convert.ToInt32(CellValue)
                };
                warehouseTransfer.LoadSelectedWarehouseTransfer();
            }
            if (FunctionID == 10)
            {
                ClsWarehouseReturn warehouseReturn = new ClsWarehouseReturn
                {
                    UserID = UserID,
                    WarehouseReturnID = Convert.ToInt32(CellValue)
                };
                warehouseReturn.LoadSelectedForm();
            }
            if (FunctionID == 11)
            {
                ClsShopDelivery shopDelivery = new ClsShopDelivery
                {
                    UserID = UserID,
                    ShopDelID = Convert.ToInt32(CellValue)
                };
                shopDelivery.LoadSelectedForm();
            }
            if (FunctionID == 12)
            {
                ClsShopAdjustment shopAdjustment = new ClsShopAdjustment
                {
                    UserID = UserID,
                    ID = Convert.ToInt32(CellValue)
                };
                shopAdjustment.LoadSelectedForm();
            }
            if (FunctionID == 13)
            {
                ClsShopTransfer shopTransfer = new ClsShopTransfer
                {
                    UserID = UserID,
                    ShopTransferID = Convert.ToInt32(CellValue)
                };
                shopTransfer.LoadSelectedForm();
            }
            if (FunctionID == 14)
            {
                ClsShopSale shopSale = new ClsShopSale
                {
                    UserID = UserID,
                    SalesID = Convert.ToInt32(CellValue)
                };
                shopSale.LoadSelectedForm();
            }
            if (FunctionID == 15)
            {
                ClsShopReturn shopReturn = new ClsShopReturn
                {
                    UserID = UserID,
                    ShopReturnID = Convert.ToInt32(CellValue)
                };
                shopReturn.LoadSelectedForm();
            }
            // Refresh the data grid
            TsbRefresh.PerformClick();
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            int selectid;
            int NoRecords = 0;
            selectid = DgvRecords.CurrentRow.Index;
            string i;
            i = DgvRecords[0, selectid].Value.ToString();
            if (FunctionID == 1)
            {
                ClsWarehouse oWarehouse = new ClsWarehouse()
                {
                    WarehouseRef = i
                };
                NoRecords = oWarehouse.TotalWarehouseTransactionRecords();
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    oWarehouse.DeleteWarehouseRecordFromDB();
                }
            }
            if (FunctionID == 2)
            {
                ClsShop oShop = new ClsShop
                {
                    ShopRef = i
                };
                NoRecords = oShop.TotalShopTransactionRecords();
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Shop Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    oShop.DeleteShopRecordFromDB();
                }
            }
            if (FunctionID == 3)
            {
                ClsSupplier oSupplier = new ClsSupplier()
                {
                    SupplierRef = i
                };

                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    oSupplier.DeleteSupplierRecordFromDB();
                }
            }
            if (FunctionID == 4)
            {
                ClsStock oStock = new ClsStock
                {
                    StockCode = i
                };
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    oStock.DeleteStockCodeFromDB();
                }

            }
            if (FunctionID == 5)
            {
                ClsStock oStock = new ClsStock
                {
                    StockCode = i
                };
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    oStock.DeleteStockCodeFromDB();
                }
            }
            if (FunctionID == 6)
            {
                ClsSeason oSeason = new ClsSeason
                {
                    SeasonID = Convert.ToInt32(i)
                };
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    oSeason.DeleteSeasonRecordFromDB();
                }
            }
            if (FunctionID == 7)
            {
                ClsPurchaseOrder oPurchaseOrder = new ClsPurchaseOrder
                {
                    PurchaseOrderID = Convert.ToInt32(i)
                };
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClsPurchaseOrderLine orderLine = new ClsPurchaseOrderLine
                    {
                        PurchaseOrderID = oPurchaseOrder.PurchaseOrderID
                    };
                    ClsPurchaseOrderHead orderHead = new ClsPurchaseOrderHead()
                    {
                        PurchaseOrderID = oPurchaseOrder.PurchaseOrderID
                    };
                    orderLine.DeletePurchaseOrderLineRecord();
                    orderHead.DeletePurchaseOrderHeadFromDB();
                }

            }
            if (FunctionID == 8)
            {
                ClsWarehouseAdjustment oWarehouseAdjustment = new ClsWarehouseAdjustment
                {
                    WarehouseAdjustmentID = Convert.ToInt32(selectid)
                };
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClsWarehouseAdjustmentHead adjustmentHead = new ClsWarehouseAdjustmentHead
                    {
                        WarehouseAdjustmentID = oWarehouseAdjustment.WarehouseAdjustmentID
                    };
                    ClsWarehouseAdjustmentLine adjustmentLine = new ClsWarehouseAdjustmentLine
                    {
                        WarehouseAdjustmentID = oWarehouseAdjustment.WarehouseAdjustmentID
                    };
                    adjustmentLine.DeleteWarehouseAdjustmentLineFromDB();
                    adjustmentHead.DeleteWarehouseAdjustmentHeadFromDB();
                }
            }
            if (FunctionID == 9)
            {
                ClsWarehouseTransfer oWarehouseTransfer = new ClsWarehouseTransfer
                {
                    WarehouseTransferID = Convert.ToInt32(selectid)
                };
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClsWarehouseTransferHead transferHead = new ClsWarehouseTransferHead
                    {
                        WarehouseTransferID = oWarehouseTransfer.WarehouseTransferID
                    };
                    ClsWarehouseTransferLine transferLine = new ClsWarehouseTransferLine
                    {
                        WarehouseTransferID = oWarehouseTransfer.WarehouseTransferID
                    };
                    transferLine.DeleteWarehouseTransferLineFromDB();
                    transferHead.DeleteWarehouseTransferHead();
                }
            }
            if (FunctionID == 10)
            {
                ClsWarehouseReturn oWarehouseReturn = new ClsWarehouseReturn
                {
                    WarehouseReturnID = Convert.ToInt32(selectid)
                };
                if (NoRecords != 0)
                {
                    MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClsWarehouseReturnHead returnHead = new ClsWarehouseReturnHead
                    {
                        WarehouseReturnID = oWarehouseReturn.WarehouseReturnID
                    };
                    ClsWarehouseReturnLine returnLine = new ClsWarehouseReturnLine
                    {
                        WarehouseReturnID = oWarehouseReturn.WarehouseReturnID
                    };
                    returnLine.DeleteWarehouseReturnLine();
                    returnHead.DeleteWarehouseReturnHead();
                }
            }
            if (FunctionID == 11)
            {
                ClsShopDelivery oShopDelivery = new ClsShopDelivery
                {
                    ShopDelID = Convert.ToInt32(selectid)
                };
                ClsShopDeliveryHead deliveryHead = new ClsShopDeliveryHead
                {
                    ShopDelID = oShopDelivery.ShopDelID
                };
                ClsShopDeliveryLine deliveryLine = new ClsShopDeliveryLine
                {
                    ShopDelID = oShopDelivery.ShopDelID
                };
                deliveryLine.DeleteShopDeliveryLine();
                deliveryHead.DeleteShopDeliveryHead();
            }
            if (FunctionID == 12)
            {
                ClsShopAdjustment oShopAdjustment = new ClsShopAdjustment
                {
                    ID = Convert.ToInt32(selectid)
                };
                ClsShopAdjustmentHead adjustmentHead = new ClsShopAdjustmentHead
                {
                    ID = oShopAdjustment.ID
                };
                ClsShopAdjustmentLine adjustmentLine = new ClsShopAdjustmentLine
                {
                    ID = oShopAdjustment.ID
                };
                adjustmentLine.DeleteShopAdjustLine();
                adjustmentHead.DeleteShopAdjustHead();

            }
            if (FunctionID == 13)
            {
                ClsShopTransfer oShopTransfer = new ClsShopTransfer
                {
                    ShopTransferID = Convert.ToInt32(selectid)
                };
                ClsShopTransferHead transferHead = new ClsShopTransferHead
                {
                    ShopTransferID = oShopTransfer.ShopTransferID
                };
                ClsShopTransferLine transferLine = new ClsShopTransferLine
                {
                    ShopTransferID = oShopTransfer.ShopTransferID
                };
                transferLine.DeleteShopTransferLine();
                transferHead.DeleteShopTransferHead();
            }
            if (FunctionID == 14)
            {
                ClsShopSale oShopSale = new ClsShopSale
                {
                    SalesID = Convert.ToInt32(selectid)
                };
                ClsShopSaleHead saleHead = new ClsShopSaleHead
                {
                    SalesID = oShopSale.SalesID
                };
                ClsShopSaleLine saleLine = new ClsShopSaleLine
                {
                    SalesID = oShopSale.SalesID
                };
                saleLine.DeleteShopSaleLine();
                saleHead.DeleteShopSaleHead();
            }
            if (FunctionID == 15)
            {
                ClsShopReturn oShopReturn = new ClsShopReturn
                {
                    ShopReturnID = Convert.ToInt32(selectid)
                };
                ClsShopReturnHead returnHead = new ClsShopReturnHead
                {
                    ShopReturnID = oShopReturn.ShopReturnID
                };
                ClsShopReturnLine returnLine = new ClsShopReturnLine
                {
                    ShopReturnID = oShopReturn.ShopReturnID
                };
                returnLine.DeleteShopReturnLine();
                returnHead.DeleteShopReturnHead();
            }
            if (NoRecords != 0)
            {
                MessageBox.Show("Unable to remove Warehouse Record from the database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            TsbRefresh.PerformClick();
        }

        private void TsbRefresh_Click(object sender, EventArgs e)
        {
            // To Refresh the data from the database
            BindingSource1.DataSource = "";
            LoadData();
            CustomiseDataGrid();
            SetupStyleGrid();
        }

        private void TsbPrint_Click(object sender, EventArgs e)
        {

        }

        private void TsbFind_Click(object sender, EventArgs e)
        {
            if (FunctionID == 1)
            {
                // Warehouses
                BindingSource1.Filter = "WarehouseRef Like '%" + Interaction.InputBox("Please Enter a Warehouse Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 2)
            {
                // Shops
                BindingSource1.Filter = "ShopRef Like '%" + Interaction.InputBox("Please Enter a Shop Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 3)
            {
                //Suppliers
                BindingSource1.Filter = "SupplierRef Like '%" + Interaction.InputBox("Please Enter a Supplier Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 4)
            {
                //Stock
                BindingSource1.Filter = "SupplierRef Like '%" + Interaction.InputBox("Please Enter a Supplier Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 5)
            {
                //Stock
                BindingSource1.Filter = "SupplierRef Like '%" + Interaction.InputBox("Please Enter a Supplier Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 6)
            {
                // season
                BindingSource1.Filter = "SeasonName Like '%" + Interaction.InputBox("Please Enter a Season Name", Application.ProductName) + "'";

            }
            if (FunctionID == 7)
            {
                // Purchase Orders
                BindingSource1.Filter = "LocationRef Like '%" + Interaction.InputBox("Please Enter a Warehouse / Shop Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 8)
            {
                // clsWarehouseAdjustment oWarehouseAdjustment = new clsWarehouseAdjustment();
                BindingSource1.Filter = "WarehouseRef Like '%" + Interaction.InputBox("Please Enter a Warehouse Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 9)
            {
                // clsWarehouseTransfer oWarehouseTransfer = new clsWarehouseTransfer();
                BindingSource1.Filter = "WarehouseRef Like '%" + Interaction.InputBox("Please Enter a Warehouse Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 10)
            {
                // clsWarehouseReturn oWarehouseReturn = new clsWarehouseReturn();
                BindingSource1.Filter = "WarehouseRef Like '%" + Interaction.InputBox("Please Enter a Warehouse Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 11)
            {
                // clsShopDelivery oShopDelivery = new clsShopDelivery();
                BindingSource1.Filter = "WarehouseRef Like '%" + Interaction.InputBox("Please Enter a Warehouse Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 12)
            {
                // clsShopAdjustment oShopAdjustment = new clsShopAdjustment();
                BindingSource1.Filter = "ShopRef Like '%" + Interaction.InputBox("Please Enter a Shop Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 13)
            {
                // clsShopTransfer oShopTransfer = new clsShopTransfer();
                BindingSource1.Filter = "FromShopRef Like '%" + Interaction.InputBox("Please Enter a Shop Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 14)
            {
                // clsShopSale oShopSale = new clsShopSale();
                BindingSource1.Filter = "ShopRef Like '%" + Interaction.InputBox("Please Enter a Shop Reference Code", Application.ProductName) + "'";
            }
            if (FunctionID == 15)
            {
                //  clsShopReturn oShopReturn = new clsShopReturn();
                BindingSource1.Filter = "WarehouseRef Like '%" + Interaction.InputBox("Please Enter a Warehouse Reference Code", Application.ProductName) + "'";
            }
            TSSCount.Text = DgvRecords.Rows.Count.ToString();
        }

        private void TSBBalances_Click(object sender, EventArgs e)
        {
            // Function not implemented.
            ClsStock stock = new ClsStock();
            if (FunctionID == 4)
            {
                stock.UpdateCostValue();
                // stock.UpdateAmountTaken();
                stock.UpdateDeliveredQtyBoxesValue();
                stock.UpdateDeliveredQtyGarmentsValue();
                stock.UpdateDeliveredQtyHangersValue();
                stock.UpdatePCMarkup();
            }
            if (FunctionID == 5)
            {
                stock.UpdateCostValue();
                // stock.UpdateAmountTaken();
                stock.UpdateDeliveredQtyBoxesValue();
                stock.UpdateDeliveredQtyGarmentsValue();
                stock.UpdateDeliveredQtyHangersValue();
                stock.UpdatePCMarkup();
            }
        }

        private void TsbClose_Click(object sender, EventArgs e)
        {
            this.Close();   // close the current data grid view screen
        }

        private void DgvRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TsbRecord.PerformClick();   // Load the selected record.
        }
        private void SetupStyleGrid()
        {
            // To give all functions a default look to the datagrids
            DgvRecords.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DgvRecords.BackgroundColor = Color.LightCoral;
            DgvRecords.DefaultCellStyle.SelectionBackColor = Color.Plum;
            DgvRecords.DefaultCellStyle.SelectionForeColor = Color.Black;
            DgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            DgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvRecords.AllowUserToResizeColumns = false;
            DgvRecords.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            DgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
        }
        private void LoadData()
        {
            // To Load Data from the database based on the function selected
            using (SqlConnection conn = new SqlConnection())
            {
                ClsUtils clsUtils = new ClsUtils();
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = GetFunctionSelectString();
                    sqlDataAdapter.SelectCommand = SelectCmd;
                    sqlDataAdapter.Fill(dataTable);
                }
                BindingSource1.DataSource = dataTable;
                DgvRecords.DataSource = BindingSource1;
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
        }
        private void CustomiseDataGrid()
        {
            // This will format the data grid of the right side of the main interface
            // this will also change the function of the stock check icon
            // Suppliers will not have the stock check icon.
            if (FunctionID == 1) // Warehouses
            {
                // WarehouseRef
                DgvRecords.Columns[0].Width = 100;
                DgvRecords.Columns[0].HeaderText = "Warehouse Ref";
                // WarehouseName
                DgvRecords.Columns[1].Width = 220;
                DgvRecords.Columns[1].HeaderText = "Warehouse Name";
                // WarehouseType
                DgvRecords.Columns[2].Width = 120;
                DgvRecords.Columns[2].HeaderText = "Warehouse Type";
                TSSLFunction.Text = "Warehouses";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 2)
            {
                // SupplierRef
                DgvRecords.Columns[0].Width = 100;
                DgvRecords.Columns[0].HeaderText = "Supplier Ref";
                // SupplierName
                DgvRecords.Columns[1].Width = 220;
                DgvRecords.Columns[1].HeaderText = "Supplier Name";
                // ContactName
                DgvRecords.Columns[2].Width = 120;
                DgvRecords.Columns[2].HeaderText = "Contact Name";
                // Telephone
                DgvRecords.Columns[3].Width = 120;
                DgvRecords.Columns[3].HeaderText = "Telephone Number";
                TSSLFunction.Text = "Suppliers";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 3)
            {
                // ShopRef
                DgvRecords.Columns[0].Width = 70;
                DgvRecords.Columns[0].HeaderText = "Shop Ref";
                // ShopName
                DgvRecords.Columns[1].Width = 220;
                DgvRecords.Columns[1].HeaderText = "Shop Name";
                // ShopType
                DgvRecords.Columns[2].Width = 120;
                DgvRecords.Columns[2].HeaderText = "Shop Type";
                TSSLFunction.Text = "Shops";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 4)
            {
                // Stock Code
                DgvRecords.Columns[0].HeaderText = "Stock Code";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                // SupplierRef
                DgvRecords.Columns[1].HeaderText = "Supplier Ref";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // SeasonName
                DgvRecords.Columns[2].HeaderText = "Season Name";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // DeadCode
                DgvRecords.Columns[3].HeaderText = "Dead Code";
                DgvRecords.Columns[3].Width = 50;
                DgvRecords.Columns[3].Visible = true;
                // AmountTaken
                DgvRecords.Columns[4].HeaderText = "Sales Amount";
                DgvRecords.Columns[4].Width = 100;
                DgvRecords.Columns[4].Visible = true;
                DgvRecords.Columns[4].DefaultCellStyle.Format = "C2";
                // DeliveredQtyHangers
                DgvRecords.Columns[5].HeaderText = "Qty Hangers";
                DgvRecords.Columns[5].Width = 50;
                DgvRecords.Columns[5].Visible = true;
                // DeliveredQtyBoxes
                DgvRecords.Columns[6].HeaderText = "Qty Boxes";
                DgvRecords.Columns[6].Width = 80;
                DgvRecords.Columns[6].Visible = true;
                // DeliveredQtyGarments
                DgvRecords.Columns[7].HeaderText = "Qty Garments";
                DgvRecords.Columns[7].Width = 80;
                DgvRecords.Columns[7].Visible = true;
                // CostValue
                DgvRecords.Columns[8].HeaderText = "Purchase Value";
                DgvRecords.Columns[8].Width = 100;
                DgvRecords.Columns[8].Visible = true;
                DgvRecords.Columns[8].DefaultCellStyle.Format = "C2";
                // PCMarkup
                DgvRecords.Columns[9].HeaderText = "Profit";
                DgvRecords.Columns[9].Width = 100;
                DgvRecords.Columns[9].Visible = true;
                DgvRecords.Columns[9].DefaultCellStyle.Format = "P2";
                // ZeroQty
                DgvRecords.Columns[10].HeaderText = "Zero Qty";
                DgvRecords.Columns[10].Width = 50;
                DgvRecords.Columns[10].Visible = true;

                TSSLFunction.Text = "Current Stock";
                TSBBalances.Visible = true;
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 5)
            {
                // Stock Code
                DgvRecords.Columns[0].HeaderText = "Stock Code";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                // SupplierRef
                DgvRecords.Columns[1].HeaderText = "Supplier Ref";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // SeasonName
                DgvRecords.Columns[2].HeaderText = "Season Name";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // DeadCode
                DgvRecords.Columns[3].HeaderText = "Dead Code";
                DgvRecords.Columns[3].Width = 50;
                DgvRecords.Columns[3].Visible = true;
                // AmountTaken
                DgvRecords.Columns[4].HeaderText = "Sales Amount";
                DgvRecords.Columns[4].Width = 100;
                DgvRecords.Columns[4].Visible = true;
                DgvRecords.Columns[4].DefaultCellStyle.Format = "C2";
                // DeliveredQtyHangers
                DgvRecords.Columns[5].HeaderText = "Qty Hangers";
                DgvRecords.Columns[5].Width = 50;
                DgvRecords.Columns[5].Visible = true;
                // DeliveredQtyBoxes
                DgvRecords.Columns[6].HeaderText = "Qty Boxes";
                DgvRecords.Columns[6].Width = 80;
                DgvRecords.Columns[6].Visible = true;
                // DeliveredQtyGarments
                DgvRecords.Columns[7].HeaderText = "Qty Garments";
                DgvRecords.Columns[7].Width = 80;
                DgvRecords.Columns[7].Visible = true;
                // CostValue
                DgvRecords.Columns[8].HeaderText = "Purchase Value";
                DgvRecords.Columns[8].Width = 100;
                DgvRecords.Columns[8].Visible = true;
                DgvRecords.Columns[8].DefaultCellStyle.Format = "C2";
                // PCMarkup
                DgvRecords.Columns[9].HeaderText = "Profit";
                DgvRecords.Columns[9].Width = 100;
                DgvRecords.Columns[9].Visible = true;
                DgvRecords.Columns[9].DefaultCellStyle.Format = "P2";
                // ZeroQty
                DgvRecords.Columns[10].HeaderText = "Zero Qty";
                DgvRecords.Columns[10].Width = 50;
                DgvRecords.Columns[10].Visible = true;

                TSSLFunction.Text = "All Stock";
                TSBBalances.Visible = true;
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 6)
            {
                // Season ID
                DgvRecords.Columns[0].Width = 70;
                DgvRecords.Columns[0].HeaderText = "Season ID";
                // Season Name
                DgvRecords.Columns[1].Width = 220;
                DgvRecords.Columns[1].HeaderText = "Season Name";
                TSSLFunction.Text = "Seasons";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 7)
            {
                // Purchase Order ID
                DgvRecords.Columns[0].HeaderText = "Order ID";
                DgvRecords.Columns[0].Width = 70;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "000000";
                // Our Ref
                DgvRecords.Columns[1].HeaderText = "Our Ref";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Supplier Ref
                DgvRecords.Columns[2].HeaderText = "Supplier Ref";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // Location Ref
                DgvRecords.Columns[3].HeaderText = "Location Ref";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // Season Name
                DgvRecords.Columns[4].HeaderText = "Season Name";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // Total Items
                DgvRecords.Columns[5].HeaderText = "Total Items";
                DgvRecords.Columns[5].Width = 50;
                DgvRecords.Columns[5].Visible = true;
                // Total Boxes
                DgvRecords.Columns[6].HeaderText = "Total Boxes";
                DgvRecords.Columns[6].Width = 50;
                DgvRecords.Columns[6].Visible = true;
                // Total Loose
                DgvRecords.Columns[7].HeaderText = "Total Loose";
                DgvRecords.Columns[7].Width = 50;
                DgvRecords.Columns[7].Visible = true;
                // Net Amount
                DgvRecords.Columns[8].HeaderText = "Net Amount";
                DgvRecords.Columns[8].Width = 80;
                DgvRecords.Columns[8].Visible = false;
                DgvRecords.Columns[8].DefaultCellStyle.Format = "C2";
                // Delivery Charage
                DgvRecords.Columns[9].HeaderText = "Delivery Charge";
                DgvRecords.Columns[9].Width = 150;
                DgvRecords.Columns[9].Visible = false;
                DgvRecords.Columns[9].DefaultCellStyle.Format = "C2";
                // Commission
                DgvRecords.Columns[10].HeaderText = "Commission";
                DgvRecords.Columns[10].Width = 150;
                DgvRecords.Columns[10].Visible = false;
                DgvRecords.Columns[10].DefaultCellStyle.Format = "C2";
                // VAT Amount
                DgvRecords.Columns[11].HeaderText = "VAT Amount";
                DgvRecords.Columns[11].Width = 150;
                DgvRecords.Columns[11].Visible = false;
                DgvRecords.Columns[11].DefaultCellStyle.Format = "C2";
                // Total Amount
                DgvRecords.Columns[12].HeaderText = "Total Amount";
                DgvRecords.Columns[12].Width = 80;
                DgvRecords.Columns[12].Visible = true;
                DgvRecords.Columns[12].DefaultCellStyle.Format = "C2";
                // Delivery Date
                DgvRecords.Columns[13].HeaderText = "Delivery Date";
                DgvRecords.Columns[13].Width = 150;
                DgvRecords.Columns[13].Visible = true;
                // Delivery Type
                DgvRecords.Columns[14].HeaderText = "Delivery Type";
                DgvRecords.Columns[14].Width = 150;
                DgvRecords.Columns[14].Visible = true;
                // Notes
                DgvRecords.Columns[15].HeaderText = "Notes";
                DgvRecords.Columns[15].Width = 150;
                DgvRecords.Columns[15].Visible = false;
                // Invoice Number
                DgvRecords.Columns[16].HeaderText = "Invoice";
                DgvRecords.Columns[16].Width = 150;
                DgvRecords.Columns[16].Visible = false;
                // Shipper Name
                DgvRecords.Columns[17].HeaderText = "Shipper";
                DgvRecords.Columns[17].Width = 150;
                DgvRecords.Columns[17].Visible = false;
                // Shipper Invoice
                DgvRecords.Columns[18].HeaderText = "Shipper Invoice";
                DgvRecords.Columns[18].Width = 150;
                DgvRecords.Columns[18].Visible = false;
                // Created By
                DgvRecords.Columns[19].HeaderText = "Created By";
                DgvRecords.Columns[19].Width = 100;
                DgvRecords.Columns[19].Visible = true;
                // Created Date
                DgvRecords.Columns[20].HeaderText = "Created Date";
                DgvRecords.Columns[20].Width = 150;
                DgvRecords.Columns[20].Visible = false;
                TSSLFunction.Text = "Purchase Orders";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 8)
            {
                // Warehouse Adjustment ID
                DgvRecords.Columns[0].HeaderText = "WH Adjust ID";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "000000";
                // Warehouse Reference
                DgvRecords.Columns[1].HeaderText = "Warehouse Reference";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Reference
                DgvRecords.Columns[2].HeaderText = "Transaction Reference";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // Total Loss Items
                DgvRecords.Columns[3].HeaderText = "Total Loss Items";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // Total Gain Items
                DgvRecords.Columns[4].HeaderText = "Total Gain Items";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // Movement Date
                DgvRecords.Columns[5].HeaderText = "Transaction Date";
                DgvRecords.Columns[5].Width = 150;
                DgvRecords.Columns[5].Visible = true;
                // Created By
                DgvRecords.Columns[6].HeaderText = "Created By";
                DgvRecords.Columns[6].Width = 150;
                DgvRecords.Columns[6].Visible = true;
                // Created Date
                DgvRecords.Columns[7].HeaderText = "Created Date";
                DgvRecords.Columns[7].Width = 150;
                DgvRecords.Columns[7].Visible = true;
                TSSLFunction.Text = "Warehouse Adjustments";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 9)
            {
                // Warehouse Transfer ID
                DgvRecords.Columns[0].HeaderText = "WH Transfer ID";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "000000";
                // Reference 
                DgvRecords.Columns[1].HeaderText = "Reference";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Transfer Date
                DgvRecords.Columns[4].HeaderText = "Transfer Date";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // From Warehouse Ref
                DgvRecords.Columns[2].HeaderText = "From Warehouse";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // To Warehouse Ref
                DgvRecords.Columns[3].HeaderText = "To Warehouse";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // Total Qty Out Garments
                DgvRecords.Columns[5].HeaderText = "Garments Out";
                DgvRecords.Columns[5].Width = 150;
                DgvRecords.Columns[5].Visible = true;
                // Total Qty Out Boxes
                DgvRecords.Columns[6].HeaderText = "Boxes Out";
                DgvRecords.Columns[6].Width = 150;
                DgvRecords.Columns[6].Visible = true;
                // Total Qty Out Hangers
                DgvRecords.Columns[7].HeaderText = "Hangers Out";
                DgvRecords.Columns[7].Width = 150;
                DgvRecords.Columns[7].Visible = true;
                // Total Qty In
                DgvRecords.Columns[8].HeaderText = "Qty In";
                DgvRecords.Columns[8].Width = 150;
                DgvRecords.Columns[8].Visible = true;
                // Created By
                DgvRecords.Columns[9].HeaderText = "Created By";
                DgvRecords.Columns[9].Width = 150;
                DgvRecords.Columns[9].Visible = true;
                // Created Date
                DgvRecords.Columns[10].HeaderText = "Created Date";
                DgvRecords.Columns[10].Width = 150;
                DgvRecords.Columns[10].Visible = true;
                TSSLFunction.Text = "Warehouse Transfers";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 10)
            {
                // Warehouse Returns ID
                DgvRecords.Columns[0].HeaderText = "WH Return ID";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "000000";
                // Warehouse Ref
                DgvRecords.Columns[1].HeaderText = "Warehouse Ref";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Supplier Ref
                DgvRecords.Columns[2].HeaderText = "Supplier Ref";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // Reference
                DgvRecords.Columns[3].HeaderText = "Reference";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // Total items
                DgvRecords.Columns[4].HeaderText = "Total Items";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // Transaction Date
                DgvRecords.Columns[5].HeaderText = "Transaction Date";
                DgvRecords.Columns[5].Width = 150;
                DgvRecords.Columns[5].Visible = true;
                // Created By
                DgvRecords.Columns[6].HeaderText = "Created By";
                DgvRecords.Columns[6].Width = 150;
                DgvRecords.Columns[6].Visible = true;
                // Created Date
                DgvRecords.Columns[7].HeaderText = "Created Date";
                DgvRecords.Columns[7].Width = 150;
                DgvRecords.Columns[7].Visible = true;
                TSSLFunction.Text = "Warehouse Returns";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 11)
            {
                // Shop Deliveries ID
                DgvRecords.Columns[0].HeaderText = "Shop Delivery ID";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "00000000";
                // Shop Ref
                DgvRecords.Columns[1].HeaderText = "Shop Ref";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Warehouse Ref
                DgvRecords.Columns[2].HeaderText = "Warehouse Ref";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // Reference
                DgvRecords.Columns[3].HeaderText = "Reference";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // Total Items
                DgvRecords.Columns[4].HeaderText = "Total Items";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // Delivery Date
                DgvRecords.Columns[5].HeaderText = "Delivery Date";
                DgvRecords.Columns[5].Width = 150;
                DgvRecords.Columns[5].Visible = true;
                // Delivery Type
                DgvRecords.Columns[6].HeaderText = "Delivery Type";
                DgvRecords.Columns[6].Width = 150;
                DgvRecords.Columns[6].Visible = true;
                // Confirmed Date
                DgvRecords.Columns[7].HeaderText = "Confirmed Date";
                DgvRecords.Columns[7].Width = 150;
                DgvRecords.Columns[7].Visible = true;
                // Notes
                DgvRecords.Columns[8].HeaderText = "Notes";
                DgvRecords.Columns[8].Width = 150;
                DgvRecords.Columns[8].Visible = true;
                // Created By
                DgvRecords.Columns[9].HeaderText = "Created By";
                DgvRecords.Columns[9].Width = 150;
                DgvRecords.Columns[9].Visible = true;
                // Created Date
                DgvRecords.Columns[10].HeaderText = "Created Date";
                DgvRecords.Columns[10].Width = 150;
                DgvRecords.Columns[10].Visible = true;
                TSSLFunction.Text = "Shop Deliveries";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 12)
            {
                // Shop Adjustment ID
                DgvRecords.Columns[0].HeaderText = "Shop Adjustment ID";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "000000";
                // Shop Reference
                DgvRecords.Columns[1].HeaderText = "Shop Ref";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Reference
                DgvRecords.Columns[2].HeaderText = "Reference";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // Total Loss Items
                DgvRecords.Columns[3].HeaderText = "Total Loss";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // Total Gain Items
                DgvRecords.Columns[4].HeaderText = "Total Gain";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // Movement Date
                DgvRecords.Columns[5].HeaderText = "Movement Date";
                DgvRecords.Columns[5].Width = 150;
                DgvRecords.Columns[5].Visible = true;
                // Created By
                DgvRecords.Columns[6].HeaderText = "Created By";
                DgvRecords.Columns[6].Width = 150;
                DgvRecords.Columns[6].Visible = true;
                // Created Date
                DgvRecords.Columns[7].HeaderText = "Created Date";
                DgvRecords.Columns[7].Width = 150;
                DgvRecords.Columns[7].Visible = true;
                TSSLFunction.Text = "Shop Adjustments";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 13)
            {
                // Shop Transfer ID
                DgvRecords.Columns[0].HeaderText = "SH Transfer ID";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "000000";
                // Reference 
                DgvRecords.Columns[1].HeaderText = "Reference";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Transfer Date
                DgvRecords.Columns[2].HeaderText = "Transfer Date";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // From Shop Name
                DgvRecords.Columns[3].HeaderText = "From Shop Name";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // To Shop Name
                DgvRecords.Columns[4].HeaderText = "To Shop Name";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // Total Qty In
                DgvRecords.Columns[5].HeaderText = "Qty In";
                DgvRecords.Columns[5].Width = 150;
                DgvRecords.Columns[5].Visible = true;
                // Total Qty Out
                DgvRecords.Columns[6].HeaderText = "Qty Out";
                DgvRecords.Columns[6].Width = 150;
                DgvRecords.Columns[6].Visible = true;
                // Created By
                DgvRecords.Columns[7].HeaderText = "Created By";
                DgvRecords.Columns[7].Width = 150;
                DgvRecords.Columns[7].Visible = true;
                // Created Date
                DgvRecords.Columns[8].HeaderText = "Created Date";
                DgvRecords.Columns[8].Width = 150;
                DgvRecords.Columns[8].Visible = true;
                TSSLFunction.Text = "Shop Transfers";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 14)
            {
                // Sales ID
                DgvRecords.Columns[0].HeaderText = "Sales ID";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "000000";
                // Shop Ref
                DgvRecords.Columns[1].HeaderText = "Shop Ref";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Shop Name
                DgvRecords.Columns[2].HeaderText = "Shop Name";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // Transaction Date
                DgvRecords.Columns[3].HeaderText = "Sales Date";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // Total Items
                DgvRecords.Columns[4].HeaderText = "Total Items";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // Total VAT
                DgvRecords.Columns[5].HeaderText = "Total VAT";
                DgvRecords.Columns[5].Width = 150;
                DgvRecords.Columns[5].Visible = true;
                DgvRecords.Columns[5].DefaultCellStyle.Format = "C2";
                // Total Value
                DgvRecords.Columns[6].HeaderText = "Total Value";
                DgvRecords.Columns[6].Width = 150;
                DgvRecords.Columns[6].Visible = true;
                DgvRecords.Columns[6].DefaultCellStyle.Format = "C2";
                // Created By
                DgvRecords.Columns[7].HeaderText = "Created By";
                DgvRecords.Columns[7].Width = 150;
                DgvRecords.Columns[7].Visible = true;
                // Created Date
                DgvRecords.Columns[8].HeaderText = "Created Date";
                DgvRecords.Columns[8].Width = 150;
                DgvRecords.Columns[8].Visible = true;
                TSSLFunction.Text = "Shop Sales";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 15)
            {
                // Shop Returns ID
                DgvRecords.Columns[0].HeaderText = "SH Return ID";
                DgvRecords.Columns[0].Width = 150;
                DgvRecords.Columns[0].Visible = true;
                DgvRecords.Columns[0].DefaultCellStyle.Format = "000000";
                // Shop Ref
                DgvRecords.Columns[1].HeaderText = "Shop Ref";
                DgvRecords.Columns[1].Width = 150;
                DgvRecords.Columns[1].Visible = true;
                // Warehouse Ref
                DgvRecords.Columns[2].HeaderText = "Warehouse Ref";
                DgvRecords.Columns[2].Width = 150;
                DgvRecords.Columns[2].Visible = true;
                // Reference
                DgvRecords.Columns[3].HeaderText = "Reference";
                DgvRecords.Columns[3].Width = 150;
                DgvRecords.Columns[3].Visible = true;
                // Total Items
                DgvRecords.Columns[4].HeaderText = "Total Items";
                DgvRecords.Columns[4].Width = 150;
                DgvRecords.Columns[4].Visible = true;
                // Transaction Date
                DgvRecords.Columns[5].HeaderText = "Transaction Date";
                DgvRecords.Columns[5].Width = 150;
                DgvRecords.Columns[5].Visible = true;
                // Created By
                DgvRecords.Columns[6].HeaderText = "Created Date";
                DgvRecords.Columns[6].Width = 150;
                DgvRecords.Columns[6].Visible = true;
                // Created Date
                DgvRecords.Columns[7].HeaderText = "Created By";
                DgvRecords.Columns[7].Width = 150;
                DgvRecords.Columns[7].Visible = true;
                TSSLFunction.Text = "Shop Returns";
                int count = DgvRecords.Rows.Count;
                TSSCount.Text = count.ToString();
            }
            if (FunctionID == 16)
            {
                DgvRecords.Columns[2].DefaultCellStyle.Format = "C2";
                TSSLFunction.Text = "Total Value";
                decimal valuescost;
                valuescost = 0.0m;
                for (int i = 0; i < DgvRecords.Rows.Count; i++)
                {
                    valuescost += Convert.ToDecimal(DgvRecords.Rows[i].Cells[2].Value);
                }
                TSSCount.Text = valuescost.ToString("C2");
                TSBBalances.Visible = false;
                TsbNew.Visible = false;
                TsbRecord.Visible = false;
                TsbFind.Visible = false;
                TsbPrint.Visible = false;
                TsbDelete.Visible = false;
            }
        }
        private string GetFunctionSelectString()
        {
            if (FunctionID == 1)
            {
                SqlCmdString = "SELECT WarehouseRef,WarehouseName,WarehouseType from tblWarehouses";
            }
            else if (FunctionID == 2)
            {
                SqlCmdString = "SELECT SupplierRef, SupplierName, ContactName, Telephone from tblSuppliers";
            }
            else if (FunctionID == 3)
            {
                SqlCmdString = "SELECT ShopRef, ShopName, ShopType from tblShops";
            }
            else if (FunctionID == 4)
            {
                SqlCmdString = "SELECT StockCode, SupplierRef, SeasonName, DeadCode = case when DeadCode != 0 then 'Yes' else 'No' end, AmountTaken, DeliveredQtyHangers, DeliveredQtyBoxes, DeliveredQtyGarments, CostValue, PCMarkup, ZeroQty = case when ZeroQty != 0 then 'Yes' else 'No' end FROM tblStock WHERE deadcode = 0";
            }
            else if (FunctionID == 5)
            {
                SqlCmdString = "SELECT StockCode, SupplierRef, SeasonName, DeadCode = case when DeadCode != 0 then 'Yes' else 'No' end, AmountTaken, DeliveredQtyHangers, DeliveredQtyBoxes, DeliveredQtyGarments, CostValue, PCMarkup, ZeroQty = case when ZeroQty != 0 then 'Yes' else 'No' end FROM tblStock";
            }
            else if (FunctionID == 6)
            {
                SqlCmdString = "SELECT * from tblSeasons";
            }
            else if (FunctionID == 7)
            {
                SqlCmdString = "SELECT * from qryPurchaseOrders order by PurchaseOrderID desc";
            }
            if (FunctionID == 8)
            {
                SqlCmdString = "SELECT * from qryWarehouseAdjustments";
            }
            if (FunctionID == 9)
            {
                SqlCmdString = "SELECT * from qryWarehouseTransfers";
            }
            if (FunctionID == 10)
            {
                SqlCmdString = "SELECT * from qryWarehouseReturns";
            }
            if (FunctionID == 11)
            {
                SqlCmdString = "SELECT * from qryShopDeliveries";
            }
            if (FunctionID == 12)
            {
                SqlCmdString = "SELECT * from qryShopAdjustments";
            }
            if (FunctionID == 13)
            {
                SqlCmdString = "SELECT * from qryShopTransfers";
            }
            if (FunctionID == 14)
            {
                SqlCmdString = "SELECT * from qryShopSales";
            }
            if (FunctionID == 15)
            {
                SqlCmdString = "SELECT * from qryShopReturns";
            }
            if (FunctionID == 16)
            {
                SqlCmdString = "SELECT * from qryTotalValue";
            }
            return SqlCmdString;
        }
    }
}
