using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Model;

namespace TableauWeb.Finitions
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly TableauxContext _context;

        public DeleteModel(TableauxContext context)
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