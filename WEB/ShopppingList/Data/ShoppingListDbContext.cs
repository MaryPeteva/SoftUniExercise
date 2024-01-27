using Microsoft.EntityFrameworkCore;
using ShopppingList.Data.Models;

namespace ShopppingList.Data
{
    public class ShoppingListDbContext:DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }

    }
}
