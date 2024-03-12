using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Utils.ClassValidationConstants.CategoryValidationConstants;
namespace SeminarHub.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("unique integer category identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(CategoryNameMaxLen)]
        [Comment("Category name, string representation")]
        public string Name { get; set; } = string.Empty;

        [Comment("All the seminars with this category")]
        public IList<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}