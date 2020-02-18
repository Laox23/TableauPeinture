using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Model;

namespace TableauWeb.Data
{
    public class UtilisateurDataInitializer
    {
        public static void SeedData (UserManager<Utilisateur> userManager, RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers (UserManager<Utilisateur> userManager)
        {
            if (userManager.FindByNameAsync(Constantes.Role_Admin).Result == null)
            {
                var user = new Utilisateur();
                user.UserName = Constantes.Role_Admin;
                user.Email = Constantes.Role_Admin + "@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Azerty01!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,Constantes.Role_Admin).Wait();
                }
            }

            if (userManager.FindByNameAsync(Constantes.Role_Redacteur).Result == null)
            {
                var user = new Utilisateur();
                user.UserName = Constantes.Role_Redacteur;
                user.Email = Constantes.Role_Redacteur + "@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Azerty01!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Constantes.Role_Redacteur).Wait();
                }
            }

            if (userManager.FindByNameAsync(Constantes.Role_Utilisateur).Result == null)
            {
                var user = new Utilisateur();
                user.UserName = Constantes.Role_Utilisateur;
                user.Email = Constantes.Role_Utilisateur + "@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Azerty01!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Constantes.Role_Utilisateur).Wait();
                }
            }
        }

        public static void SeedRoles (RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync(Constantes.Role_Admin).Result)
            {
                var role = new Role();
                role.Name = Constantes.Role_Admin;
                var roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(Constantes.Role_Redacteur).Result)
            {
                var role = new Role();
                role.Name = Constantes.Role_Redacteur;
                var roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(Constantes.Role_Utilisateur).Result)
            {
                var role = new Role();
                role.Name = Constantes.Role_Utilisateur;
                var roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
