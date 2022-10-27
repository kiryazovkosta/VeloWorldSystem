namespace VeloWorldSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VeloWorldSystem.Models.Entities.Models;

    public class ActivityLikeConfiguration : IEntityTypeConfiguration<ActivityLike>
    {
        public void Configure(EntityTypeBuilder<ActivityLike> builder)
        {
            builder.HasKey(al => new { al.ActivityId, al.UserId });
        }
    }
}
