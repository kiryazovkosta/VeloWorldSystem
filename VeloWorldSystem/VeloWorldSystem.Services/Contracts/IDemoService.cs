namespace VeloWorldSystem.Services.Contracts
{
    using VeloWorldSystem.DtoModels.Demo;

    public interface IDemoService
    {
        public Task<IEnumerable<DemoViewModel>> GetAll();

        public Task<DemoViewModel> GetById(int id);
    }
}