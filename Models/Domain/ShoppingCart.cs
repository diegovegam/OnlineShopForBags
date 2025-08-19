namespace OnlineShopForBags.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }

        public ICollection<ShoppingCartProduct> Product { get; set; } // This is of type 'ShoppingCartProduct' because that's the joined table
                                                                      // where those products' relationship will be stored. 
    }
}
