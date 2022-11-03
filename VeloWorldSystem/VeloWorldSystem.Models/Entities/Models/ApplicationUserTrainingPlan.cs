namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Entities.Identity;

    public class ApplicationUserTrainingPlan
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;


        [ForeignKey(nameof(TrainingPlan))]
        public int TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; } = null!;

        public bool IsComplited { get; set; }
    }
}
