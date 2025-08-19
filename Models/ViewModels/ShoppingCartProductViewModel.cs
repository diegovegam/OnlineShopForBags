using OnlineShopForBags.Models.Domain;

namespace OnlineShopForBags.Models.ViewModels
{
    public class ShoppingCartProductViewModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public int Amount { get; set; }

        public Guid? ShoppingCartId { get; set; }

    }
}
