namespace VeloWorldSystem.Data
{
    using Microsoft.AspNetCore.Identity;
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

        public DbSet<Image> Images { get; set; } = null!;

        public DbSet<Challenge> Challenges { get; set; } = null!;

        public DbSet<ApplicationUserChallenge> UserChallenges { get; set; } = null!;

        public DbSet<Workout> Workouts { get; set; } = null!;

        public DbSet<TrainingPlan> TrainingPlans { get; set; } = null!;

        //public DbSet<ApplicationUserTrainingPlan> UserTrainingPlans { get; set; } = null!;

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
            this.SetUsersAndRoles(builder);
            this.ConfigureIsDeletedIndex(builder);
            this.ConfigureGlobalDisableCascadeDelete(builder);
        }

        private void SetUsersAndRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>()
                .HasData(new List<IdentityUserRole<string>>()
                {
                    new IdentityUserRole<string>()
                    {
                        UserId = "a45b8508-7efc-4623-9798-747a484f8820",
                        RoleId = "22ec17b7-7cbd-4445-8713-5f2ab9397c31",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "3816a499-e914-41cf-826a-f5cf586080be",
                        RoleId = "f0389a1b-ffb9-4def-93ad-5417e1e6b30d",
                    },
                    new IdentityUserRole<string>()
                    {
                        UserId = "0f30c80a-0577-4e35-8aae-93427e32debb",
                        RoleId = "df3ae2b8-98db-434b-b250-136c48638390",
                    },
                    
                });
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