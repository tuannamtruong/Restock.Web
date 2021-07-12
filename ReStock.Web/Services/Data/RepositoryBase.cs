using Microsoft.EntityFrameworkCore;
using System;
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
        protected Func<TDbContext> DbContextCreator { get; }

        public RepositoryBase(Func<TDbContext> dbContextCreator)
        {
            DbContextCreator = dbContextCreator;
        }

        public virtual async Task AddAsync(TEntity model)
        {
            using var _filmDbContext = DbContextCreator();
            await _filmDbContext.AddAsync(model);
            await _filmDbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using var _filmDbContext = DbContextCreator();
            return await _filmDbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int modelId)
        {
            using var _filmDbContext = DbContextCreator();
            return await _filmDbContext.Set<TEntity>().FindAsync(modelId);
        }

        public virtual async Task UpdateAsync(TEntity model)
        {
            using var _filmDbContext = DbContextCreator();
            _filmDbContext.Set<TEntity>().Update(model);
            await _filmDbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity model)
        {
            using var _filmDbContext = DbContextCreator();
            _filmDbContext.Set<TEntity>().Remove(model);
            await _filmDbContext.SaveChangesAsync();
        }
    }
}
