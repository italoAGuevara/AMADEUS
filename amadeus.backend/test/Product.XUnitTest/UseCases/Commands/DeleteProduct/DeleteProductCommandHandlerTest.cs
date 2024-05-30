
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Product.XUnitTest.UseCases.Commands.DeleteProduct
{
    public class DeleteProductCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteProductCommandHandler>> _logger;

        public DeleteProductCommandHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<DeleteProductCommandHandler>>();   
        }

        [Fact]
        public async Task DeleteProductCommand_InputProduct_ReturnsUnit()
        {
            var streamerInput = new DeleteProductCommand("cfd7d995-10fd-43d6-b86e-560c2f3c568c");

            var handler = new DeleteProductCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }

        [Fact]
        public async Task DeleteProductCommand_InputProduct_ThrowException()
        {
            var query = new DeleteProductCommand("cfd7d995-10fd-43d6-b86e-560c2f3c561c");

            var handler = new DeleteProductCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Application.Exceptions.NotFoundException>(() => handler.Handle(query, CancellationToken.None));

            Assert.Equal("Entity \"Product\" (cfd7d995-10fd-43d6-b86e-560c2f3c561c)  was not found", exception.Message);
        }
    }
}
