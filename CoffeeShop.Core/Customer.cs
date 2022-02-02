namespace CoffeeShop.Core
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }
        public bool IsUsingLoyaltyPoints { get; set; }
        public CustomerType Type { get; set; }
        
        public string Title { get; set; }
        public int DiscountPercentage { get; set; }
    }

    public enum CustomerType
    {
        General,
        LoyaltyMember,
        CoffeeEmployee,
        Student
    }
}