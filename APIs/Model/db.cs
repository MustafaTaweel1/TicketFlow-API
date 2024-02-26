using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Model
{
    public class db:DbContext
    {
        public DbSet<User> users { get; set; }
		public DbSet<Password_Reset> password_resets { get; set; }

        public DbSet<Ticket> tickets { get; set; }
        public db(DbContextOptions<db> optinos) : base(optinos)
        {
            Database.EnsureCreated();
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("users");
		}


	}
}
