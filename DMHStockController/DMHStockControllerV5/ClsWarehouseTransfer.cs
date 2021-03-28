using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DMHStockControllerV5
{
    public class ClsWarehouseTransfer : ClsUtils
    {
        public int WarehouseTransferID;
        public string ToWarehouseRef { get; set; }
        public string ToWarehouseName { get; set; }
        public void LoadNewRecord()
        {
            FWarehouseTransfer warehouseTransfer = new FWarehouseTransfer()
            {
                FormMode = "New",
                UserID = UserID
            };
            warehouseTransfer.ShowDialog();
        }
        public void LoadSelectedWarehouseTransfer()
        {
            FWarehouseTransfer warehouseTransfer = new FWarehouseTransfer()
            {
                FormMode = "Old"
            };
            warehouseTransfer.TxtTransferID.Text = WarehouseTransferID.ToString();
            warehouseTransfer.ShowDialog();
        }
        public int GetLastWarehouseTransferHeadFromDB()
        {
            Result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    try
                    {
                        using (SqlCommand SelectCmd = new SqlCommand())
                        {
                            SelectCmd.Connection = conn;
                            SelectCmd.Connection.Open();
                            SelectCmd.CommandType = CommandType.Text;
                            SelectCmd.CommandText = "SELECT COUNT(*) as MaxRows FROM tblWarehouseTransfers";
                            Result = (int)SelectCmd.ExecuteScalar();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
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
