using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopForBags.Models.Domain
{
    public class ShoppingCartProduct
    {

        public int Quantity { get; set; }

        public int Amount { get; set; }

        public Guid ProductId { get; set; } //This is needed to be used as the foreign key of Products in the joined table. 

        public Product? Product { get; set; } // this is needed to tell DbContext the entity that will be part of the joined table. 

        public Guid ShoppingCartId { get; set; } //This is needed to be used as the foreign key of ShoppingCart in the joined table. 
        public ShoppingCart? ShoppingCart { get; set; } // this is needed to tell DbContext the entity that will be part of the joined table. 
    }
}
