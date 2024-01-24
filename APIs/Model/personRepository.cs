using Microsoft.EntityFrameworkCore;

namespace webAPI.Model
{
    public class personRepository : Iperson<person>
    {
        db _db;
        public personRepository(db db) {
            _db = db;
                }
        public async Task Delete(int id)
        {
            var getid = await _db.Persons.FindAsync(id);
            _db.Persons.Remove(getid);

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<person>> Get()
        {
            return await _db.Persons.ToListAsync();
        }

        public async Task<person> Get(int id)
        {
            return await _db.Persons.FindAsync(id);
        }

        public Task<person> Get(string currency)
        {
            throw new NotImplementedException();
        }

        public async Task<person> Post(person person)
        {
            _db.Persons.AddAsync(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task Put(person person)
        {
            _db.Entry(person).State = EntityState.Modified;
            await _db.SaveChangesAsync();
          }
    }
}
