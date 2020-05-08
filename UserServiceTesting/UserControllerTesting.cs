using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UserService.Controllers;
using UserService.Manager;

namespace UserServiceTesting
{
    [TestFixture]
    public class UserControllerTesting
    {
        UserController userController;
        [SetUp]
        public void SetUp()
        {
            userController = new UserController(new UserManager(new UserRepository(new BuyerContext())));
        }
        [Test]
        [TestCase(1452,"milky","abcdefg2","9636737838","milky@gmail.com")]
        public async Task Persons_Add(int buyerId, string userName, string password, string mobileNo, string email)
        {
            DateTime datetime = System.DateTime.Now;
            var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = datetime };
            var mock = new Mock<IUserManager>();
            mock.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(true);
            UserController userController1 = new UserController(mock.Object);
            var result = await userController1.Buyer(buyer);
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }

    }
}
