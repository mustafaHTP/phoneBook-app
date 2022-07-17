using FluentValidation;
using PhoneBook.Core.DTOs;

namespace PhoneBook.Service.Validations
{
    public class PhoneNumberDtoValidator : AbstractValidator<PhoneNumberViewModel>
    {
        public PhoneNumberDtoValidator()
        {
            RuleFor(x => x.PhoneNo).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").Must(x => x.Length == 11).WithMessage("Phone number length must be 11 character");
            RuleFor(x => x.ContactId).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
