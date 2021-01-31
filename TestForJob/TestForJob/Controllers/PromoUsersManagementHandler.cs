using System;
using TestForJob.Models;
using SqlKata.Execution;

namespace TestForJob.Controllers
{
    public class PromoUsersManagementHandler : DataBaseHandler
    {
        public PromoUsersManagementHandler()
        {
            initializeComponents();
        }

        //This method receive a function (update, delete or insert) and user that will be modify
        public int doDataBaseOperation(Func<PromoUserModel, int> dataBaseOperation, PromoUserModel user)
        {
            int affectedRows = 0;
            try
            {
                affectedRows = dataBaseOperation(user);
            }
            catch (Exception error)
            {
                throw error;
            }
            return affectedRows;
        }

        public int insertUser(PromoUserModel user)
        {
            int affectedRows = factory.Query("PromoUsers").Insert(new
                {
                    user.firstName,
                    user.lastName,
                    user.cellPhoneNumber,
                    user.typeOfPromo,
                    user.entryDate
                });

            return affectedRows;
        }

        public int updateUser(PromoUserModel user)
        {
            int affectedRows = factory.Query("PromoUsers").Where("id", "=", user.id).Update(new
            {
                firstName = user.firstName,
                lastName = user.lastName,
                cellPhoneNumber = user.cellPhoneNumber,
                typeOfPromo = user.typeOfPromo,
                entryDate = user.entryDate
            });

            return affectedRows;
        }

        public int deleteUser(PromoUserModel user)
        {
            int affectedRows = factory.Query("PromoUsers").Where("id", "=", user.id).Delete();
            return affectedRows;
        }
    }
}