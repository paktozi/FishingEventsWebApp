﻿using FishingEvents.Infrastructure.Data.Configuration;
using FishingEvents.Infrastructure.Data.Models;
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

        public virtual DbSet<FishingEvent> FishingEvents { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Species> Species { get; set; } = null!;
        public virtual DbSet<FishCaught> FishCaughts { get; set; } = null!;
        public virtual DbSet<EventParticipant> EventParticipants { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser table configurations
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FishingEvents)
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

            // EventParticipant configurations (composite key)
            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.FishingEventId, ep.UserId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.User)
                .WithMany(u => u.EventParticipants)
                .HasForeignKey(ep => ep.UserId);

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.FishingEvent)
                .WithMany(e => e.EventParticipants)
                .HasForeignKey(ep => ep.FishingEventId);

            // FishCaught configurations
            modelBuilder.Entity<FishCaught>()
                .HasOne(fc => fc.User)
                .WithMany(u => u.FishCaughts)
                .HasForeignKey(fc => fc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FishCaught>()
                .HasOne(fc => fc.Species)
                .WithMany(s => s.FishCaughts)
                .HasForeignKey(fc => fc.SpeciesId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion to avoid accidental removals        

            // Location configurations
            modelBuilder.Entity<Location>()
                .HasMany(l => l.FishingEvents)
                .WithOne(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
               .HasOne(c => c.Author)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
              .HasOne(c => c.FishingEvent)
              .WithMany(fe => fe.Comments)
              .HasForeignKey(c => c.FishingEventId)
              .OnDelete(DeleteBehavior.Cascade);


            //Initial Seed
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new EventParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new SpeciesConfiguration());
            modelBuilder.ApplyConfiguration(new FishCaughtConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
