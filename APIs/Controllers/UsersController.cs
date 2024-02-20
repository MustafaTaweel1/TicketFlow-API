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

        /*
        [HttpGet("currencys")]
        public async Task<IEnumerable<User>> GetUser(string currency, string name)
        {
            return await _User.Get(currency, name);
        }
        [HttpGet("currency")]
        public async Task<IEnumerable<User>> GetUser(string name)
        {
            return await _User.Get(name);
        }
        */

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User User)
        {

            var newUser = await _User.Post(User);

            return CreatedAtAction(nameof(GetUser), new { id = newUser.id}, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] User User)
        {
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
