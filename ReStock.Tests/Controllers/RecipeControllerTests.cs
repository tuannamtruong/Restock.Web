using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReStock.Models;
using ReStock.Web.Controllers;
using ReStock.Web.Services.Data;
using ReStock.Web.ViewModels;
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
            _controller.PageSize = 3;
        }

        [Fact]
        public void Index_GetAllFromRepo_ShouldGetCorrectData()
        {
            var result = (_controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<string>;
            Assert.Equal(5, result.ToList().Count);
        }

        [Fact]
        public void RecipeListDetail_GetAllFromRepo_CanPaginate()
        {
            RecipeListDetailViewModel result = _controller.RecipeListDetail(2).ViewData.Model as RecipeListDetailViewModel;
            Recipe[] prodArray = result.Recipes.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("R4", prodArray[0].Name);
            Assert.Equal("R5", prodArray[1].Name);
        }

        [Fact]
        public void RecipeListDetail_GetAllFromRepo_CanSendPaginationViewModel()
        {
            RecipeListDetailViewModel result = _controller.RecipeListDetail(2).ViewData.Model as RecipeListDetailViewModel;
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
    }
}
