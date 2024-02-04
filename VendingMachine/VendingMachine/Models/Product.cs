namespace VendingMachine.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int AmountAvailable { get; set; }
        public int Cost { get; set; }
        public string SellerId { get; set; }
    }
}
