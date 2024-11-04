using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.LeaderBoardModels
{
    public class LeaderBoardModel
    {
        public string UserId { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int TotalFishCaught { get; set; }

        public double TotalWeight { get; set; }
    }
}
