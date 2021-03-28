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
    public class ClsWarehouseTransferHead : ClsWarehouseTransfer
    {
        public bool SaveWarehouseTransferHead()
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
                            InsertCmd.CommandText = "INSERT INTO tblWarehouseTransfers (Reference, TransferDate, WarehouseRef,  ToWarehouseRef,  TotalQtyOutGarments, TotalQtyOutBoxes, TotalQtyOutHangers,TotalQtyInHangers, CreatedBy, CreatedDate) VALUES (@Reference, @TransferDate, @WarehouseRef,  @ToWarehouseRef, @TotalQtyOutGarments, @TotalQtyOutBoxes, @TotalQtyOutHangers, @TotalQtyInHangers, @CreatedBy, @CreatedDate)";
                            InsertCmd.Parameters.AddWithValue("@Reference", Reference);
                            InsertCmd.Parameters.AddWithValue("@TransferDate", MovementDate);
                            InsertCmd.Parameters.AddWithValue("@WarehouseRef", WarehouseRef);
                            InsertCmd.Parameters.AddWithValue("@ToWarehouseRef", ToWarehouseRef);
                            InsertCmd.Parameters.AddWithValue("@TotalQtyOutGarments", DeliveredQtyGarments);
                            InsertCmd.Parameters.AddWithValue("@TotalQtyOutBoxes", DeliveredQtyBoxes);
                            InsertCmd.Parameters.AddWithValue("@TotalQtyOutHangers", DeliveredQtyHangers);
                            InsertCmd.Parameters.AddWithValue("@TotalQtyInHangers", Qty);
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
        public bool UpdateWarehouseTransferHead()
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
                            UpdateCmd.CommandText = "UPDATE tblWarehouseTransfers SET Reference = @Reference, TransferDate = @TransferDate, WarehouseRef = @WarehouseRef, ToWarehouseRef = @ToWarehouseRef , TotalQtyOutGarments = @TotalQtyOutGarments, TotalQtyOutBoxes = @TotalQtyOutBoxes, TotalQtyOutHangers = @TotalQtyOutHangers, @TotalQtyInHangers = @TotalQtyInHangers WHERE WarehouseTransferID = @WarehouseTransferID";
                            UpdateCmd.Parameters.AddWithValue("@WarehouseTransferID", WarehouseTransferID);
                            UpdateCmd.Parameters.AddWithValue("@Reference", Reference);
                            UpdateCmd.Parameters.AddWithValue("@TransferDate", MovementDate);
                            UpdateCmd.Parameters.AddWithValue("@WarehouseRef", WarehouseRef);
                            UpdateCmd.Parameters.AddWithValue("@ToWarehouseRef", ToWarehouseRef);
                            UpdateCmd.Parameters.AddWithValue("@TotalQtyOutGarments", DeliveredQtyGarments);
                            UpdateCmd.Parameters.AddWithValue("@TotalQtyOutBoxes", DeliveredQtyBoxes);
                            UpdateCmd.Parameters.AddWithValue("@TotalQtyOutHangers", DeliveredQtyHangers);
                            UpdateCmd.Parameters.AddWithValue("@TotalQtyInHangers", Qty);
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
        public bool DeleteWarehouseTransferHead()
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
                            DeleteCmd.CommandText = "DELETE FROM tblWarehouseTransfers WHERE WarehouseTransferID = @WarehouseTransferID";
                            DeleteCmd.Parameters.AddWithValue("@WarehouseTransferID", WarehouseTransferID);
                            Result = (int)DeleteCmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
                        DeleteFromDB = false;
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Saving\n" + ex.Message);
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
