using OnlineShopForBags.Models.Domain;
using OnlineShopForBags.Models.ViewModels;

namespace OnlineShopForBags.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> Add(Product product);
    }
}
