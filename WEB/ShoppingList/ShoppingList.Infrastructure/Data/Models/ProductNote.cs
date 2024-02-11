using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShoppingList.Infrastructure.Constants.ValidationConstants.ProductNotesValidationConstants;
namespace ShoppingList.Infrastructure.Data.Models
{
    public class ProductNote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(ContentMaxLenght)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }

        [Required]
        public virtual Product Product { get; set; } = null!;
    }
}