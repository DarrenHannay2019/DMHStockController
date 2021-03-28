using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMHStockControllerV5
{
    public class ClsWarehouseReturn : ClsUtils
    {
        public int WarehouseReturnID { get; set; }
        public void LoadNewForm()
        {
            FWarehouseReturn warehouseReturn = new FWarehouseReturn()
            {
                FormMode = "New",
                UserID = UserID
            };
            warehouseReturn.Show();
        }
        public void LoadSelectedForm()
        {
            FWarehouseReturn warehouseReturn = new FWarehouseReturn()
            {
                FormMode = "Old"
            };
            warehouseReturn.txtReturnID.Text = WarehouseReturnID.ToString();
            warehouseReturn.Show();
        }
        public int GetLastWarehouseReturnHead()
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
                            SelectCmd.CommandText = "SELECT COUNT(*) AS MaxRef FROM tblWarehouseReturns";
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
