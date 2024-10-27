using FishingEvents.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Infrastructure
{
    public class FishingEventsDbContext : IdentityDbContext<IdentityUser>
    {
        public FishingEventsDbContext(DbContextOptions<FishingEventsDbContext> options)
            : base(options)
        {
        }

        public DbSet<FishingEvent> FishingEvents { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<FishCaught> FishCaught { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Composite primary key for EventParticipant
            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.FishingEventId, ep.ParticipantId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.FishingEvent)
                .WithMany(fe => fe.EventParticipants)
                .HasForeignKey(ep => ep.FishingEventId);

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Participant)
                .WithMany(p => p.EventParticipants)
                .HasForeignKey(ep => ep.ParticipantId);

            modelBuilder.Entity<FishCaught>()
                .HasOne(fc => fc.FishingEvent)
                .WithMany(fe => fe.FishCaught)
                .HasForeignKey(fc => fc.FishingEventId);

            modelBuilder.Entity<FishCaught>()
                .HasOne(fc => fc.Participant)
                .WithMany(p => p.FishCaught)
                .HasForeignKey(fc => fc.ParticipantId);

            modelBuilder.Entity<LeaderBoard>()
                .HasKey(lb => new { lb.FishingEventId, lb.ParticipantId });

            modelBuilder.Entity<LeaderBoard>()
                .HasOne(lb => lb.FishingEvent)
                .WithMany(fe => fe.LeaderBoards)
                .HasForeignKey(lb => lb.FishingEventId);

            modelBuilder.Entity<LeaderBoard>()
                .HasOne(lb => lb.Participant)
                .WithMany(p => p.LeaderBoards)
                .HasForeignKey(lb => lb.ParticipantId);

            modelBuilder.Entity<FishingEvent>()
                .HasOne(fe => fe.Location)
                .WithMany(l => l.FishingEvents)
                .HasForeignKey(fe => fe.LocationId);

            // Preventing multiple cascade paths
            modelBuilder.Entity<FishingEvent>()
                .HasOne(fe => fe.Creator)
                .WithMany()
                .HasForeignKey(fe => fe.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
