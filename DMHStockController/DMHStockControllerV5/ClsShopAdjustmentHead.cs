using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DMHStockControllerV5
{
    public class ClsShopAdjustmentHead : ClsShopAdjustment
    {
        public bool SaveShopAdjustmentHead()
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
                            InsertCmd.CommandText = "INSERT INTO tblShopAdjustments(ShopRef, Reference, TotalLossItems, TotalGainItems, MovementDate, CreatedBy, CreatedDate) VALUES (@ShopRef, @Reference, @TotalLossItems, @TotalGainItems, @MovementDate, @CreatedBy, @CreatedDate)";
                            InsertCmd.Parameters.AddWithValue("@ShopRef", ShopRef);
                            InsertCmd.Parameters.AddWithValue("@Reference", Reference);
                            InsertCmd.Parameters.AddWithValue("@TotalLossItems", TotalLossItems);
                            InsertCmd.Parameters.AddWithValue("@TotalGainItems", TotalGainItems);
                            InsertCmd.Parameters.AddWithValue("@MovementDate", MovementDate);
                            InsertCmd.Parameters.AddWithValue("@CreatedBy", UserID);
                            InsertCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
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
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in connecting\n" + ex.Message);
                SaveToDB = false;
                throw;
            }
            return SaveToDB;
        }
        public bool UpdateShopAdjustmentHead()
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
                            UpdateCmd.CommandText = "UPDATE tblShopAdjustments SET ShopRef = @ShopRef, Reference = @Reference, TotalLossItems = @TotalLossItems, TotalGainItems = @TotalGainItems, MovementDate = @MovementDate WHERE ShopAdjustmentID = @ShopAdjustmentID";
                            UpdateCmd.Parameters.AddWithValue("@ShopAdjustmentID", ID);
                            UpdateCmd.Parameters.AddWithValue("@ShopRef", ShopRef);
                            UpdateCmd.Parameters.AddWithValue("@Reference", Reference);
                            UpdateCmd.Parameters.AddWithValue("@TotalLossItems", TotalLossItems);
                            UpdateCmd.Parameters.AddWithValue("@TotalGainItems", TotalGainItems);
                            UpdateCmd.Parameters.AddWithValue("@MovementDate", MovementDate);
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
                System.Windows.Forms.MessageBox.Show("Error in connecting\n" + ex.Message);
                UpdateToDB = false;
                throw;
            }
            return UpdateToDB;
        }
        public bool DeleteShopAdjustHead()
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
                            DeleteCmd.CommandText = "DELETE from tblShopAdjustments where ShopAdjustmentID = @ShopAdjustmentID;";
                            DeleteCmd.Parameters.AddWithValue("@ShopAdjustmentID", ID);
                            Result = (int)DeleteCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in connecting\n" + ex.Message);
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
                System.Windows.Forms.MessageBox.Show("Error in connecting\n" + ex.Message);
                DeleteFromDB = false;
                throw;
            }
            return DeleteFromDB;
        }
    }
}
