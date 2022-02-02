using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Text;

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

            

            //general
            var totalGeneral = Customers.Count(p => p.Type == CustomerType.General);
            //employee
            var totalEmployee = Customers.Count(p => p.Type == CustomerType.CoffeeEmployee);
            //student
            var totalStudents = Customers.Count(p => p.Type == CustomerType.Student);
            //loyalty
            var totalLoyalty = Customers.Count(p => p.Type == CustomerType.LoyaltyMember);

            var incomeFromDrinks = (totalGeneral * Drink.BasePrice);
            incomeFromDrinks += (Drink.BasePrice * (Drink.DiscountPrice / 100)) * totalStudents;
          
            
            if((incomeFromDrinks- CostOfDrinks())<50)
                incomeFromDrinks += (totalEmployee * Drink.BasePrice);


            return incomeFromDrinks;
        }


        public double CostOfDrinks()
        {
            return Customers.Sum(customer => Drink.BaseCost);
        }

        public double TotalLoyaltyPointsAccrued()
        {
            return Customers.Where(customer => customer.Type== CustomerType.General ).Sum(customer => Drink.LoyaltyPointsGained);
        }

        public int TotalCustomers()
        {
            return Customers.Count;
        }

        public string GetSummary()
        {
            var totalLoyaltyPointsRedeemed = 0;
            
            foreach (var customer in Customers)
                if (customer.Type == CustomerType.LoyaltyMember && customer.IsUsingLoyaltyPoints)
                {
                    var loyaltyPointsRedeemed = Convert.ToInt32(Math.Ceiling(Drink.BasePrice));
                    customer.LoyaltyPoints -= loyaltyPointsRedeemed;
                    totalLoyaltyPointsRedeemed += loyaltyPointsRedeemed;
                }


            return BuildSummary( TotalCustomers(), totalLoyaltyPointsRedeemed);
        }


        public int BeanCount(int cups)
        {

            return 1000 -( Drink.BeansPerCup * cups);
        }

        public string BuildSummary(int totalCustomers, int totalLoyaltyPointsRedeemed)
        {
            var builder = new StringBuilder();
            var profit = IncomeFromDrinks() - CostOfDrinks();
            builder.Append("Coffee Shop Summary");

            builder.Append(_verticalWhiteSpace);

            builder.Append("Total customers: " + totalCustomers);
            builder.Append(_newLine);
            builder.Append(Indentation + "General sales: " + Customers.Count(p => p.Type == CustomerType.General));
            builder.Append(_newLine);
            builder.Append(Indentation + "Loyalty member sales: " +
                           Customers.Count(p => p.Type == CustomerType.LoyaltyMember));
            builder.Append(_newLine);
            builder.Append(Indentation + "Employee Complimentary: " +
                           Customers.Count(p => p.Type == CustomerType.CoffeeEmployee));
            builder.Append(_newLine);
            builder.Append(Indentation + "Student sales: " +
                           Customers.Count(p => p.Type == CustomerType.Student));
            builder.Append(_verticalWhiteSpace);
            builder.Append("Total revenue from drinks: " + IncomeFromDrinks());
            builder.Append(_newLine);
            builder.Append("Total costs from drinks: " + CostOfDrinks());
            builder.Append(_newLine);

            builder.Append("Bean Count: " + BeanCount(Customers.Count));
            builder.Append(_newLine);


            builder.Append((profit > 0 ? "Coffee Shop generating profit of: " : "Coffee Shop losing money of: ") +
                           profit);

            builder.Append(_verticalWhiteSpace);

            builder.Append("Total loyalty points given away: " + TotalLoyaltyPointsAccrued());
            builder.Append(_newLine);
            builder.Append("Total loyalty points redeemed: " + totalLoyaltyPointsRedeemed);

            builder.Append(_verticalWhiteSpace);

            if(profit>20 && BeanCount(Customers.Count)>=250)
            {
                builder.Append("Coffee Shop will open tomorrow");
            }
            else
            {
                builder.Append("Coffee Shop will not open tomorrow");
            }


         
            return builder.ToString();

        }
    }
}