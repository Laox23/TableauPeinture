using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using TableauWeb.Data;

namespace TableauWeb
{
    public class tModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public tModel(TableauWeb.Data.TableauxContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ImageTableau ImageTableau { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Images.Add(ImageTableau);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
