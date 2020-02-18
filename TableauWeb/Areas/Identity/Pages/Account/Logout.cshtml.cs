using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TableauWeb.Model;

namespace TableauWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<Utilisateur> _signInManager;

        public LogoutModel(SignInManager<Utilisateur> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage("/Tableaux/Index",  new { area = "" });
            }
        }
    }
}