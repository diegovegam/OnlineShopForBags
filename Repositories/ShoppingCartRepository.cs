using Microsoft.EntityFrameworkCore;
using OnlineShopForBags.Data;
using OnlineShopForBags.Models.Domain;

namespace OnlineShopForBags.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly OnlineShopDbContext onlineShopDbContext;

        public ShoppingCartRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.onlineShopDbContext = onlineShopDbContext;
        }
        public async Task<ShoppingCart> Add(ShoppingCart shoppingCart)
        {
            var currentShoppingCart = await onlineShopDbContext.ShoppingCart.FirstOrDefaultAsync();
            if ( currentShoppingCart is null)
            {
                await onlineShopDbContext.ShoppingCart.AddAsync(shoppingCart);
                await onlineShopDbContext.SaveChangesAsync();
            }
           
            return shoppingCart;
        }
    }
}
