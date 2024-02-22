using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Model;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAPIs<User> _User;
        public UsersController(IAPIs<User> User)
        {
           _User = User;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _User.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _User.Get(id);
        }
        [HttpGet("users")]
        public async Task<IEnumerable<User>> GetUser(string email, string password)
        {
            return await _User.Get(email, password);
        }
		[HttpGet("Email")]
		public async Task<IEnumerable<User>> GetUser(string email)
		{
			return await _User.Get(email);
		}




		[HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User User)
        {
            var newCurrency = await _User.Post(User);
            return CreatedAtAction(nameof(GetUser), new { id = newCurrency.id }, newCurrency);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] User User)
        {
            if (id != User.id)
            {
                return BadRequest();
            }
            await _User.Put(User);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delect(int id)
        {
            var Currencydelet = await _User.Get(id);
            if (Currencydelet == null)
            {
                return NotFound();
            }
            await  _User.Delete(Currencydelet.id);
            return NoContent();
        }
    }
}
