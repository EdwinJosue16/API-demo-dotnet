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
            if (isValidUser(retrievedUserFromDB))
            {
                response = retrievedUserFromDB.canVisualizePromoUsers();
            }
            return response;
        }

        public SystemUserModel getUserFromDB(LoginValuesModel loginValues)
        {
            SystemUserModel externalUser = buildSystemUserModel(loginValues);
            return systemUsersManager.getSystemUser(externalUser);
        }

        public SystemUserModel buildSystemUserModel(LoginValuesModel loginValues)
        {
            return new SystemUserModel { email = loginValues.email, password = loginValues.password };
        }

        public bool isValidUser(SystemUserModel systemUser)
        {
            return systemUser != null;
        }

    }
}