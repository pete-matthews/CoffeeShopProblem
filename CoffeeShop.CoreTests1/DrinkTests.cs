using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Tests
{
    [TestClass()]
    public class DrinkTests
    {
        [TestMethod()]
        public void DrinkTest()
        {
            var drink = new Drink("Americano")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5
            };

            
            Assert.AreEqual(50,drink.BaseCost);
            Assert.AreEqual(100, drink.BasePrice);
            Assert.AreEqual(5, drink.LoyaltyPointsGained);
        }
    }
}