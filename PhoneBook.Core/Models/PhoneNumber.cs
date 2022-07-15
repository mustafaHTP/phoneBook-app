using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Models
{
    public class PhoneNumber
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public string PhoneNo { get; set; }
    }
}
