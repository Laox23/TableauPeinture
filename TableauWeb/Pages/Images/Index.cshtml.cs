using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Services;

namespace TableauWeb.Images
{
    public class IndexModel : PageModel
    {
        private readonly TableauxContext _context;

        public NamesService NamesService { get; set; }

        public IndexModel(TableauxContext context, NamesService namesService)
        {
            _context = context;
            NamesService = namesService;
        }

        public IList<ImageTableau> ImageTableau { get;set; }

        public async Task OnGetAsync()
        {
            ImageTableau = await _context.Images.ToListAsync();
        }
    }
}
