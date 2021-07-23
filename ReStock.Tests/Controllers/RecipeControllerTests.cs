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
                new Recipe { Id = 1, Name = "R1", CookTime = 180, Instruction = "Do this then that then boom" },
                new Recipe { Id = 2, Name = "R2", CookTime = 20 },
                new Recipe { Id = 3, Name = "R3", Instruction = "Just this. Then .... Finally" },
                new Recipe { Id = 4, Name = "R4" },
                new Recipe { Id = 5, Name = "R5", CookTime = 8, Instruction = "Eat it" },
            };
            _repoMock = new Mock<IRecipeRepository>();
            _repoMock.Setup(r => r.GetAll()).Returns(mockData);

            _controller = new RecipeController(_loggerMock.Object, _repoMock.Object);
        }

        [Fact]
        public void Index_GetAllFromRepo_ShouldGetCorrectData()
        {
            var result = (_controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<string>;
            Assert.Equal(5, result.ToList().Count);
        }

        [Fact]
        public void ListRecipeDetail_GetAllFromRepo_CanPaginate()
        {
            _controller.PageSize = 3;
            IEnumerable<Recipe> result = (_controller.ListRecipeDetail(2) as ViewResult).ViewData.Model
                                            as IEnumerable<Recipe>;
            Recipe[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("R4", prodArray[0].Name);
            Assert.Equal("R5", prodArray[1].Name);
        }
    }
}
