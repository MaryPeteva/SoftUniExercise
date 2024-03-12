using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Data.Utils.ClassValidationConstants.SeminarValidationConstants;
namespace SeminarHub.Data.Models
{
    public class Seminar
    {
        [Key]
        [Comment("unique integer seminar identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(SeminarTopicMaxLen)]
        [Comment("Seminars theme, string representation")]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [MaxLength(SeminarLecturerMaxLen)]
        [Comment("seminars lecurer, string representation")]
        public string Lecturer { get; set; } = string.Empty;

        [Required]
        [MaxLength(SeminarDetailsMaxLen)]
        [Comment("brief overview of the theme, string representation")]
        public string Detail { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OrganizerId))]
        [Comment("unique user identifier, string/GUID repsresentation")]
        public string OrganizerId { get; set; } = string.Empty;

        [Required]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        public DateTime DateAndTime { get; set; }

        [Range(SeminarDurationMin, SeminarDurationMax)]
        [Comment("seminars duration integer representation")]
        public int? Duration { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category unique identifier, integer representation")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("seminars category, obj representation")]
        public Category Category { get; set; } = null!;

        [Comment("all users participating in the semminar, List of participans")]
        public IList<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }
}
