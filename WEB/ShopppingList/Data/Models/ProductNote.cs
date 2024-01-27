using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopppingList.Data.Models
{
    public class ProductNote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }

    }
}
