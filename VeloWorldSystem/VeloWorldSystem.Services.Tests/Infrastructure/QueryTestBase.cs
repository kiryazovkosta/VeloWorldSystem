using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Data;
using VeloWorldSystem.DtoModels;
using VeloWorldSystem.Mapping;

namespace VeloWorldSystem.Services.Tests.Infrastructure
{
    public class QueryTestBase : IDisposable
    {
        private readonly VeloWorldSystemDbContext context;

        public QueryTestBase()
        {
            this.context = VeloWorldSystemContextFactory.Create();

            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        public void Dispose()
        {
            VeloWorldSystemContextFactory.Destroy(this.context);
        }

        public VeloWorldSystemDbContext Context => this.context;
    }
}
