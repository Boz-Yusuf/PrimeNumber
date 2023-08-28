using FluentValidation;
using PrimeNumber.Core.DTOs;

namespace PrimeNumber.Service.Validations
{
    public class RegisterDtoValidator :AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Password)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");
           

            RuleFor(x => x.PasswordConfirm)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Equal(x => x.Password).WithMessage("Passwords must match");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
