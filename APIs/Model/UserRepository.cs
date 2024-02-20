using Microsoft.EntityFrameworkCore;

namespace webAPI.Model
{
    public class UserRepository : IAPIs<User>
    {
        db _db;
        public UserRepository(db db)
        {
            _db = db;
        }

        public async Task Delete(int id)
        {
            var getid=await _db.users.FindAsync(id);
            _db.users.Remove(getid);
            await  _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<User>> Get()
        {
            return await _db.users.ToListAsync();
        }


        // get by ID
        public async Task<User> Get(int id)
        {
        return await _db.users.FindAsync(id);
        }
        // GET BY CURRENCY CODE
        public async Task<IEnumerable<User>> Get(string getEmail)
        {
            var output = await _db.users.Where(or => or.email==(getEmail)).ToListAsync();
            return output;
        }

        // GET BY CURRENCY CODE AND NAME  
        public async Task<IEnumerable<User>> Get(string email = "", string password = "")
        {
            return await _db.users.Where(or => or.email==(email) && or.password==(password)).ToListAsync();

        }

        public async Task<User> Post(User user)
        {
            _db.users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task Put(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
