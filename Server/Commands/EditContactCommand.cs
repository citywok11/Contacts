using Contacts.Shared.Models;
using MediatR;
using Microsoft.Identity.Client;

namespace Contacts.Server.Commands
{
    public class EditContactCommand : IRequest
    {
        public EditContactCommand(ContactsModel contact)
        {
            Contact = contact;
        }

        public ContactsModel Contact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? HouseNumber { get; set; }
        public string? HouseName { get; set; }
        public string? PostCode { get; set; }
    }
}