using Application.UseCases.Product.Commands.CreateProduct;
using Application.UseCases.Product.Commands.DeleteProduct;
using Application.UseCases.Product.Commands.UpdateProduct;
using Application.UseCases.Product.Queries.GetProductById;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetProductDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetProductDTO>>> GetAllProducts([FromQuery] GetAllProductsQuery query)
        {
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetProductDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProductDTO>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(Guid.Parse(id));
            var product = await _mediator.Send(query);
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            await _mediator.Send(new DeleteProductCommand(id));

            return Ok();
        }
    }
}
