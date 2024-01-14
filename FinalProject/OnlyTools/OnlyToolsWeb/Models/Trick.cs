using System.ComponentModel.DataAnnotations;

namespace OnlyToolsWeb.Models
{
    public class Trick
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public int Likes { get; set; }
        // when user adds tip to favourites Likes++
        //TODO raiting rated by likes
    }
}
