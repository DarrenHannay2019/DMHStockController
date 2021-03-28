using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DMHStockControllerV5
{
    public class ClsShopDelivery : ClsUtils
    {
        public int ShopDelID;
        public void LoadNewForm()
        {
            FShopDelivery shopDelivery = new FShopDelivery
            {
                FormMode = "New",
                UserID = UserID
            };
            shopDelivery.ShowDialog();
        }
        public void LoadSelectedForm()
        {
            FShopDelivery shopDelivery = new FShopDelivery
            {
                FormMode = "Old",
                UserID = UserID
            };
            shopDelivery.txtDelNoteNumber.Text = ShopDelID.ToString();
            shopDelivery.ShowDialog();

        }
        public int GetLastShopDelivery()
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
                            SelectCmd.CommandText = "SELECT COUNT(*) AS MaxRef FROM tblShopDeliveries";
                            Result = (int)SelectCmd.ExecuteScalar();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        Result = 0;
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                Result = 0;
                throw;
            }
            return Result;
        }
    }
}
