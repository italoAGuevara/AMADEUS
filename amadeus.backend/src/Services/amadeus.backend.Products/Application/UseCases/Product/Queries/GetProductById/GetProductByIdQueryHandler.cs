

namespace Application.UseCases.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, ILogger<GetProductByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<GetProductDTO> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(query.Id);

            if (product == null)
            {
                _logger.LogError($"Product with id '{query.Id}' not founded");
                throw new NotFoundException(nameof(Product), query.Id);
            }

            return _mapper.Map<GetProductDTO>(product);
        }
    }
}
