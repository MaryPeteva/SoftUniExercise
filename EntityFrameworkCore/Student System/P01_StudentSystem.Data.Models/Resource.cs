using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
    public class Resource
    {
        public int ResourceId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Url { get; set; }
        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]

        public virtual Course Course { get; set; }
    }
}
