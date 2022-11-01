using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml;
using VeloWorldSystem.DtoModels;
using VeloWorldSystem.GpxProcessing;

namespace VeloWorldSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGpxService _gpxService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger,
            IGpxService gpxService)
        {
            _logger = logger;
            _gpxService = gpxService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Privacy(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var xml = await reader.ReadToEndAsync();
                var gpx = await _gpxService.Get(xml);
                return Json(gpx);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}