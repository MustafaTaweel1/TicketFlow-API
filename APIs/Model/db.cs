using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Model
{
    public class db:DbContext
    {
        public DbSet<person> Persons { get; set; }
        public DbSet<Currency> Currencys { get; set; } 
        public DbSet<User> users { get; set; }
        public db(DbContextOptions<db> optinos) : base(optinos)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
    .Property(p => p.price)
    .HasPrecision(9, 5);
            base.OnModelCreating(modelBuilder);
        }

    }
}
