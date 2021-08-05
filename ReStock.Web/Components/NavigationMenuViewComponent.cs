using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ReStock.Models;
using System;
using System.Collections.Generic;

namespace ReStock.Web.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public NavigationMenuViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            HashSet<string> categories = new HashSet<string>();
            foreach(var category in Enum.GetValues(typeof(RecipeCategory)))
            {
                categories.Add(category.ToString());
            }
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(categories);
        }
    }
}
