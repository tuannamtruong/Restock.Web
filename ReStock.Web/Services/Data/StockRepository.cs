using ReStock.DataProvider;
using ReStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReStock.Web.Services.Data
{
    public class StockRepository : IStockRepository //RepositoryBase<RestockDbContext, StockItem>,
    {
        private RestockDbContext _dbContext { get; }
        //protected Func<RestockDbContext> DbContextCreator { get; }

        public StockRepository(RestockDbContext dbContextCreator)
        {
            _dbContext = dbContextCreator;
        }

        public IEnumerable<StockItem> GetAll()
        {
            return _dbContext.Set<StockItem>().ToList();
        }

        //public StockRepository(Func<RestockDbContext> dbContextCreator) : base(dbContextCreator)
        //{
        //}
    }
}
