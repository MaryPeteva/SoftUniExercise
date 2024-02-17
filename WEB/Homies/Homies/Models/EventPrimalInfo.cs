using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Homies.Models
{
    public class EventPrimalInfo
    {
        /// <summary>
        /// view of the event in the all events page
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual string Organiser { get; set; }
        public DateTime Start { get; set; }
        public virtual string Type { get; set; }
    }
}
