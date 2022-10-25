using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Models.Contracts;

namespace VeloWorldSystem.Data.Contracts
{
    public interface IDeletableRepository<T> : IRepository<T>
        where T : class, IDeletableEntity
    {
        IQueryable<T> AllWithDeleted();

        IQueryable<T> AllAsNoTrackingWithDeleted();

        void HardDelete(T entity);

        void Undelete(T entity);
    }
}
