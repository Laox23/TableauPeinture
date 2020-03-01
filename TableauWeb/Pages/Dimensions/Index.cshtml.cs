using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableauWeb.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace TableauWeb.Dimensions
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TableauxContext _context;

        public IndexModel(TableauxContext context)
        {
            _context = context;
        }

        public IList<Dimension> Dimension { get;set; }

        public async Task OnGetAsync()
        {
            Dimension = await _context.Dimensions.OrderByDescending(i => i.EstActif).ToListAsync();
        }
    }
}