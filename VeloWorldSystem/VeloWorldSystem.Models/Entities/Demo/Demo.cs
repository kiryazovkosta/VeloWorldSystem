namespace VeloWorldSystem.Models.Entities.Demo
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Models.Abstract;

    public class Demo : BaseDeletableEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [MaxLength(255)]
        public string Content { get; set; } = null!;

        public DateTime DemoDate { get; set; }

        [Precision(15, 2)]
        public decimal Price { get; set; }
    }
}