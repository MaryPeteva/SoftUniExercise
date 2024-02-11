using Microsoft.EntityFrameworkCore;
using ShoppingList.Core.Contracts;
using ShoppingList.Core.Models;
using ShoppingList.Infrastructure.Data;
using ShoppingList.Infrastructure.Data.Models;
using static ShoppingList.Infrastructure.Constants.ErrorMessages;

namespace ShoppingList.Core.Services
{
    public class ProductService:IProductService
    {
        private readonly ShoppingListDbContext context;

        public ProductService(ShoppingListDbContext _context)
        {
            context = _context;
        }

        public async Task AddProductAsync(ProductModel prod)
        {
            var product = new Product()
            {
                Name = prod.Name
            };
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var prod = await context.Products.FindAsync(id);

            if (prod == null) 
            {
                throw new ArgumentException(invalidProduct);
            }

            context.Products.Remove(prod);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
           return await context.Products
                .Select(p => new ProductModel() {
                    Name = p.Name,
                    Id = p.Id,
                    ProductNotes = p.ProductNotes,
                    })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            var prod = await context.Products.FindAsync(id);

            if (prod == null)
            {
                throw new ArgumentException(invalidProduct);
            }

            return new ProductModel()
            {
                Id = id,
                Name = prod.Name
            };
        }

        public async Task UpdateProductAsync(ProductModel prod)
        {
            var pr = await context.Products.FindAsync(prod.Id);

            if (pr == null) 
            {
                throw new ArgumentException(invalidProduct);
            }

            pr.Name = prod.Name;

            await context.SaveChangesAsync();
        }
    }
}
