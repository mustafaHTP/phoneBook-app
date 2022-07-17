using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Models;

namespace PhoneBook.Repository.Seeds
{
    internal class PhoneNumberSeed : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasData(
                new PhoneNumber
                {
                    Id = 1,
                    ContactId = 1,
                    PhoneNo = "05386221584",
                    CreatedDate = DateTime.Now
                },
                new PhoneNumber
                {
                    Id = 2,
                    ContactId = 1,
                    PhoneNo = "05384332199",
                    CreatedDate = DateTime.Now
                },
                new PhoneNumber
                {
                    Id = 3,
                    ContactId = 2,
                    PhoneNo = "05406004030",
                    CreatedDate = DateTime.Now
                },
                new PhoneNumber
                {
                    Id = 4,
                    ContactId = 2,
                    PhoneNo = "05332221036",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
