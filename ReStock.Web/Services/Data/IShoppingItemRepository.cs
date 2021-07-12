using System.Collections.Generic;

namespace ReStock.Web.Services.Data
{
    public interface IShoppingItemRepository //: IRepositoryBase<>
    {
        IEnumerable<string> GetAll();
    }
}