using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Services;

namespace TableauWeb.Images
{
    public class EditModel : PageModel
    {
        private readonly TableauxContext _context;

        public NamesService NamesService { get; set; }

        public EditModel(TableauxContext context,
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var imageAUpdate = await _context.Images.FirstAsync(i => i.Id == ImageTableau.Id);

            ImageTableau.Url = imageAUpdate.Url;
            ImageTableau.MaxImpression = imageAUpdate.MaxImpression;

            try
            {
                _context.Entry(imageAUpdate).CurrentValues.SetValues(ImageTableau);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageTableauExists(ImageTableau.Id))
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

        private bool ImageTableauExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}