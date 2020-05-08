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
        [TestCase(7373, "chinnu", "abcdefg2","9365778295","chinnu@gmail.com")]
        [TestCase(6464, "cute", "abcdefg2", "9462753495", "cute@gmail.com")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyer_Successfull(int buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId=email,dateTime = datetime };
                var mock = new Mock<IUserRepository>();
                mock.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(true);
                await userRepository.BuyerRegister(buyer);
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
                Assert.IsNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }

}