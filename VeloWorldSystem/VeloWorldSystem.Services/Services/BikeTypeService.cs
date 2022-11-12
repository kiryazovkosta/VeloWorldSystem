namespace VeloWorldSystem.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Data.Contracts;
    using VeloWorldSystem.DtoModels.BikeTypes;
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Models.Entities.Models;
    using VeloWorldSystem.Services.Contracts;

    public class BikeTypeService : IBikeTypeService
    {
        private readonly IDeletableRepository<BikeType> bikeTypesRepo;

        public BikeTypeService(IDeletableRepository<BikeType> bikeTypes)
        {
            this.bikeTypesRepo = bikeTypes ?? throw new ArgumentNullException(nameof(BikeType));
        }

        public async Task<bool> Exists(int id)
        {
            return await this.bikeTypesRepo.AllAsNoTracking().AnyAsync(bt => bt.Id == id);
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var bikeType = (await this.bikeTypesRepo.All().FirstOrDefaultAsync(bt => bt.Id == id));
            return bikeType.To<T>();
        }


        public async Task<int> AddAsync(BikeTypeInputModel model)
        {
            var bikeType = model.To<BikeType>();
            await bikeTypesRepo.AddAsync(bikeType);
            await bikeTypesRepo.SaveChangesAsync();
            return bikeType.Id;
        }

        public async Task<IEnumerable<BikeTypeViewModel>> GetAllAsync()
        {
            return await this.bikeTypesRepo
                .AllWithDeleted()
                .To<BikeTypeViewModel>()
                .ToListAsync();
        }

        public async Task UpdateAsync(int id, BikeTypeInputModel model)
        {
            var bikeType = await this.bikeTypesRepo.All().FirstOrDefaultAsync(bt => bt.Id == id);
            if (bikeType != null)
            {
                bikeType.Name = model.Name;
                await this.bikeTypesRepo.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var bikeType = await this.bikeTypesRepo.All().FirstOrDefaultAsync(bt => bt.Id == id);
            this.bikeTypesRepo.Delete(bikeType);
            await this.bikeTypesRepo.SaveChangesAsync();
        }

        public async Task UndeleteAsync(int id)
        {
            var bikeType = await this.bikeTypesRepo.AllWithDeleted().FirstOrDefaultAsync(bt => bt.Id == id && bt.IsDeleted);
            this.bikeTypesRepo.Undelete(bikeType);
            await this.bikeTypesRepo.SaveChangesAsync();
        }
    }
}
