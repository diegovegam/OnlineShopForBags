using Microsoft.EntityFrameworkCore;
using OnlineShopForBags.Data;
using OnlineShopForBags.Models.Domain;
using OnlineShopForBags.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShopForBags.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext onlineShopDbContext;

        public ProductRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.onlineShopDbContext = onlineShopDbContext;
        }
        public async Task<Product> Add(Product product)
        {
            await onlineShopDbContext.Product.AddAsync(product);
            await onlineShopDbContext.SaveChangesAsync();
            return product;

        }

        public async Task<int> CountProducts()
        {
            return await onlineShopDbContext.Product.CountAsync();
        }

        public async Task<Product> Delete(Guid Id)
        {
            var product = await onlineShopDbContext.Product.FindAsync(Id);
            onlineShopDbContext.Product.Remove(product);
            await onlineShopDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Edit(Product productEdited)
        {
            var currentProduct = await onlineShopDbContext.Product.FindAsync(productEdited.Id);

            currentProduct.Id = productEdited.Id;
            currentProduct.Name = productEdited.Name;
            currentProduct.Description = productEdited.Description;
            currentProduct.Price = productEdited.Price;
            currentProduct.Code = productEdited.Code;
            currentProduct.Quantity = productEdited.Quantity;
            currentProduct.ImageUrl = productEdited.ImageUrl;

            await onlineShopDbContext.SaveChangesAsync();

            return currentProduct;
        }

        public async Task<List<Product>> GetAll(string? searchQuery, string? sortBy, string? sortDirection, int numberOfResultsPerPage = 10, int pageNumber = 1)
        {
            var queryProducts = onlineShopDbContext.Product.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                queryProducts = queryProducts.Where(product => product.Name.Contains(searchQuery) | product.Code.ToString().Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(sortBy) && !string.IsNullOrWhiteSpace(sortDirection))
            {
                if (sortBy == "Name")
                {
                    if (sortDirection == "Asc")
                    {
                        queryProducts = queryProducts.OrderBy(product => product.Name);
                    }
                    else
                    {
                        queryProducts = queryProducts.OrderByDescending(product => product.Name);
                    }
                }

                if (sortBy == "Price")
                {
                    if (sortDirection == "Asc")
                    {
                        queryProducts = queryProducts.OrderBy(product => product.Price);
                    }
                    else
                    {
                        queryProducts = queryProducts.OrderByDescending(product => product.Price);
                    }
                }

                if (sortBy == "Quantity")
                {
                    if (sortDirection == "Asc")
                    {
                        queryProducts = queryProducts.OrderBy(product => product.Quantity);
                    }
                    else
                    {
                        queryProducts = queryProducts.OrderByDescending(product => product.Quantity);
                    }
                }

            }

            var skipResults = (pageNumber - 1) * numberOfResultsPerPage;
            queryProducts = queryProducts.Skip(skipResults).Take(numberOfResultsPerPage);
            return await queryProducts.ToListAsync();

        }

        public async Task<Product> GetById(Guid Id)
        {
            return await onlineShopDbContext.Product.FirstOrDefaultAsync(p => p.Id == Id);

        }
    }
}
