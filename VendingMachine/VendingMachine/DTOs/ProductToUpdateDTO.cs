namespace VendingMachine.DTOs
{
    public class ProductToUpdateDTO
    {
        public string ProductName { get; set; }
        public int AmountAvailable { get; set; }
        public int Cost { get; set; }
    }
}
