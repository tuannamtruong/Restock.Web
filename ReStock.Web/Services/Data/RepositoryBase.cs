using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReStock.Web.Services.Data
{
    /// <summary>
    /// Base Repository. Containing basic generic CRUD operations.
    /// </summary>
    /// <typeparam name="TDbContext">DBContext</typeparam>
    /// <typeparam name="TEntity">Model class</typeparam>
    public class RepositoryBase<TDbContext, TEntity> : IRepositoryBase<TEntity> 
        where TDbContext : DbContext
        where TEntity : class
    {
        protected TDbContext DbContext { get; }

        public RepositoryBase(TDbContext dbContextCreator)
        {
            DbContext = dbContextCreator;
        }

        public virtual async Task AddAsync(TEntity model)
        {
            await DbContext.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int modelId)
        {
            return await DbContext.Set<TEntity>().FindAsync(modelId);
        }

        public virtual async Task UpdateAsync(TEntity model)
        {
            DbContext.Set<TEntity>().Update(model);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity model)
        {
            DbContext.Set<TEntity>().Remove(model);
            await DbContext.SaveChangesAsync();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }
    }
}
