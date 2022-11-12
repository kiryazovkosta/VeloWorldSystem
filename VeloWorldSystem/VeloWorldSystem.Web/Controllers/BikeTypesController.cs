namespace VeloWorldSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using VeloWorldSystem.DtoModels.BikeTypes;
    using VeloWorldSystem.Services.Contracts;
    using VeloWorldSystem.Services.Services;

    public class BikeTypesController : Controller
    {
        private readonly IBikeTypeService bikeTypeService;

        public BikeTypesController(IBikeTypeService bikeTypeServiceParam)
        {
            this.bikeTypeService = bikeTypeServiceParam ?? throw new ArgumentNullException(nameof(BikeTypeService));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await this.bikeTypeService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BikeTypeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.bikeTypeService.AddAsync(model);
            return RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.bikeTypeService.GetByIdAsync<BikeTypeInputModel>(id);
            if (model == null)
            {
                return this.NotFound();
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BikeTypeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.bikeTypeService.UpdateAsync(id, model);
            return RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public async Task<IActionResult> Undelete(int id)
        {
            return RedirectToAction(nameof(this.All));
        }
    }
}