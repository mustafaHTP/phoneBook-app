using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Services;

namespace PhoneBook.Web.Controllers
{
    public class PhoneNumbersController : Controller
    {
        private readonly IPhoneNumberService _phoneNumberService;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public PhoneNumbersController(IPhoneNumberService phoneNumberService, IContactService contactService, IMapper mapper = null)
        {
            _phoneNumberService = phoneNumberService;
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _phoneNumberService.GetPhoneNumbersWihContactAsync());
        }

        public async Task<IActionResult> Save()
        {
            var contacts = await _contactService.GetAllAsync();
            var contactDtos = _mapper.Map<List<ContactDto>>(contacts.ToList());

            ViewBag.Contacts = new SelectList(contactDtos, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(PhoneNumberDto phoneNumberDto)
        {
            if (ModelState.IsValid)
            {
                var phoneNumber = _mapper.Map<PhoneNumber>(phoneNumberDto);
                await _phoneNumberService.AddAsync(phoneNumber);

                return RedirectToAction(nameof(Index));

            }
            var contacts = await _contactService.GetAllAsync();
            var contactDtos = _mapper.Map<List<ContactDto>>(contacts.ToList());

            ViewBag.Contacts = new SelectList(contactDtos, "Id", "FirstName");

            return View();
        }
    }
}
