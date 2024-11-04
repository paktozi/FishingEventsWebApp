using FishingEventsApp.Core.Models.LeaderBoardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Contracts
{
    public interface ILeaderBoardService
    {
        Task<ICollection<LeaderBoardModel>> GetGeneralLeaderboardAsync(int id);
        Task<ICollection<LeaderBoardModel>> GetLeaderboardAsync(int id);
    }
}
