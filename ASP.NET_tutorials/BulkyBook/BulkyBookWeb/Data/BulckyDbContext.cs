using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class BulckyDbContext:DbContext
    {
        public BulckyDbContext(DbContextOptions<BulckyDbContext> options): base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }


    }
}
