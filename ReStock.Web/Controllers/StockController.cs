using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReStock.Web.Services.Data;
using ReStock.Web.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace ReStock.Web.Controllers
{
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        private IStockRepository _stockRepository;
        public StockController(ILogger<StockController> logger, IStockRepository stockRepository)
        {
            _logger = logger;
            _stockRepository = stockRepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        public IActionResult Index()
        {
            var viewModel = new StockViewModel();
            viewModel.ShoppingList = _stockRepository.GetAll().ToList();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
