using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.FishCaughtModels;
using FishingEventsApp.Core.Models.SpeciesModels;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Services
{
    public class FishCaughtService(FishingEventsDbContext context) : IFishCaughtService
    {
        public async Task AddFishAsync(FishCaughtAddModel model)
        {
            string caughDate = $"{model.DateCaught}";
            if (!DateTime.TryParseExact(caughDate, DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseStartDate))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            FishCaught entity = new FishCaught();

            entity.DateCaught = parseStartDate;
            entity.FishingEventId = model.FishingEventId;
            entity.UserId = model.UserId;
            entity.SpeciesId = model.SpeciesId;
            entity.Weight = model.Weight;
            entity.Length = model.Length;
            entity.CaughtImageUrl = model.CaughtImageUrl;
            await context.FishCaughts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SpeciesCaughtModel>> GetListSpeciesAsync()
        {
            var model = await context.Species
                .Select(s => new SpeciesCaughtModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .AsNoTracking()
                .ToListAsync();
            return model;
        }

        public async Task<ICollection<FishCaughtAllModel>> GetMyCaughtsAsync(string userId, int id)
        {
            var model = await context.FishCaughts
                .Where(f => f.FishingEventId == id && f.UserId == userId)
                .Select(f => new FishCaughtAllModel()
                {
                    FishingEventName = f.FishingEvent.EventName,
                    Species = f.Species.Name,
                    Weight = f.Weight,
                    Length = f.Length,
                    CaughtImageUrl = f.CaughtImageUrl,
                    DateCaught = f.DateCaught.ToString(DateFormat)
                })
                .AsNoTracking()
                .ToListAsync();
            return model;
        }
    }
}
