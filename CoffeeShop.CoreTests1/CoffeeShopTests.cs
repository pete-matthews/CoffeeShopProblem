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
    public class CoffeeShopTests
    {
        [TestMethod()]
        public void AddCustomerTest()
        {

            var drink = new Drink("Americano")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5
            };

          var  coffeeShop = new Core.CoffeeShop(drink);

      //      coffeeShop.AddCustomer(new Customer());

        }
    }
}