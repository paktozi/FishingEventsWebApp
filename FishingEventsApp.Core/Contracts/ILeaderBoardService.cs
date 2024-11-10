using FishingEventsApp.Core.Models.LeaderBoardModels;

namespace FishingEventsApp.Core.Contracts
{
    public interface ILeaderBoardService
    {
        Task<ICollection<LeaderBoardModel>> GetGeneralLeaderboardAsync(int id);
        Task<ICollection<LeaderBoardModel>> GetLeaderboardAsync(int id);
    }
}
