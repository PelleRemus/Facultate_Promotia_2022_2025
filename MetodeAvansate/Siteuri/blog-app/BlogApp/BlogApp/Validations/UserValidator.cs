using BlogApp.Models;
using FluentValidation;

namespace BlogApp.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(person => person.FirstName).NotNull().NotEmpty();
            RuleFor(person => person.LastName).NotNull().NotEmpty();
            RuleFor(person => person.NickName).NotNull().NotEmpty();
            RuleFor(person => person.Phone).NotNull().NotEmpty();

            RuleFor(person => person.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(person => person.Password)
                .NotNull().NotEmpty()
                .MinimumLength(8)
                .Must(password => password.FirstOrDefault(character => character >= 'a' && character <= 'z') != 0)
                    .WithMessage("Password should contain at least one lowercase letter")
                .Must(password => password.FirstOrDefault(character => character >= 'A' && character <= 'Z') != 0)
                    .WithMessage("Password should contain at least one uppercase letter")
                .Must(password => password.FirstOrDefault(character => character >= '0' && character <= '9') != 0)
                    .WithMessage("Password should contain at least one digit")
                .Must(password => password.FirstOrDefault(character => "!@#$%^&*()-_=+".Contains(character)) != 0)
                    .WithMessage("Password should contain at least one special character");
        }
    }
}
