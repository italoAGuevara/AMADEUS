
namespace Product.XUnitTest.UseCases.Commands.UpdateProduct
{
    public class UpdateProductCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<UpdateProductCommandHandler>> _logger;

        public UpdateProductCommandHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<UpdateProductCommandHandler>>();
        }

        [Fact]
        public async Task UpdateProductCommand_InputProduct_ReturnGuid_OK()
        {
            var productInput = new UpdateProductCommand
            {
                Id = Guid.Parse("6080eb0c-f1aa-4dc6-9996-75cf70acbf1f"),
                Name = "Product 1 updated",
                Price = 100,
                BarCode = "barcode1 updated",
                Description = "description updated",
                StockQuantity = 10,
                TmStmp = DateTime.Now,
            };

            var handler = new UpdateProductCommandHandler(_logger.Object, _mapper, _unitOfWork.Object);

            var result = await handler.Handle(productInput, CancellationToken.None);

            result.ShouldBeOfType<Guid>();
        }

        [Fact]
        public async Task UpdateProductCommand_InputProduct_Error()
        {
            var productInput = new UpdateProductCommand
            {
                Id = Guid.Parse("6080eb0c-f1aa-4dc6-9996-75cf70acbf1f"),
                Price = 100,
                BarCode = "barcode1 updated",
                Description = "description updated",
                StockQuantity = 10,
                TmStmp = DateTime.Now,
            };

            var handler = new UpdateProductCommandHandler(_logger.Object, _mapper, _unitOfWork.Object);

            var result = await handler.Handle(productInput, CancellationToken.None);

            result.ShouldBeOfType<Guid>();
        }
    }
}
