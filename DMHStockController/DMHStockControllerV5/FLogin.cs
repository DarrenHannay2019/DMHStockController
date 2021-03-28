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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void CmdLogin_Click(object sender, EventArgs e)
        {
            TotalUsers;
            int PassResult;
            ClsEmployee employee = new ClsEmployee();
            TotalUsers = employee.GetAllUserTotal();
            PassResult = employee.GetLoginUserID(TxtUserName.Text.TrimEnd(), TxtPassword.Text.TrimEnd());
            if (TotalUsers == 0)
            {
                DialogResult dialog = MessageBox.Show("Unknown User and do you wish to add new user?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialog == DialogResult.Yes)
                {
                    FrmEmployee frmEmployee = new FrmEmployee();
                    frmEmployee.FormMode = "New";
                    frmEmployee.ShowDialog();
                    Application.Exit();
                }
                else
                {
                    TxtUserName.Clear();
                    TxtPassword.Clear();
                    TxtUserName.Select();
                }
            }
            else
            {
                if (PassResult != 0)
                {
                    FrmMain frmMain = new FrmMain
                    {
                        RefToLoginForm = this,
                        UserID = PassResult
                    };
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    Application.Exit(); // unknown user need to keep system secure.
                }
            }
        }

        private void CmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();     // Exit the application
        }
    }
}
