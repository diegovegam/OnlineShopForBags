using Microsoft.EntityFrameworkCore;
using OnlineShopForBags.Models.Domain;

namespace OnlineShopForBags.Data
{
    public class OnlineShopDbContext : DbContext
    {

        public DbSet<Product> Product { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<ShoppingCartProduct> ShoppingCartProduct { get; set; }
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCartProduct>()
                .HasKey(scp => new { scp.ShoppingCartId, scp.ProductId }); // Primary key of the table 

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne(scp => scp.ShoppingCart) //This means the table (ShoppingCartProduct) has one shoppping cart with
                .WithMany(sc => sc.Product)      //many products in it.
                .HasForeignKey(scp => scp.ShoppingCartId); //This is the foreign key for shopping cart

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne(scp => scp.Product)   //This means the table (ShoppingCartProduct) has one product with
                .WithMany(p => p.ShoppingCart) // many shopping carts in it.
                .HasForeignKey(scp => scp.ProductId); //This is the foreign key for product 
        }
    }
}
