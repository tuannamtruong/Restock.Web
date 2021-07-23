using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReStock.Models;
using ReStock.Web.Controllers;
using ReStock.Web.Services.Data;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ReStock.Tests.Controllers
{
    public class RecipeControllerTests
    {
        private readonly Mock<ILogger<RecipeController>> _loggerMock;
        private readonly Mock<IRecipeRepository> _repoMock;
        private readonly RecipeController _controller;

        public RecipeControllerTests()
        {
            _loggerMock = new Mock<ILogger<RecipeController>>();
            List<Recipe> mockData = new List<Recipe>()
            {
                new Recipe { Id = 1, Name = "Pork ribs", CookTime = 180, Instruction = "Do this then that then boom" },
                new Recipe { Id = 2, Name = "Salat", CookTime = 20 },
                new Recipe { Id = 3, Name = "Meatballs", Instruction = "Just this. Then .... Finally" },
                new Recipe { Id = 4, Name = "Boiling Eggs" }
            };
            _repoMock = new Mock<IRecipeRepository>();
            _repoMock.Setup(r => r.GetAll()).Returns(mockData);

            _controller = new RecipeController(_loggerMock.Object, _repoMock.Object);
        }

        [Fact]
        public void ListRecipe_GetAllFromRepo_ShouldGetCorrectData()
        {
            var result = (_controller.ListRecipe() as ViewResult)?.ViewData.Model as IEnumerable<string>;

            Assert.Equal(4, result.ToList().Count);
        }
    }
}
