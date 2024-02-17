using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Homies.Utils.Constants.EventValidationConstants;

namespace Homies.Data.Models
{
    /// <summary>
    /// Represents an event in the system.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the unique identifier for the event.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        [Required]
        [MaxLength(EventMaxNameLen)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the event.
        /// </summary>
        [Required]
        [MaxLength(EventDesriptionMaxLen)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID of the organizer for the event.
        /// </summary>
        [Required]
        public string OrganiserId { get; set; }

        /// <summary>
        /// Gets or sets the organizer of the event.
        /// </summary>
        [Required]
        public virtual IdentityUser Organiser { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the event was created.
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the event.
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the event.
        /// </summary>
        [Required]
        public DateTime End { get; set; }

        /// <summary>
        /// Gets or sets the ID of the type of the event.
        /// </summary>
        [Required]
        public int TypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        [Required]
        public virtual EventType Type { get; set; }

        /// <summary>
        /// Gets or sets the collection of participants associated with the event.
        /// </summary>
        public virtual ICollection<EventParticipant> EventsParticipants { get; set; }
    }
}
