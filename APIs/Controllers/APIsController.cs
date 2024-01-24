using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Model;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIsController : ControllerBase
    {
        private readonly IAPIs<person> _person;
        public APIsController(IAPIs<person> person)
        {
            _person = person;
        }

        [HttpGet]
        public async Task<IEnumerable<person>> GetPeople()
        {
            return await _person.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<person>> GetPerson(int id)
        {
            return await _person.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<person>> Post([FromBody] person person)
        {
            var newperson = await _person.Post(person);
            return CreatedAtAction(nameof(GetPerson), new { id = newperson.id }, newperson);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] person person)
        {
            if (id != person.id)
            {
                return BadRequest();
            }
            await _person.Put(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delect(int id)
        {
            var persondelet = await _person.Get(id);
            if (persondelet == null)
            {
                return NotFound();
            }
            await _person.Delete(persondelet.id);
            return NoContent();
        }
    }
}
