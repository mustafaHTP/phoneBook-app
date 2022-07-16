using FluentValidation;
using PhoneBook.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service.Validations
{
    public class PhoneNumberDtoValidator:AbstractValidator<PhoneNumberDto>
    {
        public PhoneNumberDtoValidator()
        {
            RuleFor(x => x.PhoneNo).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ContactId).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
