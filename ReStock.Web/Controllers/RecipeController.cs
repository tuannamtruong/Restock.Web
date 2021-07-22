using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReStock.Models;
using ReStock.Web.Services.Data;
using ReStock.Web.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace ReStock.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(ILogger<RecipeController> logger,
                                IRecipeRepository recipeRepository)
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
        }

        public IActionResult Index()
        {
            return View(_recipeRepository.GetAll());
        }

        public IActionResult ListRecipe()
        {
            List<string> results = new List<string>();
            foreach(Recipe p in _recipeRepository.GetAll())
            {
                string name = p?.Name;
                decimal? price = p?.CookTime;
                string instruction = p?.Instruction ?? "TBA";
                results.Add(string.Format("Name: {0}, Price: {1}, Instruction: {2}", name, price, instruction));
            }
            return View(results);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
