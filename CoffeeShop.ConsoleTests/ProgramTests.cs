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
                prg.InputHandler.SetupData();
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
            prg.InputHandler.SetupData();
            prg.InputHandler.AddLoyalty("add loyalty Craig 0 false");
            var income = prg.InputHandler.IncomeFromDrinks();
            Assert.AreEqual(income, 100);
        }

        [TestMethod]
        public void AddLoyaltyTestCost()
        {
            prg.InputHandler.SetupData();
            prg.InputHandler.AddLoyalty("add loyalty Craig 0 false");
            var cost = prg.InputHandler.CostOfDrinks();
            Assert.AreEqual(cost, 50);
        }


        [TestMethod]
        public void AddLoyaltyUseLoyaltyTestIncome()
        {
            prg.InputHandler.SetupData();
            prg.InputHandler.AddLoyalty("add loyalty Damian 1000 true");
            var income = prg.InputHandler.IncomeFromDrinks();
            Assert.AreEqual(income, 0);
        }

        [TestMethod]
        public void AddLoyaltyUseLoyaltyTestCost()
        {
            prg.InputHandler.SetupData();
            prg.InputHandler.AddLoyalty("add loyalty Damian 1000 true");
            var cost = prg.InputHandler.CostOfDrinks();
            Assert.AreEqual(cost, 50);
        }


        [TestMethod]
        public void AddGeneralTestIncome()
        {
            prg.InputHandler.SetupData();
            prg.InputHandler.AddGeneral("add general Graeme");
            var income = prg.InputHandler.IncomeFromDrinks();
            Assert.AreEqual(income, 100 * prg.InputHandler.CustomerCount());
        }

        [TestMethod]
        public void AddGeneralTestCost()
        {
            prg.InputHandler.SetupData();
            prg.InputHandler.AddGeneral("add general Graeme");
            var cost = prg.InputHandler.CostOfDrinks();
            Assert.AreEqual(cost, 50 * prg.InputHandler.CustomerCount());
        }


        [TestMethod]
        public void AddEmployeeTestIncome()
        {
            prg.InputHandler.SetupData();
            prg.InputHandler.AddEmployee("Andrzej");
            var income = prg.InputHandler.IncomeFromDrinks();
            Assert.AreEqual(income, 100 * prg.InputHandler.CustomerCount());
        }

        [TestMethod]
        public void AddEmployeeTestCost()
        {
            prg.InputHandler.SetupData();
            prg.InputHandler.AddEmployee("Andrzej");
            var cost = prg.InputHandler.CostOfDrinks();
            Assert.AreEqual(cost, 50 * prg.InputHandler.CustomerCount());
        }

        [TestMethod]
        public void TestProgramOutput()
        {
            prg.InputHandler.SetupData();

            prg.InputHandler.AddGeneral("add general Graeme");
            prg.InputHandler.AddGeneral("add loyalty Damian 1000 true");
            prg.InputHandler.AddLoyalty("add loyalty Craig 0 false");
            prg.InputHandler.AddLoyalty("add loyalty Kirsty 60 false");
            prg.InputHandler.AddEmployee("add employee Andrzej");
            prg.InputHandler.AddGeneral("add general Matt");
            prg.InputHandler.AddGeneral("add general Colin");

            var cost = prg.InputHandler.CostOfDrinks();
            Assert.AreEqual(cost, 350);
        }
    }
}