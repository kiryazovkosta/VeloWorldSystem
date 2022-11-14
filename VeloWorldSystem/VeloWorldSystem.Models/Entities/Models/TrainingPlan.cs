namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Models.Abstract;

    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class TrainingPlan : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(TrainingPlanConstants.TrainingPlanMaxTitleLength)]
        public string Title { get; set; } = null!;

        public ICollection<Workout> Workouts { get; set; } 
            = new HashSet<Workout>();

        public ICollection<ApplicationUserTrainingPlan> Users { get; set; } 
            = new HashSet<ApplicationUserTrainingPlan>();
    }
}