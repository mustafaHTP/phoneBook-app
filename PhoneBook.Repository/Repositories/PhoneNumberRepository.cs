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
    public class PhoneNumberRepository : GenericRepository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<PhoneNumber>> GetPhoneNumbersWihContactAsync()
        {
            //Eager loading
            return await _context.PhoneNumbers.Include(x => x.Contact).ToListAsync();
        }
    }
}
