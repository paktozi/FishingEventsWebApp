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
            var leaderboard = await context.EventParticipants
        .Where(fp => fp.FishingEventId == id)
        .GroupJoin(
            context.FishCaughts.Where(fc => fc.FishingEventId == id),
            participant => participant.UserId,
            fishCaught => fishCaught.UserId,
            (participant, fishCaughts) => new { participant, fishCaughts }
        )
        .Select(group => new LeaderBoardModel
        {
            UserId = group.participant.UserId,
            FirstName = group.participant.User.FirstName,
            LastName = group.participant.User.LastName,
            TotalFishCaught = group.fishCaughts.Count(),
            TotalWeight = Math.Round(group.fishCaughts.Sum(fc => fc.Weight), 2)
        })
        .OrderByDescending(l => l.TotalWeight)
        .AsNoTracking()
        .ToListAsync();

            return leaderboard;
        }
    }
}
