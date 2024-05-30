
namespace Application.UseCases.Product.Commands.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.BarCode)
                .NotNull().WithMessage("{BarCode} is require")
                .NotEmpty().WithMessage("{BarCode} should not be empty");

            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name} is require")
                .NotEmpty().WithMessage("{Name} should not be empty");

            RuleFor(p => p.Description)
                .NotNull().WithMessage("{Description} is require")
                .NotEmpty().WithMessage("{Description} should not be empty");

        }
    }
}
