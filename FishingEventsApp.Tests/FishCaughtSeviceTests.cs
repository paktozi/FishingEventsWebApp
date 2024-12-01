using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.SpeciesModels;
using FishingEventsApp.Core.Services;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Tests
{
    public class FishCaughtSeviceTests
    {
        private ISpeciesService speciesService;
        private FishingEventsDbContext context;

        [SetUp]
        public void Setup()
        {
            // Configure in-memory database
            var options = new DbContextOptionsBuilder<FishingEventsDbContext>()
                .UseInMemoryDatabase("FishingEventsTestDb")
                .Options;
            context = new FishingEventsDbContext(options);

            // Seed initial data
            context.Species.Add(new Species
            {
                Id = 1,
                Name = "Rainbow Trout",
                Description = "Freshwater fish",
                HabitatName = "Rivers and lakes",
                FishBait = "Worms",
                FishImageUrl = "rainbowTroutImageUrl"
            });
            context.SaveChanges();

            // Create service instance
            speciesService = new SpeciesService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task AddFishAsync_ShouldAddNewSpecies()
        {
            // Arrange
            var newSpecies = new SpeciesAddModel
            {
                Name = "Bass",
                Description = "Freshwater fish",
                HabitatName = "Lakes and rivers",
                FishBait = "Minnows",
                FishImageUrl = "bassImageUrl"
            };

            // Act
            await speciesService.AddFishAsync(newSpecies);

            // Assert
            var addedSpecies = context.Species.FirstOrDefault(s => s.Name == "Bass");
            Assert.That(addedSpecies, Is.Not.Null);
            Assert.That(addedSpecies.Name, Is.EqualTo("Bass"));
            Assert.That(addedSpecies.Description, Is.EqualTo("Freshwater fish"));
            Assert.That(addedSpecies.HabitatName, Is.EqualTo("Lakes and rivers"));
        }

        [Test]
        public async Task DeleteFishAsync_ShouldRemoveSpecies()
        {
            // Arrange
            var speciesToDelete = await context.Species.FirstOrDefaultAsync(s => s.Id == 1);

            // Act
            await speciesService.DeleteFishAsync(speciesToDelete);

            // Assert
            var deletedSpecies = await context.Species.FirstOrDefaultAsync(s => s.Id == 1);
            Assert.That(deletedSpecies, Is.Null);
        }

        [Test]
        public async Task EditSpeciesAsync_ShouldUpdateSpecies()
        {
            // Arrange
            var speciesToEdit = await context.Species.FirstOrDefaultAsync(s => s.Id == 1);
            var editModel = new SpeciesEditModel
            {
                Name = "Rainbow Trout Updated",
                Description = "Updated description",
                HabitatName = "Mountain streams",
                FishBait = "Artificial lures",
                FishImageUrl = "updatedImageUrl"
            };

            // Act
            await speciesService.EditSpeciesAsync(editModel, speciesToEdit);

            // Assert
            var editedSpecies = await context.Species.FirstOrDefaultAsync(s => s.Id == 1);
            Assert.That(editedSpecies, Is.Not.Null);
            Assert.That(editedSpecies.Name, Is.EqualTo("Rainbow Trout Updated"));
            Assert.That(editedSpecies.Description, Is.EqualTo("Updated description"));
            Assert.That(editedSpecies.HabitatName, Is.EqualTo("Mountain streams"));
        }

        [Test]
        public async Task FindSpeciesAsync_ShouldReturnCorrectSpecies()
        {
            // Act
            var species = await speciesService.FindSpeciesAsync(1);

            // Assert
            Assert.That(species, Is.Not.Null);
            Assert.That(species.Name, Is.EqualTo("Rainbow Trout"));
            Assert.That(species.Description, Is.EqualTo("Freshwater fish"));
        }

        [Test]
        public async Task GetAllSpeciesAsync_ShouldReturnAllSpecies()
        {
            // Act
            var speciesList = await speciesService.GetAllSpeciesAsync(null);

            // Assert
            Assert.That(speciesList, Is.Not.Null);
            Assert.That(speciesList.Count(), Is.EqualTo(1));
            Assert.That(speciesList.First().Name, Is.EqualTo("Rainbow Trout"));
        }

        [Test]
        public async Task GetAllSpeciesAsync_WithFilter_ShouldReturnFilteredSpecies()
        {
            // Act
            var speciesList = await speciesService.GetAllSpeciesAsync("Trout");

            // Assert
            Assert.That(speciesList, Is.Not.Null);
            Assert.That(speciesList.Count(), Is.EqualTo(1));
            Assert.That(speciesList.First().Name, Is.EqualTo("Rainbow Trout"));
        }

        [Test]
        public async Task GetSpeciesToEdit_ShouldReturnSpeciesForEditing()
        {
            // Act
            var speciesToEdit = await speciesService.GetSpeciesToEdit(1);

            // Assert
            Assert.That(speciesToEdit, Is.Not.Null);
            Assert.That(speciesToEdit.Name, Is.EqualTo("Rainbow Trout"));
            Assert.That(speciesToEdit.Description, Is.EqualTo("Freshwater fish"));
        }

    }
}
