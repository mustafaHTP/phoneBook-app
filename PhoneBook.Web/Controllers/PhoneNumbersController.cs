using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Services;

namespace PhoneBook.Web.Controllers
{
    public class PhoneNumbersController : Controller
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumbersController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _phoneNumberService.GetPhoneNumbersWihContactAsync());
        }
    }
}
