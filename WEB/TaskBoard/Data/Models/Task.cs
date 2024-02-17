using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoard.Utils.Validations.TaskValidationsConstants;
namespace TaskBoard.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskTitleMaxLen)]
        public string Title { get; set; }

        [Required]
        [MaxLength(TaskDescriptionMaxLen)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        public virtual Board? Board { get; set; }

        [Required]
        public string OwnerId {get; set;}

        [Required]
        public virtual IdentityUser Owner { get; set;}
    }
}
