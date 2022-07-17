using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Services;
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

        public async Task<IActionResult> Save()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        [HttpPost]
        public async Task<IActionResult> Save(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var contact = _mapper.Map<Contact>(contactViewModel);
                await _contactService.AddAsync(contact);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Contact>))]
        public async Task<IActionResult> Update(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            var contactViewModel = _mapper.Map<ContactViewModel>(contact);

            return View(contactViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var contact = _mapper.Map<Contact>(contactViewModel);
                await _contactService.UpdateAsync(contact);

                return RedirectToAction(nameof(Index));
            }

            return View(contactViewModel);
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
