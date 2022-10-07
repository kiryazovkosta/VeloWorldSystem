namespace VeloWorldSystem.Web.Models.Demo
{
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Services.Models;

    public class DemoViewModel : IMapFrom<DemoDto>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!; 
        public DateTime DemoDate { get; set; }
        public decimal Price { get; set; }
    }
}
