using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.FishCaughtModels;
using FishingEventsApp.Core.Models.SpeciesModels;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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
                throw new InvalidOperationException(DateErrorMessage);
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

        public async Task DeleteCaughtAsync(FishCaught entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditCaughtAsync(FishCaughtEditModel model, FishCaught fishCaught)
        {
            string dateCaught = $"{model.DateCaught}";
            if (!DateTime.TryParseExact(dateCaught, DateFormat, CultureInfo.InvariantCulture,
               DateTimeStyles.None, out DateTime parseDateCaught))
            {
                throw new InvalidOperationException(DateErrorMessage);
            }

            fishCaught.DateCaught = parseDateCaught;
            fishCaught.Length = model.Length;
            fishCaught.Weight = model.Weight;
            fishCaught.CaughtImageUrl = model.CaughtImageUrl;
            fishCaught.SpeciesId = model.SpeciesId;

            await context.SaveChangesAsync();
        }

        public async Task<FishCaught> FindCaughtAsync(int id)
        {
            return await context.FishCaughts.FindAsync(id);
        }

        public async Task<FishCaught> FindCaughtToDeleteAsync(int id)
        {
            return await context.FishCaughts
                 .Include(fc => fc.FishingEvent)
                 .Include(fc => fc.Species)
                 .FirstOrDefaultAsync(fc => fc.Id == id);
        }

        public async Task<FishCaughtEditModel> GetCaughtToEditAsync(int id)
        {

            var caught = await context.FishCaughts
                .Where(c => c.Id == id)
                .Select(c => new FishCaughtEditModel()
                {
                    CaughtImageUrl = c.CaughtImageUrl,
                    Weight = c.Weight,
                    Length = c.Length,
                    DateCaught = c.DateCaught.ToString(DateFormat),
                    SpeciesId = c.SpeciesId,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return caught;
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
