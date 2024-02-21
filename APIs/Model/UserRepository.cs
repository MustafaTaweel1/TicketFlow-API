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

        public async Task<IEnumerable<User>> Get(string email = "", string password = "")
        {
            // Convert email and password to lowercase for case-insensitive comparison
            var lowercaseEmail = email.ToLower();
            var lowercasePassword = password.ToLower();
            return await _db.users.Where(or => or.email == lowercaseEmail && or.password == lowercasePassword).ToListAsync();
        }

        public async Task<User> Post(User user)
        {
            user.email = user.email.ToLower(); // Convert email to lowercase
            await _db.users.AddAsync(user); // Add the user to the database
            await _db.SaveChangesAsync(); // Save changes to the database
            return user;
        }


        public async Task Put(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
