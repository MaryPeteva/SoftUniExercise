using System.ComponentModel.DataAnnotations;
using static Homies.Utils.Constants.TypeValidationConstants;

namespace Homies.Data.Models
{
    /// <summary>
    /// Represents the type of an event.
    /// </summary>
    public class EventType
    {
        /// <summary>
        /// Gets or sets the unique identifier of the type.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        [Required]
        [MaxLength(TypeNameMaxLen)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of events associated with this type.
        /// </summary>
        public virtual IEnumerable<Event> Events { get; set; }
    }
}
