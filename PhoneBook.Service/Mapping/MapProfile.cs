using AutoMapper;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;

namespace PhoneBook.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumberDto>().ReverseMap();

            //CreateMap<PhoneNumberUpdateDto, PhoneNumber>();
            CreateMap<PhoneNumber, PhoneNumberUpdateDto>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumbersWithContactDto>();
            CreateMap<Contact, ContactWithPhoneNumbersDto>();

        }
    }
}
