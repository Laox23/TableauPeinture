using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Model;

namespace TableauWeb.Utilisateurs
{
    [Authorize(Roles = Constantes.Role_Admin)]
    public class CreateModel : PageModel
    {
        private readonly SignInManager<Utilisateur> _signInManager;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly RoleManager<Role> _roleManager;

        [BindProperty]
        public UtilisateurModel Utilisateur { get; set; }

        public SelectList Roles { get; set; }

        public CreateModel(SignInManager<Utilisateur> signInManager,
            UserManager<Utilisateur> userManager,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task OnGetAsync()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            Roles = new SelectList(roles);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new Utilisateur { UserName = Utilisateur.Nom, Email = Utilisateur.Nom + "@test.test", EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, Utilisateur.Password);
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, Utilisateur.Role).Wait();

                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToPage("/Tableaux/Index", new { area = "" });
        }
    }
}