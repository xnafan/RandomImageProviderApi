using Microsoft.AspNetCore.Mvc;
using RandomImageProviderApi.Model;

namespace RandomImageProviderApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class RandomImageController : ControllerBase
    {
        
        private IImageProvider _imageProvider;

        public RandomImageController(IImageProvider imageprovider) =>_imageProvider = imageprovider;

        [HttpGet]
        public ActionResult Get()
        {
            var image = _imageProvider.GetImage();
            return File(image.GetContentsAsByteArray(), image.MimeType);
        }
    }
}