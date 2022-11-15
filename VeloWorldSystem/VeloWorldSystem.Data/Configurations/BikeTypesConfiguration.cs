using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeloWorldSystem.Models.Entities.Models;

namespace VeloWorldSystem.Data.Configurations
{
    public class BikeTypesConfiguration : IEntityTypeConfiguration<BikeType>
    {
        public void Configure(EntityTypeBuilder<BikeType> builder)
        {
            builder.HasData(SeedBikeTypes());
        }

        private IEnumerable<BikeType> SeedBikeTypes()
        {
            return new List<BikeType>()
            {
                new BikeType { Id = 1, Name = "Road Bike" },
                new BikeType { Id = 2, Name = "Mountain Bike" },
                new BikeType { Id = 3, Name = "TT Bike" },
                new BikeType { Id = 4, Name = "Cross Bike" },
                new BikeType { Id = 5, Name = "Gravel Bike" }
            };
        }
    }
}
