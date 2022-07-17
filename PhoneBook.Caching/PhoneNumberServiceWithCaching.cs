using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Repositories;
using PhoneBook.Core.Services;
using PhoneBook.Core.UnitOfWorks;
using PhoneBook.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Caching
{
    public class PhoneNumberServiceWithCaching : IPhoneNumberService
    {
        private const string CachePhoneNumberKey = "phoneNumbersCache";
        private readonly IMapper _mapper;
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public PhoneNumberServiceWithCaching(IMapper mapper, IPhoneNumberRepository phoneNumberRepository, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _phoneNumberRepository = phoneNumberRepository;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;

            if(!_memoryCache.TryGetValue(CachePhoneNumberKey, out _))
            {
                _memoryCache.Set(CachePhoneNumberKey, _phoneNumberRepository.GetPhoneNumbersWihContactAsync().Result);
            }
        }

        public async Task<PhoneNumber> AddAsync(PhoneNumber entity)
        {
            await _phoneNumberRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPhoneNumbers();

            return entity;
        }

        public async Task<IEnumerable<PhoneNumber>> AddRangeAsync(IEnumerable<PhoneNumber> entities)
        {
            await _phoneNumberRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllPhoneNumbers();

            return entities;

        }

        public async Task<bool> AnyAsync(Expression<Func<PhoneNumber, bool>> expression)
        {

            throw new NotImplementedException();
        }

        public Task<IEnumerable<PhoneNumber>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<PhoneNumber>>(CachePhoneNumberKey));
        }

        public Task<PhoneNumber> GetByIdAsync(int id)
        {
            var phoneNumber = _memoryCache.Get<List<PhoneNumber>>(CachePhoneNumberKey).FirstOrDefault(x => x.Id == id);
            if(phoneNumber == null)
            {
                throw new NotFoundException($"{typeof(PhoneNumber).Name} ({id}) not found");
            }
            return Task.FromResult(phoneNumber);
        }

        public Task<CustomResponseDto<List<PhoneNumbersWithContactDto>>> GetPhoneNumbersWihContactAsync()
        {
            var phoneNumbers = _memoryCache.Get<IEnumerable<List<PhoneNumber>>>(CachePhoneNumberKey);
            var phoneNumbersWithContactDto = _mapper.Map<List<PhoneNumbersWithContactDto>>(phoneNumbers);

            return Task.FromResult(CustomResponseDto<List<PhoneNumbersWithContactDto>>.Success(200, phoneNumbersWithContactDto));
        }

        public async Task RemoveAsync(PhoneNumber entity)
        {
            _phoneNumberRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPhoneNumbers();
        }

        public async Task RemoveRangeAsync(IEnumerable<PhoneNumber> entities)
        {
            _phoneNumberRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllPhoneNumbers();
        }

        public async Task UpdateAsync(PhoneNumber entity)
        {
            _phoneNumberRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPhoneNumbers();
        }

        public IQueryable<PhoneNumber> Where(Expression<Func<PhoneNumber, bool>> expression)
        {
            return _memoryCache.Get<List<PhoneNumber>>(CachePhoneNumberKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllPhoneNumbers()
        {
            _memoryCache.Set(CachePhoneNumberKey, await _phoneNumberRepository.GetAll().ToListAsync());
        }
    }
}
