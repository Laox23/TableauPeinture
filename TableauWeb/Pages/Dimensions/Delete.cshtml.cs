using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Threading.Tasks;

namespace TableauWeb.Dimensions
{
    public class DeleteModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public DeleteModel(TableauWeb.Data.TableauxContext context)
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
