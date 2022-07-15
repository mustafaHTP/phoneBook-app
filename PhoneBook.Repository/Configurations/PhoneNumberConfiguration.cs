using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Configurations
{
    internal class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.PhoneNo).IsRequired().HasMaxLength(10);

            //explicit way to show relation between Contact and PhoneNumber
            builder.HasOne(x => x.Contact).WithMany(x => x.PhoneNumbers).HasForeignKey(x => x.ContactId);

            builder.ToTable("PhoneNumbers");
        }
    }
}
