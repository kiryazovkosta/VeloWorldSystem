using Microsoft.AspNetCore.Mvc;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Services.Contracts;
using VeloWorldSystem.Web.Models.Demo;

namespace VeloWorldSystem.Web.Controllers
{
    public class DemosController : Controller
    {
        private readonly IDemoService demoService;

        public DemosController(IDemoService demoServiceParam)
        {
            this.demoService = demoServiceParam ?? throw new ArgumentNullException(nameof(demoService));
        }

        public async Task<IActionResult> Index()
        {
            var demo = await this.demoService.GetById(1);
            var model = demo.To<DemoViewModel>();
            return this.View(model);
        }
    }
}
