namespace VeloWorldSystem.Models.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Models.Abstract;

    using static VeloWorldSystem.Common.Constants.GlobalData.BikeTypeConstants;

    public class BikeType : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(BikeTypeMaxNameLength)]
        public string Name { get; set; } = null!;

        public ICollection<Bike> Bikes { get; set; } = new HashSet<Bike>();
    }
}