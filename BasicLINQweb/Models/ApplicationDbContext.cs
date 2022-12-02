using Microsoft.EntityFrameworkCore;

namespace BasicLINQweb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
