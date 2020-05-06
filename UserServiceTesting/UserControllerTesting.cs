using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UserService.Controllers;

namespace UserServiceTesting
{
    [TestFixture]
    public class UserControllerTesting
    {
        UserController userController;
        [SetUp]
        //public void SetUp()
        //{
        //    userController = new UserController();
        //}
        [Test]
        [TestCase(6785, "krish", "abcdefg@", "krish@gmail.com", "9358778295")]
        [TestCase(9652, "sri", "abcdefg@", "sri@gmail.com", "9462623495")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyerController_Successfull(int buyerId, string userName, string password, string email, string mobileNo)
        {
                DateTime datetime = System.DateTime.Now;
                Buyer buyer = new Buyer { Bid = buyerId, Username = userName, Password = password, Email = email, Mobileno = mobileNo, Datetime = datetime };
                await userController.Buyer(buyer);
                var mock = new Mock<UserController>();
                mock.Setup(x => x.Buyer(buyer));
                var login = new Login { userName = userName, userPassword = password };
                Task<IActionResult> result1 =  userController.BuyerLogin(login);
               // var okResult = result as ObjectResult;
                Assert.NotNull(result1);
        }

    }
}
