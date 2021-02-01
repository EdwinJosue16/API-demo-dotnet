using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestForJob.Models;
using TestForJob.Controllers;

namespace TestForJob.Tests.Controllers
{
    [TestClass]
    public class TestSUHandler
    {
        SystemUserModel SUserToEdit = new SystemUserModel
        {
            email = "example@email.com",
            role = 2,
            password = "Comm",
            firstName = "User",
            lastName = "Herrera",
            entryDate = DateTime.Now,
            cellPhoneNumber = "878988907"
        };

        SystemUserModel SUserToCreate = new SystemUserModel
        {
            email = "example5@email.com",
            role = 2,
            password = "pcconnection",
            firstName = "User",
            lastName = "Example",
            entryDate = DateTime.Now,
            cellPhoneNumber = "878988907"
        };

        //It is necessary to change user id after run test
        SystemUserModel SUserToDelete = new SystemUserModel
        {
            email = "example5@email.com"
        };

        SystemUserModel SUserInvalid = new SystemUserModel
        {
            email = "test@email.com",
            password = "123456FF",
            entryDate = DateTime.Now
        };

        SystemUsersManagementHandler promoManager = new SystemUsersManagementHandler();

        [TestMethod]
        public void updateValidSU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.updateUser, SUserToEdit) > 0);
        }

        [TestMethod]
        public void deleteValidSU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.deleteUser, SUserToDelete) > 0);
        }

        [TestMethod]
        public void updateInvalidSU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.updateUser, SUserInvalid) == 0);
        }

        [TestMethod]
        public void deleteInvalidSU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.deleteUser, SUserInvalid) == 0);
        }

        [TestMethod]
        public void createSU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.insertUser, SUserToCreate) > 0);
        }
    }
}
