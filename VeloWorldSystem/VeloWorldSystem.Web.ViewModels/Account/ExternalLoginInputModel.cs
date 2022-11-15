using System;
namespace VeloWorldSystem.DtoModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
