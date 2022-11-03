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
    public class ApplicationUserChallengeConfiguration : IEntityTypeConfiguration<ApplicationUserChallenge>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserChallenge> builder)
        {
            builder.HasKey(uc => new { uc.UserId, uc.ChallengeId });
        }
    }
}
