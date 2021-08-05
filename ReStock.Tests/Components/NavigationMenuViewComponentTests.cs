using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Logging;
using Moq;
using ReStock.Models;
using ReStock.Web.Components;
using ReStock.Web.Controllers;
using ReStock.Web.Services.Data;
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
             
        }
    }
}
