using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReStock.Web.Services.Data
{
    public class StockRepository : IStockRepository
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
