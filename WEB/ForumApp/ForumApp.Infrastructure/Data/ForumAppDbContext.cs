using ForumApp.Infrastructure.configuration;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Infrastructure.Data
{
    public class ForumAppDbContext:IdentityDbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options):base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
    }
}
