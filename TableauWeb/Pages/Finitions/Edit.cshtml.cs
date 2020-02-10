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

namespace TableauWeb.Finitions
{
    public class EditModel : PageModel
    {
        private readonly TableauWeb.Data.TableauxContext _context;

        public EditModel(TableauWeb.Data.TableauxContext context)
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

            Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.Id == id);

            if (Finition == null)
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

            _context.Attach(Finition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinitionExists(Finition.Id))
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

        private bool FinitionExists(int id)
        {
            return _context.Finitions.Any(e => e.Id == id);
        }
    }
}
