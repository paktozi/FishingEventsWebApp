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
        public DbSet<Organiser> Organisers { get; set; } = null!;
        public DbSet<Participant> Participants { get; set; } = null!;
        public DbSet<FishingEvent> FishingEvents { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<EventParticipant> EventParticipants { get; set; } = null!;
        public DbSet<FishCaught> FishCaughts { get; set; } = null!;
        public DbSet<LeaderBoard> LeaderBoards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // Configure composite keys for EventParticipant and LeaderBoard
            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.FishingEventId, ep.ParticipantId });

            modelBuilder.Entity<LeaderBoard>()
                .HasKey(lb => new { lb.FishingEventId, lb.ParticipantId });

            // Organiser - FishingEvent relationship
            modelBuilder.Entity<FishingEvent>()
                .HasOne(fe => fe.Organiser)
                .WithMany(o => o.CreatedEvents)
                .HasForeignKey(fe => fe.OrganiserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure EventParticipant relationships
            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.FishingEvent)
                .WithMany(fe => fe.EventParticipants)
                .HasForeignKey(ep => ep.FishingEventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Participant)
                .WithMany(p => p.EventParticipants)
                .HasForeignKey(ep => ep.ParticipantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure FishCaught relationships
            modelBuilder.Entity<FishCaught>()
                .HasOne(fc => fc.FishingEvent)
                .WithMany(fe => fe.FishCaught)
                .HasForeignKey(fc => fc.FishingEventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FishCaught>()
                .HasOne(fc => fc.Participant)
                .WithMany(p => p.FishCaught)
                .HasForeignKey(fc => fc.ParticipantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure LeaderBoard relationships
            modelBuilder.Entity<LeaderBoard>()
                .HasOne(lb => lb.FishingEvent)
                .WithMany(fe => fe.LeaderBoards)
                .HasForeignKey(lb => lb.FishingEventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LeaderBoard>()
                .HasOne(lb => lb.Participant)
                .WithMany(p => p.LeaderBoards)
                .HasForeignKey(lb => lb.ParticipantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
