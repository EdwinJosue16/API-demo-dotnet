using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; // Sql Server Connection Namespace
using TestForJob.Models;
using SqlKata;
using SqlKata.Execution;
using SqlKata.Compilers;

namespace TestForJob.Controllers
{
    public class DataBaseHandler
    {
        //These are some elements for using SQL connection in lower level
        private SqlConnection connection;
        private SqlServerCompiler compiler;
        private QueryFactory dataBase;

        private const string CONNECTION_NAME = "TestForJobConnection";
        private string connectionString;

        public DataBaseHandler()
        {
            connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ToString();
            connection = new SqlConnection(connectionString);
            compiler = new SqlServerCompiler();
            dataBase = new QueryFactory(connection, compiler);
        }

        public IEnumerable<UserModel> getUsersBuilder()
        {
            IEnumerable<UserModel> allUsers = dataBase.Query("Users").Select("*").Get<UserModel>();
            return allUsers;
        }

        public int insertNewUser(UserModel user)
        {
            int affectedRows = 0;
            try
            {
               affectedRows  = dataBase.Query("Users").Insert(new
                               {
                                    user.id,
                                    user.firstName,
                                    user.lastName,
                                    user.cellPhoneNumber,
                                    user.typeOfPromo,
                                    user.entryDate
                               });
            }
            catch (Exception error)
            {
                throw error;
            }
            return affectedRows;
        }

        public IEnumerable<UserModel> getAllUsers()
        {
            DataTable tableFromQueryString = getTableFromQueryString("SELECT * FROM Users");
            List<UserModel> allUsers = parseDataTableToList(tableFromQueryString);
            return allUsers;
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

        public List<UserModel> parseDataTableToList(DataTable tableFromQueryString)
        {
            List<UserModel> resultingList = new List<UserModel>();
            foreach (DataRow row in tableFromQueryString.Rows)
            {
                resultingList.Add(
                    new UserModel
                    {
                        id = Convert.ToInt32(row["id"]),
                        firstName = Convert.ToString(row["firstName"]),
                        lastName = Convert.ToString(row["lastName"]),
                        cellPhoneNumber = Convert.ToString(row["cellPhoneNumber"]),
                        typeOfPromo = Convert.ToString(row["typeOfPromo"]),
                        entryDate = Convert.ToDateTime(row["entryDate"])
                    });
            }
            return resultingList;
        }
    }
}