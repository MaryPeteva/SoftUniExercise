using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyToolsWeb.Models
{
    public class UserOwnedTool
    {
        [ForeignKey(nameof(OwnerId))]
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        [ForeignKey(nameof(ToolId))]
        public int ToolId { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
