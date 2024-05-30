namespace Application.UseCases.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var productToDelete = await _unitOfWork.ProductRepository.GetByIdAsync(Guid.Parse(command.Id));
            if (productToDelete == null)
            {
                _logger.LogError($"Product with id '{command.Id}' not exist");
                throw new NotFoundException(nameof(Domain.Product), command.Id);
            }

            await _unitOfWork.ProductRepository.DeleteAsync(productToDelete);
            await _unitOfWork.Complete();

            _logger.LogInformation($"Product '{command.Id}' was deleted");

            return Unit.Value;
        }
    }
}
