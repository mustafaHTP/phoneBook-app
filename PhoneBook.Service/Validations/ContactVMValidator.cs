using FluentValidation;
using FluentValidation.Results;
using PhoneBook.Core.DTOs;

namespace PhoneBook.Service.Validations
{
    public class ContactVMValidator : AbstractValidator<ContactViewModel>
    {
        public ContactVMValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} is required");
        }

        
    }
}
