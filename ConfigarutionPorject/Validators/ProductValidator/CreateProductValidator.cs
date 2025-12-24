using ConfigarutionPorject.Entities.DTOs.ProductDtos;
using FluentValidation;

namespace ConfigarutionPorject.Validators.ProductValidator
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.")
                .Must(ProductName).WithMessage("Product name must start with 'P'.");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("Price is required.")
                .Must(PriceGreaterThanZero).WithMessage("Price must be greater than zero.");
        }

        private bool ProductName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.StartsWith("P");
        }






        private bool PriceGreaterThanZero(decimal price)
        {
 
            return  price > 0;
        }
    }
}
