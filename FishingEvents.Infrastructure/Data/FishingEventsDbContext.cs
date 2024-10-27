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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite primary keys for many-to-many relationships
            builder.Entity<FishingEventParticipant>()
                .HasKey(fp => new { fp.FishingEventId, fp.ParticipantId });

            builder.Entity<Leaderboard>()
                .HasKey(lb => new { lb.FishingEventId, lb.ParticipantId });

            // Define relationships
            builder.Entity<FishingEvent>()
                .HasOne(e => e.Creator)
                .WithMany(c => c.FishingEvents)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FishingEvent>()
                .HasOne(e => e.Location)
                .WithMany(l => l.FishingEvents)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FishCaught>()
                .HasOne(fc => fc.Participant)
                .WithMany(p => p.FishCaughtRecords)
                .HasForeignKey(fc => fc.ParticipantId);

            builder.Entity<FishCaught>()
                .HasOne(fc => fc.FishingEvent)
                .WithMany(fe => fe.FishCaughtRecords)
                .HasForeignKey(fc => fc.FishingEventId);

            builder.Entity<Leaderboard>()
                .HasOne(lb => lb.Participant)
                .WithMany(p => p.Leaderboards)
                .HasForeignKey(lb => lb.ParticipantId);

            builder.Entity<Leaderboard>()
                .HasOne(lb => lb.FishingEvent)
                .WithMany(fe => fe.Leaderboards)
                .HasForeignKey(lb => lb.FishingEventId);
        }


        public DbSet<Creator> Creators { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<FishingEvent> FishingEvents { get; set; }
        public DbSet<FishingEventParticipant> FishingEventParticipants { get; set; }
        public DbSet<FishCaught> FishCaughtRecords { get; set; }
        public DbSet<Leaderboard> Leaderboards { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
