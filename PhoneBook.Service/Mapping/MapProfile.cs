using AutoMapper;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;

namespace PhoneBook.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Contact, ContactViewModel>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumberViewModel>().ReverseMap();

            CreateMap<PhoneNumber, PhoneNumbersWithContactViewModel>().ReverseMap();
            CreateMap<Contact, ContactWithPhoneNumbersViewModel>().ReverseMap();

        }
    }
}
