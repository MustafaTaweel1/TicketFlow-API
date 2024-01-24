using Microsoft.EntityFrameworkCore;

namespace webAPI.Model
{
    public class CurrencyRepository : IAPIs<Currency>
    {
        db _db;
        public CurrencyRepository(db db)
        {
            _db = db;
        }

        public async Task Delete(int id)
        {
            var getid=await _db.Currencys.FindAsync(id);
            _db.Currencys.Remove(getid);
            await  _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Currency>> Get()
        {
            return await _db.Currencys.ToListAsync();
        }


        // get by ID
        public async Task<Currency> Get(int id)
        {
        return await _db.Currencys.FindAsync(id);
        }
        // GET BY CURRENCY CODE
        public async Task<IEnumerable<Currency>> Get(string currency)
        {
            var output = await _db.Currencys.Where(or => or.currency.Contains(currency)).ToListAsync();
            return output;
        }

        // GET BY CURRENCY CODE AND NAME  
        public async Task<IEnumerable<Currency>> Get(string currency = "", string name = "")
        {
            return await _db.Currencys.Where(or => or.currency.Contains(currency) && or.Name.Contains(name)).ToListAsync();

        }

        public async Task<Currency> Post(Currency Currency)
        {
            _db.Currencys.AddAsync(Currency);
            await _db.SaveChangesAsync();
            return Currency;
        }

        public async Task Put(Currency Currency)
        {
            _db.Entry(Currency).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
