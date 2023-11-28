using ContactsFS.Logic.DtoModels;
using ContactsFS.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactsFS.Web.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary> Gets all contacts from DB. </summary>
        /// <returns> Returns a list of contacts. </returns>
        [HttpGet]
        public async Task<List<ContactDto>> GetAllAsync()
        {
            return await _contactService.GetAllAsync();
        }

        /// <summary> Gets the contact from DB by Id. </summary>
        /// <param name="contactId"> Id must only be a positive number. </param>
        /// <returns> Returns the object with Id: <paramref name="contactId"/>. </returns>
        /// <remarks> Id must only be a positive number </remarks>
        /// <exception cref="Exception"></exception>
        [HttpGet("{contactId}")]
        public async Task<ContactDto> GetByIdAsync(int? contactId)
        {
            if (contactId == null)
                throw new Exception("Object Id can't be null.");

            return await _contactService.GetByIdAsync(contactId) ?? throw new Exception("Object with this Id don`t exist.");
        }

        /// <summary> Creates new contact. </summary>
        /// <param name="contactDto"> Object`s id must be null, name and birth date are required. </param>
        /// <returns> Returns operation status code. </returns>
        /// <remarks> Id must be null. Name and birth date are required. </remarks>
        /// <exception cref="Exception"></exception>
        [HttpPost("create")]
        public async Task CreateAsync([FromBody] ContactDto contactDto)
        {
            await _contactService.CreateAsync(contactDto);
        }

        /// <summary> Updates the contact in DB. </summary>
        /// <param name="contactDto"> Object`s must only be a positive number, name and birth date are required. </param>
        /// <returns> Returns operation status code. </returns>
        /// <remarks> Id must only be a positive number. Name and birth date are required. </remarks> 
        /// <exception cref="Exception"></exception>
        [HttpPut("update")]
        public async Task UpdateAsync([FromBody] ContactDto contactDto)
        {
            await _contactService.UpdateAsync(contactDto);
        }

        /// <summary> Deletes the contact from DB. </summary>
        /// <param name="contactId"> Id must only be a positive number. </param>
        /// <returns> Returns operation status code. </returns>
        /// <remarks> Id must only be a positive number. </remarks> 
        /// <exception cref="Exception"></exception>
        [HttpDelete("{contactId}")]
        public async Task DeleteAsync(int? contactId)
        {
            if (contactId == null)
                throw new Exception("Object Id can't be null.");

            await _contactService.DeleteAsync(contactId);
        }
    }
}
