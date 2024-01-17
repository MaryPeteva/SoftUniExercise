using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;
public class CategoryController : Controller
{
    private readonly BulckyDbContext _db;

    public CategoryController(BulckyDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View(objCategoryList);
    }

    
    public IActionResult Create()
    {//GET returns a view for creating a new category
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {//POST handles the form submission when creating a new category,checks if the Name and DisplayOrder values are different,
     //If the model state is valid, a new category is added to the database, and the user is redirected to the "Index" action
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Edit(int? id)
    {//GET  takes an id parameter and retrieves the corresponding category from the database. If the category is not found, it returns a "Not Found" response
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
       
        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {//POST handles the form submission when editing a category checks if the Name and DisplayOrder values are different,
     //If the model state is valid, a new category is added to the database, and the user is redirected to the "Index" action
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully!";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Delete(int? id)
    {//GET  takes an id parameter and retrieves the corresponding category from the database. If the category is not found, it returns a "Not Found" response
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Categories.Find(id);
        if(obj == null) 
        {
            return NotFound();
        }
        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully!";
        return RedirectToAction("Index");
    }
}