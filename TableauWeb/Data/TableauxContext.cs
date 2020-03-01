using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TableauWeb.Model;

namespace TableauWeb.Data
{
    public class TableauxContext :  IdentityDbContext<Utilisateur, Role, string, IdentityUserClaim<string>,
        UtilisateurRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public TableauxContext(DbContextOptions<TableauxContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UtilisateurRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UtilisateursRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.Utilisateur)
                    .WithMany(r => r.UtilisateursRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }

        public DbSet<Finition> Finitions { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<ImageTableau> Images { get; set; }
        public DbSet<Tableau> Tableaux { get; set; }
    }
}