using Contacts.Server.Commands;
using Contacts.Server.Queries;
using Contacts.Shared.Models;
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

        public ContactsController(IMediator mediator, ILogger<ContactsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var query = new GetAllContactsQuery();
            var contacts = await _mediator.Send(query);
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult> AddContact([FromBody] ContactsModel contact)
        {
            {
                await _mediator.Send(new CreateContactCommand(contact));
                return StatusCode(201);
            }
        }
    }
}