using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Models;

namespace VeloWorldSystem.DtoModels.Bikes
{
    public class BikeListViewModel : IMapFrom<Bike>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
