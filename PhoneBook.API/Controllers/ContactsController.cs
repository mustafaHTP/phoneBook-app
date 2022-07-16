using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Services;

namespace PhoneBook.API.Controllers
{
    public class ContactsController : CustomBaseController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("[action]/{contactId}")]
        public async Task<IActionResult> GetSingleContactByIdWithPhoneNumbers(int contactId)
        {
            return CreateActionResult(await _contactService.GetSingleContactByIdWithPhoneNumbersAsync(contactId));

        }
    }
}
