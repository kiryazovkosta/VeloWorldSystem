using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Common.Exceptions;
using VeloWorldSystem.Data;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Demo;
using VeloWorldSystem.Services.Contracts;
using VeloWorldSystem.Services.Models;

namespace VeloWorldSystem.Services
{
    public class DemoService : IDemoService
    {
        private readonly VeloWorldSystemDbContext context;

        public DemoService(VeloWorldSystemDbContext contextParam)
        {
            this.context = contextParam;
        }

        public Task<IEnumerable<DemoDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DemoDto> GetById(int id)
        {
            var demo = await this.context.Demos.FirstOrDefaultAsync(d => d.Id == id);
            if (demo == null)
            {
                throw new NotFoundException(nameof(Demo), id);
            }

            return demo.To<DemoDto>();
        }
    }
}
