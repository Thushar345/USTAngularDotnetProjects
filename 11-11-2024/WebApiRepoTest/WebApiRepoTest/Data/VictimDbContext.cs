using Microsoft.EntityFrameworkCore;
using WebApiRepoTest.Models;

namespace WebApiRepoTest.Data
{
    public class VictimDbContext : DbContext
    {
        public VictimDbContext(DbContextOptions<VictimDbContext> options) : base(options) { }
        public DbSet<Victim> victims { get; set; }


    }
}
