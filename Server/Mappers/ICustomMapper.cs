using Contacts.Server.Entities;
using Contacts.Shared.Models;

namespace Contacts.Server.Mappers
{
    public interface ICustomMapper
    {
        public List<ContactsResponse> MapContactsDtoToContactsResponse(List<Contact> contacts);
    }
}