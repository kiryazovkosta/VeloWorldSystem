using VeloWorldSystem.Models.Abstract;
using VeloWorldSystem.Models.Entities.Identity;

namespace VeloWorldSystem.Models.Entities.Models
{
    public class TrainingPlan : BaseDeletableEntity<int>
    {
        public string Title { get; set; } = null!;

        public ICollection<Workout> Workouts { get; set; } = new HashSet<Workout>();

        public ICollection<ApplicationUserTrainingPlan> Users { get; set; } = new HashSet<ApplicationUserTrainingPlan>();
    }
}
