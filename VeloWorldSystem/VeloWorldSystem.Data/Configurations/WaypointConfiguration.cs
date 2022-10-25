using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Models.Entities.Models;

namespace VeloWorldSystem.Data.Configurations
{
    public class WaypointConfiguration : IEntityTypeConfiguration<Waypoint>
    {
        public void Configure(EntityTypeBuilder<Waypoint> builder)
        {
            builder.HasKey(w => new { w.ActivityId, w.OrderNumber });
        }
    }
}
