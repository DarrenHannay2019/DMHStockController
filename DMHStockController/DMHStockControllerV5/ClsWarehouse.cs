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
    public class ClsWarehouse : ClsUtils
    {
        // properties of the class
        // started 01/01/2020
        // Completed 02/01/2020 
        public string WarehouseName;
        public string WarehouseType;
        // constructor for the class
        public ClsWarehouse()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        // deconstructor for the class
        ~ClsWarehouse()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
            WarehouseName = "";
            WarehouseType = "";
        }
        // methods for the class
        public void LoadNewRecord()
        {
            // loading the new form and setting the properties of the form
            FWarehouse warehouse = new FWarehouse
            {
                UserID = UserID,
                FormMode = "New"
            };
            warehouse.ShowDialog();
        }
        public void LoadSelectedWarehouse()
        {
            // loading a selected record into the form
            FWarehouse warehouse = new FWarehouse
            {
                FormMode = "Old",
                UserID = UserID
            };
            warehouse.TxtWarehouseRef.Text = WarehouseRef;
            warehouse.ShowDialog();
        }
        public bool SaveWarehouseRecordToDB()
        {
            // Saving the entered data into the database
            SaveToDB = false;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand InsertCmd = new SqlCommand())
                    {
                        InsertCmd.Connection = conn;
                        InsertCmd.CommandType = CommandType.Text;
                        InsertCmd.CommandText = "INSERT INTO tblWarehouses (WarehouseRef, WarehouseName, Address1, Address2, Address3, Address4 ,PostCode, ContactName, Telephone, WebSite, Fax, eMail, WarehouseType, Memo, CreatedBy, CreatedDate) VALUES (@WarehouseRef, @WarehouseName, @Address1, @Address2, @Address3, @Address4 , @PostCode, @ContactName, @Telephone, @WebSite, @Fax, @eMail, @WarehouseType, @Memo, @CreatedBy, @CreatedDate)";
                        InsertCmd.Parameters.AddWithValue("@WarehouseRef", WarehouseRef);
                        InsertCmd.Parameters.AddWithValue("@WarehouseName", WarehouseName);
                        InsertCmd.Parameters.AddWithValue("@Address1", AddressLine1);
                        InsertCmd.Parameters.AddWithValue("@Address2", AddressLine2);
                        InsertCmd.Parameters.AddWithValue("@Address3", AddressLine3);
                        InsertCmd.Parameters.AddWithValue("@Address4", AddressLine4);
                        InsertCmd.Parameters.AddWithValue("@PostCode", PostCode);
                        InsertCmd.Parameters.AddWithValue("@ContactName", ContactName);
                        InsertCmd.Parameters.AddWithValue("@Telephone", Telephone);
                        InsertCmd.Parameters.AddWithValue("@WebSite", WebsiteAddress);
                        InsertCmd.Parameters.AddWithValue("@Fax", Fax);
                        InsertCmd.Parameters.AddWithValue("@eMail", eMail);
                        InsertCmd.Parameters.AddWithValue("@WarehouseType", WarehouseType);
                        InsertCmd.Parameters.AddWithValue("@Memo", Memo);
                        InsertCmd.Parameters.AddWithValue("@CreatedBy", UserID);
                        InsertCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        Result = (int)InsertCmd.ExecuteNonQuery();
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
        public bool UpdateWarehouseRecordInDB()
        {
            // Updating selected warehouse record in the database
            UpdateToDB = true;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand UpdateCmd = new SqlCommand())
                    {
                        UpdateCmd.Connection = conn;
                        UpdateCmd.CommandType = CommandType.Text;
                        UpdateCmd.CommandText = "UPDATE tblWarehouses SET WarehouseName = @WarehouseName, Address1 = @Address1, Address2 = @Address2, Address3 = @Address3, Address4 = @Address4, PostCode = @PostCode, ContactName = @ContactName, Telephone = Telephone, WebSite = @WebSite, Fax = @Fax, eMail = @eMail, Memo = @Memo, WarehouseType = @WarehouseType WHERE WarehouseRef = @WarehouseRef";
                        UpdateCmd.Parameters.AddWithValue("@WarehouseRef", WarehouseRef);
                        UpdateCmd.Parameters.AddWithValue("@WarehouseName", WarehouseName);
                        UpdateCmd.Parameters.AddWithValue("@Address1", AddressLine1);
                        UpdateCmd.Parameters.AddWithValue("@Address2", AddressLine1);
                        UpdateCmd.Parameters.AddWithValue("@Address3", AddressLine1);
                        UpdateCmd.Parameters.AddWithValue("@Address4", AddressLine1);
                        UpdateCmd.Parameters.AddWithValue("@PostCode", PostCode);
                        UpdateCmd.Parameters.AddWithValue("@ContactName", ContactName);
                        UpdateCmd.Parameters.AddWithValue("@Telephone", Telephone);
                        UpdateCmd.Parameters.AddWithValue("@WebSite", WebsiteAddress);
                        UpdateCmd.Parameters.AddWithValue("@Fax", Fax);
                        UpdateCmd.Parameters.AddWithValue("@eMail", eMail);
                        UpdateCmd.Parameters.AddWithValue("@WarehouseType", WarehouseType);
                        UpdateCmd.Parameters.AddWithValue("@Memo", Memo);
                        UpdateCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return UpdateToDB;
        }
        public bool DeleteWarehouseRecordFromDB()
        {
            // delete the warehouse record from the database
            DeleteFromDB = false;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand DeleteCmd = new SqlCommand())
                    {
                        DeleteCmd.Connection = conn;
                        DeleteCmd.CommandType = CommandType.Text;
                        DeleteCmd.CommandText = "DELETE FROM tblWarehouses where WarehouseRef = @WarehouseRef";
                        DeleteCmd.Parameters.AddWithValue("@WarehouseRef", WarehouseRef);
                        Result = (int)DeleteCmd.ExecuteNonQuery();
                    }
                }
                if (Result == 1)
                {
                    DeleteFromDB = true;
                }
                else
                {
                    DeleteFromDB = false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return DeleteFromDB;
        }
        public string GetWarehouseNameFromDB()
        {
            // getting the name of a specific warehouse from the database
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand SelectCmd = new SqlCommand())
                    {
                        SelectCmd.Connection = conn;
                        SelectCmd.CommandType = CommandType.Text;
                        SelectCmd.CommandText = "SELECT WarehouseName FROM tblWarehouses WHERE WarehouseRef = @WarehouseRef";
                        SelectCmd.Parameters.AddWithValue("@WarehouseRef", WarehouseRef);
                        WarehouseName = (string)SelectCmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return WarehouseName;
        }
        public int TotalWarehouseTransactionRecords()
        {
            // to check to see if warehouse can be deleted from the database
            Result = 0; // setting the inital value to be passed back if nothing is returned
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand SelectCmd = new SqlCommand())
                    {
                        SelectCmd.Connection = conn;
                        SelectCmd.CommandText = "SELECT COUNT(*) AS TotalRecords FROM tblStockMovements WHERE LocationRef = @LocationRef";
                        SelectCmd.CommandType = CommandType.Text;
                        SelectCmd.Parameters.AddWithValue("@LocationRef", WarehouseRef);
                        Result = (int)SelectCmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Result = 0;
                throw;
            }
            return Result;
        }
    }
}
