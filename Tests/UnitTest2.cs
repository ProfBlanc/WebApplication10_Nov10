using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication10_Nov10.Controllers;
using WebApplication10_Nov10.Data;
using WebApplication10_Nov10.Models;
using System.Collections.Generic;

namespace TestProject3
{
    [TestClass]
    public class UnitTest2
    {

        private ApplicationDbContext _context;
        private MonthsController _controller;
        private ViewResult _result;

        [TestInitialize]
        public void SetUp()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer("Data Source=HP-Craie;Initial Catalog=Prog36944Fall2025;Integrated Security=True;Encrypt=True;Trust Server Certificate=True")

                    .Options;

            _context = new ApplicationDbContext(options);
            _controller = new MonthsController(_context);


        }


        [TestMethod]
        public async Task TestingMonthsControllerIndex()
        {

            //Arrange

            //Act
            _result = await _controller.Index() as ViewResult;


            //Assert
            Assert.IsNotNull(_result);
            IEnumerable<MonthModel> months = _result.Model as IEnumerable<MonthModel>;
            Assert.IsTrue(months.Count() > 5);

        }
        /*
         * 
         *      Test The controllers behaviour for Details, Create, Edit, Delete method calls
         *      
         *      Test one of the views of the Controller: determine if an specific eleemnt
         *      is found in the View file (.cshtml)
         *     
         * 
         */



        [DataTestMethod]
        [DataRow(1)]
        [DataRow(4)]
        public async Task TestControllerDetails(int id)
        {

            _result = await _controller.Details(id) as ViewResult;

            Assert.IsNotNull(_result);

            MonthModel model = _result.Model as MonthModel;

            Assert.IsNotNull(model);
            Assert.AreEqual(id, model.MonthId);
        }



    }
}
