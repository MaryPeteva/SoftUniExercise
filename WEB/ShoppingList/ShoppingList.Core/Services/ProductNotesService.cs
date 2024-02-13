using ShoppingList.Core.Contracts;
using ShoppingList.Infrastructure.Data;
using ShoppingList.Infrastructure.Data.Models;

namespace ShoppingList.Core.Services
{
    public class ProductNotesService : IProductNotesService
    {
        private readonly ShoppingListDbContext context;

        public ProductNotesService(ShoppingListDbContext _context)
        {
            context = _context;
        }
        public async Task AddProductNoteAsync(int prodId, string content)
        {
            var note = new ProductNote { ProductId = prodId, Content = content };
            await context.ProductNotes.AddAsync(note);
            await context.SaveChangesAsync();
        }
    }
}
