using Microsoft.AspNetCore.Mvc;

namespace OnlineShopForBags.Controllers
{
    public class AdminProductController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
