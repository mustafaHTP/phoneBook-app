using FluentValidation;
using PhoneBook.Core.DTOs;

namespace PhoneBook.Service.Validations
{
    public class PhoneNumberVMValidator : AbstractValidator<PhoneNumberViewModel>
    {
        public PhoneNumberVMValidator()
        {
            RuleFor(x => x.PhoneNo).NotEmpty().WithMessage("Phone Number cannot be empty!").Must(x => x.Length == 11 ).When(x=> !string.IsNullOrEmpty(x.PhoneNo)).WithMessage("Phone Number length must equal to 11!");
            RuleFor(x => x.ContactId).NotEmpty().WithMessage("You must choose Contact!");
        }
    }
}
