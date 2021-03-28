using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMHStockControllerV5
{
    public class ClsWarehouseAdjustment : ClsUtils
    {
        public int WarehouseAdjustmentID { get; set; }
        public void LoadNewWarehouseAdjustment()
        {
            FWarehouseAdjustment warehouseAdjustment = new FWarehouseAdjustment
            {
                FormMode = "New",
                UserID = UserID
            };
            warehouseAdjustment.ShowDialog();
        }
        public void LoadSelectedWarehouseAdjustment()
        {
            FWarehouseAdjustment warehouseAdjustment = new FWarehouseAdjustment
            {
                FormMode = "Old",
                UserID = UserID

            };
            warehouseAdjustment.TxtRecordID.Text = WarehouseAdjustmentID.ToString();
            warehouseAdjustment.ShowDialog();
        }

        public int GetLastWarehouseAdjustmentHead()
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
                            SelectCmd.CommandText = "SELECT COUNT(*) AS MaxRef FROM tblWarehouseAdjustments";
                            Result = (int)SelectCmd.ExecuteScalar();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Looking for Last Record\n" + ex.Message);
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Looking for Last Record\n" + ex.Message);
                throw;
            }
            return Result;
        }
    }
}
