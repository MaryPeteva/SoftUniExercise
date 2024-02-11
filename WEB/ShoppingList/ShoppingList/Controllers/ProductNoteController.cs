using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Controllers
{
    public class ProductNoteController : Controller
    {
        // GET: ProductNoteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductNoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductNoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductNoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductNoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductNoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductNoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductNoteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
