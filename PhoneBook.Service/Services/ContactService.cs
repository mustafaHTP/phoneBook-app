using AutoMapper;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Repositories;
using PhoneBook.Core.Services;
using PhoneBook.Core.UnitOfWorks;

namespace PhoneBook.Service.Services
{
    public class ContactService : GenericService<Contact>, IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IGenericRepository<Contact> genericRepository, IUnitOfWork unitOfWork, IContactRepository contactRepository, IMapper mapper) : base(genericRepository, unitOfWork)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactWithPhoneNumbersViewModel> GetSingleContactByIdWithPhoneNumbersAsync(int contactId)
        {
            var contactWithPhoneNumbers = await _contactRepository.GetSingleContactByIdWithPhoneNumbersAsync(contactId);
            var contactWithPhoneNumbersDto = _mapper.Map<ContactWithPhoneNumbersViewModel>(contactWithPhoneNumbers);

            return contactWithPhoneNumbersDto;
        }
    }
}
