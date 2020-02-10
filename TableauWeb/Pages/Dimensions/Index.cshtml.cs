using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TableauWeb.Dimensions
{
    public class IndexModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public IndexModel(TableauWeb.Data.TableauxContext context)
        {
            _context = context;
        }

        public IList<Dimension> Dimension { get;set; }

        public async Task OnGetAsync()
        {
            Dimension = await _context.Dimensions.ToListAsync();
        }
    }
}
