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
    public class ClsWarehouseReturnLine : ClsWarehouseReturn
    {
        public int ReturnQty;
        public int ReturnValue;
        public bool SaveWarehouseReturnLine()
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
                            InsertCmd.CommandText = "INSERT INTO tblWarehouseReturnLines (WarehouseReturnID, StockCode, Qty, Value) VALUES (@WarehouseReturnID, @StockCode, @Qty, @Value)";
                            InsertCmd.Parameters.AddWithValue("@WarehouseReturnID", WarehouseReturnID);
                            InsertCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            InsertCmd.Parameters.AddWithValue("@Qty", ReturnQty);
                            InsertCmd.Parameters.AddWithValue("@Value", ReturnValue);
                            Result = (int)InsertCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        SaveToDB = false;
                        MessageBox.Show(ex.Message);

                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

                SaveToDB = false;
                throw;
            }
            if (Result == 1)
                SaveToDB = true;
            else
                SaveToDB = false;
            return SaveToDB;
        }
        public bool UpdateWarehouseReturnLine()
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
                            UpdateCmd.CommandText = "UPDATE tblWarehouseReturnLines SET Qty = @Qty,Value = @Value WHERE ReturnID = @ReturnID AND StockCode = @StockCode";
                            UpdateCmd.Parameters.AddWithValue("@ReturnID", WarehouseReturnID);
                            UpdateCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            UpdateCmd.Parameters.AddWithValue("@Qty", ReturnQty);
                            UpdateCmd.Parameters.AddWithValue("@Value", ReturnValue);
                            Result = (int)UpdateCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        UpdateToDB = false;
                        MessageBox.Show(ex.Message);

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
                UpdateToDB = false;
                MessageBox.Show(ex.Message);

                throw;
            }
            if (Result == 1)
                UpdateToDB = true;
            else
                UpdateToDB = false;
            return UpdateToDB;
        }
        public bool DeleteWarehouseReturnLine()
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
                            DeleteCmd.CommandText = "DELETE FROM tblWarehouseReturnLines WHERE ReturnID = @ReturnID;";
                            DeleteCmd.Parameters.AddWithValue("@ReturnID", WarehouseReturnID);
                            Result = (int)DeleteCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        DeleteFromDB = false;
                        MessageBox.Show(ex.Message);

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
                MessageBox.Show(ex.Message);

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
