using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.DTOs
{
    public class ContactWithPhoneNumbersDto:ContactDto
    {
        public List<PhoneNumberDto> PhoneNumbers{ get; set; }
    }
}
