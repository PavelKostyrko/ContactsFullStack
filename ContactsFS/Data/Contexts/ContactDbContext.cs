using ContactsFS.Data.Configurations;
using ContactsFS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsFS.Data.Contexts
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ContactDb> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            modelBuilder.SeedData();
        }
    }
}
