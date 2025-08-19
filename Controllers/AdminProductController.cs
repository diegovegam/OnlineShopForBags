using Microsoft.AspNetCore.Mvc;
using OnlineShopForBags.Models.Domain;
using OnlineShopForBags.Models.ViewModels;
using OnlineShopForBags.Repositories;
using System.Threading.Tasks;

namespace OnlineShopForBags.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IProductRepository productRepository;


        public AdminProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [HttpGet]
        public IActionResult Add()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel viewModel)
        {


            var product = new Product
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Code = viewModel.Code,
                Quantity = viewModel.Quantity,
                ImageUrl = viewModel.ImageUrl
            };

            await productRepository.Add(product);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? searchQuery, string? sortBy, string? sortDirection, int numberOfResultsPerPage = 2, int pageNumber = 1)
        {
            var totalProducts = await productRepository.CountProducts();
            var totalPages = Math.Ceiling((decimal)totalProducts / numberOfResultsPerPage);

            if (pageNumber > totalPages)
            {
                pageNumber--;
            }

            if (pageNumber < 1)
            {
                pageNumber++;
            }

            ViewBag.TotalPages = totalPages;
            ViewBag.SearchQuery = searchQuery;
            ViewBag.SortBy = sortBy;
            ViewBag.SortDirection = sortDirection;
            ViewBag.NumberOfResultsPerPage = numberOfResultsPerPage;
            ViewBag.PageNumber = pageNumber;
            var products = await productRepository.GetAll(searchQuery, sortBy, sortDirection, numberOfResultsPerPage, pageNumber);
            var viewModel = new ProductViewModel
            {
                Products = products
            };
            return View(viewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Edit (Guid Id)
        {
            var product = await productRepository.GetById(Id);
            ViewBag.Name = false;
            ViewBag.Price = false;
            ViewBag.Quantity = false;
            ViewBag.Code = false;
            ViewBag.ImageUrl = false;
            ViewBag.Description = false;

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Description = product.Description,
                Code = product.Code,
                ImageUrl = product.ImageUrl
            };

            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel viewModel)
        {
            var currentProduct = await productRepository.GetById(viewModel.Id);

            ViewBag.Name = currentProduct.Name == viewModel.Name ? false : true;
            ViewBag.Price = currentProduct.Price == viewModel.Price ? false : true;
            ViewBag.Quantity = currentProduct.Quantity == viewModel.Quantity ? false : true;
            ViewBag.Code = currentProduct.Code == viewModel.Code ? false : true;
            ViewBag.ImageUrl = currentProduct.ImageUrl == viewModel.ImageUrl ? false : true;
            ViewBag.Description = currentProduct.Description == viewModel.Description ? false : true;


            var product = new Product
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                Description = viewModel.Description,
                Code = viewModel.Code,
                ImageUrl = viewModel.ImageUrl
            };

            await productRepository.Edit(product);

            var viewModelUpdated = new ProductViewModel
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                Description = viewModel.Description,
                Code = viewModel.Code,
                ImageUrl = viewModel.ImageUrl
            };

            return View(viewModelUpdated);

        }

        [HttpPost]
        public async Task<IActionResult> Delete (Guid Id)
        {
            await productRepository.Delete(Id);
            return RedirectToAction("GetAll");
        }

    }
}
