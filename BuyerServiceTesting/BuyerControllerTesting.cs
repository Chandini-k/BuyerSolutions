using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Repositories;
using BuyerService.Controllers;
using BuyerService.Manager;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyerServiceTesting
{
    [TestFixture]
    public class BuyerControllerTesting
    {
        BuyerController buyerController;
        [SetUp]
        public void SetUp()
        {
            buyerController = new BuyerController(new BuyerManager(new BuyerRepository(new BuyerContext())));
        }

        [TearDown]
        public void TearDown()
        {
            buyerController = null;
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [TestCase(4526)]
        [TestCase(3252)]
        [Description("testing buyer Profile")]
        public async Task BuyerProfile_Successfull(int buyerId)
        {
            try
            {
                var result = await buyerController.GetBuyerProfile(buyerId);
                var mock = new Mock<BuyerController>();
                mock.Setup(x => x.GetBuyerProfile(buyerId));
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [TestCase(458)]
        [TestCase(322)]
        [Description("testing buyer Profile failure")]
        public async Task BuyerProfile_UnSuccessfull(int buyerId)
        {
            try
            {
                var result = await buyerController.GetBuyerProfile(buyerId);
                var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.GetBuyerProfile(buyerId));
                Assert.IsNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [Description("testing buyer edit Profile")]
        public async Task EditBuyerProfile_Successfull()
        {
            try
            {
                var actionResult= await buyerController.GetBuyerProfile(4526);
                Buyer buyer = new Buyer();
                buyer.Email = "sumabade23@gmail.com";
                await buyerController.EditBuyerProfile(buyer);
                var actionResult1= buyerController.GetBuyerProfile(4526);
                var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.GetBuyerProfile(4526));
                Assert.AreSame(actionResult, actionResult1);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [Description("testing buyer edit Profile")]
        public async Task EditBuyerProfile_UnSuccessfull()
        {
            try
            {
                Buyer buyer = await buyerRepository.GetBuyerProfile(4526);
                buyer.Email = "sumab@gmail.com";
                await buyerRepository.EditBuyerProfile(buyer);
                Buyer buyer1 = await buyerRepository.GetBuyerProfile(3252);
                var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.GetBuyerProfile(4526));
                Assert.AreNotSame(buyer, buyer1);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
    }
}
