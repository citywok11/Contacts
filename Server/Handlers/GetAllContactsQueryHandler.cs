using Contacts.Server.Mappers;
using Contacts.Server.Queries;
using Contacts.Server.Repositories;
using Contacts.Shared.Models;
using MediatR;

namespace Contacts.Server.Handlers
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactsResponse>>
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ICustomMapper _mapper;

        public GetAllContactsQueryHandler(IContactsRepository contactsRepository, ICustomMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _mapper = mapper;
        }

        public async Task<List<ContactsResponse>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactsRepository.GetAllAsync();
            return await _mapper.MapContactsListDtoToContactsResponse(contacts);
        }

    }
}