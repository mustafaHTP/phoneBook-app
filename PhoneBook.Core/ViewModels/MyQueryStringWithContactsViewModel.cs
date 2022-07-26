using PhoneBook.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.ViewModels
{
    public class MyQueryStringWithContactsViewModel
    {
        public List<ContactViewModel>? ContactViewModels { get; set; }
        public MyQueryStringViewModel? MyQueryViewModel { get; set; }
    }
}
