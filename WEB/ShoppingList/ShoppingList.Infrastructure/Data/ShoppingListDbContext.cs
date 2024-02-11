using Microsoft.EntityFrameworkCore;
using ShoppingList.Infrastructure.Data.Models;

namespace ShoppingList.Infrastructure.Data
{
    public class ShoppingListDbContext:DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }

        
    }
}
