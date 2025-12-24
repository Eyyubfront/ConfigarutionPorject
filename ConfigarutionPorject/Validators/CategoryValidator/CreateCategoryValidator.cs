using ConfigarutionPorject.Entities.DTOs.CagtegoryDtos;
using FluentValidation;

namespace ConfigarutionPorject.Validators.CategoryValidator
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.")
            .NotNull().WithMessage("Category name cannot be null.")
            .Must(CategoryName).WithMessage("Category name starwith I.");
            RuleFor(c => c.Description)
                     .NotEmpty().WithMessage("Description name is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                      .NotNull().WithMessage("Description about cannot be null.")
                       .Must(CategoryDescription).WithMessage("Description starwith number."); ;
        }

        public bool CategoryName (string name)
        {
            return name.StartsWith("İ");
        }
        public bool CategoryDescription(string description)
        {
            return char.IsDigit(description[0]);

        }
    }
}
