namespace VeloWorldSystem.DtoModels.Bikes
{
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.DtoModels.BikeTypes;
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Models.Entities.Models;
    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class BikeInputModel : IMapTo<Bike>, IMapFrom<Bike>
    {
        [Required]
        [StringLength(BikeConstants.NameMaxLength, MinimumLength = BikeConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(BikeConstants.WeightMinValue, 
            BikeConstants.WeightMaxValue, 
            ErrorMessage = "Price Per Month must be a positive number and less than {2}")]
        public double Weight { get; set; }

        [Required]
        [StringLength(BikeConstants.BrandMaxLength, MinimumLength = BikeConstants.BrandMinLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(BikeConstants.ModelMaxLength, MinimumLength = BikeConstants.ModelMinLength)]
        public string Model { get; set; } = null!;

        [MaxLength(BikeConstants.NotesMaxLength)]
        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        [Display(Name = "Bike Type")]
        public int BikeTypeId { get; set; }

        public string UserId { get; set; } = null!;

        public IEnumerable<BikeTypeViewModel> BikeTypes { get; set; }
            = new HashSet<BikeTypeViewModel>();
    }
}
