using ReStock.Models;
using System.Collections.Generic;

namespace ReStock.Web.Services.Data
{
    public interface IShoppingItemRepository : IRepositoryBase<ShoppingItem>
    {
        IEnumerable<ShoppingItem> GetAll();
    }
}