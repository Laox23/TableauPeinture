using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using TableauWeb.Data;

namespace TableauWeb.Finitions
{
    public class IndexModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public IndexModel(TableauWeb.Data.TableauxContext context)
        {
            _context = context;
        }

        public IList<Finition> Finition { get;set; }

        public async Task OnGetAsync()
        {
            Finition = await _context.Finitions.ToListAsync();
        }
    }
}
