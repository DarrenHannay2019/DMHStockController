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
    public class ClsEmployee : ClsUtils
    {
        // constructor for the class
        public ClsEmployee()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        // de-constructor for the class
        ~ClsEmployee()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        // properties for the class
        public string PasswordEntered { get; set; }
        private string PasswordHashed;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginCode { get; set; }
        public int ProfileID { get; set; }
        // methods for the class
        public static string HashingSHA1(string ValueToHash)
        {
            // Create The Highest Hash Value
            var sha1 = System.Security.Cryptography.SHA512.Create();
            // Encode the string passed in to a hash (7-bit)
            var inputValueToHash = Encoding.ASCII.GetBytes(ValueToHash);
            // Create the hash based on the encoded value
            var hashing = sha1.ComputeHash(inputValueToHash);
            // destroy the cryptography when not needed
            sha1.Dispose();
            // create a new string
            var stringbuilder = new StringBuilder();
            for (var a = 0; a < hashing.Length; a++)
            {
                // add the computed hash to a string value
                stringbuilder.Append(hashing[a].ToString("X2"));
            }
            return stringbuilder.ToString(); // return back to the calling function
        }
        public int GetAllUserTotal()
        {
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
                        SelectCmd.CommandText = "SELECT COUNT(*) AS TotalRecords from tblEmployees";
                        SelectCmd.CommandType = CommandType.Text;
                        Result = (int)SelectCmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                return ex.Number;
                throw;
            }
            return Result;
        }
        public int GetLoginUserID(string LoginName, string Password)
        {
            UserID = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = GetConnString(1);
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.CommandText = "SELECT EmployeeID,Password,UserGuid from tblEmployees WHERE LoginCode = @LoginCode";
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.Parameters.AddWithValue("@LoginCode", LoginName);
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        while (dataReader.Read())
                        {
                            int dbUserId = Convert.ToInt32(dataReader["EmployeeID"]);
                            string dbPassword = Convert.ToString(dataReader["Password"]);
                            string dbUserGuid = Convert.ToString(dataReader["UserGuid"]);
                            string PasswordHash = HashingSHA1(Password + dbUserGuid);
                            if (dbPassword == PasswordHash)
                            {
                                UserID = dbUserId;
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username and Password \nPlease try again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                UserID = 0;
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return UserID;
        }
        public bool SaveToEmployeeTable()
        {
            SaveToDB = false;
            Guid usergiud = System.Guid.NewGuid();
            PasswordHashed = HashingSHA1(PasswordEntered + usergiud.ToString());
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand InsertCmd = new SqlCommand())
                    {
                        InsertCmd.Connection = conn;
                        InsertCmd.CommandText = "INSERT INTO tblEmployees (FirstName, LastName, LoginCode, Password, ProfileID, UserGuid) VALUES (@FirstName, @LastName, @LoginCode, @Password, @ProfileID, @UserGuid)";
                        InsertCmd.Parameters.AddWithValue("@FirstName", FirstName);
                        InsertCmd.Parameters.AddWithValue("@LastName", LastName);
                        InsertCmd.Parameters.AddWithValue("@LoginCode", LoginCode);
                        InsertCmd.Parameters.AddWithValue("@Password", PasswordHashed);
                        InsertCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                        InsertCmd.Parameters.AddWithValue("@UserGuid", usergiud);
                        Result = (int)InsertCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                SaveToDB = false;
                return SaveToDB;
                throw;
            }
            if (Result == 1)
                SaveToDB = true;
            else
                SaveToDB = false;
            return SaveToDB;
        }
        public bool UpdateToEmployeeTable()
        {
            PasswordHashed = HashingSHA1(PasswordEntered);
            UpdateToDB = false;
            try
            {

            }
            catch (SqlException ex)
            {
                UpdateToDB = false;
                MessageBox.Show(ex.Message);
                return UpdateToDB;
                throw;
            }
            return UpdateToDB;
        }
        public bool DeleteEmployee()
        {
            try
            {

            }
            catch (SqlException ex)
            {
                DeleteFromDB = false;
                MessageBox.Show(ex.Message);
                throw;
            }
            return DeleteFromDB;
        }
    }
}
