using ReStock.Models;
using System.Collections.Generic;

namespace ReStock.Web.ViewModels
{
    /// <summary>
    /// ViewModel for <see cref="Controllers.StockController.Index"/>
    /// </summary>
    public class StockViewModel
    {
        public List<ShoppingItem> ShoppingListItems { get; set; }
        public Dictionary<StockType, List<(string Name, string Amount)>> StockItemGroupByType {get;set;}
    }
}
