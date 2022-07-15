using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Models
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }
        public string NickName { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

    }
}

