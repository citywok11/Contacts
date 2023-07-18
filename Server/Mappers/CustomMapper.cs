using Contacts.Server.Commands;
using Contacts.Server.Entities;
using Contacts.Shared.Models;

namespace Contacts.Server.Mappers
{
    public class CustomMapper : ICustomMapper
    {
        public Contact MapContactsCommandToContact(CreateContactCommand contactCommand)
        {
            return new Contact
            {
                FirstName = contactCommand.FirstName,
                LastName = contactCommand.LastName,
                Email = contactCommand.Email,
                PhoneNumber = contactCommand.PhoneNumber,
                HouseNumber = (int)contactCommand.HouseNumber ,
                HouseName = contactCommand.HouseName,
                PostCode = contactCommand.PostCode
            };
        }

        public Task<ContactsResponse> MapContactsDtoToContactsResponse(Contact contacts)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContactsResponse>> MapContactsListDtoToContactsResponse(List<Contact> contacts)
        {
            return contacts.Select(contact => new ContactsResponse
            {
                ContactID = contact.ContactID,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                HouseNumber = contact.HouseNumber,
                HouseName = contact.HouseName,
                PostCode = contact.PostCode
            }).ToList();
        }

        public Contact MapContactsModelToContact(ContactsModel contactModel)
        {
            return new Contact
            {
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Email = contactModel.Email,
                PhoneNumber = contactModel.PhoneNumber,
                HouseNumber = contactModel.HouseNumber ?? default(int),
                HouseName = contactModel.HouseName,
                PostCode = contactModel.PostCode
            };
        }
    }
}
