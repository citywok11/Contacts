using Contacts.Shared.Models;
using MediatR;

namespace Contacts.Server.Handlers
{
    public class GetAllContactsQuery : IRequest<List<ContactsResponse>>
    {
    }
}