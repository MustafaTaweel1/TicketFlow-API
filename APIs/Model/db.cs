using APIs.Model.models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Model
{
    public class db:DbContext
    {
        public DbSet<User> users { get; set; }
		public DbSet<Password_Reset> password_resets { get; set; }

        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Department> departments { get; set; }
        public db(DbContextOptions<db> optinos) : base(optinos)
        {
            Database.EnsureCreated();
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Ticket>()
			//	.HasOne(t => t.Creator)
			//	.WithMany()
			//	.HasForeignKey(t => t.id_create)
			//	.OnDelete(DeleteBehavior.NoAction);

			//modelBuilder.Entity<Ticket>()
			//	.HasOne(t => t.Handler)
			//	.WithMany()
			//	.HasForeignKey(t => t.take_user)
			//	.OnDelete(DeleteBehavior.NoAction);
		modelBuilder.Entity<User>().ToTable("users");
		}
	}
}
