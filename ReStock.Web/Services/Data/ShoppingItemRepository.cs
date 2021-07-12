using ReStock.DataProvider;
using ReStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReStock.Web.Services.Data
{
    public class ShoppingItemRepository : IShoppingItemRepository //RepositoryBase<RestockDbContext, ShoppingItem>,
    {
        //public ShoppingItemRepository(Func<RestockDbContext> dbContextCreator) : base(dbContextCreator)
        //{
        //}
        private RestockDbContext _dbContext { get; }

        public ShoppingItemRepository(RestockDbContext dbContextCreator)
        {
            _dbContext = dbContextCreator;
        }

        public IEnumerable<ShoppingItem> GetAll()
        {
            return _dbContext.Set<ShoppingItem>().ToList();
        }
    }
}
