using Microsoft.EntityFrameworkCore;
using OnlyToolsWeb.Models;
namespace OnlyToolsWeb.Data
{
    public class OnlyToolsDbContext :DbContext
    {
        public OnlyToolsDbContext() { }
        public OnlyToolsDbContext(DbContextOptions<OnlyToolsDbContext> options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Trick> TipsAndTricks { get; set; }
        public DbSet<UserOwnedTool> UsersTools { get; set; }
        public DbSet<UserRentedTool> UserRentedTools { get; set; }
        public DbSet<UserPublishedTip> UserPublishedTips { get; set; }
        public DbSet<Favourites> Favourites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
