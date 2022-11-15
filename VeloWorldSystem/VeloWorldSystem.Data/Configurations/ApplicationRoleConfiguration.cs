using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Common.Constants;
using VeloWorldSystem.Models.Entities.Identity;

namespace VeloWorldSystem.Data.Configurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(GetApplicationRoles());
        }

        private IEnumerable<ApplicationRole> GetApplicationRoles()
        {
            return new List<ApplicationRole>()
            {
                new ApplicationRole()
                {
                    Id = "22ec17b7-7cbd-4445-8713-5f2ab9397c31",
                    Name = DataConstants.ApplicationRoleConstants.MemberRole,
                    NormalizedName = DataConstants.ApplicationRoleConstants.MemberRole.ToUpper()
                },
                new ApplicationRole()
                {
                    Id = "f0389a1b-ffb9-4def-93ad-5417e1e6b30d",
                    Name = DataConstants.ApplicationRoleConstants.SuperMemberRole,
                    NormalizedName = DataConstants.ApplicationRoleConstants.SuperMemberRole.ToUpper()
                },
                new ApplicationRole()
                {
                    Id = "df3ae2b8-98db-434b-b250-136c48638390",
                    Name = DataConstants.ApplicationRoleConstants.AdminRole,
                    NormalizedName = DataConstants.ApplicationRoleConstants.AdminRole.ToUpper()
                }
            };
        }
    }
}
