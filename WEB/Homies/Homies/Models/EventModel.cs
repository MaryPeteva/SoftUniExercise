using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Homies.Utils.Constants.EventValidationConstants;
using static Homies.Utils.Errors.ErrorMessages;

namespace Homies.Models
{
    public class EventModel
    {
        /// <summary>
        /// event shown in edit 
        /// </summary>
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(EventMaxNameLen, MinimumLength = EventMinNameLen, ErrorMessage = FieldMaxMinLen)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(EventDesriptionMaxLen, MinimumLength = EventDesriptionMinLen, ErrorMessage = FieldMaxMinLen)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public virtual IdentityUser Organiser { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm}")]
        public DateTime Start { get; set; }


        [Required(ErrorMessage = RequiredField)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm}")]
        public DateTime End { get; set; }

        [Required(ErrorMessage = RequiredField)]
        public int TypeId { get; set; }

        public IEnumerable<EventTypeModel> Types { get; set; } = new List<EventTypeModel>(); 
    }
}
