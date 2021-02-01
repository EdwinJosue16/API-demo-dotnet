using TestForJob.Models;

namespace TestForJob.Controllers
{
    public class RequestProcessor
    {
        private SystemUsersManagementHandler systemUsersManager;
        public string REJECTED_REQUEST = "Access denied";

        public RequestProcessor()
        {
            systemUsersManager = new SystemUsersManagementHandler();
        }

        public bool isPossibleReturnPromoUsersInfo(LoginValuesModel loginValues)
        {
            bool response = false;
            SystemUserModel retrievedUserFromDB = getUserFromDB(loginValues);
            if (systemUsersManager.isValidUser(retrievedUserFromDB))
            {
                response = retrievedUserFromDB.canVisualizePromoUsers();
            }
            return response;
        }

        private SystemUserModel getUserFromDB(LoginValuesModel loginValues)
        {
            SystemUserModel externalUser = buildSystemUserModel(loginValues);
            return systemUsersManager.getSystemUser(externalUser);
        }

        private SystemUserModel buildSystemUserModel(LoginValuesModel loginValues)
        {
            return new SystemUserModel { email = loginValues.email, password = loginValues.password };
        }


    }
}