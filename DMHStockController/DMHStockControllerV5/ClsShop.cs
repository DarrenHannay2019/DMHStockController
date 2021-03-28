using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DMHStockControllerV5
{
    public class ClsShop : ClsUtils
    {
        // properties for the class
        // started 02/01/2020
        // completed 03/01/2020
        public string ShopName;
        public string ShopType;
        // constructor for the class
        public ClsShop()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        // deconstructor for the class
        ~ClsShop()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        // Methods for the class
        public void LoadNewRecord()
        {
            // loading the new form and setting the properties for the new form
            FShop shop = new FShop
            {
                UserID = UserID,
                FormMode = "New"
            };
            shop.ShowDialog();
        }
        public void LoadSelectedShop()
        {
            // loading selected record into the shop form
            FShop shop = new FShop
            {
                FormMode = "Old",
                UserID = UserID,
            };
            shop.TxtShopRef.Text = ShopRef;
            shop.ShowDialog();
        }
        public bool SaveShopRecordToDB()
        {
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
                        InsertCmd.CommandText = "INSERT INTO tblShops (ShopRef, ShopName, Address1, Address2, Address3, Address4, PostCode, Telephone, Fax, eMail, ShopType, Memo, ContactName, CreatedBy, CreatedDate) VALUES (@ShopRef, @ShopName, @Address1, @Address2, @Address3, @Address4, @PostCode, @Telephone, @Fax, @eMail, @ShopType, @Memo, @ContactName, @CreatedBy, @CreatedDate)";
                        InsertCmd.Parameters.AddWithValue("@ShopRef", ShopRef);
                        InsertCmd.Parameters.AddWithValue("@ShopName", ShopName);
                        InsertCmd.Parameters.AddWithValue("@Address1", AddressLine1);
                        InsertCmd.Parameters.AddWithValue("@Address2", AddressLine2);
                        InsertCmd.Parameters.AddWithValue("@Address3", AddressLine3);
                        InsertCmd.Parameters.AddWithValue("@Address4", AddressLine4);
                        InsertCmd.Parameters.AddWithValue("@PostCode", PostCode);
                        InsertCmd.Parameters.AddWithValue("@ContactName", ContactName);
                        InsertCmd.Parameters.AddWithValue("@Telephone", Telephone);
                        InsertCmd.Parameters.AddWithValue("@Fax", Fax);
                        InsertCmd.Parameters.AddWithValue("@eMail", eMail);
                        InsertCmd.Parameters.AddWithValue("@ShopType", ShopType);
                        InsertCmd.Parameters.AddWithValue("@Memo", Memo);
                        InsertCmd.Parameters.AddWithValue("@CreatedBy", UserID);
                        InsertCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        Result = (int)InsertCmd.ExecuteNonQuery();
                    }
                }
                if (Result != 1)
                    SaveToDB = false;
                else
                    SaveToDB = true;
            }
            catch (SqlException ex)
            {
                SaveToDB = false;
                MessageBox.Show("Error in adding to database\n" + ex.Message);
            }
            return SaveToDB;
        }
        public bool UpdateShopRecordInDB()
        {
            UpdateToDB = false;
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
                        UpdateCmd.CommandText = "UPDATE tblShops SET ShopName = @ShopName, Address1 = @Address1, Address2 = @Address2, Address3 = @Address3, Address4 = @Address4, PostCode = @PostCode, ContactName = @ContactName, Telephone = Telephone, Fax = @Fax, eMail = @eMail, Memo = @Memo, ShopType = @ShopType WHERE ShopRef = @ShopRef";
                        UpdateCmd.Parameters.AddWithValue("@ShopRef", ShopRef);
                        UpdateCmd.Parameters.AddWithValue("@ShopName", ShopName);
                        UpdateCmd.Parameters.AddWithValue("@Address1", AddressLine1);
                        UpdateCmd.Parameters.AddWithValue("@Address2", AddressLine2);
                        UpdateCmd.Parameters.AddWithValue("@Address3", AddressLine3);
                        UpdateCmd.Parameters.AddWithValue("@Address4", AddressLine4);
                        UpdateCmd.Parameters.AddWithValue("@PostCode", PostCode);
                        UpdateCmd.Parameters.AddWithValue("@ContactName", ContactName);
                        UpdateCmd.Parameters.AddWithValue("@Telephone", Telephone);
                        UpdateCmd.Parameters.AddWithValue("@Fax", Fax);
                        UpdateCmd.Parameters.AddWithValue("@eMail", eMail);
                        UpdateCmd.Parameters.AddWithValue("@ShopType", ShopType);
                        UpdateCmd.Parameters.AddWithValue("@Memo", Memo);
                        Result = (int)UpdateCmd.ExecuteNonQuery();
                    }
                }
                if (Result != 1)
                    UpdateToDB = false;
                else
                    UpdateToDB = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                UpdateToDB = false;
                throw;
            }
            return UpdateToDB;
        }
        public bool DeleteShopRecordFromDB()
        {
            // Delete the selected Shop Record from the database
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
                        DeleteCmd.CommandText = "DELETE FROM tblShops WHERE ShopRef = @ShopRef";
                        DeleteCmd.Parameters.AddWithValue("@ShopRef", ShopRef);
                        Result = (int)DeleteCmd.ExecuteNonQuery();
                    }
                }
                if (Result != 1)
                    DeleteFromDB = false;
                else
                    DeleteFromDB = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                DeleteFromDB = false;
                throw;
            }
            return DeleteFromDB;
        }
        public string GetShopNameFromDB()
        {
            // Get Shop name from the selected shop reference in all shop functions of the application.
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = GetConnString(1);
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = "SELECT ShopName FROM tblShops WHERE ShopRef = @ShopRef";
                        sqlCommand.Parameters.AddWithValue("@ShopRef", ShopRef);
                        ShopName = (string)sqlCommand.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return ShopName;
        }
        public int TotalShopTransactionRecords()
        {
            // To get the total number of transactions before deleting the shop record from the database
            Result = 0;
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
                        SelectCmd.CommandText = "SELECT * FROM tblStockMovements WHERE LocationRef = @LocationRef";
                        SelectCmd.Parameters.AddWithValue("@LocationRef", ShopRef);
                        Result = (int)SelectCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return Result;
        }
    }
}
