namespace VeloWorldSystem.DtoModels.Bikes
{
    using AutoMapper;
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Models.Entities.Models;

    public class BikeViewModel : IMapFrom<Bike>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Weight { get; set; }
        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string? Notes { get; set; }

        public string BikeType { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Bike, BikeViewModel>()
                .ForMember(ds => ds.BikeType, opt => opt.MapFrom(src => src.BikeType.Name));
        }
    }
}