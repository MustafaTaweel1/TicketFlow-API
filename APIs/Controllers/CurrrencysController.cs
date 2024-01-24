using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Model;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrrencysController : ControllerBase
    {
        private readonly IAPIs<Currency> _Currency;
        public CurrrencysController(IAPIs<Currency> Currency)
        {
            _Currency = Currency;
        }

        [HttpGet]
        public async Task<IEnumerable<Currency>> GetCurrency()
        {
            return await _Currency.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
            return await _Currency.Get(id);
        }
        [HttpGet("currencys")]
        public async Task<IEnumerable<Currency>> GetCurrency(string currency, string name)
        {
            return await _Currency.Get(currency, name);
        }
        [HttpGet("currency")]
        public async Task<IEnumerable<Currency>> GetCurrency(string currency)
        {
            return await _Currency.Get(currency);
        }




        [HttpPost]
        public async Task<ActionResult<Currency>> Post([FromBody] Currency Currency)
        {
            var newCurrency = await _Currency.Post(Currency);
            return CreatedAtAction(nameof(GetCurrency), new { id = newCurrency.id }, newCurrency);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Currency Currency)
        {
            if (id != Currency.id)
            {
                return BadRequest();
            }
            await _Currency.Put(Currency);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delect(int id)
        {
            var Currencydelet = await _Currency.Get(id);
            if (Currencydelet == null)
            {
                return NotFound();
            }
            await _Currency.Delete(Currencydelet.id);
            return NoContent();
        }
    }
}
