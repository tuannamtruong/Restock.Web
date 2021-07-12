using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        protected TDbContext _dbContext { get; }

        public RepositoryBase(TDbContext dbContextCreator)
        {
            _dbContext = dbContextCreator;
        }

        public virtual async Task AddAsync(TEntity model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int modelId)
        {
            return await _dbContext.Set<TEntity>().FindAsync(modelId);
        }

        public virtual async Task UpdateAsync(TEntity model)
        {
            _dbContext.Set<TEntity>().Update(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity model)
        {
            _dbContext.Set<TEntity>().Remove(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
