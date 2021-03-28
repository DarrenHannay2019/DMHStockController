using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public class ClsWarehouseAdjustmentLine : ClsWarehouseAdjustment
    {
        public bool SaveWarehouseAdjustmentLineToDB()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    try
                    {
                        using (SqlCommand InsertCmd = new SqlCommand())
                        {
                            InsertCmd.Connection = conn;
                            InsertCmd.Connection.Open();
                            InsertCmd.CommandType = CommandType.Text;
                            InsertCmd.CommandText = "INSERT INTO tblWarehouseAdjustmentsLines (WarehouseAdjustmentID, StockCode, MovementType, Qty, Value) VALUES (@WarehouseAdjustmentID, @StockCode, @MovementType, @Qty, @Value)";
                            InsertCmd.Parameters.AddWithValue("@WarehouseAdjustmentID", WarehouseAdjustmentID);
                            InsertCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            InsertCmd.Parameters.AddWithValue("@MovementType", SMovementType);
                            InsertCmd.Parameters.AddWithValue("@Qty", Qty);
                            InsertCmd.Parameters.AddWithValue("@Value", Value);
                            Result = (int)InsertCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error in Saving\n" + ex.Message);
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
                MessageBox.Show("Error in Saving\n" + ex.Message);
                throw;
            }
            if (Result == 1)
                SaveToDB = true;
            else
                SaveToDB = false;
            return SaveToDB;
        }
        public bool UpdateWarehouseAdjustmentLineInDB()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    try
                    {
                        using (SqlCommand UpdateCmd = new SqlCommand())
                        {
                            UpdateCmd.Connection = conn;
                            UpdateCmd.Connection.Open();
                            UpdateCmd.CommandType = CommandType.Text;
                            UpdateCmd.CommandText = "UPDATE tblWarehouseAdjustmentsLines SET MovementType = @MovementType, Qty = @Qty, Value = @Value WHERE WarehouseAdjustmentID = @WarehouseAdjustmentID AND StockCode = @StockCode";
                            UpdateCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            UpdateCmd.Parameters.AddWithValue("@MovementType", SMovementType);
                            UpdateCmd.Parameters.AddWithValue("@Qty", Qty);
                            UpdateCmd.Parameters.AddWithValue("@Value", Value);
                            UpdateCmd.Parameters.AddWithValue("@WarehouseAdjustmentID", WarehouseAdjustmentID);
                            Result = (int)UpdateCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error in Updating Record\n" + ex.Message);
                        UpdateToDB = false;
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Updating Record\n" + ex.Message);
                throw;
            }
            if (Result == 1)
                UpdateToDB = true;
            else
                UpdateToDB = false;
            return UpdateToDB;
        }
        public bool DeleteWarehouseAdjustmentLineFromDB()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    try
                    {
                        using (SqlCommand DeleteCmd = new SqlCommand())
                        {
                            DeleteCmd.Connection = conn;
                            DeleteCmd.Connection.Open();
                            DeleteCmd.CommandType = CommandType.Text;
                            DeleteCmd.CommandText = "DELETE from tblWarehouseAdjustmentsLines WHERE WarehouseAdjustmentID = @WarehouseAdjustmentID;";
                            DeleteCmd.Parameters.AddWithValue("@WHAdjustID", WarehouseAdjustmentID);
                            DeleteCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        DeleteFromDB = false;
                        MessageBox.Show("Error in Deleting Record\n" + ex.Message);
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
                DeleteFromDB = false;
                MessageBox.Show("Error in Deleteing Record\n" + ex.Message);
                throw;
            }
            if (Result == 1)
                DeleteFromDB = true;
            else
                DeleteFromDB = false;
            return DeleteFromDB;
        }
    }
}
