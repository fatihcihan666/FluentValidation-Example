using FluentValidation;
using FluentValidation_Example.Models;

namespace FluentValidation_Example.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {

        public ProductValidator()
        {
            //RuleFor(x => x.Name).NotNull().When(x => x.Id < 0).NotEmpty().... boyle uzun uzun devam edilebilir ama gerek yok
            //RuleFor(x => x.Id).NotNull().NotEmpty();

            RuleFor(x => x.Name).NotNull().WithMessage("Please do not leave the product name field blank!");
            RuleFor(x => x.Name).Length(5, 30).WithMessage("Product name must be between 5 and 30 characters");


            RuleFor(x => x.Description).NotNull().WithMessage("Please do not leave the product description field blank!");
            RuleFor(x => x.Description).Length(5, 30).WithMessage("Description must be between 5 and 30 characters");

            RuleFor(x => x.UnitPrice).NotNull().NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero");

            RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("Quantity cannot be empty or null");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity can not be less than zero");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(50)
                .When(x => x.CategoryId == 2)
                .WithMessage("The price of products with category id 2 cannot be less than fifty");
        }

    }
}
