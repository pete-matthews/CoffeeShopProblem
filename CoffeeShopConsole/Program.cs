using System;
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
            else if (enteredText.Contains("add employee"))
                AddEmployee();
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

        public void AddEmployee()
        {
            _coffeeShop.AddCustomer(new Customer
            {
                Type = CustomerType.CoffeeEmployee
            });

            System.Console.WriteLine("Entry added... ");
        }

        public void AddLoyalty(string enteredText)
        {
            var segments = enteredText.Split(' ');
            _coffeeShop.AddCustomer(new Customer
            {
                Type = CustomerType.LoyaltyMember,
                LoyaltyPoints = Convert.ToInt32(segments[3]),
                IsUsingLoyaltyPoints = Convert.ToBoolean(segments[4])
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
                LoyaltyPointsGained = 5
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