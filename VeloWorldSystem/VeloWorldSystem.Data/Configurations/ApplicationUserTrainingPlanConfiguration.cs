namespace VeloWorldSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using VeloWorldSystem.Models.Entities.Models;

    public class ApplicationUserTrainingPlanConfiguration : IEntityTypeConfiguration<ApplicationUserTrainingPlan>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserTrainingPlan> builder)
        {
            builder.HasKey(utp => new { utp.TrainingPlanId, utp.UserId });
        }
    }
}
