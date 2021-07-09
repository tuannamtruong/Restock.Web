using System.Collections.Generic;

namespace ReStock.Web.Services.Data
{
    public interface IStockRepository
    {
        IEnumerable<string> GetAll();
    }
}