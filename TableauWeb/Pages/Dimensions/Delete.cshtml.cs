using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Model;

namespace TableauWeb.Dimensions
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
        public Dimension Dimension { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dimension = await _context.Dimensions.FirstOrDefaultAsync(m => m.DimensionId == id);

            if (Dimension == null)
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

            Dimension = await _context.Dimensions.FindAsync(id);

            if (Dimension != null)
            {
                _context.Dimensions.Remove(Dimension);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
