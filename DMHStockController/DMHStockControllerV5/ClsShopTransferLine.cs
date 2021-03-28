using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DMHStockControllerV5
{
    public class ClsShopTransferLine : ClsShopTransfer
    {
        public int ID;
        public int CurrQty;
        public int TOQty;
        public int TIQty;
        public bool SaveShopTransferLine()
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
                        InsertCmd.CommandText = "INSERT INTO tblShopTransferLines (ShopTransferID, StockCode, CurrentQty, TOQty, TIQty) VALUES (@ShopTransferID,  @StockCode, @CurrentQty, @TOQty, @TIQty)";
                        InsertCmd.Parameters.AddWithValue("@ShopTransferID", ID);
                        InsertCmd.Parameters.AddWithValue("@StockCode", StockCode);
                        InsertCmd.Parameters.AddWithValue("@CurrentQty", CurrQty);
                        InsertCmd.Parameters.AddWithValue("@TOQty", TOQty);
                        InsertCmd.Parameters.AddWithValue("@TIQty", TIQty);
                        Result = (int)InsertCmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                    SaveToDB = false;
                    throw;
                }
            }
            if (Result == 1)
                SaveToDB = true;
            else
                SaveToDB = false;
            return SaveToDB;
        }
        public bool UpdateShopTransferLine()
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
                            UpdateCmd.CommandText = "UPDATE tblShopTransferLines SET TOQty = @TOQty, TIQty = @TIQty WHERE ShopTransferID = @ShopTransferID AND StockCode = @StockCode";
                            UpdateCmd.Parameters.AddWithValue("@ShopTransferID", ID);
                            UpdateCmd.Parameters.AddWithValue("@StockCode", StockCode);
                            UpdateCmd.Parameters.AddWithValue("@TOQty", TOQty);
                            UpdateCmd.Parameters.AddWithValue("@TIQty", TIQty);
                            Result = (int)UpdateCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        UpdateToDB = false;
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        throw;
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
        public bool DeleteShopTransferLine()
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
                            DeleteCmd.CommandText = "DELETE FROM tblShopTransferLines WHERE ShopTransferID = @ShopTransferID;";
                            DeleteCmd.Parameters.AddWithValue("@ShopTransferID", ID);
                            Result = (int)DeleteCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        DeleteFromDB = false;
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        throw;
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
