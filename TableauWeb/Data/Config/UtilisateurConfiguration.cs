using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TableauWeb.Data.Config
{
    public class UtilisateurConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(
            new IdentityUser
            {
                UserName = "Administrateur",
                NormalizedUserName = "Administrateur",
            },
            new IdentityUser
            {
                UserName = "Redacteur",
                NormalizedUserName = "Redacteur"
            });
        }
    }
}