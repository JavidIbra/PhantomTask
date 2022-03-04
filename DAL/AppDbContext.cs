using Microsoft.EntityFrameworkCore;
using PhantomTask.Models.Entity;

namespace PhantomTask.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Block> Blocks { get; set; }

    }
}
