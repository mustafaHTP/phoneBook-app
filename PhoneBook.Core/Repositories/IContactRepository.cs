using PhoneBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Repositories
{
    public interface IContactRepository:IGenericRepository<Contact>
    {
        Task<Contact> GetSingleContactByIdWithPhoneNumbersAsync(int contactId);
    }
}
