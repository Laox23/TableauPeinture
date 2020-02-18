using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TableauWeb.Model
{
    public class Role : IdentityRole
    {
        public ICollection<UtilisateurRole> UtilisateursRoles { get; set; }
    }
}