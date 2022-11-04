using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeloWorldSystem.GpxProcessing;
using VeloWorldSystem.Services.Libraries.Contracts;

namespace VeloWorldSystem.Web.Controllers
{
    public class TestController : BaseController
    {
        private readonly IGpxService gpxService;
        private readonly ICloudinaryService cloudinaryService;

        public TestController(
            IGpxService gpxServiceParam,
            ICloudinaryService cloudinaryServiceParam)
        {
            this.gpxService = gpxServiceParam ?? throw new ArgumentNullException(nameof(gpxService));
            this.cloudinaryService = cloudinaryServiceParam ?? throw new ArgumentNullException(nameof(cloudinaryService));
        }

        [HttpGet]
        public IActionResult Gpx()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Gpx(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var xml = await reader.ReadToEndAsync();
                var gpx = await this.gpxService.Get(xml);
                return View("ViewGpx", gpx);
            }
        }

        [HttpGet]
        public IActionResult Image()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Image(IFormFile file)
        {
            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploudAsync(file);
            }
            catch (Exception exception)
            {
                imageUrl = exception.Message;
            }

            return View("ViewImage", imageUrl);
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View("Pinokio");
        }
    }
}
