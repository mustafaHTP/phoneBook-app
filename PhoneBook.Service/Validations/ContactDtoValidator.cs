using FluentValidation;
using PhoneBook.Core.DTOs;

namespace PhoneBook.Service.Validations
{
    public class ContactDtoValidator : AbstractValidator<ContactViewModel>
    {
        public ContactDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.LastName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
