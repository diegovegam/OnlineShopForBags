using OnlineShopForBags.Models.Domain;

namespace OnlineShopForBags.Repositories
{
    public interface IShoppingCartProductRepository
    {
        public Task<ShoppingCartProduct> Add(ShoppingCartProduct shopCartProduct);

        public Task<int> GetQuantityProducts();
    }
}
