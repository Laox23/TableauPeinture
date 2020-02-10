using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Linq;
using System.Threading.Tasks;

namespace TableauWeb.Dimensions
{
    public class EditModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public EditModel(TableauWeb.Data.TableauxContext context)
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

            Dimension = await _context.Dimensions.FirstOrDefaultAsync(m => m.Id == id);

            if (Dimension == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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
                if (!DimensionExists(Dimension.Id))
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
            return _context.Dimensions.Any(e => e.Id == id);
        }
    }
}
