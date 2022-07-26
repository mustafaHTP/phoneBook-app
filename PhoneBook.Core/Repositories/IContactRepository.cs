using PhoneBook.Core.Models;
using System.Linq.Expressions;

namespace PhoneBook.Core.Repositories
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<Contact> GetSingleContactByIdWithPhoneNumbersAsync(int contactId);
        Task<List<Contact>> SearchAsync(string queryString);
        Task AddContactWithPhoneNumbersAsync(Contact contact);
        void UpdateContactWithPhoneNumbers(Contact contact);
    }
}
