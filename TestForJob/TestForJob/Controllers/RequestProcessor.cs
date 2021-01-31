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

        public bool requestCanBeProcessed(LoginValuesModel loginValues)
        {
            bool response = false;
            SystemUserModel externalUser = buildSystemUserModel(loginValues);
            SystemUserModel retrievedUserFromDB = systemUsersManager.getSystemUser(externalUser);
            if (systemUsersManager.isValidUser(retrievedUserFromDB))
            {
                response = retrievedUserFromDB.canVisualizePromoUsers();
            }
            return response;
        }

        private SystemUserModel buildSystemUserModel(LoginValuesModel loginValues)
        {
            return new SystemUserModel { email = loginValues.email, password = loginValues.password };
        }
    }
}