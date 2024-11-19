using Microsoft.EntityFrameworkCore;
using MyAuthDemoBackend.Models;

namespace MyAuthDemoBackend.Data
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User { Id = 1,UserName="admin",Password="1234" });
        }
    }
}
