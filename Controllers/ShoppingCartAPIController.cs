using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopForBags.Models.Domain;
using OnlineShopForBags.Models.ViewModels;
using OnlineShopForBags.Repositories;
using OnlineShopForBags.Services;

namespace OnlineShopForBags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartAPIController : ControllerBase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IShoppingCartProductRepository shoppingCartProductRepository;

        public ShoppingCartAPIController(IShoppingCartRepository shoppingCartRepository, IShoppingCartProductRepository shoppingCartProductRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.shoppingCartProductRepository = shoppingCartProductRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] ShoppingCartProductViewModel viewModel)
        {
            var shoppingCartService = new ShoppingCartService(this.HttpContext);

            var cartId = shoppingCartService.GetOrCreateCartId();

            ShoppingCart shoppingCart = new ShoppingCart
            { Id = Guid.Parse(cartId)};

            await shoppingCartRepository.Add(shoppingCart);

            ShoppingCartProduct shoppingCartProduct = new ShoppingCartProduct
            {
                ProductId = viewModel.ProductId,
                ShoppingCartId = Guid.Parse(cartId),
                Quantity = viewModel.Quantity,
                Amount = viewModel.Amount
            };

            await shoppingCartProductRepository.Add(shoppingCartProduct);

            return Ok();
        }

        [HttpGet]
        [Route("GetQuantityProdsInShopCart")]
        public async Task<IActionResult> GetQuantityProdsInShopCart ()
        {
            int quantityOfProdsInShopCar = await shoppingCartProductRepository.GetQuantityProducts();

            return Ok(quantityOfProdsInShopCar);
        }
    }
}
