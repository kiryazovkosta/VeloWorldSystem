namespace VeloWorldSystem.DtoModels.Account
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Common.Constants;
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Models.Entities.Identity;
    using VeloWorldSystem.Web.Infrastructure.Attributes;

    public class RegisterInputModel : IMapTo<ApplicationUser>
    {
        [Required]
        [Display(Name = GlobalConstants.RegisterUserModel.FirstNameDispaly)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = GlobalConstants.RegisterUserModel.LastNameDispaly)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = GlobalConstants.RegisterUserModel.EmailNameDispaly)]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = GlobalConstants.RegisterUserModel.UserNameNameDispaly)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ApplicationUserConstants.PasswordMaxLength, 
            ErrorMessage = GlobalErrorMessages.RegisterUserModelErrors.PasswordLength, 
            MinimumLength = DataConstants.ApplicationUserConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = GlobalConstants.RegisterUserModel.PasswordNameDispaly)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = GlobalConstants.RegisterUserModel.ConfirmPasswordNameDispaly)]
        [Compare(nameof(Password), ErrorMessage = GlobalErrorMessages.RegisterUserModelErrors.PasswordCompare)]
        public string ConfirmPassword { get; set; } = null!;

        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = GlobalErrorMessages.RegisterUserModelErrors.AvatarError)]
        public IFormFile? Avatar { get; set; } 
    }
}