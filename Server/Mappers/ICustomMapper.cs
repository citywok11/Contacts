using Contacts.Server.Commands;
using Contacts.Server.Entities;
using Contacts.Shared.Models;

namespace Contacts.Server.Mappers
{
    public interface ICustomMapper
    {
        public Task<ContactsResponse> MapContactsDtoToContactsResponse(Contact contacts);
        public Task<List<ContactsResponse>> MapContactsListDtoToContactsResponse(List<Contact> contacts);

        public Contact MapContactsCommandToContact(CreateContactCommand contactCommand);
        public Contact MapContactsModelToContact(ContactsModel contactModel);
    }
}