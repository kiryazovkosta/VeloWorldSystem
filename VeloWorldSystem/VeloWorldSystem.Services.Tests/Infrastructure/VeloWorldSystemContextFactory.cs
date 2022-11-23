using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Common.Constants;
using VeloWorldSystem.Data;
using VeloWorldSystem.DtoModels.Bikes;
using VeloWorldSystem.Models.Entities.Identity;
using VeloWorldSystem.Models.Entities.Models;

namespace VeloWorldSystem.Services.Tests.Infrastructure
{
    public class VeloWorldSystemContextFactory
    {
        public static VeloWorldSystemDbContext Create(bool empty = false)
        {
            var builder = new DbContextOptionsBuilder<VeloWorldSystemDbContext>();

            var options = builder.Options;
            options = new DbContextOptionsBuilder<VeloWorldSystemDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var dbContext = new VeloWorldSystemDbContext(options);

            dbContext.Database.EnsureCreated();
            Console.WriteLine($"Create {dbContext}");

            if (!empty)
            {
                SeedData(dbContext);
            }

            return dbContext;
        }

        public static void Destroy(VeloWorldSystemDbContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine($"Delete {context}");
            context.Dispose();
        }

        private static void SeedData(VeloWorldSystemDbContext context)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            context.Users.AddRange(
                new List<ApplicationUser>()
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
                });

            context.Roles.AddRange(
                new List<ApplicationRole>()
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
                });

            context.UserRoles.AddRange(
                new List<IdentityUserRole<string>>()
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

            context.BikeTypes.AddRange(new List<BikeType>()
            {
                new BikeType 
                { 
                    Id = 1, 
                    Name = "Road Bike", 
                    Bikes = new List<Bike>() 
                    {
                        new Bike() { Id = 1, Name = "Cube AMS", Brand = "Cube", Model = "AMS SL 100", Weight = 10.50, UserId = "a45b8508-7efc-4623-9798-747a484f8820" }
                    } 
                },
                new BikeType 
                { 
                    Id = 2, 
                    Name = "Mountain Bike"
                },
                new BikeType 
                { 
                    Id = 3, 
                    Name = "TT Bike", 
                    Bikes = new List<Bike>() 
                    {
                        new Bike() { Id = 2, Name = "Scott Spark", Brand = "Scot", Model = "Spark RC", Weight = 11.30, UserId = "3816a499-e914-41cf-826a-f5cf586080be" },
                        new Bike() { Id = 3, Name = "Ram XL", Brand = "Ram", Model = "XL 23", Weight = 14.00, UserId = "a45b8508-7efc-4623-9798-747a484f8820" },
                        new Bike() { Id = 4, Name = "Cube Reaction", Brand = "Cube", Model = "Reaction M", Weight = 13.50, UserId = "a45b8508-7efc-4623-9798-747a484f8820" }
                    } 
                },
                new BikeType 
                { 
                    Id = 4, 
                    Name = "Cross Bike", 
                    Bikes = new List<Bike>() 
                    {
                        new Bike() { Id = 5, Name = "Drag Work", Brand = "Drag", Model = "C1", Weight = 16.00, UserId = "3816a499-e914-41cf-826a-f5cf586080be" },
                    } 
                },
                new BikeType 
                { 
                    Id = 5, 
                    Name = "Gravel Bike" 
                }
            });

            context.SaveChanges();

        }
    }
}
