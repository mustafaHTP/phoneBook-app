using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Services;
using PhoneBook.Web.Filters;

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
            var contactDtos = _mapper.Map<List<ContactViewModel>>(contacts.ToList());

            ViewBag.Contacts = new SelectList(contactDtos, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(PhoneNumberViewModel phoneNumberDto)
        {
            if (ModelState.IsValid)
            {
                var phoneNumber = _mapper.Map<PhoneNumber>(phoneNumberDto);
                await _phoneNumberService.AddAsync(phoneNumber);

                return RedirectToAction(nameof(Index));

            }
            var contacts = await _contactService.GetAllAsync();
            var contactDtos = _mapper.Map<List<ContactViewModel>>(contacts.ToList());

            ViewBag.Contacts = new SelectList(contactDtos, "Id", "FullName");

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<PhoneNumber>))]
        public async Task<IActionResult> Update(int id)
        {
            var phoneNumber = await _phoneNumberService.GetByIdAsync(id);

            var contacts = await _contactService.GetAllAsync();
            var contactDtos = _mapper.Map<List<ContactViewModel>>(contacts.ToList());

            ViewBag.Contacts = new SelectList(contactDtos, "Id", "FullName", phoneNumber.ContactId);

            return View(_mapper.Map<PhoneNumberViewModel>(phoneNumber));
        }

        [HttpPost]
        public async Task<IActionResult> Update(PhoneNumberViewModel phoneNumberDto)
        {
            if (ModelState.IsValid)
            {
                var phoneNumber = _mapper.Map<PhoneNumber>(phoneNumberDto);
                await _phoneNumberService.UpdateAsync(phoneNumber);

                return RedirectToAction(nameof(Index));
            }

            var contacts = await _contactService.GetAllAsync();
            var contactDtos = _mapper.Map<List<ContactViewModel>>(contacts.ToList());

            ViewBag.Contacts = new SelectList(contactDtos, "Id", "FullName", phoneNumberDto.ContactId);

            return View(phoneNumberDto);
        }

        [ServiceFilter(typeof(NotFoundFilter<PhoneNumber>))]
        public async Task<IActionResult> Remove(int id)
        {
            var phoneNumber = await _phoneNumberService.GetByIdAsync(id);
            await _phoneNumberService.RemoveAsync(phoneNumber);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveAfterReturnSamePage(int id)
        {
            var phoneNumber = await _phoneNumberService.GetByIdAsync(id);
            await _phoneNumberService.RemoveAsync(phoneNumber);

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
