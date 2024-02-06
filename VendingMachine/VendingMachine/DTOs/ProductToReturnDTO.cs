namespace VendingMachine.DTOs
{
    public class ProductToReturnDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int AmountAvailable { get; set; }
        public int Cost { get; set; }
    }
}
