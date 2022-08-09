using FluentValidation;
using FluentValidation_Example.Models;

namespace FluentValidation_Example.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {

        public ProductValidator()
        {

            //RuleFor(x => x.Name).NotNull().When(x => x.Id < 0).NotEmpty()....
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Description).NotNull();



            RuleFor(x => x.Name).Length(5, 30);
            RuleFor(x => x.Description).Length(5, 30);

        }

    }
}
