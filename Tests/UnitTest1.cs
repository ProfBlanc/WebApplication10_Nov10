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
    public class UnitTest1
    {

        private ApplicationDbContext _context;

        [TestInitialize]
        public void SetUp() {
        
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Data Source=HP-Craie;Initial Catalog=Prog36944Fall2025;Integrated Security=True;Encrypt=True;Trust Server Certificate=True")
                
                .Options;

            _context = new ApplicationDbContext(options);



        }

        [TestMethod]
        public void TestCreateNewMonth() {

            //_context.Temperatures

            //using the _context, add a new db entry and assert/confirm that
            // the entry has been saved

            MonthModel month = new MonthModel() {MonthName="January"};

            int count = _context.Months.Count();

            _context.Add(month);
            _context.SaveChanges();

            Assert.AreEqual(count + 1, _context.Months.Count());
            Assert.AreEqual(month.MonthId, 
                _context.Months.OrderBy(m => m.MonthId).Last().MonthId);

            Assert.AreEqual(month.MonthName, 
                _context.Months.OrderBy(m => m.MonthId).Last().MonthName);
        }

        

        [TestMethod]
        public void TestEditLastMonthEntry() {
            string updatedMonthName = "February";
            MonthModel lastEntry;

            lastEntry = _context.Months.OrderBy(m => m.MonthId).Last();
            lastEntry.MonthName = updatedMonthName;
            _context.SaveChanges();
            //reload last item from the database
            lastEntry = _context.Months.OrderBy(m => m.MonthId).Last();
            Assert.AreEqual(updatedMonthName, lastEntry.MonthName);

        }

        [TestMethod]
        public void TestViewMonth() {

            MonthModel current = _context.Months.Find(1);
            string expectedMonthName = "January";
            Assert.AreEqual(expectedMonthName, current.MonthName);
        }

        [TestMethod]
        public void TestDeleteMonth() {

            int targetId = _context.Months.OrderBy(m=> m.MonthId).Last().MonthId;
            MonthModel current = _context.Months.Find(targetId);
           
            _context.Months.Remove(current);
            _context.SaveChanges();

            Assert.IsNull(_context.Months.Find(targetId));
        }

        

    }
}
