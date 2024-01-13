using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyToolsWeb.Models
{
    public class Favourites
    {
        [ForeignKey(nameof(UserLikedId))]
        public int UserLikedId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey(nameof(TrikId))]
        public int TrikId { get; set;}
        public virtual Trick Trick { get; set; }
    }
}
