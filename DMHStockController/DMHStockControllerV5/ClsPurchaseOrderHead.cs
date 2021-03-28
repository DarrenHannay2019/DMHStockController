using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public class ClsPurchaseOrderHead : ClsPurchaseOrder
    {
        public int TotalGarments;
        public int TotalHangers;
        public int TotalBoxes;
        public decimal NetAmount;
        public decimal DeliveryCharge;
        public decimal Commission;
        public string SeasonName;
        public decimal TotalAmount;
        public string Shipper;
        public string ShipperInvoice;
        public string SupplierInvoice;
        public string OurRef;
        public ClsPurchaseOrderHead()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        ~ClsPurchaseOrderHead()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        public bool SaveToPurchaseOrderHeadToDB()
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
                        sqlCommand.CommandText = "INSERT INTO tblPurchaseOrders (OurRef, SupplierRef, LocationRef, TotalGarments, TotalBoxes, TotalHangers, NetAmount, DeliveryCharge, Commission, VATAmount, TotalAmount, DeliveryDate, DeliveryType, SeasonName, Notes, InvoiceNumber, ShipperName, ShipperInvoice, CreatedBy, CreatedDate) VALUES (@OurRef, @SupplierRef, @LocationRef, @TotalGarments, @TotalBoxes, @TotalHangers, @NetAmount, @DeliveryCharge, @Commission, @VATAmount, @TotalAmount, @DeliveryDate, @DeliveryType, @SeasonName, @Notes, @InvoiceNumber, @ShipperName, @ShipperInvoice, @CreatedBy, @CreatedDate)";
                        sqlCommand.Parameters.AddWithValue("@OurRef", OurRef);
                        sqlCommand.Parameters.AddWithValue("@SupplierRef", SupplierRef);
                        sqlCommand.Parameters.AddWithValue("@LocationRef", WarehouseRef);
                        sqlCommand.Parameters.AddWithValue("@TotalGarments", TotalGarments);
                        sqlCommand.Parameters.AddWithValue("@TotalBoxes", TotalBoxes);
                        sqlCommand.Parameters.AddWithValue("@TotalHangers", TotalHangers);
                        sqlCommand.Parameters.AddWithValue("@NetAmount", NetAmount);
                        sqlCommand.Parameters.AddWithValue("@Commission", Commission);
                        sqlCommand.Parameters.AddWithValue("@DeliveryCharge", DeliveryCharge);
                        sqlCommand.Parameters.AddWithValue("@VATAmount", VATAmount);
                        sqlCommand.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        sqlCommand.Parameters.AddWithValue("@DeliveryDate", MovementDate);
                        sqlCommand.Parameters.AddWithValue("@DeliveryType", DeliveryType);
                        sqlCommand.Parameters.AddWithValue("@SeasonName", SeasonName);
                        sqlCommand.Parameters.AddWithValue("@Notes", Memo);
                        sqlCommand.Parameters.AddWithValue("@InvoiceNumber", SupplierInvoice);
                        sqlCommand.Parameters.AddWithValue("@ShipperName", Shipper);
                        sqlCommand.Parameters.AddWithValue("@ShipperInvoice", ShipperInvoice);
                        sqlCommand.Parameters.AddWithValue("@CreatedBy", UserID);
                        sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
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
        public bool UpdateToPurchaseOrderHeadInDB()
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
                        sqlCommand.CommandText = "UPDATE tblPurchaseOrders SET OurRef = @OurRef, SupplierRef = @SupplierRef, LocationRef = @LocationRef, TotalItems = @TotalItems, TotalBoxes = @TotalBoxes, TotalLoose = @TotalLoose, NetAmount = @NetAmount, DeliveryCharge = @DeliveryCharge, Commission = @Commission, VATAmount = @VATAmount, TotalAmount = @TotalAmount, DeliveryDate = @DeliveryDate, SeasonName = @SeasonName, Notes = @Notes, InvoiceNumber = @InvoiceNumber, ShipperName = @ShipperName, ShipperInvoice = @ShipperInvoice WHERE PurchaseOrderID = @PurchaseOrderID";
                        sqlCommand.Parameters.AddWithValue("@OurRef", OurRef);
                        sqlCommand.Parameters.AddWithValue("@SupplierRef", SupplierRef);
                        sqlCommand.Parameters.AddWithValue("@LocationRef", WarehouseRef);
                        sqlCommand.Parameters.AddWithValue("@TotalItems", TotalGarments);
                        sqlCommand.Parameters.AddWithValue("@TotalBoxes", TotalBoxes);
                        sqlCommand.Parameters.AddWithValue("@TotalLoose", TotalHangers);
                        sqlCommand.Parameters.AddWithValue("@NetAmount", NetAmount);
                        sqlCommand.Parameters.AddWithValue("@Commission", Commission);
                        sqlCommand.Parameters.AddWithValue("@DeliveryCharge", DeliveryCharge);
                        sqlCommand.Parameters.AddWithValue("@VATAmount", VATAmount);
                        sqlCommand.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        sqlCommand.Parameters.AddWithValue("@DeliveryDate", MovementDate);
                        sqlCommand.Parameters.AddWithValue("@SeasonName", SeasonName);
                        sqlCommand.Parameters.AddWithValue("@Notes", Memo);
                        sqlCommand.Parameters.AddWithValue("@InvoiceNumber", SupplierInvoice);
                        sqlCommand.Parameters.AddWithValue("@ShipperName", Shipper);
                        sqlCommand.Parameters.AddWithValue("@ShipperInvoice", ShipperInvoice);
                        sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
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
        public bool DeletePurchaseOrderHeadFromDB()
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
        public int GetLastPurchaseOrderHead()
        {
            Result = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = GetConnString(1);
                conn.Open();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT COUNT(*) AS MaxRef FROM tblPurchaseOrders";
                    Result = (int)SelectCmd.ExecuteScalar();
                }
            }
            return Result;
        }
    }
}
