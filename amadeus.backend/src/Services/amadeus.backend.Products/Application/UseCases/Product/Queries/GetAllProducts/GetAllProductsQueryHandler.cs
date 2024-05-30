
namespace Application.UseCases.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetProductDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetProductDTO>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var productList = await _unitOfWork.ProductRepository.GetAsync(query.PageNumber, query.PageSize);

            return _mapper.Map<List<GetProductDTO>>(productList);
        }
    }
}
