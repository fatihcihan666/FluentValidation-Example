using FluentValidation;
using FluentValidation_Example.Models;

namespace FluentValidation_Example.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

        }
    }
}
