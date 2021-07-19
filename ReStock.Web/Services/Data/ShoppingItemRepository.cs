using ReStock.DataProvider;
using ReStock.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReStock.Web.Services.Data
{
    public class ShoppingItemRepository : RepositoryBase<RestockDbContext, ShoppingItem>, IShoppingItemRepository 
    {
        public ShoppingItemRepository(RestockDbContext dbContextCreator) : base(dbContextCreator)
        {
        }
        
        public IEnumerable<ShoppingItem> GetAll()
        {
            return DbContext.Set<ShoppingItem>().ToList();
        }
    }
}
