﻿namespace OnlineShopForBags.Models.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}
