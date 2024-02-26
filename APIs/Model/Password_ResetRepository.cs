using Microsoft.EntityFrameworkCore;

namespace webAPI.Model
{
    public class Password_ResetRepository : IAPIs<Password_Reset>
    {
        db _db;
        public Password_ResetRepository(db db)
        {
            _db = db;
        }

        public async Task Delete(int id)
        {
            var getid=await _db.password_resets.FindAsync(id);
            _db.password_resets.Remove(getid);
            await  _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Password_Reset>> Get()
        {
            return await _db.password_resets.ToListAsync();
        }


        // get by ID
        public async Task<Password_Reset> Get(int id)
        {

        return await _db.password_resets.FindAsync(id);
        }
        // GET BY CURRENCY CODE
        public async Task<IEnumerable<Password_Reset>> Get(string getEmail)
        {
			getEmail = getEmail.ToLower();
			var output = await _db.password_resets.Where(or => or.email==(getEmail)).ToListAsync();
            return output;
        }

		// GET BY CURRENCY CODE AND NAME  
		public async Task<IEnumerable<Password_Reset>> Get(string email, string token)
		{
			email = email.ToLower();

			// Fetch users from the database
			var password_s = await _db.password_resets

				.Where(password => password.email.Equals(email))
				.ToListAsync();

			// Perform case-sensitive password comparison on the client side
			return password_s.Where(user => user.token.Equals(token));
		}



		public async Task<Password_Reset> Post(Password_Reset password_reset)
        {
			password_reset.email = password_reset.email.ToLower();
            _db.password_resets.AddAsync(password_reset);
            await _db.SaveChangesAsync();
            return password_reset;
        }

        public async Task Put(Password_Reset password_reset)
        {
			password_reset.email = password_reset.email.ToLower();

			_db.Entry(password_reset).State = EntityState.Modified;

			await _db.SaveChangesAsync();

        }
	}
}
