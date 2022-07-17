using PhoneBook.Core.Models;

namespace PhoneBook.Core.Repositories
{
    public interface IPhoneNumberRepository : IGenericRepository<PhoneNumber>
    {
        Task<List<PhoneNumber>> GetPhoneNumbersWihContactAsync();
    }
}
