using Moq;
using System;
using WebApplication10_Nov10.Controllers;
using WebApplication10_Nov10.Repository;
using WebApplication10_Nov10.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestProject3
{

    [TestClass]
    public class UnitTest3
    {

        private PurchaseController _controller;
        private Mock<IPurchaseRepository> _mockRepo;


        [TestInitialize]
        public void SetUp()
        {
            _mockRepo = new Mock<IPurchaseRepository>();
            _controller = new PurchaseController( _mockRepo.Object );


            List<Purchase> data = new List<Purchase>
                {
new Purchase{PurchaseId = 1, Name= "Food", Description = "Tasty Food", Price=9.99},
new Purchase{PurchaseId = 2, Name= "Drink", Description = "Refreshing Drink", Price=4.99},
new Purchase{PurchaseId = 3, Name= "Clothes", Description = "Stylish Clothes", Price=29.99},
new Purchase{PurchaseId = 4, Name= "Hat", Description = "Warm Hat", Price=19.99},
new Purchase{PurchaseId = 5, Name= "Shoes", Description = "Cool Shoes", Price=39.99},

                };

            _mockRepo
                .Setup(
                r=> r.GetAll()
                )
                .Returns(
                data 
                );


            _mockRepo.Setup(r => r.Add(It.IsAny<Purchase>()))
     .Callback<Purchase>(p => data.Add(p));

        }

        [TestMethod]
        public void TestGetAllPurchases()
        {

            ViewResult result = _controller.Index() as ViewResult;

            List<Purchase> model = result.Model as List<Purchase>;

            Assert.AreEqual(5, model.Count);
            Assert.AreEqual(1, model[0].PurchaseId);
        
        
        }

        [TestMethod]
        public void TestCreatePurchase()
        {

            Purchase item = new Purchase { PurchaseId = 6, Name = "Socks", Description = "Fuzzy Socks", Price = 7.99 };
            var result = _controller.Create(item) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);

            var result1 = _controller.Index() as ViewResult;
            List<Purchase> model = result1.Model as List<Purchase>;

            Assert.AreEqual(6, model.Count);
            Assert.AreEqual(item.PurchaseId, model[model.Count - 1].PurchaseId);
            

        }

    }
}
