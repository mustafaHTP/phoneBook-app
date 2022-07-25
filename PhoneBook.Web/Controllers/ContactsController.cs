using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Services;
using PhoneBook.Service.Services;
using PhoneBook.Web.Filters;

namespace PhoneBook.Web.Controllers
{
    public class ContactsController : Controller
    {
        IContactService _contactService;
        IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _contactService.GetAllAsync();
            var contactViewModels = _mapper.Map<List<ContactViewModel>>(contacts);
            return View(contactViewModels);
        }

        public async Task<IActionResult> GetContactDetailsWithPhoneNumbers(int id)
        {
            var contactWithPhoneNumbersViewModel = await _contactService.GetSingleContactByIdWithPhoneNumbersAsync(id);
            return View(contactWithPhoneNumbersViewModel);
        }

        public async Task<IActionResult> GetContactWithPhoneNumbers(int id)
        {
            var contactWithPhoneNumbersViewmodel = await _contactService.GetSingleContactByIdWithPhoneNumbersAsync(id);
            return View(contactWithPhoneNumbersViewmodel);
        }


        public async Task<IActionResult> Save()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        [HttpPost]
        public async Task<IActionResult> Save(ContactWithPhoneNumbersViewModel contactWithPhoneNumbersViewModel)
        {
            if (ModelState.IsValid)
            {
                await _contactService.AddContactWithPhoneNumbersAsync(contactWithPhoneNumbersViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Contact>))]
        public async Task<IActionResult> Update(int id)
        {
            var contactWithPhoneNumbersViewModel = await _contactService.GetSingleContactByIdWithPhoneNumbersAsync(id);

            return View(contactWithPhoneNumbersViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactWithPhoneNumbersViewModel contactWithPhoneNumbersViewModel)
        {
            if (ModelState.IsValid)
            {
                await _contactService.UpdateContactWithPhoneNumbersAsync(contactWithPhoneNumbersViewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(contactWithPhoneNumbersViewModel);
        }

        [ServiceFilter(typeof(NotFoundFilter<Contact>))]
        public async Task<IActionResult> Remove(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            await _contactService.RemoveAsync(contact);

            return RedirectToAction(nameof(Index));
        }

        


    }
}
