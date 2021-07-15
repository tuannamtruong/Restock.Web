using ReStock.Models;
using System.Collections.Generic;

namespace ReStock.Web.Services.Data
{
    public interface IStockRepository : IRepositoryBase<StockItem>
    {
        IEnumerable<StockItem> GetAll();
    }
}