using OnlineShopForBags.Models.Domain;

namespace OnlineShopForBags.Models.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public int Code { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public List<Product> Products { get; set; }
    }
}
