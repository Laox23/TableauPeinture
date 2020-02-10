using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dimensions.Add(Dimension);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
