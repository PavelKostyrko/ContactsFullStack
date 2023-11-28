using ContactsFS.Data.Contexts;
using ContactsFS.Logic.Builders;
using ContactsFS.Logic.DtoModels;
using ContactsFS.Logic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsFS.Logic.Services
{
    public class ContactService : BaseService, IContactService
    {
        public ContactService(ContactDbContext context) : base(context)
        {}

        /// <summary> Gets all contacts from DB. </summary>
        /// <returns> Returns a list of contacts. </returns>
        public async Task<List<ContactDto>> GetAllAsync()
        {
           var contactDbs = await _context.Contacts.OrderBy(o => o.Id).ToListAsync().ConfigureAwait(false);

            return ContactBuilder.Build(contactDbs);
        }

        /// <summary> Gets the contact from DB by Id. </summary>
        /// <param name="contactId">Id must only be a positive number. </param>
        /// <returns> Returns the object with Id: <paramref name="contactId"/>. </returns>
        /// <exception cref="Exception"></exception>
        public async Task<ContactDto> GetByIdAsync(int? contactId)
        {
            if (contactId != null)
            {
                var contactDb = await _context.Contacts.SingleOrDefaultAsync(o => o.Id == contactId).ConfigureAwait(false);

                return ContactBuilder.Build(contactDb);
            }
            else throw new Exception("Object Id can't be null.");
        }

        /// <summary> Creates new contact. </summary>
        /// <param name="contactDto"> Object`s id must be null, name and birth date are required. </param>
        /// <returns> Returns operation status code. </returns>
        /// <exception cref="Exception"></exception>
        public async Task CreateAsync(ContactDto contactDto)
        {
            if (contactDto.Id == null)
            {
                await _context.Contacts.AddAsync(ContactBuilder.Build(contactDto)).ConfigureAwait(false);

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch
                {
                    throw new Exception("Object has not been created.");
                }
            }
            else throw new Exception("The contact you are trying to create have invalid information");
        }

        /// <summary> Updates the contact in DB. </summary>
        /// <param name="contactDto"> Object`s must only be a positive number, name and birth date are required.</param>
        /// <returns> Returns operation status code. </returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(ContactDto contactDto)
        {
            if (contactDto != null)
            {
                var contactDb = await _context.Contacts.SingleOrDefaultAsync(o => o.Id == contactDto.Id).ConfigureAwait(false);

                if (contactDb != null)
                {
                    contactDb.Name = contactDto.Name;
                    contactDb.MobilePhone = contactDto.MobilePhone;
                    contactDb.JobTitle = contactDto.JobTitle;
                    contactDb.BirthDate = contactDto.BirthDate;

                    try
                    {
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    catch
                    {
                        throw new Exception("Object has not been updated.");
                    }
                }
                else throw new Exception("There is no object you are trying to update."); 
            }
            else throw new Exception("The contact you are trying to change is invalid");

        }

        /// <summary> Deletes the contact from DB. </summary>
        /// <param name="contactId"> Id must only be a positive number. </param>
        /// <returns> Returns operation status code. </returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(int? contactId)
        {
            if (contactId != null)
            {
                var contactDb = await _context.Contacts.SingleOrDefaultAsync(o => o.Id == contactId).ConfigureAwait(false);

                if (contactDb != null)
                {
                    _context.Contacts.Remove(contactDb);

                    try
                    {
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    catch
                    {
                        throw new Exception("Object has not been deleted.");
                    }
                }
                else throw new Exception("There is no object you are trying to deleted.");

            }
            else throw new Exception("The contact you are trying to delete is invalid");   
        }  
    }
}
