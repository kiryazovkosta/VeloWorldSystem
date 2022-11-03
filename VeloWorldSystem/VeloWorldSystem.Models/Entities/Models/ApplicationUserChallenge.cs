namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Entities.Identity;

    public class ApplicationUserChallenge
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Challenge))]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; } = null!;
    }
}