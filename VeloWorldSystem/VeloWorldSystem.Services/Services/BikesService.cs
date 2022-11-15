using Microsoft.EntityFrameworkCore;
using VeloWorldSystem.Data.Contracts;
using VeloWorldSystem.DtoModels.Bikes;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Models;
using VeloWorldSystem.Services.Contracts;

namespace VeloWorldSystem.Services.Services
{
    public class BikesService : IBikesService
    {
        private readonly IDeletableRepository<Bike> bikesRepo;

        public BikesService(IDeletableRepository<Bike> bikesRepoParam)
        {
            bikesRepo= bikesRepoParam ?? throw new ArgumentNullException(nameof(bikesRepo));
        }

        public async Task CreateAsync(BikeInputModel model)
        {
            var bike = model.To<Bike>();
            await this.bikesRepo.AddAsync(bike);
            await this.bikesRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bike = await this.bikesRepo.All().FirstOrDefaultAsync(bt => bt.Id == id);
            this.bikesRepo.Delete(bike);
            await this.bikesRepo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await this.bikesRepo.AllAsNoTracking().AnyAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string userId)
        {
            var bikes = await this.bikesRepo.AllAsNoTracking().Where(b => b.UserId == userId).To<T>().ToListAsync();
            return bikes;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var bike = await this.bikesRepo.AllAsNoTracking().To<T>().FirstOrDefaultAsync();
            return bike;
        }

        public async Task<bool> IsOwner(int id, string userId)
        {
            if (!await this.Exists(id))
            {
                return false;
            }

            return (await this.bikesRepo.AllAsNoTracking().FirstAsync(b => b.Id == id)).UserId == userId;
        }

        public async Task UpdateAsync(int id, BikeInputModel model)
        {
            if (await this.Exists(id) && await this.IsOwner(id, model.UserId))
            {
                var bike = model.To<Bike>();
                bike.Id = id;
                this.bikesRepo.Update(bike);
                await this.bikesRepo.SaveChangesAsync();
            }

        }
    }
}
