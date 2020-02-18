using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TableauWeb.Model;
using System.Threading.Tasks;

namespace TableauWeb.Dimensions
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
        public Dimension Dimension { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Dimension.EstActif = true;

            _context.Dimensions.Add(Dimension);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}