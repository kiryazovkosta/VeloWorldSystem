namespace VeloWorldSystem.DtoModels.BikeTypes
{
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Models.Entities.Models;

    public class BikeTypeViewModel : IMapFrom<BikeType>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}