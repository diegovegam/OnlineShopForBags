using OnlineShopForBags.Data;
using OnlineShopForBags.Models.Domain;
using OnlineShopForBags.Models.ViewModels;

namespace OnlineShopForBags.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext onlineShopDbContext;

        public ProductRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.onlineShopDbContext = onlineShopDbContext;
        }
        public async Task<Product> Add(Product product)
        {
            await onlineShopDbContext.AddAsync(product);
            await onlineShopDbContext.SaveChangesAsync();
            return product;

        }
    }
}
