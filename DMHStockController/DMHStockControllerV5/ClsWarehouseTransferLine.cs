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
    public class ClsWarehouseTransferLine : ClsWarehouseTransfer
    {
        public int CurrQtyGarments;
        public int CurrQtyBoxes;
        public int CurrQtyHangers;
        public int TOQtyGarments;
        public int TOQtyBoxes;
        public int TOQtyHangers;
        public int TIQty;

        public bool SaveWarehouseTransferLineToDB()
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
                            InsertCmd.CommandText = "INSERT INTO tblWarehouseTransferLines (WarehouseTransferID, StockCode, CurrentQtyGarments, CurrentQtyBoxes, CurrentQtyHangers, TOQtyGarments, TOQtyBoxes, TIQtyHangers, TOQtyHangers) VALUES (@WarehouseTransferID,  @StockCode, @CurrentQtyGarments, @CurrentQtyBoxes, @CurrentQtyHangers, @TOQtyGarments, @TOQtyBoxes , @TIQtyHangers, TOQtyHangers)";
                            InsertCmd.Parameters.AddWithValue("@WarehouseTransferID", WarehouseTransferID);
                            InsertCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            InsertCmd.Parameters.AddWithValue("@CurrentQtyHangers", CurrQtyHangers);
                            InsertCmd.Parameters.AddWithValue("@CurrentQtyBoxes", CurrQtyBoxes);
                            InsertCmd.Parameters.AddWithValue("@CurrentQtyGarments", CurrQtyGarments);
                            InsertCmd.Parameters.AddWithValue("@TOQtyGarments", TOQtyGarments);
                            InsertCmd.Parameters.AddWithValue("@TOQtyBoxes", TOQtyBoxes);
                            InsertCmd.Parameters.AddWithValue("@TOQtyHangers", TOQtyHangers);
                            InsertCmd.Parameters.AddWithValue("@TIQtyHangers", TIQty);
                            Result = (int)InsertCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        SaveToDB = false;
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
                SaveToDB = false;
                throw;
            }
            if (Result == 1)
                SaveToDB = true;
            else
                SaveToDB = false;
            return SaveToDB;
        }
        public bool UpdateWarehouseTransferLineInDB()
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
                            UpdateCmd.CommandText = "UPDATE tblWarehouseTransferLines SET CurrentQtyGarments = @CurrentQtyGarments, CurrentQtyBoxes = @CurrentQtyBoxes, CurrentQtyHangers = @CurrentQtyHangers, TOQtyGarments = @TOQtyGarments ,TOQtyBoxes = @TOQtyBoxes, TOQtyHangers = @TOQtyHangers, TIQtyHangers = @TIQtyHangers WHERE WarehouseTransferID = @WarehouseTransferID AND StockCode = @StockCode";
                            UpdateCmd.Parameters.AddWithValue("@WarehouseTransferID", WarehouseTransferID);
                            UpdateCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            UpdateCmd.Parameters.AddWithValue("@CurrentQtyHangers", CurrQtyHangers);
                            UpdateCmd.Parameters.AddWithValue("@CurrentQtyBoxes", CurrQtyBoxes);
                            UpdateCmd.Parameters.AddWithValue("@CurrentQtyGarments", CurrQtyGarments);
                            UpdateCmd.Parameters.AddWithValue("@TOQtyGarments", TOQtyGarments);
                            UpdateCmd.Parameters.AddWithValue("@TOQtyBoxes", TOQtyBoxes);
                            UpdateCmd.Parameters.AddWithValue("@TOQtyHangers", TOQtyHangers);
                            UpdateCmd.Parameters.AddWithValue("@TIQtyHangers", TIQty);
                            Result = (int)UpdateCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        UpdateToDB = false;
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
                UpdateToDB = false;
                throw;
            }
            if (Result == 1)
                UpdateToDB = true;
            else
                UpdateToDB = false;
            return UpdateToDB;
        }
        public bool DeleteWarehouseTransferLineFromDB()
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
                            DeleteCmd.CommandText = "DELETE FROM tblWarehouseTransferLines WHERE WarehouseTransferID = @WarehouseTransferID;";
                            DeleteCmd.Parameters.AddWithValue("@WarehouseTransferID", WarehouseTransferID);
                            DeleteCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        DeleteFromDB = false;
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
