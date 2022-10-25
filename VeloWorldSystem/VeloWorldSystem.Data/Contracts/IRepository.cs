using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloWorldSystem.Data.Contracts
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IQueryable<T> All();

        IQueryable<T> AllAsNoTracking();

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<int> SaveChangesAsync();
    }
}
