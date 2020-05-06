using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceTesting
{
    [TestFixture]
    public class TestUserRepository
    {
        IUserRepository userRepository;
        //IUserManager iUserManager;
        [SetUp]
        public void SetUp()
        {
            userRepository = new UserRepository(new BuyerContext());
        }

        [TearDown]
        public void TearDown()
        {
            userRepository = null;
        }
        /// <summary>
        /// Testing register buyer
        /// </summary>
        [Test]
        [TestCase(6785, "krish", "abcdefg@", "krish@gmail.com", "9358778295")]
        [TestCase(9652, "sri", "abcdefg@", "sri@gmail.com", "9462623495")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyer_Successfull(int buyerId, string userName, string password, string email, string mobileNo)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new Buyer { Bid = buyerId, Username = userName, Password = password, Email = email, Mobileno = mobileNo, Datetime = datetime };
                await userRepository.BuyerRegister(buyer);
                var mock = new Mock<IUserRepository>();
                mock.Setup(x => x.BuyerRegister(buyer));
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.NotNull(result);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("chandinik","abcdefg@")]
        [Description("testing buyer login")]
        public async Task BuyerLogin_Successfull(string userName,string password)
        {
            try
            {
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("chandin", "abcdefg@")]
        [Description("Test buyer login failure case")]
        public async Task BuyerLogin_UnSuccessfull(string userName,string password)
        {
            try
            {
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.AreEqual(null, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }

}