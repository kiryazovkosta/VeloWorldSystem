using Microsoft.AspNetCore.Mvc;

namespace VeloWorldSystem.Web.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
