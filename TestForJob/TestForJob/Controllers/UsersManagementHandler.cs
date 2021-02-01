using System;
using TestForJob.Models;

namespace TestForJob.Controllers
{
    public abstract class UsersManagementHandler : DataBaseHandler
    {
        //This method receive a function (update, delete or insert) and user that will be modify
        public int doDataBaseOperation(Func<BaseUserModel, int> dataBaseOperation, BaseUserModel user)
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

        public abstract int insertUser(BaseUserModel user);
        public abstract int updateUser(BaseUserModel user);
        public abstract int deleteUser(BaseUserModel user);
    }
}