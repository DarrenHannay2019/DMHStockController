using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public partial class FSupplier : Form
    {
        public int UserID { get; set; }
        public string FormMode { get; set; }
        public FSupplier()
        {
            InitializeComponent();
        }
        // getting all the data from the database of the selected supplier
        private void LoadData()
        {
            // get the record details of th selected supplier
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable dtk = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT * from tblSuppliers Where SupplierRef = @SupplierRef";
                    SelectCmd.Parameters.AddWithValue("@SupplierRef", TxtSupplierRef.Text.TrimEnd());
                    sqlDataAdapter.SelectCommand = SelectCmd;
                    sqlDataAdapter.Fill(dtk);
                }
                TxtSupplierRef.Text = dtk.Rows[0][0].ToString();
                TxtSupplierName.Text = dtk.Rows[0][1].ToString();
                TxtAddressLine1.Text = dtk.Rows[0][2].ToString();
                TxtAddressLine2.Text = dtk.Rows[0][3].ToString();
                TxtAddressLine3.Text = dtk.Rows[0][4].ToString();
                TxtAddressLine4.Text = dtk.Rows[0][5].ToString();
                TxtPostCode.Text = dtk.Rows[0][6].ToString();
                TxtTelephoneNumber1.Text = dtk.Rows[0][7].ToString();
                TxtFaxNumber.Text = dtk.Rows[0][8].ToString();
                TxtEmailAddress.Text = dtk.Rows[0][9].ToString();
                TxtMemo.Text = dtk.Rows[0][10].ToString();
                TxtContactName.Text = dtk.Rows[0][11].ToString();
            }
            // get the transactions of the selected supplier
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT StockCode, MovementType, MovementQtyHangers, MovementDate, MovementReference, LocationRef from qrySupplierTransactions where SupplierRef = @SupplierRef Order By MovementDate";
                    SelectCmd.Parameters.AddWithValue("@SupplierRef", TxtSupplierRef.Text.TrimEnd());
                    sqlDataAdapter.SelectCommand = SelectCmd;
                    sqlDataAdapter.Fill(dt);
                }
                gridTrans.DataSource = dt;
                gridTrans.AutoGenerateColumns = true;
                gridTrans.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gridTrans.BackgroundColor = Color.LightCoral;
                gridTrans.DefaultCellStyle.SelectionBackColor = Color.Plum;
                gridTrans.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                gridTrans.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gridTrans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gridTrans.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridTrans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridTrans.AllowUserToResizeColumns = false;
                gridTrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                gridTrans.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                gridTrans.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
                gridTrans.Columns[0].HeaderText = "Stock Code";
                gridTrans.Columns[1].HeaderText = "Type";
                gridTrans.Columns[2].HeaderText = "Qty";

                gridTrans.Columns[3].HeaderText = "Date";
                gridTrans.Columns[4].HeaderText = "Reference";
                gridTrans.Columns[5].HeaderText = "Location";
                this.Text = "Supplier Details for [" + TxtSupplierRef.Text.TrimEnd() + "] " + TxtSupplierName.Text.TrimEnd();
            }
        }
        private void ClearTextBoxes(Control control)
        {
            // Code from https://stackoverflow.com/questions/4811229/how-to-clear-the-text-of-all-textboxes-in-the-form
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }
        private void FSupplier_Load(object sender, EventArgs e)
        {
            if (FormMode == "New")
            {
                CmdOK.Text = "Save";
                this.Text = "New Supplier";
            }
            else
            {
                CmdOK.Text = "OK";
                LoadData();
            }
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            ClsSupplier supplier = new ClsSupplier
            {
                SupplierRef = TxtSupplierRef.Text.TrimEnd(),
                SupplierName = TxtSupplierName.Text.TrimEnd(),
                AddressLine1 = TxtAddressLine1.Text.TrimEnd(),
                AddressLine2 = TxtAddressLine2.Text.TrimEnd(),
                AddressLine3 = TxtAddressLine3.Text.TrimEnd(),
                AddressLine4 = TxtAddressLine4.Text.TrimEnd(),
                PostCode = TxtPostCode.Text.TrimEnd(),
                Telephone = TxtTelephoneNumber1.Text.TrimEnd(),
                ContactName = TxtContactName.Text.TrimEnd(),
                eMail = TxtEmailAddress.Text.TrimEnd(),
                Fax = TxtFaxNumber.Text.TrimEnd(),
                Memo = TxtMemo.Text.TrimEnd(),
                WebsiteAddress = TxtWebsiteAddress.Text.TrimEnd()
            };
            if (FormMode == "New")
            {
                supplier.UserID = UserID;
                supplier.SaveSupplierRecordToDB();
            }
            else
            {
                supplier.UpdateSupplierRecordInDB();
            }
            this.Close();   // close the form after saving
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);   // clearing the textboxes on the form
        }

        private void TxtSupplierName_Leave(object sender, EventArgs e)
        {
            TxtSupplierName.Text = ClsUtils.ChangeCase(TxtSupplierName.Text, 0);
        }

        private void TxtSupplierRef_Leave(object sender, EventArgs e)
        {
            TxtSupplierRef.Text = ClsUtils.ChangeCase(TxtSupplierRef.Text, 1);
        }

        private void TxtAddressLine1_Leave(object sender, EventArgs e)
        {
            TxtAddressLine1.Text = ClsUtils.ChangeCase(TxtAddressLine1.Text, 0);
        }

        private void TxtAddressLine2_Leave(object sender, EventArgs e)
        {
            TxtAddressLine2.Text = ClsUtils.ChangeCase(TxtAddressLine2.Text, 0);
        }

        private void TxtAddressLine3_Leave(object sender, EventArgs e)
        {
            TxtAddressLine3.Text = ClsUtils.ChangeCase(TxtAddressLine3.Text, 0);
        }

        private void TxtAddressLine4_Leave(object sender, EventArgs e)
        {
            TxtAddressLine4.Text = ClsUtils.ChangeCase(TxtAddressLine4.Text, 0);
        }

        private void TxtContactName_Leave(object sender, EventArgs e)
        {
            TxtContactName.Text = ClsUtils.ChangeCase(TxtContactName.Text, 0);
        }

        private void TxtEmailAddress_Leave(object sender, EventArgs e)
        {
            // to check to see if the email address is in the correct format
            if (TxtEmailAddress.TextLength != 0)
            {
                if (ClsUtils.IsValidEmail(TxtEmailAddress.Text))
                    TxtEmailAddress.Text = ClsUtils.ChangeCase(TxtEmailAddress.Text, 2);
                else
                { TxtEmailAddress.Text = "Please Try Again"; }
            }
            else
            {
                // do nothing
            }
        }

        private void TxtMemo_Leave(object sender, EventArgs e)
        {
            TxtMemo.Text = ClsUtils.ChangeCase(TxtMemo.Text, 0);
        }

        private void TxtPostCode_Leave(object sender, EventArgs e)
        {
            TxtPostCode.Text = ClsUtils.ChangeCase(TxtPostCode.Text, 1);
        }

        private void TxtWebsiteAddress_Leave(object sender, EventArgs e)
        {
            // to check to see if the website is in the correct format
            if (TxtWebsiteAddress.TextLength != 0)
            {
                // https://stackoverflow.com/questions/3228984/a-better-way-to-validate-url-in-c-sharp-than-try-catch 
                // User https://stackoverflow.com/users/626273/stema
                string regular = @"^(ht|f|sf)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
                string regular123 = @"^(www.)[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

                string myString = TxtWebsiteAddress.Text.Trim();
                if (Regex.IsMatch(myString, regular))
                {
                    MessageBox.Show("It is valid url  " + myString);
                }
                else if (Regex.IsMatch(myString, regular123))
                {
                    MessageBox.Show("Valid url with www. " + myString);
                }
                else
                {
                    MessageBox.Show("InValid URL  " + myString);
                }
            }
            else
            {
                // do nothing
            }
        }
    }
}
