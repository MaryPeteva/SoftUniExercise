using ForumApp.Infrastructure.configuration;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Infrastructure.Data
{
    public class ForumAppDbContext:DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options):base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }

        public void SeedData(ForumAppDbContext context) 
        {
            if (!context.Posts.Any()) 
            {
                Post[] posts = Seed.SeedData();
                Posts.AddRange(posts);
                SaveChanges();
            }
        }
    }
}
