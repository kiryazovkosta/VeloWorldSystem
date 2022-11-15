namespace VeloWorldSystem.Models.Entities.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Abstract;
    using VeloWorldSystem.Models.Entities.Identity;
    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class Activity : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(ActivityConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(ActivityConstants.DescriptionMaxLength)]
        public string? Description { get; set; } = null!;

        [MaxLength(ActivityConstants.PrivateNotesMaxLength)]
        public string? PrivateNotes { get; set; } = null!;

        [Required]
        [Precision(ActivityConstants.DestancePrecision, ActivityConstants.DestanceScale)]
        public decimal Destance { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public int Elevation { get; set; }

        [Required]
        [ForeignKey(nameof(Bike))]
        public int BikeId { get; set; }
        public Bike Bike { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public ICollection<Waypoint> Waypoints { get; set; }
            = new HashSet<Waypoint>();

        public ICollection<Image> Images { get; set; }
            = new HashSet<Image>();

        public ICollection<ActivityLike> Likes { get; set; }
            = new HashSet<ActivityLike>();

        public ICollection<Comment> Comments { get; set; }
            = new HashSet<Comment>();

    }
}