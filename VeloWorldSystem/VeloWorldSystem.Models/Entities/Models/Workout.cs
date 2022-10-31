namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Abstract;

    public class Workout : BaseDeletableEntity<int>
    {
        public string Title { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(TrainingPlan))]
        public int TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; } = null!;
    }
}