using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;

namespace TableauWeb.Finitions
{
    public class IndexModel : PageModel
    {
        private readonly TableauxContext _context;

        public IndexModel(TableauxContext context)
        {
            _context = context;
        }

        public IList<Finition> Finition { get;set; }

        public async Task OnGetAsync()
        {
            Finition = await _context.Finitions.OrderByDescending(i => i.EstActif).ToListAsync();
        }
    }
}