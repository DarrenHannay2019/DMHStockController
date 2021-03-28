using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DMHStockControllerV5
{
    public class ClsShopTransfer : ClsUtils
    {
        public int ShopTransferID { get; set; }
        public void LoadNewForm()
        {
            FShopTransfer shopTransfer = new FShopTransfer()
            {
                FormMode = "New",
                UserID = UserID
            };
            shopTransfer.Show();
        }
        public void LoadSelectedForm()
        {
            FShopTransfer shopTransfer = new FShopTransfer()
            {
                FormMode = "Old"
            };
            shopTransfer.TxtTransferID.Text = ShopTransferID.ToString();
            shopTransfer.Show();
        }
        public int GetLastShopTransferHead()
        {
            Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    try
                    {
                        conn.Open();
                        using (SqlCommand SelectCmd = new SqlCommand())
                        {
                            SelectCmd.Connection = conn;
                            SelectCmd.CommandText = "SELECT COUNT(*) AS MaxRef FROM tblShopTransfers";
                            Result = (int)SelectCmd.ExecuteScalar();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                throw;
            }
            return Result;
        }
    }
}
