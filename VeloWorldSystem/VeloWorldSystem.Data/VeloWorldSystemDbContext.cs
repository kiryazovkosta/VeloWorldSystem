namespace VeloWorldSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Models.Entities.Demo;
    using VeloWorldSystem.Models.Entities.Identity;
    using VeloWorldSystem.Models.Entities.Models;

    public class VeloWorldSystemDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public VeloWorldSystemDbContext(DbContextOptions<VeloWorldSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; } = null!;

        public DbSet<Demo> Demos { get; set; } = null!;
    }
}