using ReStock.DataProvider;
using ReStock.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReStock.Web.Services.Data
{
    public class StockRepository : RepositoryBase<RestockDbContext, StockItem>, IStockRepository 
    {
        public StockRepository(RestockDbContext dbContextCreator) : base(dbContextCreator)
        {
        }

        public IEnumerable<StockItem> GetAll()
        {
            return DbContext.Set<StockItem>().ToList();
        }
    }
}
