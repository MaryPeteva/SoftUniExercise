using ShoppingList.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static ShoppingList.Infrastructure.Constants.ErrorMessages;
using static ShoppingList.Infrastructure.Constants.ValidationConstants.ProductValidationConstants;
namespace ShoppingList.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage =StringLenErrorMessage)]
        public string Name { get; set; } = null!;

        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
