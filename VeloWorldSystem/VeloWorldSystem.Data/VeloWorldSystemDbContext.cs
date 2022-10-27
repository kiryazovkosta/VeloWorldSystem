namespace VeloWorldSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Models.Contracts;
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

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Waypoint> Waypoints { get; set; } = null!;

        public DbSet<ActivityLike> ActivityLikes { get; set; } = null!;

        public override int SaveChanges() 
            => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
            => this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.ConfigureEntityTypes(builder);
            this.ConfigureIsDeletedIndex(builder);
            this.ConfigureGlobalDisableCascadeDelete(builder);
        }

        private void ConfigureGlobalDisableCascadeDelete(ModelBuilder builder)
        {
            var entityTypes = builder.Model.GetEntityTypes().ToList();
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys()
                .Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private void ConfigureIsDeletedIndex(ModelBuilder builder)
        {
            var deletableEntityTypes = builder.Model
                .GetEntityTypes()
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
                        foreach (var deletableEntityType in deletableEntityTypes)
                        {
                            builder.Entity(deletableEntityType.ClrType)
                                .HasIndex(nameof(IDeletableEntity.IsDeleted));
            }
        }

        private void ConfigureEntityTypes(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedAt == default)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedAt = DateTime.UtcNow;
                }
            }
        }
    }
}