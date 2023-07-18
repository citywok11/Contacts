using Contacts.Shared.Models;
using MediatR;

namespace Contacts.Server.Queries
{
    public class GetAllContactsQuery : IRequest<List<ContactsResponse>>
    {
    }
}