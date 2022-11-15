namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Abstract;
    using VeloWorldSystem.Models.Entities.Identity;
    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class Comment : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(CommentConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Activity))]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;
    }
}