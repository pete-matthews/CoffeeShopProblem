using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeShop.Core.Tests
{
    [TestClass]
    public class CoffeeShopTests
    {
        [TestMethod]
        public void AddCustomerTest()
        {
            try
            {
                var drink = new Drink("Americano")
                {
                    BaseCost = 50,
                    BasePrice = 100,
                    LoyaltyPointsGained = 5
                };

                var coffeeShop = new CoffeeShop(drink);
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(
                    $"Unexpected exception of type {e.GetType()} caught: {e.Message}"
                );
            }
        }
    }
}