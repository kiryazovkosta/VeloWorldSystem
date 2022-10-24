namespace VeloWorldSystem.DtoModels.Demo
{
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Models.Entities.Demo;

    public class DemoViewModel : IMapFrom<Demo>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DemoDate { get; set; }
        public decimal Price { get; set; }
    }
}
