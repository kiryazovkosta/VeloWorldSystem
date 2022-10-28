namespace VeloWorldSystem.Models.Entities.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using VeloWorldSystem.Models.Entities.Models;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
            //Roles
            //Claims 
            //Logins 
        }

        [Required]
        [ForeignKey(nameof(Image))]
        public int ImageId { get; set; }
        public Image Image { get; set; }

        public ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<ActivityLike> Likes { get; set; } = new HashSet<ActivityLike>();


        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
             = new HashSet<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
            = new HashSet<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
            = new HashSet<IdentityUserLogin<string>>();
    }
}
