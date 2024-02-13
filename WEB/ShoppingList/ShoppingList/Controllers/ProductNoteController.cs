using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Contracts;
using ShoppingList.Core.Models;
using System.Threading.Tasks;

namespace ShoppingList.Controllers
{
    public class ProductNoteController : Controller
    {
        private readonly IProductNotesService _productNotesService;

        public ProductNoteController(IProductNotesService productNotesService)
        {
            _productNotesService = productNotesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(ProductController.Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            var note = new ProductNotesModel();
            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int prodId, string content)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index));
            }

            await _productNotesService.AddProductNoteAsync(prodId, content);
            return RedirectToAction(nameof(ProductController.Index), "Product");
        }
    }
}
