using APIs.Model.IRepository;
using APIs.Model.models;
using Microsoft.EntityFrameworkCore;
using webAPI.Model;

namespace APIs.Model.Repository
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
            var getid = await _db.users.FindAsync(id);
            _db.users.Remove(getid);
            await _db.SaveChangesAsync();
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
            getEmail = getEmail.ToLower();
            var output = await _db.users.Where(or => or.email == getEmail).ToListAsync();
            return output;
        }

        // GET BY CURRENCY CODE AND NAME  
        public async Task<IEnumerable<User>> Get(string email, string password)
        {
            email = email.ToLower();

            // Fetch users from the database
            var users = await _db.users

                .Where(user => user.email.Equals(email))
                .ToListAsync();

            // Perform case-sensitive password comparison on the client side
            return users.Where(user => user.password.Equals(password));
        }

		public async Task<IEnumerable<User>> GetAllDepartment(int depId)
		{
			return await _db.users.Where(d=>d.DepartmentId == depId).ToListAsync();
		}

		public async Task<User> Post(User user)
        {
            user.email = user.email.ToLower();
            _db.users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task Put(User user)
        {
            user.email = user.email.ToLower();

			_db.Entry(user).State = EntityState.Modified;

			await _db.SaveChangesAsync();

        }
    }
}
