using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public partial class FSettings : Form
    {
        public string FormMode { get; set; }
        double VatRate { get; set; }
        decimal ValueVat { get; set; }
        SqlDataReader Reader;   // to read all data into the application

        public FSettings()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ClsUtils.GetConnString(1);
                conn.Open();
                DataSet SettingData = new DataSet();
                SqlDataAdapter SettingsDataAdapter = new SqlDataAdapter("SELECT * from tblCompanyDetails", conn);
                SettingsDataAdapter.Fill(SettingData, "tblCompanyDetails");
                txtCompanyName.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["CompanyName"].ToString();
                txtAdd1.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["Address1"].ToString();
                txtAdd2.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["Address2"].ToString();
                txtAdd3.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["Address3"].ToString();
                txtAdd4.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["Address4"].ToString();
                txtPostCode.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["PostCode"].ToString();
                txtTelephone.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["Telephone"].ToString();
                txtFax.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["Fax"].ToString();
                txtVATReg.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["VATRegistrationNo"].ToString();
                txtEmail.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["Email"].ToString();
                txtWWW.Text = SettingData.Tables["tblCompanyDetails"].Rows[0]["Website"].ToString();

                VatRate = Convert.ToDouble(SettingData.Tables["tblCompanyDetails"].Rows[0]["VatRate"]);
                txtVATRate.Text = VatRate.ToString("P2", CultureInfo.InvariantCulture);
                // txtVATRate.Text = FormatPercent(txtVATRate.Text)
            }
        }
        private void LoadCombos()
        {
            ComboBox1.Items.Clear();
            ComboBox2.Items.Clear();
            ComboBox3.Items.Clear();
            // load all database from the Server
            using (SqlConnection conn = new SqlConnection())
            {
                // attach the loading function to the connection string of the server
                conn.ConnectionString = ClsUtils.GetConnString(3);
                using (SqlCommand DBNameCmd = new SqlCommand())
                {
                    DBNameCmd.CommandText = "Select name from sys.databases";
                    DBNameCmd.Connection = conn;
                    DBNameCmd.Connection.Open();
                    Reader = DBNameCmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        ComboBox1.Items.Add(Reader[0]);
                        ComboBox2.Items.Add(Reader[0]);
                    }
                    string[] files = Directory.GetFiles(@"C:\\DBBackup");
                    if (Directory.Exists(@"C:\\DBBackup"))
                    {
                        foreach (string file in files)
                        {
                            ComboBox3.Items.Add(file);
                        }
                    }
                }
            }
        }
        private void FSettings_Load(object sender, EventArgs e)
        {
            if (FormMode == "New")
            {
                CmdOK.Text = "Save";
            }
            else
            {
                LoadData();
                CmdOK.Text = "OK";
            }
            LoadCombos();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            ClsSettings settings = new ClsSettings
            {
                CompanyName = txtCompanyName.Text.TrimEnd(),
                AddressLine1 = txtAdd1.Text.TrimEnd(),
                AddressLine2 = txtAdd2.Text.TrimEnd(),
                AddressLine3 = txtAdd3.Text.TrimEnd(),
                AddressLine4 = txtAdd4.Text.TrimEnd(),
                PostCode = txtPostCode.Text.TrimEnd(),
                Telephone = txtTelephone.Text.TrimEnd(),
                Fax = txtFax.Text.TrimEnd(),
                Memo = txtVATReg.Text.TrimEnd(),
                eMail = txtEmail.Text.TrimEnd(),
                WebsiteAddress = txtWWW.Text.TrimEnd(),
                VATRate = ValueVat,
                VATRegistration = txtVATReg.Text.TrimEnd()
            };
            if (FormMode == "New")
            {
                settings.SaveToDB = settings.SaveSettings();
                if (settings.SaveToDB == false)
                    MessageBox.Show("Unable to Save to Database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.Close();
            }
            else
            {
                settings.UpdateToDB = settings.UpdateSettings();
                if (settings.UpdateToDB == false)
                    MessageBox.Show("Unable to Update in Database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.Close();
            }
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void CmdBackup_Click(object sender, EventArgs e)
        {
            ClsSettings settings = new ClsSettings();
            settings.Reference = ComboBox1.Text;
            lblBackupinfo.Text = settings.Backup();
        }

        private void CmdRestore_Click(object sender, EventArgs e)
        {
            ClsSettings settings = new ClsSettings();
            settings.Reference = ComboBox1.Text;
            settings.AddressLine1 = ComboBox3.Text;
            lblRestoreInfo.Text = settings.Restore();
        }

        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // not implemented fully yet task to complete at a later date.
        }

        private void txtAdd1_Leave(object sender, EventArgs e)
        {
            txtAdd1.Text = ClsUtils.ChangeCase(txtAdd1.Text, 3);
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            txtCompanyName.Text = ClsUtils.ChangeCase(txtCompanyName.Text, 3);
        }

        private void txtAdd2_Leave(object sender, EventArgs e)
        {
            txtAdd2.Text = ClsUtils.ChangeCase(txtAdd2.Text, 3);
        }

        private void txtAdd3_Leave(object sender, EventArgs e)
        {
            txtAdd3.Text = ClsUtils.ChangeCase(txtAdd3.Text, 3);
        }

        private void txtAdd4_Leave(object sender, EventArgs e)
        {
            txtAdd4.Text = ClsUtils.ChangeCase(txtAdd4.Text, 3);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.TextLength != 0)
            {
                if (ClsUtils.IsValidEmail(txtEmail.Text))
                    txtEmail.Text = ClsUtils.ChangeCase(txtEmail.Text, 2);
                else
                { txtEmail.Text = "Please Try Again"; }
            }
        }

        private void txtPostCode_Leave(object sender, EventArgs e)
        {
            txtPostCode.Text = ClsUtils.ChangeCase(txtPostCode.Text, 1);
        }

        private void txtVATReg_Leave(object sender, EventArgs e)
        {
            txtVATReg.Text = ClsUtils.ChangeCase(txtVATReg.Text, 1);
        }

        private void txtVATRate_Leave(object sender, EventArgs e)
        {
            ValueVat = Convert.ToDecimal(txtVATRate.Text);
            VatRate = Convert.ToDouble(txtVATRate.Text.TrimEnd());
            txtVATRate.Text = VatRate.ToString("P2", CultureInfo.InvariantCulture);
        }

        private void txtWWW_Leave(object sender, EventArgs e)
        {
            if (txtWWW.TextLength != 0)
            {
                // https://stackoverflow.com/questions/3228984/a-better-way-to-validate-url-in-c-sharp-than-try-catch 
                // User https://stackoverflow.com/users/626273/stema
                string regular = @"^(ht|f|sf)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
                string regular123 = @"^(www.)[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

                string myString = txtWWW.Text.Trim();
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
        }
    }
}
