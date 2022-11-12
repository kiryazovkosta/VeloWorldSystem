namespace VeloWorldSystem.Models.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VeloWorldSystem.Models.Abstract;
    using VeloWorldSystem.Models.Entities.Identity;
    using static VeloWorldSystem.Common.Constants.GlobalData.CommentConstants;

    public class Comment : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(CommentMaxContentLength)]
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