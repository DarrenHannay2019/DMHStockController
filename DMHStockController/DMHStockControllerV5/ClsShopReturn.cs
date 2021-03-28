using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DMHStockControllerV5
{
    public class ClsShopReturn : ClsUtils
    {
        public int ShopReturnID { get; set; }
        public void LoadNewForm()
        {
            FShopReturn shopReturn = new FShopReturn()
            {
                FormMode = "New",
                UserID = UserID
            };
            shopReturn.Show();
        }
        public void LoadSelectedForm()
        {
            FShopReturn shopReturn = new FShopReturn()
            {
                FormMode = "Old"
            };
            shopReturn.txtReturnID.Text = ShopReturnID.ToString();
            shopReturn.Show();
        }
        public int GetLastShopReturnHead()
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
                            SelectCmd.CommandText = "SELECT COUNT(*) AS MaxRef FROM tblShopReturns";
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
