using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyToolsWeb.Models
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [ForeignKey(nameof(OwnerID))]
        public int OwnerID { get; set; }
        public virtual User Owner { get; set; }
        public bool IsRented { get; set; }
        public string? ToolPictureUrl { get; set; }
    }
}
