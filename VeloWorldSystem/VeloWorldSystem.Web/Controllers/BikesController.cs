namespace VeloWorldSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using VeloWorldSystem.DtoModels.Bikes;
    using VeloWorldSystem.Services.Contracts;

    public class BikesController : AuthorizedController
    {
        private readonly IBikesService bikesService;
        private readonly IBikeTypeService bikeTypeService;

        public BikesController(
            IBikesService bikesService,
            IBikeTypeService bikeTypeService,
            IUsersService usersService)
            : base(usersService)
        {
            this.bikesService = bikesService;
            this.bikeTypeService = bikeTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var bikeModel = await this.bikesService.GetAllAsync<BikeViewModel>(this.CurrentUserId);
            return View(bikeModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bikeModel = new BikeInputModel() { UserId = this.CurrentUserId, BikeTypes = await this.bikeTypeService.GetAllAsync() };
            return View(bikeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BikeInputModel bikeModel)
        {
            if (!await this.bikeTypeService.Exists(bikeModel.BikeTypeId))
            {
                this.ModelState.AddModelError(nameof(bikeModel.BikeTypeId), "Bike type does not exists.");
            }

            if (bikeModel.UserId != this.CurrentUserId)
            {
                this.ModelState.AddModelError(nameof(bikeModel.UserId), "User does not have a proper permmison for this operation.");
            }

            if (!ModelState.IsValid)
            {
                bikeModel.BikeTypes = await this.bikeTypeService.GetAllAsync();
                return View(bikeModel);
            }

            await this.bikesService.CreateAsync(bikeModel);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.bikesService.Exists(id))
            {
                return BadRequest();
            }

            if (!await this.bikesService.IsOwner(id, this.CurrentUserId))
            {
                return Unauthorized();
            }

            var bikeModel = await this.bikesService.GetByIdAsync<BikeInputModel>(id);
            bikeModel.BikeTypes = await this.bikeTypeService.GetAllAsync();
            return View(bikeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BikeInputModel bikeModel)
        {
            if (!await this.bikesService.Exists(id))
            {
                return NotFound();
            }

            if (!await this.bikesService.IsOwner(id, this.CurrentUserId))
            {
                return Unauthorized();
            }

            if (!await this.bikeTypeService.Exists(bikeModel.BikeTypeId))
            {
                this.ModelState.AddModelError(nameof(bikeModel.BikeTypeId), "Bike type does not exists.");
            }

            if (!ModelState.IsValid)
            {
                bikeModel.BikeTypes = await this.bikeTypeService.GetAllAsync();
                return View(bikeModel);
            }

            await this.bikesService.UpdateAsync(id, bikeModel);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.bikesService.Exists(id))
            {
                return NotFound();
            }

            await this.bikesService.DeleteAsync(id);
            return RedirectToAction(nameof(this.All));
        }
    }
}
