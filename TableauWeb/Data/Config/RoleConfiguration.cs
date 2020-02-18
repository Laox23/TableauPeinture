using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TableauWeb.Data.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "Utilisateur",
                NormalizedName = "UTILISATEUR"
            },
             new IdentityRole
             {
                 Name = "Redacteur",
                 NormalizedName = "REDACTEUR"
             },
            new IdentityRole
            {
                Name = "Administrateur",
                NormalizedName = "ADMINISTRATEUR"
            });
        }
    }
}