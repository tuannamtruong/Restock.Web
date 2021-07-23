using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReStock.Models;
using ReStock.Web.Services.Data;
using ReStock.Web.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ReStock.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeRepository _recipeRepository;
        public int PageSize = 4;

        public RecipeController(ILogger<RecipeController> logger,
                                IRecipeRepository recipeRepository)
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
        }

        public IActionResult Index()
        {
            List<string> results = new List<string>();
            foreach(Recipe p in _recipeRepository.GetAll())
            {
                string name = p?.Name;
                decimal? price = p?.CookTime;
                results.Add(string.Format("Name: {0}, Time: {1} mins", name, price));
            }
            return View("ListRecipe", results);
        }

        public IActionResult ListRecipeDetail(int recipePage = 1)
        {
            return View(_recipeRepository.GetAll()
                .OrderBy(r => r.Name)
                .Skip((recipePage - 1) * PageSize)
                .Take(PageSize));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
