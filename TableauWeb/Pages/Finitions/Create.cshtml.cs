using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
using System.Threading.Tasks;

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