using Contacts.Shared.Models;

namespace Contacts.Client.Services
{
    public interface IContactsService
    {
        Task<List<ContactsResponse>> GetContactsAsync();
        Task AddContactAsync(ContactsModel contact);
        Task EditContactASync(ContactsModel contact);

    }
}
