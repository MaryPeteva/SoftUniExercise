using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    /// <summary>
    /// Represents a participant of an event.
    /// </summary>
    public class EventParticipant
    {
        /// <summary>
        /// Gets or sets the ID of the helper participating in the event.
        /// </summary>
        [Required]
        [ForeignKey(nameof(HelperId))]
        public string HelperId { get; set; }

        /// <summary>
        /// Gets or sets the helper participating in the event.
        /// </summary>
        public IdentityUser Helper { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ID of the event associated with this participant.
        /// </summary>
        [Required]
        [ForeignKey(nameof(EventId))]
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the event associated with this participant.
        /// </summary>
        public Event Event { get; set; } = null!;
    }
}
