
namespace Application.UseCases.Product.Queries.GetProductById
{

    public class GetProductByIdQuery : IRequest<GetProductDTO>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid Id) 
        {
            this.Id = Id;
        }
    }
}
