using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReStock.Models;
using ReStock.Web.Services.Data;
using ReStock.Web.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace ReStock.Web.Controllers
{
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        private readonly IShoppingItemRepository _shoppingItemRepository;
        private readonly IStockRepository _stockRepository;

        public StockController(ILogger<StockController> logger,
            IShoppingItemRepository shoppingItemRepository,
            IStockRepository stockRepository)
        {
            _logger = logger;
            _shoppingItemRepository = shoppingItemRepository;
            _stockRepository = stockRepository;
        }

        public IActionResult Index()
        {
            var stockItems = _stockRepository.GetAll().ToList();
            var stockItemGroupByTpe = stockItems
                .GroupBy(x => x.StockType)
                .ToDictionary(x => x.Key, x => x.Select(a => (a.Name, a.Amount)).ToList());

            var viewModel = new StockViewModel
            {
                ShoppingListItems = _shoppingItemRepository.GetAll().ToList(),
                StockItemGroupByType = stockItemGroupByTpe
            };
            return View(viewModel);
        }

        //[HttpPost]
        //public IActionResult AddShoppingItem(ShoppingItem shoppingItem)
        //{
        //    _shoppingItemRepository.AddAsync(shoppingItem);
        //    //return View(nameof(Index));
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
