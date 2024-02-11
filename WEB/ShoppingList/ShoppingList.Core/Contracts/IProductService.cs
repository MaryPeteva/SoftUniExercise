using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Models;

namespace ShoppingList.Core.Contracts
{
    public interface IProductService
    {
        Task AddProductAsync(ProductModel prod);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetByIdAsync(int id);
        Task UpdateProductAsync(ProductModel prod);
    }
}
