﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsWebApp.CustomAttributes
{
    public class AdminAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the user is authenticated
            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? true)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null); // Redirect unauthenticated users to Login
                return;
            }

            // Check if the user is in the Admin role
            if (!context.HttpContext.User.IsInRole(AdminRole) && !context.HttpContext.User.IsInRole(GlobalAdminRole))
            {
                context.Result = new RedirectToActionResult("Unauthorized", "Errors", null); // Redirect unauthorized users
            }
        }
    }
}
