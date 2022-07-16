using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Services
{
    public interface IContactService:IGenericService<Contact>
    {
        Task<CustomResponseDto<ContactWithPhoneNumbersDto>> GetSingleContactByIdWithPhoneNumbersAsync(int contactId);
    }
}
