using Contacts.Server.Handlers;
using Contacts.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IMediator _mediator;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var query = new GetAllContactsQuery();
            var contacts = await _mediator.Send(query);
            return Ok(contacts);
        }
    }
}