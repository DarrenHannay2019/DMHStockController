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
    public class ClsWarehouseReturnHead : ClsWarehouseReturn
    {
        public int TotalItems;

        public bool SaveWarehouseReturnHead()
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
                            InsertCmd.CommandText = "INSERT INTO tblWarehouseReturns (WarehouseRef, SupplierRef, Reference, TotalItems, TransactionDate, CreatedBy, CreatedDate) VALUES (@WarehouseRef, @SupplierRef, @Reference, @TotalItems, @TransactionDate, @CreatedBy, @CreatedDate)";
                            InsertCmd.Parameters.AddWithValue("@SupplierRef", SupplierRef);
                            InsertCmd.Parameters.AddWithValue("@WarehouseRef", WarehouseRef);
                            InsertCmd.Parameters.AddWithValue("@Reference", Reference);
                            InsertCmd.Parameters.AddWithValue("@TotalItems", TotalItems);
                            InsertCmd.Parameters.AddWithValue("@TransactionDate", MovementDate);
                            InsertCmd.Parameters.AddWithValue("@CreatedBy", UserID);
                            InsertCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                            Result = (int)InsertCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        SaveToDB = false;
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
                SaveToDB = false;
                MessageBox.Show(ex.Message);

                throw;
            }
            if (Result == 1)
                SaveToDB = true;
            else
                SaveToDB = false;
            return SaveToDB;
        }
        public bool UpdateWarehouseReturnHead()
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
                            UpdateCmd.CommandText = "UPDATE tblWarehouseReturns SET ToWarehouseRef = @ToWarehouseRef, WarehouseRef = @WarehouseRef, Reference = @Reference, TotalItems = @TotalItems, TransactionDate = @TransactionDate WHERE ReturnsID = @ReturnsID";
                            UpdateCmd.Parameters.AddWithValue("@ReturnsID", WarehouseReturnID);
                            UpdateCmd.Parameters.AddWithValue("@WarehouseRef", WarehouseRef);
                            UpdateCmd.Parameters.AddWithValue("@ToWarehouseRef", SupplierRef);
                            UpdateCmd.Parameters.AddWithValue("@Reference", Reference);
                            UpdateCmd.Parameters.AddWithValue("@TotalItems", TotalItems);
                            UpdateCmd.Parameters.AddWithValue("@TransactionDate", MovementDate);
                            Result = (int)UpdateCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        UpdateToDB = false;
                        MessageBox.Show(ex.Message);

                        throw;
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
        public bool DeleteWarehouseReturnHead()
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
                            DeleteCmd.CommandText = "DELETE FROM tblWarehouseReturns WHERE ReturnsID = @ReturnsID";
                            DeleteCmd.Parameters.AddWithValue("@ReturnsID", WarehouseReturnID);
                            Result = (int)DeleteCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);

                        DeleteFromDB = false;
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

                DeleteFromDB = false;
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
