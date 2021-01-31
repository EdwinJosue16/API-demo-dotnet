using System.Collections.Generic;
using System.Linq;
using TestForJob.Models;
using SqlKata.Execution;
using System;
using System.Data;
using SpreadsheetLight;

namespace TestForJob.Controllers
{
    public class PromoUsersVisualizationHandler : DataBaseHandler
    {
        private const bool INCLUDE_HEADERS_INTO_EXCEL = true;
        private const int CELL_REFERENCE = 1;
        private const string EXCEL_FILES_NAME = "users_information.xlsx";

        public PromoUsersVisualizationHandler()
        {
            initializeComponents();
        }


        public void exportAllUsersInfoToExcel()
        {
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + EXCEL_FILES_NAME;
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

        private DataTable usersListToDataTable(IEnumerable<PromoUserModel> usersInformation)
        {
            DataTable usersDataTable = new DataTable();

            usersDataTable.Columns.Add("User id", typeof(string));
            usersDataTable.Columns.Add("First name", typeof(string));
            usersDataTable.Columns.Add("Last name", typeof(string));
            usersDataTable.Columns.Add("Cellphone number", typeof(string));
            usersDataTable.Columns.Add("Promo type", typeof(string));
            usersDataTable.Columns.Add("Entry date", typeof(string));

            foreach (PromoUserModel user in usersInformation)
            {
                user.convertToDataRow(usersDataTable);
            }

            return usersDataTable;
        }

        public IEnumerable<PromoUserModel> getAllUsers()
        {
            IEnumerable<PromoUserModel> allUsers = factory.
                                                    Query("PromoUsers").
                                                    Select("*").
                                                    Get<PromoUserModel>();
            return allUsers;
        }

        public IEnumerable<PromoUserModel> getUserByPromo(string typeOfPromo)
        {
            IEnumerable<PromoUserModel> usersByPromo = factory.
                                                    Query("PromoUsers").
                                                    Select("*").
                                                    Where("typeOfPromo","=",typeOfPromo).
                                                    Get<PromoUserModel>();
            return usersByPromo;
        }

        public PromoUserModel getUserByPhoneNumber(string phoneNumber)
        {
            PromoUserModel userByPhoneNumber = factory.
                                            Query("PromoUsers").
                                            Select("*").
                                            Where("cellPhoneNumber", "=", phoneNumber).
                                            FirstOrDefault<PromoUserModel>();
            return userByPhoneNumber;
        }

        public PromoUserModel getUsersBetweenDates(DateTime minDate, DateTime maxDate)
        {
            PromoUserModel usersBetweenDates = factory.
                                            Query("PromoUsers").
                                            Select("*").
                                            Where("entryDate", ">=", minDate).
                                            Where("entryDate", "<=", maxDate).
                                            OrderBy("entryDate").
                                            FirstOrDefault<PromoUserModel>();
            return usersBetweenDates;
        }
    }
}