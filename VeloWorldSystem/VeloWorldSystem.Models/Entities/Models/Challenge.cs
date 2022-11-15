namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Common.Enumerations;
    using VeloWorldSystem.Models.Abstract;

    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class Challenge : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(ChallengeConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ChallengeConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime BeginDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        public ChallengeType ChallengeType { get; set; }

        [Required]
        public bool IsActive { get; set; }  

        public ICollection<ApplicationUserChallenge> Users = new HashSet<ApplicationUserChallenge>();
    }
}
