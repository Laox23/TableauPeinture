﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TableauWeb.Model
{
    public class Utilisateur : IdentityUser
    {
        public ICollection<UtilisateurRole> UtilisateursRoles { get; set; }
    }
}