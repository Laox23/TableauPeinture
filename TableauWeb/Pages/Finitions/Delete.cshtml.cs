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
    public class DeleteModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public DeleteModel(TableauWeb.Data.TableauxContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Finition Finition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.FinitionId == id);

            if (Finition == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Finition = await _context.Finitions.FindAsync(id);

            if (Finition != null)
            {
                _context.Finitions.Remove(Finition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
