using Microsoft.EntityFrameworkCore;
using OnlineShopForBags.Data;
using OnlineShopForBags.Models.Domain;

namespace OnlineShopForBags.Repositories
{
    public class ShoppingCartProductRepository : IShoppingCartProductRepository
    {

        private readonly OnlineShopDbContext onlineShopDbContext;

        public ShoppingCartProductRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.onlineShopDbContext = onlineShopDbContext;
        }
   
    
        public async Task<ShoppingCartProduct> Add(ShoppingCartProduct shopCartProduct)
        {
            await onlineShopDbContext.ShoppingCartProduct.AddAsync(shopCartProduct);
            await onlineShopDbContext.SaveChangesAsync();
            return shopCartProduct;
        }
        public async Task<int> GetQuantityProducts()
        {
            var shopCarProds = await onlineShopDbContext.ShoppingCartProduct.ToListAsync();
            int amountProds = 0;
            foreach (var shopCarProd in shopCarProds)
            {
                    amountProds += shopCarProd.Quantity;
            }

            return amountProds;
        }
    }
}
