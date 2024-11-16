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
        // Selected user ID for role assignment or removal
        public string UserId { get; set; }

        // Selected role for assignment or removal
        public string SelectedRole { get; set; }

        // List of users to be displayed in the dropdown
        public IEnumerable<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        // List of roles to be displayed in the dropdown
        public IEnumerable<SelectListItemModel> Roles { get; set; } = new List<SelectListItemModel>();
    }
}
