using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.DtoModels;
using VeloWorldSystem.DtoModels.Bikes;

namespace VeloWorldSystem.Services.Contracts
{
    public interface IBikesService
    {
        Task<bool> ExistsAsync(int id);

        Task<bool> IsOwner(int id, string userId);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<T>> GetAllAsync<T>(string userId);

        Task CreateAsync(BikeInputModel model);

        Task UpdateAsync(int id,BikeInputModel model);

        Task DeleteAsync(int id);


    }
}
