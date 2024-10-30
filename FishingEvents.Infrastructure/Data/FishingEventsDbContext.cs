using FishingEvents.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Infrastructure
{
    public class FishingEventsDbContext : IdentityDbContext<ApplicationUser>
    {
        public FishingEventsDbContext(DbContextOptions<FishingEventsDbContext> options)
            : base(options)
        {
        }

        public DbSet<FishingEvent> FishingEvents { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<FishCaught> FishCaughts { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser table configurations
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.FishingEvents)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete for organizer

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.EventParticipants)
                .WithOne(ep => ep.User)
                .HasForeignKey(ep => ep.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Allows user participation entries to be deleted

            // FishingEvent configurations
            modelBuilder.Entity<FishingEvent>()
                .HasMany(e => e.EventParticipants)
                .WithOne(ep => ep.FishingEvent)
                .HasForeignKey(ep => ep.FishingEventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FishingEvent>()
                .HasMany(e => e.FishCaughts)
                .WithOne(fc => fc.FishingEvent)
                .HasForeignKey(fc => fc.FishingEventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FishingEvent>()
                .HasMany(e => e.LeaderBoards)
                .WithOne(lb => lb.FishingEvent)
                .HasForeignKey(lb => lb.FishingEventId)
                .OnDelete(DeleteBehavior.Cascade);

            // EventParticipant configurations (composite key)
            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.FishingEventId, ep.UserId });

            // FishCaught configurations
            modelBuilder.Entity<FishCaught>()
                .HasOne(fc => fc.User)
                .WithMany(u => u.FishCaughts)
                .HasForeignKey(fc => fc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // LeaderBoard configurations
            modelBuilder.Entity<LeaderBoard>()
                .HasKey(lb => new { lb.FishingEventId, lb.UserId });

            modelBuilder.Entity<LeaderBoard>()
                .HasOne(lb => lb.User)
                .WithMany(u => u.LeaderBoards)
                .HasForeignKey(lb => lb.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Location configurations
            modelBuilder.Entity<Location>()
                .HasMany(l => l.FishingEvents)
                .WithOne(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
