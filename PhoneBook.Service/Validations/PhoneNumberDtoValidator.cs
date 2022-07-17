using FluentValidation;
using PhoneBook.Core.DTOs;

namespace PhoneBook.Service.Validations
{
    public class PhoneNumberDtoValidator : AbstractValidator<PhoneNumberDto>
    {
        public PhoneNumberDtoValidator()
        {
            RuleFor(x => x.PhoneNo).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ContactId).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
