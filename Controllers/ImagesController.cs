using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopForBags.Repositories;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopForBags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageUploadRepository imageUploadRepository;

        public ImagesController(IImageUploadRepository imageUploadRepository)
        {
            this.imageUploadRepository = imageUploadRepository;

        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {

            var imageUrl = await imageUploadRepository.UploadAsync(image);
            if (imageUrl == null)
            {
                return Problem("Something went wrong", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageUrl });
        }
    }
}
