using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Demo;

namespace VeloWorldSystem.Services.Models
{
    public class DemoDto : IMapFrom<Demo>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DemoDate { get; set; }
        public decimal Price { get; set; }
    }
}