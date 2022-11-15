using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloWorldSystem.DtoModels.Account
{
    public class DeletePersonalDataInputModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
