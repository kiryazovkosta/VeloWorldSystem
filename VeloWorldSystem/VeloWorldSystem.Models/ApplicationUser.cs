namespace VeloWorldSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// ApplicationUser.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUser"/> class.
        /// </summary>
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        /// <summary>
        /// Gets or sets Claims.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        /// <summary>
        /// Gets or sets Logins.
        /// </summary>
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
