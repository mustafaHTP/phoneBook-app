using AutoMapper;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumberDto>().ReverseMap();

            //CreateMap<PhoneNumberUpdateDto, PhoneNumber>();
            CreateMap<PhoneNumber, PhoneNumberUpdateDto>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumbersWithContactDto>();
           
        }
    }
}
