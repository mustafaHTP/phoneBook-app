using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Seeds
{
    internal class ContactSeed : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Mustafa",
                    LastName = "Hatipoğlu",
                    Email = "mustafa@outlook.com",
                    Profession = "Student",
                    Address = "Üsküdar/İstanbul",
                    WebAddress = "www.api.com",
                    NickName = "mustafa",
                    CreatedDate = DateTime.Now
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    Email = "ahmet@gmail.com",
                    Profession = "Student",
                    Address = "Ümraniye/İstanbul",
                    WebAddress = "www.google.com",
                    NickName = "ahmet",
                    CreatedDate = DateTime.Now
                }
                );
        }
    }
}
