using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [ForeignKey(nameof(PosterId))]
        public int PosterId { get; set; }

        [Required]
        public virtual IdentityUser Poster { get; set; } = null!;
    }
}
