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

        [HttpGet("login")]
        public async Task<IEnumerable<User>> GetUser(string email, string password)
        {
            return await _User.Get();
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


        //Same as Sign-Up
        [HttpPost("create")]
        public async Task<ActionResult<User>> Post(string userName, string email, string password, [FromBody] User User)
        {

            // Generate a random value for userUN
            Random random = new Random();
            User.userUN = random.Next();

            var newUser = await _User.Post(User);

            return CreatedAtAction(nameof(GetUser), new { id = newUser.id}, newUser);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Put(string userName, string email, string password, [FromBody] User User)
        {
            if(User.password != password)
            {
                return BadRequest();
            }

            await _User.Put(User);
            return NoContent();
        }

        [HttpDelete("destroy/{id}")]
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
