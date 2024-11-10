using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.LeaderBoardModels;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class LeaderBoardController(ILeaderBoardService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> LeaderBoard(int id)
        {
            ICollection<LeaderBoardModel> model = await service.GetLeaderboardAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GeneralLeaderBoard(int id)
        {
            ICollection<LeaderBoardModel> model = await service.GetGeneralLeaderboardAsync(id);
            return View(model);
        }
    }
}
