namespace Application.UseCases.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<GetProductDTO>>
    {
        public int? PageNumber {  get; set; }
        public int? PageSize { get; set; }
    }
}
