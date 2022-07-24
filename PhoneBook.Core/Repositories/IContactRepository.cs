using PhoneBook.Core.Models;

namespace PhoneBook.Core.Repositories
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<Contact> GetSingleContactByIdWithPhoneNumbersAsync(int contactId);
        Task AddContactWithPhoneNumbersAsync(Contact contact);
        void UpdateContactWithPhoneNumbers(Contact contact);
    }
}
