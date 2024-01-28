using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopppingList.Data;
using ShopppingList.Data.Models;

namespace ShopppingList.Controllers
{
    public class ProductNotesController : Controller
    {
        private readonly ShoppingListDbContext _context;

        public ProductNotesController(ShoppingListDbContext context)
        {
            _context = context;
        }

        // GET: ProductNotes
        public async Task<IActionResult> Index()
        {
            var shoppingListDbContext = _context.ProductNotes.Include(p => p.Product);
            return View(await shoppingListDbContext.ToListAsync());
        }

        // GET: ProductNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductNotes == null)
            {
                return NotFound();
            }

            var productNote = await _context.ProductNotes
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productNote == null)
            {
                return NotFound();
            }

            return View(productNote);
        }

        // GET: ProductNotes/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: ProductNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductId")] ProductNote productNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productNote.ProductId);
            return View(productNote);
        }

        // GET: ProductNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductNotes == null)
            {
                return NotFound();
            }

            var productNote = await _context.ProductNotes.FindAsync(id);
            if (productNote == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productNote.ProductId);
            return View(productNote);
        }

        // POST: ProductNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductId")] ProductNote productNote)
        {
            if (id != productNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductNoteExists(productNote.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productNote.ProductId);
            return View(productNote);
        }

        // GET: ProductNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductNotes == null)
            {
                return NotFound();
            }

            var productNote = await _context.ProductNotes
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productNote == null)
            {
                return NotFound();
            }

            return View(productNote);
        }

        // POST: ProductNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductNotes == null)
            {
                return Problem("Entity set 'ShoppingListDbContext.ProductNotes'  is null.");
            }
            var productNote = await _context.ProductNotes.FindAsync(id);
            if (productNote != null)
            {
                _context.ProductNotes.Remove(productNote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductNoteExists(int id)
        {
          return (_context.ProductNotes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
