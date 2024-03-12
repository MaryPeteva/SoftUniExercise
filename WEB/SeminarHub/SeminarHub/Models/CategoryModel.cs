using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Utils.ClassValidationConstants.CategoryValidationConstants;
using static SeminarHub.Data.Utils.Errors.ErrorMess;

namespace SeminarHub.Models
{
    public class CategoryModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(CategoryNameMaxLen, MinimumLength = CategoryNameMinLen, ErrorMessage = StringLengthErrorMessage)]
        [Comment("Category name, string representation")]
        public string Name { get; set; }
    }
}
