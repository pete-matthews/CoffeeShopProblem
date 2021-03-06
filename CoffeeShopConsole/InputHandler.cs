using System;
using System.Linq;
using CoffeeShop.Core;

namespace CoffeeShop.Console
{
    public class InputHandler
    {
        private Core.CoffeeShop _coffeeShop;

        private bool HasEmployeeHadDrinkLimit(string employee)
        {
            var output = _coffeeShop.Customers.Count(customer => customer.Title == employee);
            return output >= 2;
        }

        public void AddEmployee(string enteredText)
        {
            var segments = enteredText.Split(' ');
            if (segments.Length < 2)
            {
                System.Console.WriteLine("One or more fields missing");
                return;
            }


            if (HasEmployeeHadDrinkLimit(segments[2]))
            {
                System.Console.WriteLine("Employee drink limit exceeded");
                return;
            }

            _coffeeShop.AddCustomer(new Customer
            {
                Type = CustomerType.CoffeeEmployee,
                Title = segments[2]
            });

            System.Console.WriteLine("Entry added... ");
        }

        public void AddLoyalty(string enteredText)
        {
            var segments = enteredText.Split(' ');
            _coffeeShop.AddCustomer(new Customer
            {
                Type = CustomerType.LoyaltyMember,
                Title = segments[2],
                LoyaltyPoints = Convert.ToInt32(segments[3]),
                IsUsingLoyaltyPoints = Convert.ToBoolean(segments[4])
            });

            System.Console.WriteLine("Entry added... ");
        }

        public void AddStudent(string enteredText)
        {
            var segments = enteredText.Split(' ');
            _coffeeShop.AddCustomer(new Customer
            {
                Type = CustomerType.Student,
                LoyaltyPoints = 0,
                Title = segments[2],
                IsUsingLoyaltyPoints = false,
                DiscountPercentage = 75
            });

            System.Console.WriteLine("Entry added... ");
        }

        public void AddGeneral(string enteredText)
        {
            var segments = enteredText.Split(' ');
            _coffeeShop.AddCustomer(new Customer
            {
                Type = CustomerType.General,
                Title = segments[2]
            });
            System.Console.WriteLine("Entry added... ");
        }

        public void PrintSummary()
        {
            System.Console.WriteLine();
            System.Console.WriteLine(_coffeeShop.GetSummary());
        }

        public void SetupData()
        {
            var drink = new Drink("Americano")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5,
                DiscountPrice = 75
            };

            _coffeeShop = new Core.CoffeeShop(drink);
        }

        public double IncomeFromDrinks()
        {
            return _coffeeShop.IncomeFromDrinks();
        }

        public double CostOfDrinks()
        {
            return _coffeeShop.CostOfDrinks();
        }

        public double CustomerCount()
        {
            return _coffeeShop.TotalCustomers();
        }
    }
}