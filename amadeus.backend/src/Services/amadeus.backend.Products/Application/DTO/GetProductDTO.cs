
namespace Application.DTO
{
    public class GetProductDTO : BaseEntity
    {
        public string BarCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public uint StockQuantity { get; set; }
    }
}
