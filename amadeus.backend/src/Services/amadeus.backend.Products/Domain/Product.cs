namespace Domain
{
    public class Product : BaseEntity
    {
        public string BarCode {  get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public uint StockQuantity { get; set; }
    }
}
