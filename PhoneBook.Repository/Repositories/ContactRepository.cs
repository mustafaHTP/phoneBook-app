using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Models;
using PhoneBook.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Contact> GetSingleContactByIdWithPhoneNumbersAsync(int contactId)
        {
            return await _context.Contacts.Include(x => x.PhoneNumbers).Where(x => x.Id == contactId).SingleOrDefaultAsync();
        }
    }
}
