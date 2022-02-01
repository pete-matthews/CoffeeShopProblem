namespace CoffeeShop.Core
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }
        public bool IsUsingLoyaltyPoints { get; set; }
        public CustomerType Type { get; set; }
    }

    public enum CustomerType
    {
        General,
        LoyaltyMember,
        CoffeeEmployee
    }
}