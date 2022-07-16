using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.API.Filters;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Services;

namespace PhoneBook.API.Controllers
{
    public class PhoneNumbersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumbersController(IMapper mapper, IPhoneNumberService phoneNumberService)
        {
            _mapper = mapper;
            _phoneNumberService = phoneNumberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var phoneNumbers = await _phoneNumberService.GetAllAsync();
            var phoneNumberDtos = _mapper.Map<List<PhoneNumberDto>>(phoneNumbers.ToList());

            return CreateActionResult(CustomResponseDto<List<PhoneNumberDto>>.Success(200, phoneNumberDtos));

        }

        [HttpGet("GetPhoneNumbersWithContact")]
        public async Task<IActionResult> GetPhoneNumbersWithContact()
        {
            var phoneNumbersWithContactDto = await _phoneNumberService.GetPhoneNumbersWihContactAsync();

            return CreateActionResult(phoneNumbersWithContactDto);

        }

        //www.site.com/api/products/5
        [ServiceFilter(typeof(NotFoundFilter<PhoneNumber>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var phoneNumber = await _phoneNumberService.GetByIdAsync(id);
            var phoneNumberDto = _mapper.Map<PhoneNumberDto>(phoneNumber);

            return CreateActionResult(CustomResponseDto<PhoneNumberDto>.Success(200, phoneNumberDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PhoneNumberDto newPhoneNumberDto)
        {
            var phoneNumber = _mapper.Map<PhoneNumber>(newPhoneNumberDto);
            await _phoneNumberService.AddAsync(phoneNumber);

            return CreateActionResult(CustomResponseDto<PhoneNumberDto>.Success(201, newPhoneNumberDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PhoneNumberDto newPhoneNumberDto)
        {
            var phoneNumber = _mapper.Map<PhoneNumber>(newPhoneNumberDto);
            await _phoneNumberService.UpdateAsync(phoneNumber);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var phoneNumber = await _phoneNumberService.GetByIdAsync(id);
            await _phoneNumberService.RemoveAsync(phoneNumber);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
