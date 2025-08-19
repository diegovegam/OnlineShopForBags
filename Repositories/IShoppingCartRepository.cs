using OnlineShopForBags.Models.Domain;

namespace OnlineShopForBags.Repositories
{
    public interface IShoppingCartRepository
    {
        public Task<ShoppingCart> Add(ShoppingCart shoppingCart);
    }
}
