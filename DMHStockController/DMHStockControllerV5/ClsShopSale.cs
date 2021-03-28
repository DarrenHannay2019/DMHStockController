using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DMHStockControllerV5
{
    public class ClsShopSale : ClsUtils
    {
        public int SalesID { get; set; }
        public void LoadNewForm()
        {
            FShopSale shopSale = new FShopSale()
            {
                FormMode = "New",
                UserID = UserID
            };
            shopSale.Show();
        }
        public void LoadSelectedForm()
        {
            FShopSale shopSale = new FShopSale()
            {
                FormMode = "Old"
            };
            shopSale.txtSalesID.Text = SalesID.ToString();
            shopSale.Show();
        }
        public int GetLastShopSaleHead()
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
                            SelectCmd.CommandText = "SELECT COUNT(*) AS MaxRef FROM tblShopSales";
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
