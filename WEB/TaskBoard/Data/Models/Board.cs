using System.ComponentModel.DataAnnotations;
using static TaskBoard.Utils.Validations.BoardValidationsConstants;
namespace TaskBoard.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(BoardNameMaxLen)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task>? Tasks { get; set; } = new List<Task>();
    }
}
