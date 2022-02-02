namespace CoffeeShop.Core
{
    public class Drink
    {
        public Drink(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public double BasePrice { get; set; }
        public double DiscountPrice { get; set; }

        public double BaseCost { get; set; }
        public int LoyaltyPointsGained { get; set; }
        public int BeansPerCup => 150;
    }
}