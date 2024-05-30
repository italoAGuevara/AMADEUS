
namespace Product.XUnitTest.UseCases.Commands.CreateProduct
{
    public class CreateProductCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateProductCommandHandler>> _logger;

        public CreateProductCommandHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            _logger = new Mock<ILogger<CreateProductCommandHandler>>();
        }

        [Fact]
        public async Task CreateProductCommand_InputProduct_ReturnsGuid()
        {
            var streamerInput = new CreateProductCommand
            {
                BarCode = "code1",
                Description = "Description",
                Name = "Name",
                Price = 1,
                StockQuantity = 1
            };

            var handler = new CreateProductCommandHandler(_logger.Object, _mapper,  _unitOfWork.Object );

            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<Guid>();
        }
    }
}
