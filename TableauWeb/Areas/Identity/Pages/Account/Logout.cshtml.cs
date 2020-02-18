using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TableauWeb.Model;

namespace TableauWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<Utilisateur> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<Utilisateur> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if(_signInManager.IsSignedIn(User))
            {

            }
            else
            {

            }

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage("/Tableaux/Index",  new { area = "" });
            }
        }

        //public async Task<IActionResult> OnPost(string returnUrl = null)
        //{
        //    await _signInManager.SignOutAsync();

        //    if (_signInManager.IsSignedIn(User))
        //    {

        //    }
        //    else
        //    {

        //    }

        //    if (returnUrl != null)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToPage("/Images/Index", new { area = "" });
        //    }
        //}
    }
}
