namespace OnlineShopForBags.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }

        public int Code { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl {  get; set; }

        public ICollection<ShoppingCartProduct> ShoppingCart { get; set; } // This is of type 'ShoppingCartProduct' because that's the joined table
                                                                           // where those ShoppingCarts' relationship will be stored. 
    }
}
