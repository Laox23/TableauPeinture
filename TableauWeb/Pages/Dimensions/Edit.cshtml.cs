using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Model;

namespace TableauWeb.Dimensions
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly TableauxContext _context;

        public EditModel(TableauxContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dimension).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimensionExists(Dimension.DimensionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DimensionExists(int id)
        {
            return _context.Dimensions.Any(e => e.DimensionId == id);
        }
    }
}
