using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;

namespace PhoneBook.Core.Services
{
    public interface IPhoneNumberService:IGenericService<PhoneNumber>
    {
        Task<List<PhoneNumbersWithContactDto>> GetPhoneNumbersWihContactAsync();
    }
}
