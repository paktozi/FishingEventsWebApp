using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FishingEventsWebApp.CustomAttributes
{
    public class GlobalAdminAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the user is authenticated
            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? true)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null); // Redirect unauthenticated users to Login
                return;
            }

            // Check if the user is in the GrandAdmin role
            if (!context.HttpContext.User.IsInRole("GlobalAdmin"))
            {
                context.Result = new RedirectToActionResult("Unauthorized", "Errors", null); // Redirect unauthorized users
            }
        }
    }
}
