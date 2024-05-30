
namespace Application.UseCases.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public string Id;

        public DeleteProductCommand(string id)
        {
            Id = id;
        }
    }
}
