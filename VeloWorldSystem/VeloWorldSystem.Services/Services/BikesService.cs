using Microsoft.EntityFrameworkCore;
using VeloWorldSystem.Data.Contracts;
using VeloWorldSystem.DtoModels.Bikes;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Models;
using VeloWorldSystem.Services.Contracts;
using VeloWorldSystem.Common.Exceptions;

namespace VeloWorldSystem.Services.Services
{
    public class BikesService : IBikesService
    {
        private readonly IDeletableRepository<Bike> bikesRepo;

        public BikesService(IDeletableRepository<Bike> bikesRepoParam)
        {
            this.bikesRepo = bikesRepoParam ?? throw new ArgumentNullException(nameof(bikesRepo));
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

        public async Task<bool> ExistsAsync(int id)
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
            var bike = await this.bikesRepo.AllAsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            if (bike == null)
            {
                throw new NotFoundException(nameof(Bike), id);
            }

            return bike.To<T>();
        }

        public async Task<bool> IsOwner(int id, string userId)
        {
            if (!await this.ExistsAsync(id))
            {
                return false;
            }

            return (await this.bikesRepo.AllAsNoTracking().FirstAsync(b => b.Id == id)).UserId == userId;
        }

        public async Task UpdateAsync(int id, BikeInputModel model)
        {
            if (!await this.ExistsAsync(id) )
            {
                throw new NotFoundException(nameof(Bike), id);
            }

            if( !await this.IsOwner(id, model.UserId))
            {
                throw new NotAuthenticatedException(nameof(Bike), id);
            }

            var bike = this.bikesRepo.All().First(b => b.Id == id);
            bike.Name= model.Name;
            bike.Brand = model.Brand;
            bike.Model = model.Model;
            bike.Notes = model.Notes;
            bike.Weight = model.Weight;
            bike.BikeTypeId= model.BikeTypeId;
            this.bikesRepo.Update(bike);
            await this.bikesRepo.SaveChangesAsync();
        }
    }
}
