using Microsoft.EntityFrameworkCore;
using MyAuthDemoBackend.Models;

namespace MyAuthDemoBackend.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User { Id=1, UserName="Rithin", Password="12345"});
        }

    }
}
