
namespace Application.UseCases.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Domain.Product>(command);

            _unitOfWork.ProductRepository.AddEntity(productEntity);

            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                _logger.LogError("Was no posible insert product");
                throw new Exception("Was no posible insert product");
            }

            return productEntity.Id;
        }
    }
}
