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
    public class EditModel : PageModel
    {
        private readonly UserManager<Utilisateur> _userManager;
        private readonly RoleManager<Role> _roleManager;

        [BindProperty]
        public UtilisateurModel Utilisateur { get; set; }

        public SelectList Roles { get; set; }

        public EditModel(UserManager<Utilisateur> userManager,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            Roles = new SelectList(roles);

            var utilisateur = await _userManager.FindByIdAsync(id);

            var rolesUtilisateur = await _userManager.GetRolesAsync(utilisateur);

            Utilisateur = new UtilisateurModel()
            {
                Nom = utilisateur.UserName,
                Role = rolesUtilisateur.First()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var utilisateur = await _userManager.FindByNameAsync(Utilisateur.Nom);

            var roles = await _userManager.GetRolesAsync(utilisateur);
            await _userManager.RemoveFromRolesAsync(utilisateur, roles.ToArray());

            await _userManager.AddToRoleAsync(utilisateur, Utilisateur.Role);

            return RedirectToPage("./Index");
        }
    }
}