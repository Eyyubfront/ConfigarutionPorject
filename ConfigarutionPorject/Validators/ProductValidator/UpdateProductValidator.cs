using ConfigarutionPorject.Entities.DTOs.ProductDtos;
using FluentValidation;

namespace ConfigarutionPorject.Validators.ProductValidator
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.")
                .Must(ProductName).WithMessage("Product name must start with 'M'.");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("Price is required.")
                .Must(PriceGreaterThanZero).WithMessage("Price must be greater than 20.");
        }

        private bool ProductName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.StartsWith("M");
        }

        private bool PriceGreaterThanZero(decimal price)
        {

            return price > 20;
        }
    }
}
