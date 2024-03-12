using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Utils.ClassValidationConstants.SeminarValidationConstants;
using static SeminarHub.Data.Utils.Errors.ErrorMess;
namespace SeminarHub.Models
{
    public class SeminarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarTopicMaxLen, MinimumLength =SeminarTopicMinLen, ErrorMessage =StringLengthErrorMessage)]
        [Comment("Seminars theme, string representation")]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarLecturerMaxLen, MinimumLength = SeminarLecturerMinLen, ErrorMessage = StringLengthErrorMessage)]
        [Comment("seminars lecurer, string representation")]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarDetailsMaxLen, MinimumLength = SeminarDetailsMinLen, ErrorMessage = StringLengthErrorMessage)]
        [Comment("brief overview of the theme, string representation")]
        public string Details { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OrganizerId))]
        [Comment("unique user identifier, string/GUID repsresentation")]
        public string OrganizerId { get; set; } = string.Empty;

        [Required]
        public IdentityUser Organizer { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm}")]
        public DateTime DateAndTime { get; set; }

        [Range(SeminarDurationMin, SeminarDurationMax)]
        [Comment("seminars duration integer representation")]
        public int? Duration { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category unique identifier, integer representation")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Comment("seminars category, obj representation")]
        public Category Category { get; set; } = null!;

        [Comment("all users participating in the semminar, List of participans")]
        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
