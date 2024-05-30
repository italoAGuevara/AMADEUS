
namespace Product.XUnitTest.UseCases.Commands.UpdateProduct
{
    public class UpdateProductValidatorTests
    {
        private readonly UpdateProductValidator _validator;

        public UpdateProductValidatorTests()
        {
            _validator = new UpdateProductValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            var command = new UpdateProductCommand { Id = Guid.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(p => p.Id)
                  .WithErrorMessage("{Id} should not be empty");
        }

        [Fact]
        public void Should_Have_Error_When_BarCode_Is_Null()
        {
            var command = new UpdateProductCommand { BarCode = null };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(p => p.BarCode)
                  .WithErrorMessage("{BarCode} is require");
        }

        [Fact]
        public void Should_Have_Error_When_BarCode_Is_Empty()
        {
            var command = new UpdateProductCommand { BarCode = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(p => p.BarCode)
                  .WithErrorMessage("{BarCode} should not be empty");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Null()
        {
            var command = new UpdateProductCommand { Name = null };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(p => p.Name)
                  .WithErrorMessage("{Name} is require");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command = new UpdateProductCommand { Name = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(p => p.Name)
                  .WithErrorMessage("{Name} should not be empty");
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Null()
        {
            var command = new UpdateProductCommand { Description = null };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(p => p.Description)
                  .WithErrorMessage("{Description} is require");
        }

        [Fact]
        public void Should_Have_Error_When_Description_Is_Empty()
        {
            var command = new UpdateProductCommand { Description = string.Empty };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(p => p.Description)
                  .WithErrorMessage("{Description} should not be empty");
        }

        [Fact]
        public void Should_Not_Have_Error_When_Command_Is_Valid()
        {
            var command = new UpdateProductCommand
            {
                Id = Guid.NewGuid(),
                BarCode = "123456",
                Name = "Product Name",
                Description = "Product Description"
            };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(p => p.Id);
            result.ShouldNotHaveValidationErrorFor(p => p.BarCode);
            result.ShouldNotHaveValidationErrorFor(p => p.Name);
            result.ShouldNotHaveValidationErrorFor(p => p.Description);
        }
    }
}
