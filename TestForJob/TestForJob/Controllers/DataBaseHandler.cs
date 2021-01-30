using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TestForJob.Models;

namespace TestForJob.Controllers
{
    public class DataBaseHandler
    {
        private SqlConnection connection;
        private string connectionString;

        public DataBaseHandler()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TestForJobConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        private DataTable getTableFromQueryString(string query)
        {
            SqlCommand queryCommand = new SqlCommand(query, connection);
            SqlDataAdapter tableAdapter = new SqlDataAdapter(queryCommand);
            DataTable tableFromQueryString = new DataTable();
            connection.Open();
            tableAdapter.Fill(tableFromQueryString);
            connection.Close();
            return tableFromQueryString;
        }

        public IEnumerable<UserModel> getAllUsers() {
            DataTable tableFromQueryString = getTableFromQueryString("SELECT * FROM Users");
            List<UserModel> allUsers = new List<UserModel>();

            foreach(DataRow row in tableFromQueryString.Rows)
            {
                allUsers.Add(
                    new UserModel
                    {
                        userId = Convert.ToInt32(row["id"]),
                        firstName = Convert.ToString(row["firstName"]),
                        lastName = Convert.ToString(row["lastName"]),
                        cellPhoneNumber = Convert.ToString(row["cellPhoneNumber"]),
                        typeOfPromo = Convert.ToString(row["typeOfPromo"]),
                        entryDate = Convert.ToDateTime(row["entryDate"])
                    });
            }

            IEnumerable<UserModel> enumUsers = allUsers;
            return enumUsers;
        } 
    }
}