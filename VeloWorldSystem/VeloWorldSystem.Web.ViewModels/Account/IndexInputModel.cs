namespace VeloWorldSystem.DtoModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class IndexInputModel
    {
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
