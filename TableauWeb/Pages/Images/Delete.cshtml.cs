using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Services;

namespace TableauWeb.Images
{
    public class DeleteModel : PageModel
    {
        private readonly TableauxContext _context;

        public NamesService NamesService { get; set; }

        public DeleteModel(TableauWeb.Data.TableauxContext context, 
            NamesService namesService)
        {
            _context = context;
            NamesService = namesService;
        }

        [BindProperty]
        public ImageTableau ImageTableau { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ImageTableau = await _context.Images.FirstOrDefaultAsync(m => m.Id == id);

            if (ImageTableau == null)
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

            ImageTableau = await _context.Images.FindAsync(id);

            if (ImageTableau != null)
            {
                _context.Images.Remove(ImageTableau);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
