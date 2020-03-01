using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Model;

namespace TableauWeb.Finitions
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TableauxContext _context;

        public CreateModel(TableauxContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Finition Finition { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Finition.EstActif = true;

            _context.Finitions.Add(Finition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}