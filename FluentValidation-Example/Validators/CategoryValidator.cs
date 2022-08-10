using FluentValidation;
using FluentValidation_Example.Models;

namespace FluentValidation_Example.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
