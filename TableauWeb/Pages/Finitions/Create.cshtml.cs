using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using TableauWeb.Data;

namespace TableauWeb.Finitions
{
    public class CreateModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public CreateModel(TableauWeb.Data.TableauxContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Finition Finition { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Finitions.Add(Finition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
