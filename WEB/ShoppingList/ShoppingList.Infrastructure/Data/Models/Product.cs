using System.ComponentModel.DataAnnotations;
using static ShoppingList.Infrastructure.Constants.ValidationConstants.ProductValidationConstants;
namespace ShoppingList.Infrastructure.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}