using FluentValidation;
using PrimeNumber.Core.DTOs;

namespace PrimeNumber.Service.Validations
{
    public class FindRequestDtoValidator : AbstractValidator<FindRequestDto>
    {
        public FindRequestDtoValidator()
        {
            RuleFor(x => x.NumberSet).NotNull().WithMessage("{PropertyName} is required");
            RuleForEach(x => x.NumberSet).NotNull().WithMessage("Any value can't be null").GreaterThan(1).WithMessage("Each value must be bigger then 1");

        }
    }
}
