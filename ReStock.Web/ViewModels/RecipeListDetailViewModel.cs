using ReStock.Models;
using System.Collections.Generic;

namespace ReStock.Web.ViewModels
{
    public class RecipeListDetailViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
