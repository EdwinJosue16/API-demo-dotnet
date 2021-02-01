using System.Linq;
using TestForJob.Models;
using SqlKata.Execution;
using System;

namespace TestForJob.Controllers
{
    public class SystemUsersManagementHandler : UsersManagementHandler
    {
        private const string ASSOCIATED_TABLE_NAME = "SystemUsers";

        public SystemUsersManagementHandler()
        {
            initializeComponents();
        }

        public SystemUserModel getSystemUser(SystemUserModel externalUser)
        {
            SystemUserModel systemUser = factory.
                                Query(ASSOCIATED_TABLE_NAME).
                                Select("*").
                                Where("email", "=", externalUser.email).
                                Where("password", "=", Encryptor.GetSHA256(externalUser.password)).
                                FirstOrDefault<SystemUserModel>();
            return systemUser;
        }

        public override int insertUser(BaseUserModel baseUser)
        {
            SystemUserModel user = (SystemUserModel) baseUser;
            int affectedRows = factory.Query(ASSOCIATED_TABLE_NAME).Insert(new
            {
                user.firstName,
                user.lastName,
                user.cellPhoneNumber,
                user.entryDate,
                user.email,
                password = Encryptor.GetSHA256(user.password),
                user.role
            });

            return affectedRows;
        }

        public override int updateUser(BaseUserModel baseUser)
        {
            SystemUserModel user = (SystemUserModel)baseUser;
            user.password = Encryptor.GetSHA256(user.password);
            int affectedRows = factory.Query(ASSOCIATED_TABLE_NAME).Where("email", "=", user.email).Update(new
            {
                firstName = user.firstName,
                lastName = user.lastName,
                cellPhoneNumber = user.cellPhoneNumber,
                entryDate = user.entryDate,
                password = user.password,
                role = user.role
            });

            return affectedRows;
        }

        public override int deleteUser(BaseUserModel baseUser)
        {
            SystemUserModel user = (SystemUserModel)baseUser;
            int affectedRows = factory.Query(ASSOCIATED_TABLE_NAME).Where("email", "=", user.email).Delete();
            return affectedRows;
        }

        public int changeRoleToUser(SystemUserModel user)
        {
            int affectedRows = factory.Query(ASSOCIATED_TABLE_NAME).Where("email", "=", user.email).Update(new
            {
                role = user.role
            });

            return affectedRows;
        }
    }
}