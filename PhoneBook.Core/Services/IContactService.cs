using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;

namespace PhoneBook.Core.Services
{
    public interface IContactService : IGenericService<Contact>
    {
        Task<CustomResponseViewModel<ContactWithPhoneNumbersViewModel>> GetSingleContactByIdWithPhoneNumbersAsync(int contactId);
    }
}
