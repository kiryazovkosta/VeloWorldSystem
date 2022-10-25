namespace TestTemplate.Data.Repositories
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Data;
    using VeloWorldSystem.Data.Contracts;
    using VeloWorldSystem.Data.Repositories;
    using VeloWorldSystem.Models.Contracts;

    public class EfDeletableRepository<T> : EfRepository<T>, IDeletableRepository<T>
        where T : class, IDeletableEntity
    {
        public EfDeletableRepository(VeloWorldSystemDbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All() => base.All().Where(x => !x.IsDeleted);

        public override IQueryable<T> AllAsNoTracking() => base.AllAsNoTracking().Where(x => !x.IsDeleted);

        public IQueryable<T> AllWithDeleted() => base.All().IgnoreQueryFilters();

        public IQueryable<T> AllAsNoTrackingWithDeleted() => base.AllAsNoTracking().IgnoreQueryFilters();

        public void HardDelete(T entity) => base.Delete(entity);

        public void Undelete(T entity)
        {
            entity.IsDeleted = false;
            entity.DeletedAt = null;
            this.Update(entity);
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;
            this.Update(entity);
        }
    }
}
