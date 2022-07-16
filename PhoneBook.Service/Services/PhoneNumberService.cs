using AutoMapper;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Repositories;
using PhoneBook.Core.Services;
using PhoneBook.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service.Services
{
    public class PhoneNumberService : GenericService<PhoneNumber>, IPhoneNumberService
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IMapper _mapper;
        public PhoneNumberService(IGenericRepository<PhoneNumber> genericRepository, IUnitOfWork unitOfWork, IPhoneNumberRepository phoneNumberRepository, IMapper mapper) : base(genericRepository, unitOfWork)
        {
            _phoneNumberRepository = phoneNumberRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<PhoneNumbersWithContactDto>>> GetPhoneNumbersWihContactAsync()
        {
            var phoneNumbersWithContact = await _phoneNumberRepository.GetPhoneNumbersWihContactAsync();
            var phoneNumbersWithContactDto = _mapper.Map<List<PhoneNumbersWithContactDto>>(phoneNumbersWithContact);

            return CustomResponseDto<List<PhoneNumbersWithContactDto>>.Success(200, phoneNumbersWithContactDto);
        }
    }
}
