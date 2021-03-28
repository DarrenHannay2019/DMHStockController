using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DMHStockControllerV5
{
    public class ClsShopAdjustmentLine : ClsShopAdjustment
    {
        public bool SaveShopAdjustmentLine()
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
                            InsertCmd.CommandText = "INSERT INTO tblShopAdjustmentLines(ShopAdjustmentID, StockCode, MovementType, Qty, Value) VALUES (@ShopAdjustmentID, @StockCode, @MovementType, @Qty, @Value)";
                            InsertCmd.Parameters.AddWithValue("@ShopAdjustmentID", ID);
                            InsertCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            InsertCmd.Parameters.AddWithValue("@MovementType", SMovementType);
                            InsertCmd.Parameters.AddWithValue("@Qty", Qty);
                            InsertCmd.Parameters.AddWithValue("@Value", Value);
                            Result = (int)InsertCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        SaveToDB = false;
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        throw;
                    }
                }
                if (Result == 1)
                    SaveToDB = true;
                else
                    SaveToDB = false;
            }
            catch (SqlException ex)
            {
                SaveToDB = false;
                System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                throw;
            }
            return SaveToDB;
        }
        public bool UpdateShopAdjustmentLine()
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
                            UpdateCmd.CommandText = "UPDATE tblShopAdjustmentLines SET MovementType = @MovementType, Qty = @Qty, Value = @Value WHERE ShopAdjustmentID = @ShopAdjustmentID AND StockCode = @StockCode";
                            UpdateCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            UpdateCmd.Parameters.AddWithValue("@MovementType", SMovementType);
                            UpdateCmd.Parameters.AddWithValue("@Qty", Qty);
                            UpdateCmd.Parameters.AddWithValue("@Value", Value);
                            UpdateCmd.Parameters.AddWithValue("@ShopAdjustmentID", ID);
                            Result = (int)UpdateCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Updating\n" + ex.Message);
                        UpdateToDB = false;
                        throw;
                    }
                }
                if (Result == 1)
                    UpdateToDB = true;
                else
                    UpdateToDB = false;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Updating\n" + ex.Message);
                UpdateToDB = false;
                throw;
            }

            return UpdateToDB;
        }
        public bool DeleteShopAdjustLine()
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
                            DeleteCmd.CommandText = "DELETE from tblShopAdjustmentLines WHERE ShopAdjustmentID = @ShopAdjustmentID;";
                            DeleteCmd.Parameters.AddWithValue("@ShopAdjustmentID", ID);
                            Result = (int)DeleteCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Delete\n" + ex.Message);
                        DeleteFromDB = false;
                        throw;
                    }
                }
                if (Result == 1)
                    DeleteFromDB = true;
                else
                    DeleteFromDB = false;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Delete\n" + ex.Message);
                DeleteFromDB = false;
                throw;
            }
            return DeleteFromDB;
        }
    }
}
