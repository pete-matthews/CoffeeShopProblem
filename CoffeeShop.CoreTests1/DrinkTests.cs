using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeShop.Core.Tests
{
    [TestClass]
    public class DrinkTests
    {
        [TestMethod]
        public void DrinkTest()
        {
            var drink = new Drink("Americano")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5
            };


            Assert.AreEqual(50, drink.BaseCost);
            Assert.AreEqual(100, drink.BasePrice);
            Assert.AreEqual(5, drink.LoyaltyPointsGained);
        }
    }
}