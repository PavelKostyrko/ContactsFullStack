using ContactsFS.Data.Models;
using ContactsFS.Logic.DtoModels;

namespace ContactsFS.Logic.Builders
{
    public static class ContactBuilder
    {
        public static ContactDto Build(ContactDb db)
        {
            return db != null ? 
                new ContactDto()
                {
                    Id = db.Id,
                    Name = db.Name,
                    MobilePhone = db.MobilePhone,
                    JobTitle = db.JobTitle,
                    BirthDate = db.BirthDate
                }
                : null;
        }
        public static List<ContactDto> Build(List<ContactDb> dbs)
        {
            return dbs?.Select(o => Build(o))?.ToList();
        }

        public static ContactDb Build(ContactDto dto)
        {
            return dto != null ? 
                new ContactDb()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    MobilePhone = dto.MobilePhone,
                    JobTitle = dto.JobTitle,
                    BirthDate = dto.BirthDate
                }
                : null;
        }

        public static List<ContactDb>  Build(List<ContactDto> dtos)
        {
            return dtos?.Select(o => Build(o))?.ToList();
        }
    }
}
