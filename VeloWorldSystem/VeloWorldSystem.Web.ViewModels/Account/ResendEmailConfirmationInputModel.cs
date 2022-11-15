namespace VeloWorldSystem.DtoModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ResendEmailConfirmationInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}