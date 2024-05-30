
namespace Product.XUnitTest.UseCases.Queries.GetProductById
{
    public class GetProductByIdQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<GetProductByIdQueryHandler>> _logger;

        public GetProductByIdQueryHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<GetProductByIdQueryHandler>>();
        }

        [Fact]
        public async Task GetProductByTest_Exist()
        {
            var handler = new GetProductByIdQueryHandler(_mapper, _unitOfWork.Object, _logger.Object);
            var query = new GetProductByIdQuery(Guid.Parse("6080eb0c-f1aa-4dc6-9996-75cf70acbf1f"));

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<GetProductDTO>();
        }

        [Fact]
        public async Task GetProductByTest_NotExist()
        {
            var handler = new GetProductByIdQueryHandler(_mapper, _unitOfWork.Object, _logger.Object);
            var query = new GetProductByIdQuery(Guid.Parse("6080eb0c-f1aa-4dc6-9996-75cf70acbf12"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Application.Exceptions.NotFoundException>(() => handler.Handle(query, CancellationToken.None));

            Assert.Equal("Entity \"Product\" (6080eb0c-f1aa-4dc6-9996-75cf70acbf12)  was not found", exception.Message);
        }
    }
}
