using System;
using System.Linq;
using CoffeeShop.Core;

namespace CoffeeShop.Console
{
    public class Program
    {
        private static Core.CoffeeShop _coffeeShop;

        private static void Main()
        {
            var prog = new Program();

            prog.SetupData();
            prog.RunProgram();
        }

        private void RunProgram()
        {
            string command;
            do
            {
                command = System.Console.ReadLine() ?? "";
                ProcessInput(command.ToLower());
            } while (command != "exit");
        }

        private void ProcessInput(string enteredText)
        {
            if (enteredText.Contains("print summary"))
                PrintSummary();
            else if (enteredText.Contains("add general"))
                AddGeneral();
            else if (enteredText.Contains("add loyalty"))
                AddLoyalty(enteredText);
            else if (enteredText.Contains("add student"))
                AddStudent(enteredText);
            else if (enteredText.Contains("add employee"))
                AddEmployee(enteredText);
            else if (enteredText.Contains("exit"))
                Exit();
            else
                UnknownInput();
        }

        private void UnknownInput()
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("UNKNOWN INPUT");
            System.Console.ResetColor();
        }

        private void Exit()
        {
            Environment.Exit(1);
        }

        private bool HasEmployeeHadDrinkLimit(string employee)
        {

         var output =   _coffeeShop.Customers.Count(customer => customer.Title == employee);
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

        public void AddGeneral()
        {
            _coffeeShop.AddCustomer(new Customer
            {
                Type = CustomerType.General
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