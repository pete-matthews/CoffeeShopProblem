using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeShop.Console.Tests
{
    [TestClass]
    public class ProgramTests
    {
        private Program prg;

        [TestInitialize]
        public void Initialize()
        {
            prg = new Program();

        }


        [TestMethod]
        public void SetupDataTest()
        {
            try
            {
                prg.SetupData();
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(
                    $"Unexpected exception of type {e.GetType()} caught: {e.Message}"
                );
            }
        }


        [TestMethod]
        public void AddLoyaltyTestIncome()
        {
            prg.AddLoyalty("add loyalty Craig 0 false");
            var income = prg.IncomeFromDrinks();
            Assert.AreEqual(income, 100);
        }

        [TestMethod]
        public void AddLoyaltyTestCost()
        {
            prg.AddLoyalty("add loyalty Craig 0 false");
            var cost = prg.CostOfDrinks();
            Assert.AreEqual(cost, 50);
        }


        [TestMethod]
        public void AddLoyaltyUseLoyaltyTestIncome()
        {
            prg.SetupData();
            prg.AddLoyalty("add loyalty Damian 1000 true");
            var income = prg.IncomeFromDrinks();
            Assert.AreEqual(income, 100);
        }

        [TestMethod]
        public void AddLoyaltyUseLoyaltyTestCost()
        {
            prg.SetupData();
            prg.AddLoyalty("add loyalty Damian 1000 true");
            var cost = prg.CostOfDrinks();
            Assert.AreEqual(cost, 50);
        }


        [TestMethod]
        public void AddGeneralTestIncome()
        {
            prg.SetupData();
            prg.AddGeneral();
            var income = prg.IncomeFromDrinks();
            Assert.AreEqual(income, 100 * prg.CustomerCount());
        }

        [TestMethod]
        public void AddGeneralTestCost()
        {
            prg.SetupData();
            prg.AddGeneral();
            var cost = prg.CostOfDrinks();
            Assert.AreEqual(cost, 50 * prg.CustomerCount());
        }


        [TestMethod]
        public void AddEmployeeTestIncome()
        {
            prg.SetupData();
            prg.AddEmployee("Andrzej");
            var income = prg.IncomeFromDrinks();
            Assert.AreEqual(income, 100 * prg.CustomerCount());
        }

        [TestMethod]
        public void AddEmployeeTestCost()
        {
            prg.SetupData();
            prg.AddEmployee("Andrzej");
            var cost = prg.CostOfDrinks();
            Assert.AreEqual(cost, 50 * prg.CustomerCount());
        }
    }
}