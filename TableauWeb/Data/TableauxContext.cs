using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TableauWeb.Data.Config;
using TableauWeb.Model;

namespace TableauWeb.Data
{
    public class TableauxContext : IdentityDbContext<Utilisateur>
    {
        public TableauxContext(DbContextOptions<TableauxContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UtilisateurConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Finition> Finitions { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<ImageTableau> Images { get; set; }
        public DbSet<Tableau> Tableaux { get; set; }
    }
}