using Microsoft.AspNetCore.Mvc;
using webAPI.Model;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITickets<Ticket> _Ticket;
        public TicketsController(ITickets<Ticket> Ticket)
        {
            _Ticket = Ticket;
        }

        [HttpGet]
        public async Task<IEnumerable<Ticket>> GetTicket()
        {
            return await _Ticket.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            return await _Ticket.Get(id);
        }

        [HttpGet("Status")]
        public async Task<IEnumerable<Ticket>> GetStatus(int status)
        {
            return await _Ticket.GetStatus(status);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> Post([FromBody] Ticket Ticket)
        {
            var newCurrency = await _Ticket.Post(Ticket);
            return CreatedAtAction(nameof(GetTicket), new { id = newCurrency.id }, newCurrency);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Ticket Ticket)
        {
            if (id != Ticket.id)
            {
                return BadRequest();
            }
            await _Ticket.Put(Ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delect(int id)
        {
            var Currencydelet = await _Ticket.Get(id);
            if (Currencydelet == null)
            {
                return NotFound();
            }
            await _Ticket.Delete(Currencydelet.id);
            return NoContent();
        }
    }
}
