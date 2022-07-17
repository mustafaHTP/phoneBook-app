using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Models;

namespace PhoneBook.Repository.Configurations
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Profession).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.WebAddress).HasMaxLength(100);
            builder.Property(x => x.NickName).HasMaxLength(100);


            //same name DbSet<contact> "Contacts"
            builder.ToTable("Contacts");
        }
    }
}
