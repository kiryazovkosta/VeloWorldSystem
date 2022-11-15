namespace VeloWorldSystem.Models.Entities.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using VeloWorldSystem.Models.Contracts;
    using VeloWorldSystem.Models.Entities.Models;

    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(ApplicationUserConstants.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationUserConstants.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationUserConstants.ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<ActivityLike> Likes { get; set; } = new HashSet<ActivityLike>();

        public ICollection<ApplicationUserChallenge> Challenges { get; set; } = new HashSet<ApplicationUserChallenge>();

        public ICollection<ApplicationUserTrainingPlan> TrainingPlans { get; set; } = new HashSet<ApplicationUserTrainingPlan>();


        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
             = new HashSet<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
            = new HashSet<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
            = new HashSet<IdentityUserLogin<string>>();

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
