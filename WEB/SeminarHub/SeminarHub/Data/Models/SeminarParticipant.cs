using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{
    public class SeminarParticipant
    {

        [Required]
        [ForeignKey(nameof(SeminarId))]
        [Comment("integer seminar identifier, part of composite key")]
        public int SeminarId { get; set; }

        [Comment("seminar, obj representation")]
        public Seminar Seminar { get; set; } = null!;

 
        [Required]
        [ForeignKey(nameof(ParticipantId))]
        [Comment("string user identifier, part of composite key")]
        public string ParticipantId { get; set; } = string.Empty;

        [Comment("user, obj representation")]
        public IdentityUser Participant { get; set; } = null!;

    }
}