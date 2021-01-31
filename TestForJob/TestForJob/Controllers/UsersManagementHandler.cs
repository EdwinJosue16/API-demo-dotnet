using System;
using TestForJob.Models;
using SqlKata.Execution;

namespace TestForJob.Controllers
{
    public class UsersManagementHandler : DataBaseHandler
    {
        public UsersManagementHandler()
        {
            initializeComponents();
        }

        public int insertUser(UserModel user)
        {
            int affectedRows = factory.Query("Users").Insert(new
                {
                    user.firstName,
                    user.lastName,
                    user.cellPhoneNumber,
                    user.typeOfPromo,
                    user.entryDate
                });

            return affectedRows;
        }

        public int updateUser(UserModel user)
        {
            int affectedRows = factory.Query("Users").Where("id", "=", user.id).Update(new
            {
                firstName = user.firstName,
                lastName = user.lastName,
                cellPhoneNumber = user.cellPhoneNumber,
                typeOfPromo = user.typeOfPromo,
                entryDate = user.entryDate
            });

            return affectedRows;
        }

        public int deleteUser(UserModel user)
        {
            int affectedRows = factory.Query("Users").Where("id", "=", user.id).Delete();
            return affectedRows;
        }

        //This method receive a function (update, delete or insert) and user that will be modify
        public int doDataBaseOperation(Func <UserModel,int> dataBaseOperation, UserModel user)
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
    }
}