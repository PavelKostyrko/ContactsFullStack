using ContactsFS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsFS.Data
{
    internal static class ModelBuilderExtension
    {
        internal static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactDb>().HasData(
                    new ContactDb()
                    {
                        Id = 1,
                        Name = "Pavel",
                        MobilePhone = "375295053167",
                        JobTitle = "Developer",
                        BirthDate = "1990-05-12"
                    },
                    new ContactDb()
                    {
                        Id = 2,
                        Name = "Ivan",
                        MobilePhone = "375441101533",
                        JobTitle = "Driver",
                        BirthDate = "2000-04-13"
                    },
                    new ContactDb()
                    {
                        Id = 3,
                        Name = "Alex",
                        MobilePhone = "375441471238",
                        JobTitle = "Designer",
                        BirthDate = "1992-03-18"
                    },
                    new ContactDb()
                    {
                        Id = 4,
                        Name = "Sergey",
                        MobilePhone = "375447130154",
                        JobTitle = "HR",
                        BirthDate = "1997-11-22"
                    },
                    new ContactDb()
                    {
                        Id = 5,
                        Name = "Victor",
                        MobilePhone = "375291347306",
                        JobTitle = "Developer",
                        BirthDate = "1993-08-14"
                    }
                );
        }
    }
}
