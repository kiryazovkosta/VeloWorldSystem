namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Abstract;
    using VeloWorldSystem.Models.Entities.Identity;
    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class Bike : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(BikeConstants.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(BikeType))]
        public int BikeTypeId { get; set; }
        public BikeType BikeType { get; set; } = null!;

        [Required]
        public double Weight { get; set; }

        [Required]
        [MaxLength(BikeConstants.BrandMaxLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(BikeConstants.ModelMaxLength)]
        public string Model { get; set; } = null!;

        [MaxLength(BikeConstants.NotesMaxLength)]
        public string? Notes { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public ICollection<Activity> Activities { get; set; }
            = new HashSet<Activity>();
    }
}
