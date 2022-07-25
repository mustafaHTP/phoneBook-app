using FluentValidation;
using PhoneBook.Core.DTOs;

namespace PhoneBook.Service.Validations
{
    public class PhoneNumberVMValidator : AbstractValidator<PhoneNumberViewModel>
    {
        public PhoneNumberVMValidator()
        {
            RuleFor(x => x.PhoneNo).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").Must(x => x.Length == 11).WithMessage("Phone number length must be 11 character");
        }
    }
}
