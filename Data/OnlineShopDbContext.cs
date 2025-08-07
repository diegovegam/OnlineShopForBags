using Microsoft.EntityFrameworkCore;
using OnlineShopForBags.Models.Domain;

namespace OnlineShopForBags.Data
{
    public class OnlineShopDbContext : DbContext
    {

        public DbSet<Product> Product { get; set; }
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
