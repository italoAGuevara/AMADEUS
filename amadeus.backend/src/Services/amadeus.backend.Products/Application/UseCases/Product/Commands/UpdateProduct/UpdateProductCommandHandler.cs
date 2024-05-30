
namespace Application.UseCases.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var productToUpdate = await _unitOfWork.ProductRepository.GetByIdAsync(command.Id);

            if (productToUpdate == null)
            {
                _logger.LogError($"Product with id '{command.Id}' not founded");
                throw new NotFoundException(nameof(Product), command.Id);
            }

            _mapper.Map(command, productToUpdate, typeof(UpdateProductCommand), typeof(Domain.Product));
            await _unitOfWork.ProductRepository.UpdateAsync(productToUpdate);
            await _unitOfWork.Complete();

            _logger.LogInformation($"Success, product with id '{command.Id}' was updated");


            return productToUpdate.Id;
        }
    }
}
