namespace VeloWorldSystem.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;
    using VeloWorldSystem.Common.Constants;
    using VeloWorldSystem.Models.Entities.Identity;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(au => au.UserName).IsUnique();

            builder
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GetApplicationUsers());
        }

        private IEnumerable<ApplicationUser> GetApplicationUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            return new List<ApplicationUser>()
                {
                    new ApplicationUser()
                    {
                        Id = "a45b8508-7efc-4623-9798-747a484f8820",
                        FirstName = "Demo",
                        LastName = "User",
                        UserName= "user",
                        NormalizedUserName = "USER",
                        Email = "user@example.com",
                        NormalizedEmail = "USER@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "user123"),
                        ImageUrl = GlobalConstants.Images.DefaultAvatarImage
                    },
                    new ApplicationUser()
                    {
                        Id = "3816a499-e914-41cf-826a-f5cf586080be",
                        FirstName = "Super",
                        LastName = "User",
                        UserName= "super",
                        NormalizedUserName = "SUPER",
                        Email = "superuser@example.com",
                        NormalizedEmail = "SUPERUSER@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "super123"),
                        ImageUrl = GlobalConstants.Images.DefaultAvatarImage
                    },
                    new ApplicationUser()
                    {
                        Id = "0f30c80a-0577-4e35-8aae-93427e32debb",
                        FirstName = "Kosta",
                        LastName = "Kiryazov",
                        UserName= "admin",
                        NormalizedUserName = "ADMIN",
                        Email = "kosta.kiryazov@yahoo.com",
                        NormalizedEmail = "KOSTA.KIRYAZOV@YAHOO.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "admin123"),
                        ImageUrl = GlobalConstants.Images.DefaultAvatarImage
                    }
                };
        }
    }
}
