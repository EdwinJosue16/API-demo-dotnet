using System;
using TestForJob.Models;
using SqlKata.Execution;

namespace TestForJob.Controllers
{
    public class PromoUsersManagementHandler : UsersManagementHandler
    {
        private const string ASSOCIATED_TABLE_NAME = "PromoUsers";

        public PromoUsersManagementHandler()
        {
            initializeComponents();
        }

        public override int insertUser(BaseUserModel baseUser)
        {
            PromoUserModel user = (PromoUserModel)baseUser;
            int affectedRows = factory.Query(ASSOCIATED_TABLE_NAME).Insert(new
                {
                    user.firstName,
                    user.lastName,
                    user.cellPhoneNumber,
                    user.typeOfPromo,
                    user.entryDate
                });

            return affectedRows;
        }

        public override int updateUser(BaseUserModel baseUser)
        {
            PromoUserModel user = (PromoUserModel)baseUser;
            int affectedRows = factory.Query(ASSOCIATED_TABLE_NAME).Where("id", "=", user.id).Update(new
            {
                firstName = user.firstName,
                lastName = user.lastName,
                cellPhoneNumber = user.cellPhoneNumber,
                typeOfPromo = user.typeOfPromo,
                entryDate = user.entryDate
            });

            return affectedRows;
        }

        public override int deleteUser(BaseUserModel baseUser)
        {
            PromoUserModel user = (PromoUserModel)baseUser;
            int affectedRows = factory.Query(ASSOCIATED_TABLE_NAME).Where("id", "=", user.id).Delete();
            return affectedRows;
        }
    }
}