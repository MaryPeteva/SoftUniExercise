using Homies.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>()
               .HasKey(ep => new { ep.EventId, ep.HelperId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(e => e.Event)
                .WithMany(e => e.EventsParticipants)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<EventType>()
                .HasData(new EventType()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new EventType()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new EventType()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new EventType()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EventType> Types { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventsParticipants { get; set; }
    }
}