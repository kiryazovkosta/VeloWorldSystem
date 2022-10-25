namespace VeloWorldSystem.Models.Entities.Identity
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using VeloWorldSystem.Models.Entities.Models;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
            Roles = new HashSet<IdentityUserRole<string>>();
            Claims = new HashSet<IdentityUserClaim<string>>();
            Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public ICollection<Activity> Activities { get; set; }
            = new HashSet<Activity>();

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
