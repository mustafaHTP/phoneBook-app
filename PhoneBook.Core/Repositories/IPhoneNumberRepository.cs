using PhoneBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Repositories
{
    public interface IPhoneNumberRepository : IGenericRepository<PhoneNumber>
    {
        Task<List<PhoneNumber>> GetPhoneNumbersWihContactAsync();
    }
}
