using ReStock.DataProvider;
using ReStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReStock.Web.Services.Data
{
    public class ShoppingItemRepository : IShoppingItemRepository//: RepositoryBase<RestockDbContext,StockItem>,
    {
        public IEnumerable<string> GetAll()
        {
            return new List<string>()
            {
                "Item 1232323", "Item 2"
            };
        }
    }
}
