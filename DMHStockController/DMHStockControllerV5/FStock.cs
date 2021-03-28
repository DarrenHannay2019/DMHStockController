using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public partial class FStock : Form
    {
        public string FormMode { get; set; }
        public decimal AmountTaken { get; set; }
        public decimal CostValue { get; set; }
        public decimal PCMarkUp { get; set; }
        public int UserID { get; set; }
        public FStock()
        {
            InitializeComponent();
        }

        private void FStock_Load(object sender, EventArgs e)
        {
            GetAllSeasonData();
            LoadSupplierIntoForm();
            LoadStockIntoForm();
            if (FormMode == "New")
            {
                CmdOK.Text = "Save";
            }
            else
            {
                CmdOK.Text = "Ok";
                LoadData();
            }
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            ClsStock stock = new ClsStock
            {
                StockCode = TxtStockCode.Text.TrimEnd(),
                SupplierRef = TxtSupplierRef.Text.TrimEnd(),
                SeasonName = CboSeason.Text.TrimEnd(),
                DeadCode = ChkDeadCode.Checked,
                ZeroQty = ChkZeroQty.Checked,
                DeliveredQtyBoxes = Convert.ToInt32(TxtDelBoxesQty.Text.TrimEnd()),
                DeliveredQtyGarments = Convert.ToInt32(TxtDelGarmentsQty.Text.TrimEnd()),
                DeliveredQtyHangers = Convert.ToInt32(TxtDelHangersQty.Text.TrimEnd()),
                PCMarkUp = PCMarkUp
            };
            decimal.TryParse(TxtAmountTaken.Text, System.Globalization.NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out decimal toConvert);
            if (toConvert == AmountTaken)
                stock.AmountTaken = AmountTaken;
            else
                stock.AmountTaken = Convert.ToDecimal(TxtAmountTaken.Text.TrimEnd());
            decimal.TryParse(TxtCostValue.Text, System.Globalization.NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out toConvert);
            if (toConvert == CostValue)
                stock.CostValue = CostValue;
            else
                stock.CostValue = Convert.ToDecimal(TxtCostValue.Text.TrimEnd());
            if (FormMode == "New")
            {
                stock.UserID = UserID;
                stock.SaveStockCodeToDB();
            }
            else
                stock.UpdateStockCodeInDB();
            this.Close();
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void TxtStockCode_Leave(object sender, EventArgs e)
        {
            TxtStockCode.Text = ClsUtils.ChangeCase(TxtStockCode.Text, 1);  // change to uppercase text
        }

        private void TxtSupplierRef_Leave(object sender, EventArgs e)
        {
            TxtSupplierRef.Text = ClsUtils.ChangeCase(TxtSupplierRef.Text, 1);  // change to uppercase text
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
                    CboSeason.Items.Add(dataReader.GetString(i));
                }
            }
            dataReader.Close();
            conn.Close();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable dtk = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblStock Where StockCode = @StockCode";
                    SelectCmd.Parameters.AddWithValue("@StockCode", TxtStockCode.Text.TrimEnd());
                    sqlDataAdapter.SelectCommand = SelectCmd;
                    sqlDataAdapter.Fill(dtk);
                }
                TxtSupplierRef.Text = dtk.Rows[0][1].ToString();
                CboSeason.Text = dtk.Rows[0][2].ToString();
                ChkDeadCode.Checked = Convert.ToBoolean(dtk.Rows[0][3].ToString());
                AmountTaken = Convert.ToDecimal(dtk.Rows[0][4].ToString());
                TxtAmountTaken.Text = AmountTaken.ToString("C2");
                TxtDelHangersQty.Text = dtk.Rows[0][5].ToString();
                TxtDelBoxesQty.Text = dtk.Rows[0][6].ToString();
                TxtDelGarmentsQty.Text = dtk.Rows[0][7].ToString();
                CostValue = Convert.ToDecimal(dtk.Rows[0][8].ToString());
                TxtCostValue.Text = CostValue.ToString("C2");
                PCMarkUp = Convert.ToDecimal(dtk.Rows[0][9].ToString());
                TxtPcMarkUp.Text = PCMarkUp.ToString("P2");
                ChkZeroQty.Checked = Convert.ToBoolean(dtk.Rows[0][10].ToString());
            }
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from qryStockLevels where StockCode = @StockCode";
                    SelectCmd.Parameters.AddWithValue("@StockCode", TxtStockCode.Text.TrimEnd());
                    sqlDataAdapter.SelectCommand = SelectCmd;
                    sqlDataAdapter.Fill(dt);
                }
                DgvLocationQty.DataSource = dt;
                DgvLocationQty.AutoGenerateColumns = true;
                DgvLocationQty.CellBorderStyle = DataGridViewCellBorderStyle.None;
                DgvLocationQty.BackgroundColor = Color.LightCoral;
                DgvLocationQty.DefaultCellStyle.SelectionBackColor = Color.Plum;
                DgvLocationQty.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                DgvLocationQty.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                DgvLocationQty.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DgvLocationQty.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DgvLocationQty.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DgvLocationQty.AllowUserToResizeColumns = false;
                DgvLocationQty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvLocationQty.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                DgvLocationQty.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                DgvLocationQty.Columns[0].HeaderText = "Location Ref";
                DgvLocationQty.Columns[1].HeaderText = "Type";
                DgvLocationQty.Columns[2].HeaderText = "Hangers";
                DgvLocationQty.Columns[3].HeaderText = "Boxes";
                DgvLocationQty.Columns[4].HeaderText = "Garments";
                DgvLocationQty.Columns[5].Visible = false;
            }
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
        private void LoadStockIntoForm()
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
    }
}
