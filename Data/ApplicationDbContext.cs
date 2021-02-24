using IGS.OnlineMarketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace IGS.OnlineMarketplace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}