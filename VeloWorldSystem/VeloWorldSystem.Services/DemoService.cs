using Microsoft.EntityFrameworkCore;
using VeloWorldSystem.Common.Exceptions;
using VeloWorldSystem.Data;
using VeloWorldSystem.DtoModels.Demo;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Demo;
using VeloWorldSystem.Services.Contracts;

namespace VeloWorldSystem.Services
{
    public class DemoService : IDemoService
    {
        private readonly VeloWorldSystemDbContext context;

        public DemoService(VeloWorldSystemDbContext contextParam)
        {
            this.context = contextParam;
        }

        public Task<IEnumerable<DemoViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DemoViewModel> GetById(int id)
        {
            var demo = await this.context.Demos.FirstOrDefaultAsync(d => d.Id == id);
            if (demo == null)
            {
                throw new NotFoundException(nameof(Demo), id);
            }

            return demo.To<DemoViewModel>();
        }
    }
}
