using APIs.Model;
using APIs.Model.IRepository;
using APIs.Model.models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
		private readonly IAPIs<User> _users;
		private readonly ITickets<Ticket> _Ticket;
		private readonly IWebHostEnvironment hosting;

		public TicketsController(IAPIs<User> users, ITickets<Ticket> Ticket, IWebHostEnvironment hosting)
		{
			_Ticket = Ticket;
			_users = users;
			this.hosting = hosting;
		}


     

        [HttpGet]
        public async Task<IEnumerable<Ticket>> GetTicket()
        {
            return await _Ticket.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
			var ticket = await _Ticket.Get(id);
			if (ticket == null) return NotFound();
			return ticket;
		}
// update 
        [HttpGet("Status")]
        public async Task<IEnumerable<Ticket>> GetStatus(int status)
        {
            return await _Ticket.GetStatus(status);
        }
        [HttpGet("Create")]
        public async Task<IEnumerable<Ticket>> GetUserCreate(int idc)
        {
            return await _Ticket.GetUser_Create(idc);
        }
			[HttpGet("Take")]
			public async Task<IEnumerable<Ticket>> GetUserTake(int idt)
			{
				return await _Ticket.GetUser_Take(idt);
			}
		[HttpGet("Department")]
		public async Task<IEnumerable<Ticket>> GetDepartment(int idt)
		{
			return await _Ticket.GetDepartment(idt);
		}

		[HttpPost]
        public async Task<ActionResult<Ticket>> Post([FromBody] Ticket Ticket)
        {
            Ticket.Creator = await _users.Get(Ticket.id_create);
			Ticket.Handler = await _users.Get(Ticket.take_user);



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
