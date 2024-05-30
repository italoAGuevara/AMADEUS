
namespace Application.UseCases.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : BaseEntity, IRequest<Guid>
    {

        public string BarCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public uint StockQuantity { get; set; }
    }
}
