using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public class ClsPurchaseOrderLine : ClsPurchaseOrder
    {
        public decimal LineAmount { get; set; }
        public ClsPurchaseOrderLine()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }

        ~ClsPurchaseOrderLine()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        public bool SaveToPurchaseOrderLinetbl()
        {
            SaveToDB = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = GetConnString(1);
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = "INSERT INTO tblPurchaseOrderLines (PurchaseOrderID, StockCode, DeliveredQtyGarments, DeliveredQtyBoxes, DeliveredQtyHangers, LineAmount) VALUES (@PurchaseOrderID, @StockCode, @DeliveredQtyGarments, @DeliveredQtyBoxes, @DeliveredQtyHangers, @LineAmount)";
                        sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
                        sqlCommand.Parameters.AddWithValue("@StockCode", StockCode);
                        sqlCommand.Parameters.AddWithValue("@DeliveredQtyGarments", DeliveredQtyGarments);
                        sqlCommand.Parameters.AddWithValue("@DeliveredQtyBoxes", DeliveredQtyBoxes);
                        sqlCommand.Parameters.AddWithValue("@DeliveredQtyHangers", DeliveredQtyHangers);
                        sqlCommand.Parameters.AddWithValue("@LineAmount", LineAmount);
                        Result = (int)sqlCommand.ExecuteNonQuery();
                    }
                }
                if (Result != 1)
                {
                    SaveToDB = false;
                }
                else
                {
                    SaveToDB = true;
                }
            }
            catch (SqlException ex)
            {
                SaveToDB = false;
                MessageBox.Show("Error in adding to database\n" + ex.Message);
            }
            return SaveToDB;
        }
        public bool UpdateToPurchaseOrderLinetbl()
        {
            UpdateToDB = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = GetConnString(1);
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = "UPDATE tblPurchaseOrderLines SET DeliveredQtyGarments = @DeliveredQtyGarments, DeliveredQtyBoxes = @DeliveredQtyBoxes, DeliveredQtyHangers = @DeliveredQtyHangers, LineAmount = @LineAmount WHERE PurchaseOrderID = @PurchaseOrderID AND StockCode = @StockCode";
                        sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
                        sqlCommand.Parameters.AddWithValue("@StockCode", StockCode);
                        sqlCommand.Parameters.AddWithValue("@DeliveredQtyGarments", DeliveredQtyGarments);
                        sqlCommand.Parameters.AddWithValue("@DeliveredQtyBoxes", DeliveredQtyBoxes);
                        sqlCommand.Parameters.AddWithValue("@DeliveredQtyHangers", DeliveredQtyHangers);
                        sqlCommand.Parameters.AddWithValue("@LineAmount", LineAmount);
                        Result = (int)sqlCommand.ExecuteNonQuery();
                    }
                }
                if (Result != 1)
                {
                    UpdateToDB = false;
                }
                else
                {
                    UpdateToDB = true;
                }
            }
            catch (SqlException ex)
            {
                UpdateToDB = false;
                MessageBox.Show("Error in adding to database\n" + ex.Message);
            }
            return UpdateToDB;
        }
        public bool DeletePurchaseOrderLineRecord()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = GetConnString(1);
                conn.Open();
                using (SqlCommand DeleteCmd = new SqlCommand())
                {
                    DeleteCmd.Connection = conn;
                    DeleteCmd.CommandText = "DELETE FROM tblPurchaseOrders where PurchaseOrderID = @PurchaseOrderID";
                    DeleteCmd.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
                    DeleteCmd.ExecuteNonQuery();
                }
            }
            return DeleteFromDB;
        }
    }
}
