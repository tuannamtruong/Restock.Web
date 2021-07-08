using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReStock.Web.Models;
using System.Diagnostics;

namespace ReStock.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<StockController> _logger;

        public RecipeController(ILogger<StockController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
