// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

//TODO: don't actually need this file just for reference

using System;
using System.Threading.Tasks;
using KlinikH.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KlinikH.Web.Areas.User.AccountBundle.Views
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<AppUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
			return RedirectToPage("Logout");
			/*            if (false)
						{
							return LocalRedirect(returnUrl);
						}
						else
						{
							// This needs to be a redirect so that the browser performs a new
							// request and the identity for the user gets updated.
							return RedirectToPage();
						}*/
		}

        //TODO: there is actually also a onGet counter part here too nice
    }
}
