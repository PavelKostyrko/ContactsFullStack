using ContactsFS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsFS.Data.Configurations
{
    internal class ContactConfiguration : IEntityTypeConfiguration<ContactDb>
    {
        public void Configure(EntityTypeBuilder<ContactDb> builder)
        {
            builder.ToTable("Contacts").HasKey(o => o.Id); 
            builder.Property(_ => _.Id).ValueGeneratedOnAdd(); 
            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.BirthDate).IsRequired();
        }
    }
}
