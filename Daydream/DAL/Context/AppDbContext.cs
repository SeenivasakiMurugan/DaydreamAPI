using Daydream.BAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Daydream.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Part> Parts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }
    }
}
