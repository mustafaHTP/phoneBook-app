using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.DTOs
{
    public class PhoneNumbersWithContactDto : PhoneNumberDto
    {
        public ContactDto Contact { get; set; }
    }
}
