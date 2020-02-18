using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Model;

namespace TableauWeb.Utilisateurs
{
    [Authorize(Roles = Constantes.Role_Admin)]
    public class IndexModel : PageModel
    {
        private UserManager<Utilisateur> _userManager;
        private RoleManager<Role> _roleManager;

        [BindProperty(SupportsGet = true)]
        public IList<Utilisateur> Utilisateurs { get; set; }

        public IndexModel(UserManager<Utilisateur> userManager,
         RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync()
        {
            Utilisateurs = await _userManager.Users.Include(u => u.UtilisateursRoles).ThenInclude(ur => ur.Role).ToListAsync();
        }
    }
}