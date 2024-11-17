using FishingEvents.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.UserRoleModel
{
    public class AssignRoleViewModel
    {
        public string UserId { get; set; } = string.Empty;

        public string SelectedRole { get; set; } = null!;

        public IEnumerable<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        public IEnumerable<SelectListItemModel> Roles { get; set; } = new List<SelectListItemModel>();
    }
}
