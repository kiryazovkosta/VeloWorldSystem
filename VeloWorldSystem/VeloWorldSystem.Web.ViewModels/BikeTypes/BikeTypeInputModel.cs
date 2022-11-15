namespace VeloWorldSystem.DtoModels.BikeTypes
{
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Common.Constants;
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Models.Entities.Models;
    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class BikeTypeInputModel : IMapTo<BikeType>, IMapFrom<BikeType>
    {
        [Required]
        [StringLength(BikeTypeConstants.NameMaxLength, 
            MinimumLength = BikeTypeConstants.NameMinLength, 
            ErrorMessage = GlobalErrorMessages.BikeTypeErrors.PasswordLength)]
        public string Name { get; set; } = null!;
    }
}
