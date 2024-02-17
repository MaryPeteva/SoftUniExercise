using Homies.Data.Models;
using System.ComponentModel.DataAnnotations;
using static Homies.Utils.Constants.TypeValidationConstants;
using static Homies.Utils.Errors.ErrorMessages;
namespace Homies.Models
{
    public class EventTypeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(TypeNameMaxLen, MinimumLength = TypeNameMinLen, ErrorMessage = FieldMaxMinLen)]
        public string Name { get; set; }

    }
}
