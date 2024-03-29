﻿using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;

namespace PhoneBook.Core.Services
{
    public interface IContactService : IGenericService<Contact>
    {
        Task<ContactWithPhoneNumbersViewModel> GetSingleContactByIdWithPhoneNumbersAsync(int contactId);
        Task<List<ContactViewModel>> SearchAsync(string queryString);
        Task<ContactWithPhoneNumbersViewModel> AddContactWithPhoneNumbersAsync(ContactWithPhoneNumbersViewModel contactWithPhoneNumbersViewModel);
        Task<ContactWithPhoneNumbersViewModel> UpdateContactWithPhoneNumbersAsync(ContactWithPhoneNumbersViewModel contactWithPhoneNumbersViewModel);
    }
}
