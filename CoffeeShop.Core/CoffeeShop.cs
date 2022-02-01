using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Core
{
    public class CoffeeShop 
    {
        private const string Indentation = "    ";
        private readonly string _newLine = Environment.NewLine;
        private readonly string _verticalWhiteSpace = Environment.NewLine + Environment.NewLine;

        public CoffeeShop(Drink drink)
        {
            Drink = drink;
            Customers = new List<Customer>();
        }

        private Drink Drink { get; }
        public List<Customer> Customers { get; }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        

        public double IncomeFromDrinks()
        {
            return Customers.Sum(customer => Drink.BasePrice);
        }


        public double CostOfDrinks()
        {
            return Customers.Sum(customer => Drink.BaseCost);
        }
        public double TotalLoyaltyPointsAccrued()
        {
            return Customers.Sum(customer => Drink.LoyaltyPointsGained);
        }


        public string GetSummary()
        {
        
          
            var totalLoyaltyPointsRedeemed = 0;
            var totalCustomers = 0;

            var result = "Coffee Shop Summary";

            foreach (var customer in Customers)
            {
                if (customer.Type == CustomerType.LoyaltyMember)
                {
                    if (customer.IsUsingLoyaltyPoints)
                    {
                        var loyaltyPointsRedeemed = Convert.ToInt32(Math.Ceiling(Drink.BasePrice));
                        customer.LoyaltyPoints -= loyaltyPointsRedeemed;
                        totalLoyaltyPointsRedeemed += loyaltyPointsRedeemed;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }


                totalCustomers++;
            }

            return BuildSummary(result, totalCustomers, totalLoyaltyPointsRedeemed);
        }

        private string BuildSummary(string result, int totalCustomers, int totalLoyaltyPointsRedeemed)
        {
            result += _verticalWhiteSpace;

            result += "Total customers: " + totalCustomers;
            result += _newLine;
            result += Indentation + "General sales: " + Customers.Count(p => p.Type == CustomerType.General);
            result += _newLine;
            result += Indentation + "Loyalty member sales: " +
                      Customers.Count(p => p.Type == CustomerType.LoyaltyMember);
            result += _newLine;
            result += Indentation + "Employee Complimentary: " +
                      Customers.Count(p => p.Type == CustomerType.CoffeeEmployee);

            result += _verticalWhiteSpace;

            result += "Total revenue from drinks: " + IncomeFromDrinks();
            result += _newLine;
            result += "Total costs from drinks: " + CostOfDrinks();
            result += _newLine;

            var profit = IncomeFromDrinks() - CostOfDrinks();

            result += (profit > 0 ? "Coffee Shop generating profit of: " : "Coffee Shop losing money of: ") + profit;

            result += _verticalWhiteSpace;

            result += "Total loyalty points given away: " + TotalLoyaltyPointsAccrued();
            result += _newLine;
            result += "Total loyalty points redeemed: " + totalLoyaltyPointsRedeemed;

            result += _verticalWhiteSpace;

            result += profit > 20 ? "Coffee Shop will open tomorrow " : "Coffee Shop will not open tomorrow";

            return result;
        }
    }
   
}