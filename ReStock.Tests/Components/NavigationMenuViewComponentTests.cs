using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ReStock.Models;
using ReStock.Web.Components;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace ReStock.Tests.Components
{
    public class NavigationMenuViewComponentTests
    {
        private readonly NavigationMenuViewComponent _viewComponent;

        public NavigationMenuViewComponentTests()
        {
            _viewComponent = new NavigationMenuViewComponent();
        }


        [Fact]
        public void Invoke_ShouldGetCorrectCategories()
        {
            string[] results = ((IEnumerable<string>)(_viewComponent.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();
            // How to mock new Enum? 
            // Inject in constructor?
            // Inject in function?
            // No need to test?
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            var categoryToSelect = RecipeCategory.Meat.ToString();
            _viewComponent.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };
            _viewComponent.RouteData.Values["category"] = categoryToSelect;
            string result = (string)(_viewComponent.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];
            Assert.Equal(categoryToSelect, result);
        }
    }
}
