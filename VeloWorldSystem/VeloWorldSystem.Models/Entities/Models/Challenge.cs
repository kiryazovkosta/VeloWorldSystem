namespace VeloWorldSystem.Models.Entities.Models
{
    using VeloWorldSystem.Common.Enumerations;
    using VeloWorldSystem.Models.Abstract;
    using VeloWorldSystem.Models.Entities.Identity;

    public class Challenge : BaseDeletableEntity<int>
    {
        public string Title { get; set; } = null!;
        
        public string Description { get; set; } = null!;

        public DateTime BeginDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public ChallengeType ChallengeType { get; set; }

        public bool IsActive { get; set; }  

        public ICollection<ApplicationUserChallenge> Users = new HashSet<ApplicationUserChallenge>();
    }
}
