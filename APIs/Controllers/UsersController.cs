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
        public async Task<ActionResult<IEnumerable<User>>> GetUser(string email, string password)
        {
            // Query the database for users with the exact email and password (case-sensitive)
            var users = await _User.Get(email, password);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("checkEmail")]
        public async Task<IEnumerable<User>> GetUser(string email)
        {
            return await _User.Get(email);
        }
     
        //Same as Create
        [HttpPost("signUp")]
        public async Task<ActionResult<User>> Post([FromBody] User User)
        {

            // Generate a random value for userUN
            Random random = new Random();
            User.userUN = random.Next();

            var newUser = await _User.Post(User);

            return CreatedAtAction(nameof(GetUser), new { id = newUser.id}, newUser);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Put([FromBody] User User)
        {
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
