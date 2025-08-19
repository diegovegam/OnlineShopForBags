using OnlineShopForBags.Models.Domain;
using OnlineShopForBags.Models.ViewModels;

namespace OnlineShopForBags.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> Add(Product product);
        public Task<List<Product>> GetAll(string? searchQuery, string? sortBy, string? sortDirection, int numberOfResultsPerPage = 10, int pageNumber = 1);
        public Task<Product> GetById(Guid Id);

        public Task<Product> Edit(Product productEdited);

        public Task<Product> Delete(Guid Id);

        public Task<int> CountProducts();
    }
}
