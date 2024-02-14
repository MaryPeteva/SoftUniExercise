using System.ComponentModel.DataAnnotations;
using static ForumApp.Infrastructure.Constants.PostValidations;

namespace ForumApp.Infrastructure.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(PostTitleMaxLen)]
        public string Title { get; set; }
        [Required]
        [MaxLength(PostContentMaxLen)]
        public string Content { get; set; }
    }
}
