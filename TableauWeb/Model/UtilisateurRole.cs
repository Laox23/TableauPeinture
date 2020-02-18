using Microsoft.AspNetCore.Identity;

namespace TableauWeb.Model
{
    public class UtilisateurRole : IdentityUserRole<string>
    {
        public virtual Utilisateur Utilisateur { get; set; }
        public virtual Role Role { get; set; }
    }
}