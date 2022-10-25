namespace VeloWorldSystem.Models.Entities.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Abstract;
    using VeloWorldSystem.Models.Entities.Identity;
    using static VeloWorldSystem.Common.Constants.GlobalData.Activity;

    public class Activity : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(ActivityMaxTitleLength)]
        public string Title { get; set; } = null!;

        [MaxLength(ActivityMaxDescriptionLength)]
        public string? Description { get; set; } = null!;

        [MaxLength(ActivityMaxPrivateNotesLength)]
        public string? PrivateNotes { get; set; } = null!;

        [Required]
        [Precision(7, 3)]
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
    }
}