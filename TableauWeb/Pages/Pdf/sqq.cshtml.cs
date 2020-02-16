using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using TableauWeb.Data;

namespace TableauWeb
{
    public class sqqModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public sqqModel(TableauWeb.Data.TableauxContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ImageTableau ImageTableau { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ImageTableau = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == id);

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ImageTableau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageTableauExists(ImageTableau.ImageTableauId))
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
            return _context.Images.Any(e => e.ImageTableauId == id);
        }
    }
}
