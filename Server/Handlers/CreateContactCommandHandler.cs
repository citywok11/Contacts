using Contacts.Server.Commands;
using Contacts.Server.Config;
using Contacts.Server.Entities;
using Contacts.Server.Mappers;
using Contacts.Server.Repositories;
using Contacts.Shared.Models;
using MediatR;

namespace Contacts.Server.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ICustomMapper _mapper;

        public CreateContactCommandHandler(IContactsRepository contactsRepository, ICustomMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await _contactsRepository.AddAsync(_mapper.MapContactsModelToContact(request.Contact));
            return;

        }
    }

}
