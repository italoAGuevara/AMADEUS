
namespace Product.XUnitTest.UseCases.Queries.GetAllProducts
{
    public class GetProductListQueryHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetProductListQueryHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]
        public async Task GetListProductsTest_PageHasData()
        {
            var handler = new GetAllProductsQueryHandler(_mapper, _unitOfWork.Object);
            var query = new GetAllProductsQuery()
            {
                PageNumber = 1,
                PageSize = 2
            };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<GetProductDTO>>();

            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetListProductsTest_PageHasNotData()
        {
            var handler = new GetAllProductsQueryHandler(_mapper, _unitOfWork.Object);
            var query = new GetAllProductsQuery()
            {
                PageNumber = 10,
                PageSize = 2
            };

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<GetProductDTO>>();

            result.Count.ShouldBe(0);
        }
    }
}
