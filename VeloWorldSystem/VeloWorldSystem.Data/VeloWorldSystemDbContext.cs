namespace VeloWorldSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Models.Entities.Identity;
    using VeloWorldSystem.Models.Entities.Models;

    public class VeloWorldSystemDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public VeloWorldSystemDbContext(DbContextOptions<VeloWorldSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<BikeType> BikeTypes { get; set; } = null!;

        public DbSet<Bike> Bikes { get; set; } = null!;

        public DbSet<Activity> Activities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            this.ConfigureEntityTypes(builder);
        }

        private void ConfigureEntityTypes(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}