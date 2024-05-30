
namespace Application.UseCases.Product.Commands.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} should not be empty")
                .Must(id => id != Guid.Empty).WithMessage("{Id} should not be empty"); ;

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
