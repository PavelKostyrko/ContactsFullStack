using ContactsFS.Logic.DtoModels;

namespace ContactsFS.Logic.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactDto>> GetAllAsync();
        Task<ContactDto> GetByIdAsync(int? contactId);
        Task CreateAsync(ContactDto contactDto);
        Task UpdateAsync(ContactDto contactDto);
        Task DeleteAsync(int? contactId);
    }
}
