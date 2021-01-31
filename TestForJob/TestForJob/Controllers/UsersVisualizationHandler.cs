using System.Collections.Generic;
using System.Linq;
using TestForJob.Models;
using SqlKata.Execution;
using System;
using System.Data;
using SpreadsheetLight;

namespace TestForJob.Controllers
{
    public class UsersVisualizationHandler : DataBaseHandler
    {
        private const bool INCLUDE_HEADERS_INTO_EXCEL = true;
        private const int CELL_REFERENCE = 1;

        public UsersVisualizationHandler()
        {
            initializeComponents();
        }


        public void exportAllUsersInfoToExcel()
        {
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "users_information.xlsx";
            SLDocument excelDocument = new SLDocument();
            DataTable usersTable = usersListToDataTable( getAllUsers() );
            excelDocument.ImportDataTable(
                CELL_REFERENCE, 
                CELL_REFERENCE, 
                usersTable, 
                INCLUDE_HEADERS_INTO_EXCEL
            );
            excelDocument.SaveAs(pathFile);
        }

        private DataTable usersListToDataTable(IEnumerable<UserModel> usersInformation)
        {
            DataTable usersDataTable = new DataTable();

            usersDataTable.Columns.Add("User id", typeof(string));
            usersDataTable.Columns.Add("First name", typeof(string));
            usersDataTable.Columns.Add("Last name", typeof(string));
            usersDataTable.Columns.Add("Cellphone number", typeof(string));
            usersDataTable.Columns.Add("Promo type", typeof(string));
            usersDataTable.Columns.Add("Entry date", typeof(string));

            foreach (UserModel user in usersInformation)
            {
                user.convertToDataRow(usersDataTable);
            }

            return usersDataTable;
        }

        public IEnumerable<UserModel> getAllUsers()
        {
            IEnumerable<UserModel> allUsers = factory.Query("Users").Select("*").Get<UserModel>();
            return allUsers;
        }

        public IEnumerable<UserModel> getUserByPromo(string typeOfPromo)
        {
            IEnumerable<UserModel> usersByPromo = factory.
                                                    Query("Users").
                                                    Select("*").
                                                    Where("typeOfPromo","=",typeOfPromo).
                                                    Get<UserModel>();
            return usersByPromo;
        }

        public UserModel getUserByPhoneNumber(string phoneNumber)
        {
            UserModel userByPhoneNumber = factory.
                                            Query("Users").
                                            Select("*").
                                            Where("cellPhoneNumber", "=", phoneNumber).
                                            FirstOrDefault<UserModel>();
            return userByPhoneNumber;
        }

        public UserModel getUsersBetweenDates(DateTime minDate, DateTime maxDate)
        {
            UserModel usersBetweenDates = factory.
                                            Query("Users").
                                            Select("*").
                                            Where("entryDate", ">=", minDate).
                                            Where("entryDate", "<=", maxDate).
                                            OrderBy("entryDate").
                                            FirstOrDefault<UserModel>();
            return usersBetweenDates;
        }
    }
}