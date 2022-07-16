using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.DTOs
{
    public class ContactDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }
        public string NickName { get; set; }

    }
}

