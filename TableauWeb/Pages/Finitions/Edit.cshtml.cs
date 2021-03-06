﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableauWeb.Model;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace TableauWeb.Finitions
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
        public Finition Finition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.FinitionId == id);

            if (Finition == null)
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

            _context.Attach(Finition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinitionExists(Finition.FinitionId))
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
            return _context.Finitions.Any(e => e.FinitionId == id);
        }
    }
}