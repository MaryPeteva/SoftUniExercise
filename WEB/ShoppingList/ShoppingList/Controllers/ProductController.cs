using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Contracts;
using ShoppingList.Core.Models;
namespace ShoppingList.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<ProductModel> prods = await productService.GetAllProductsAsync();
            return View(prods);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            var prod = new ProductModel();

            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel prod) 
        {
            if (!ModelState.IsValid) 
            {
                return View(prod);
            }

            await productService.AddProductAsync(prod);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var prod = await productService.GetByIdAsync(id);
            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel prod, int id) 
        {
            if (!ModelState.IsValid) 
            {
                return View(prod);
            }

            await productService.UpdateProductAsync(prod);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            await productService.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }

}
