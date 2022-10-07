namespace VeloWorldSystem.Services.Contracts
{
    using VeloWorldSystem.Services.Models;

    public interface IDemoService
    {
        public Task<IEnumerable<DemoDto>> GetAll();

        public Task<DemoDto> GetById(int id);
    }
}
