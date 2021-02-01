using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestForJob.Models;
using TestForJob.Controllers;

namespace TestForJob.Tests.Controllers
{
    [TestClass]
    public class TestPUHandler
    {
        PromoUserModel PUserToEdit = new PromoUserModel
        {
            id = 7,
            firstName = "Jose",
            lastName = "Herrera",
            typeOfPromo = "type-3",
            entryDate = DateTime.Now,
            cellPhoneNumber = "878988907"
        };

        PromoUserModel PUserToCreate = new PromoUserModel
        {
            firstName = "New",
            lastName = "Test",
            typeOfPromo = "type-Test",
            entryDate = DateTime.Now,
            cellPhoneNumber = "test-test"
        };

        //It is necessary to change user id after run test
        PromoUserModel PUserToDelete = new PromoUserModel
        {
            id = 27
        };
       
        PromoUserModel PUserInvalid = new PromoUserModel
        {
            id = -12222,
            entryDate = DateTime.Now
        };

        PromoUsersManagementHandler promoManager = new PromoUsersManagementHandler();

        [TestMethod]
        public void updateValidPU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.updateUser, PUserToEdit) > 0);
        }

        [TestMethod]
        public void deleteValidPU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.deleteUser, PUserToDelete) >0);
        }

        [TestMethod]
        public void updateInvalidPU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.updateUser, PUserInvalid) ==0);
        }

        [TestMethod]
        public void deleteInvalidPU()
        {
            Assert.IsTrue(promoManager.doDataBaseOperation(promoManager.deleteUser, PUserInvalid) == 0);
        }

        [TestMethod]
        public void createPU()
        {
            Assert.IsTrue( promoManager.doDataBaseOperation(promoManager.insertUser, PUserToCreate)>0);
        }

        [TestMethod]
        public void findValidPU()
        {
            Assert.IsNotNull(promoManager.findUserById(1));
        }

        [TestMethod]
        public void findInvalidPU()
        {
            Assert.IsNull(promoManager.findUserById(-1));
        }
    }
}
