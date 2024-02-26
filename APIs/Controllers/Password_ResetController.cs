using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Model;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Password_ResetController : ControllerBase
    {
        private readonly IAPIs<Password_Reset>  _password_reset;
        public Password_ResetController(IAPIs<Password_Reset> Password_Reset)
        {
            _password_reset = Password_Reset;
        }

        [HttpGet]
        public async Task<IEnumerable<Password_Reset>> GetUser()
        {
            return await _password_reset.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Password_Reset>> GetUser(int id)
        {
            return await _password_reset.Get(id);
        }
        [HttpGet("token")]
        public async Task<IEnumerable<Password_Reset>> GetUser(string email, string token)
        {
            return await _password_reset.Get(email, token);
        }
		[HttpGet("Email")]
		public async Task<IEnumerable<Password_Reset>> GetUser(string email)
		{
			return await _password_reset.Get(email);
		}




		[HttpPost]
        public async Task<ActionResult<Password_Reset>> Post([FromBody] Password_Reset Password_Reset)
        {
            var newCurrency = await _password_reset.Post(Password_Reset);
            return CreatedAtAction(nameof(GetUser), new { id = newCurrency.id }, newCurrency);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Password_Reset Password_Reset)
        {
            if (id != Password_Reset.id)
            {
                return BadRequest();
            }
            await  _password_reset.Put(Password_Reset);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delect(int id)
        {
            var Currencydelet = await  _password_reset.Get(id);
            if (Currencydelet == null)
            {
                return NotFound();
            }
            await   _password_reset.Delete(Currencydelet.id);
            return NoContent();
        }
    }
}
