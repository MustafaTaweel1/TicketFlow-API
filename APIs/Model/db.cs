using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Model
{
    public class db:DbContext
    {
        public DbSet<User> users { get; set; }
        public db(DbContextOptions<db> optinos) : base(optinos)
        {
            Database.EnsureCreated();
        }

    }
}
