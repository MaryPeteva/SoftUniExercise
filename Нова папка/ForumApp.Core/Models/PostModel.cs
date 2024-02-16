using System.ComponentModel.DataAnnotations;
using static ForumApp.Infrastructure.Constants.PostValidations;
using static ForumApp.Infrastructure.Constants.ErrorMessages;

namespace ForumApp.Core.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(PostTitleMaxLen, MinimumLength = PostTitleMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Title { get; set; }
        [Required(ErrorMessage = RequiredField)]
        [StringLength(PostContentMaxLen, MinimumLength = PostContentMinLen, ErrorMessage = StringLenErrorMessage)]
        public string Content { get; set; }
    }
}
