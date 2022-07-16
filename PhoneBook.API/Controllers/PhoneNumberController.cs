using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Services;

namespace PhoneBook.API.Controllers
{
    public class PhoneNumberController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<PhoneNumber> _genericService;

        public PhoneNumberController(IMapper mapper, IGenericService<PhoneNumber> genericService)
        {
            _mapper = mapper;
            _genericService = genericService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var phoneNumbers = await _genericService.GetAllAsync();
            var phoneNumberDtos = _mapper.Map<List<PhoneNumberDto>>(phoneNumbers.ToList());

            return CreateActionResult(CustomResponseDto<List<PhoneNumberDto>>.Success(200, phoneNumberDtos));

        }

        //www.site.com/api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var phoneNumber = await _genericService.GetByIdAsync(id);
            var phoneNumberDto = _mapper.Map<PhoneNumberDto>(phoneNumber);

            return CreateActionResult(CustomResponseDto<PhoneNumberDto>.Success(200, phoneNumberDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PhoneNumberDto newPhoneNumberDto)
        {
            var phoneNumber = _mapper.Map<PhoneNumber>(newPhoneNumberDto);
            await _genericService.AddAsync(phoneNumber);

            return CreateActionResult(CustomResponseDto<PhoneNumberDto>.Success(201, newPhoneNumberDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PhoneNumberDto newPhoneNumberDto)
        {
            var phoneNumber = _mapper.Map<PhoneNumber>(newPhoneNumberDto);
            await _genericService.UpdateAsync(phoneNumber);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var phoneNumber = await _genericService.GetByIdAsync(id);
            await _genericService.RemoveAsync(phoneNumber);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
