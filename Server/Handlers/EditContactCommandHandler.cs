using Contacts.Server.Commands;
using Contacts.Server.Config;
using Contacts.Server.Entities;
using Contacts.Server.Mappers;
using Contacts.Server.Repositories;
using Contacts.Shared.Models;
using MediatR;

namespace Contacts.Server.Handlers
{
    public class EditContactCommandHandler : IRequestHandler<EditContactCommand>
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ICustomMapper _mapper;

        public EditContactCommandHandler(IContactsRepository contactsRepository, ICustomMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _mapper = mapper;
        }

        public async Task Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            await _contactsRepository.UpdateAsync(_mapper.MapContactsModelToContact(request.Contact));
            return;

        }
    }
}
