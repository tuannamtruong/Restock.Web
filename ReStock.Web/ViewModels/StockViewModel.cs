using ReStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReStock.Web.ViewModels
{
    public class StockViewModel
    {
        public List<string> ShoppingListItems { get; set; }
        public Dictionary<StockType, List<(string Name, string Amount)>> StockItemGroupByType {get;set;}
        //public List<StockItem> StockItems { get; set; }
        //public Dictionary<StockType, >
    }
}
