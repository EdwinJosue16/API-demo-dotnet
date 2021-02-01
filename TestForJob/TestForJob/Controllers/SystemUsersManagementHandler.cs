using System.Linq;
using TestForJob.Models;
using SqlKata.Execution;

namespace TestForJob.Controllers
{
    public class SystemUsersManagementHandler : DataBaseHandler
    {
        public SystemUsersManagementHandler()
        {
            initializeComponents();
        }

        public SystemUserModel getSystemUser(SystemUserModel externalUser)
        {
            SystemUserModel systemUser = factory.
                                Query("SystemUsers").
                                Select("*").
                                Where("email", "=", externalUser.email).
                                Where("password", "=", Encryptor.GetSHA256(externalUser.password)).
                                FirstOrDefault<SystemUserModel>();
            return systemUser;
        }

        public int changeRoleToUser(SystemUserModel user)
        {
            int affectedRows = factory.Query("SystemUsers").Where("email", "=", user.email).Update(new
            {
                role = user.role
            });

            return affectedRows;
        }

        public bool isValidUser(SystemUserModel systemUser)
        {
            return systemUser != null;
        }
    }
}