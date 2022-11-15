namespace VeloWorldSystem.DtoModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Common.Constants;

    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [Display(Name = GlobalConstants.LoginUserModel.Remember)]
        public bool RememberMe { get; set; }
    }
}