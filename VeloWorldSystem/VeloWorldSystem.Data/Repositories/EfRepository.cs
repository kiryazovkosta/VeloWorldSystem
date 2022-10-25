namespace VeloWorldSystem.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Data.Contracts;

    public class EfRepository<T> : IRepository<T>
        where T : class
    {
        public EfRepository(VeloWorldSystemDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = Context.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        protected VeloWorldSystemDbContext Context { get; set; }

        public virtual IQueryable<T> All() => DbSet;

        public virtual IQueryable<T> AllAsNoTracking() => DbSet.AsNoTracking();

        public virtual Task AddAsync(T entity) => DbSet.AddAsync(entity).AsTask();

        public virtual void Update(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity) => DbSet.Remove(entity);

        public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }
    }
}
