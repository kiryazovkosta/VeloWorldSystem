namespace VeloWorldSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using VeloWorldSystem.Models.Entities.Models;

    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder
            .HasOne(a => a.Bike)
            .WithMany(b => b.Activities)
            .HasForeignKey(a => a.BikeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
