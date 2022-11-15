using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VeloWorldSystem.DtoModels.Account
{
    public class LoginWithRecoveryCodeInputModel
    {
        //[BindProperty]
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Recovery Code")]
        public string RecoveryCode { get; set; } = null!;
    }
}
