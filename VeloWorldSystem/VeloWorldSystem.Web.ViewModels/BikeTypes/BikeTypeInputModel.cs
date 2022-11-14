using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Models;
using static VeloWorldSystem.Common.Constants.DataConstants.BikeTypeConstants;

namespace VeloWorldSystem.DtoModels.BikeTypes
{
    public class BikeTypeInputModel : IMapTo<BikeType>, IMapFrom<BikeType>
    {
        [Required]
        [StringLength(BikeTypeMaxNameLength, MinimumLength = BikeTypeMinNameLength, ErrorMessage = "Name must be a string with length between {1} and {2} symbols.")]
        public string Name { get; set; } = null!;
    }
}
