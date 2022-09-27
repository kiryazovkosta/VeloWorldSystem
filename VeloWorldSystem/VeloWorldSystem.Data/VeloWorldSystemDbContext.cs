namespace VeloWorldSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Models;

    /// <summary>
    /// VeloWorldSystemDbContext.
    /// </summary>
    public class VeloWorldSystemDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VeloWorldSystemDbContext"/> class.
        /// </summary>
        /// <param name="options">options.</param>
        public VeloWorldSystemDbContext(DbContextOptions<VeloWorldSystemDbContext> options)
            : base(options)
        {
        }
    }
}