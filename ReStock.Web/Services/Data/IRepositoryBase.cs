using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReStock.Web.Services.Data
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity model);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int modelId);
        Task RemoveAsync(TEntity model);
        Task UpdateAsync(TEntity model);

        IEnumerable<TEntity> GetAll();
        Task SaveChangesAsync();
    }
}