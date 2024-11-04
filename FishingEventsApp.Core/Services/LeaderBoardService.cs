using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.LeaderBoardModels;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Services
{
    public class LeaderBoardService(FishingEventsDbContext context) : ILeaderBoardService
    {
        public async Task<ICollection<LeaderBoardModel>> GetGeneralLeaderboardAsync(int id)
        {
            var leaderboard = await context.FishCaughts
       .GroupBy(fc => new { fc.UserId, fc.User.FirstName, fc.User.LastName })
       .Select(g => new LeaderBoardModel
       {
           UserId = g.Key.UserId,
           FirstName = g.Key.FirstName,
           LastName = g.Key.LastName,
           TotalFishCaught = g.Count(),
           TotalWeight = Math.Round(g.Sum(fc => fc.Weight), 2)
       })
       .OrderByDescending(entry => entry.TotalWeight)
       .AsNoTracking()
       .ToListAsync();

            return leaderboard;
        }

        public async Task<ICollection<LeaderBoardModel>> GetLeaderboardAsync(int id)
        {
            var leaderboard = await context.FishCaughts
        .Where(fc => fc.FishingEventId == id)
        .GroupBy(fc => new { fc.UserId, fc.User.FirstName, fc.User.LastName })
        .Select(g => new LeaderBoardModel
        {
            UserId = g.Key.UserId,
            FirstName = g.Key.FirstName,
            LastName = g.Key.LastName,
            TotalFishCaught = g.Count(),
            TotalWeight = Math.Round(g.Sum(fc => fc.Weight), 2)
        })
        .OrderByDescending(l => l.TotalWeight)
        .AsNoTracking()
        .ToListAsync();

            return leaderboard;
        }
    }
}
