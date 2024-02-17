using System.ComponentModel.DataAnnotations;
using static TaskBoard.Utils.Validations.BoardValidationsConstants;
using static TaskBoard.Utils.Errors.ErrorMessages;
namespace TaskBoard.Models
{
    public class BoardModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage =RequiredField)]
        [StringLength(BoardNameMaxLen, MinimumLength = BoardNameMinLen, ErrorMessage = StringLenError)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task>? Tasks { get; set; } = new List<Task>();
    }
}
