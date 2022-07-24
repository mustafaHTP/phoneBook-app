﻿using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Models;
using PhoneBook.Core.Repositories;

namespace PhoneBook.Repository.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddContactWithPhoneNumbersAsync(Contact contact)
        {
            await _context.PhoneNumbers.AddRangeAsync(contact.PhoneNumbers);
            await _context.Contacts.AddAsync(contact);
        }

        public async Task<Contact> GetSingleContactByIdWithPhoneNumbersAsync(int contactId)
        {
            return await _context.Contacts.Include(x => x.PhoneNumbers).Where(x => x.Id == contactId).SingleOrDefaultAsync();
        }

        public void UpdateContactWithPhoneNumbers(Contact contact)
        {
            _context.PhoneNumbers.UpdateRange(contact.PhoneNumbers);
            _context.Contacts.Update(contact);
        }
    }
}
