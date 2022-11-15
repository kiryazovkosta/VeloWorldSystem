namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Abstract;
    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class Image : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(ImageConstants.UrlMaxLength)]
        public string Url { get; set; } = null!;

        [ForeignKey(nameof(Activity))]
        public int? ActivityId { get; set; }
        public Activity? Activity { get; set; }
    }
}
