using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReStock.Web.Services.Data;
using ReStock.Web.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace ReStock.Web.Controllers
{
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        private readonly IShoppingItemRepository _shoppingItemRepository;
        private readonly IStockRepository _stockRepository;

        public StockController(ILogger<StockController> logger, IShoppingItemRepository shoppingItemRepository, IStockRepository stockRepository)
        {
            _logger = logger;
            _shoppingItemRepository = shoppingItemRepository;
            _stockRepository = stockRepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            var stockItems = _stockRepository.GetAll().ToList();
            Dictionary<Models.StockType, List<(string Name, string Amount)>> grouper =
                stockItems
                .GroupBy(x => x.StockType)
                .ToDictionary(x => x.Key, x => x.Select(a => (a.Name, a.Amount)).ToList());

            var viewModel = new StockViewModel();
            viewModel.ShoppingListItems = _shoppingItemRepository.GetAll().ToList();
            viewModel.StockItemGroupByType = grouper;
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
