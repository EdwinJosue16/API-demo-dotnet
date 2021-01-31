
using System.Collections.Generic;
using System.Linq;
using TestForJob.Models;
using SqlKata.Execution;
using System;
using System.Data;

namespace TestForJob.Controllers
{
    public class UsersValidationHandler : DataBaseHandler
    {
        public UsersValidationHandler()
        {
            initializeComponents();
        }

        public SystemUserModel getSystemUser(SystemUserModel externalUser)
        {
            SystemUserModel systemUser = factory.
                                Query("SystemUsers").
                                Select("*").
                                Where("email", "=", externalUser.email).
                                Where("password", "=", externalUser.password).
                                FirstOrDefault<SystemUserModel>();
            return systemUser;
        }

        public bool isValidUser(SystemUserModel systemUser)
        {
            return systemUser != null;
        }
    }
}