using Microsoft.EntityFrameworkCore;
using Model;

namespace TableauWeb.Data
{
    public class TableauxContext : DbContext
    {
        public TableauxContext(DbContextOptions<TableauxContext> options)
           : base(options)
        {
        }

        public DbSet<Finition> Finitions { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<ImageTableau> Images { get; set; }
        public DbSet<Tableau> Tableaux { get; set; }
    }
}