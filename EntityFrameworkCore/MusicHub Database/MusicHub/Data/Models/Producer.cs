
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string? Pseudonym { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
