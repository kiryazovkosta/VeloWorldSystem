using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.DtoModels.BikeTypes;
using VeloWorldSystem.Models.Abstract;

namespace VeloWorldSystem.Services.Contracts
{
    public interface IBikeTypeService
    {
        Task<bool> ExistsAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<IEnumerable<BikeTypeViewModel>> GetAllAsync();

        Task<int> AddAsync(BikeTypeInputModel model);

        Task UpdateAsync(int id, BikeTypeInputModel model);

        Task DeleteAsync(int id);

        Task UndeleteAsync(int id);
    }
}
