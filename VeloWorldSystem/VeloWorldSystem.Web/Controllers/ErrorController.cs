namespace VeloWorldSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : BaseController
    {
        [Route("Error/{statusCode}")]
        public IActionResult ProcessErrorStatusCode(int statusCode)
        {
            var status = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404: return View("NotFound");
                default: return View("Unknown");
            }
        }
    }
}
