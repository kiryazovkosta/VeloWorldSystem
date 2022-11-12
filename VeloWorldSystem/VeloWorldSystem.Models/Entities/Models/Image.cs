namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Abstract;
    using VeloWorldSystem.Models.Entities.Identity;
    using static VeloWorldSystem.Common.Constants.GlobalData.ImageConstants;

    public class Image : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(ImageMaxUrlLength)]
        public string Url { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUser))]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey(nameof(Activity))]
        public int? ActivityId { get; set; }
        public Activity? Activity { get; set; }
    }
}
