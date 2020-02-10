using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Services;

namespace TableauWeb.Tableaux
{
    public class CreateModel : PageModel
    {
        private readonly TableauxContext _context;


        [BindProperty]
        public Tableau Tableau { get; set; }

        [BindProperty]
        public ImageTableau Image { get; set; }

        public IList<Dimension> Dimensions { get; set; }
        public IList<Finition> Finitions { get; set; }
        public IList<Tableau> Tableaux { get; set; }

        public NamesService NamesService { get; set; }

        public CreateModel(TableauxContext context,
            NamesService namesService)
        {
            _context = context;
            NamesService = namesService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Image = await _context.Images.FirstOrDefaultAsync(m => m.Id == id);

            if (Image == null)
            {
                return NotFound();
            }

            Dimensions = await _context.Dimensions.OrderByDescending(d => d.Hauteur).ToListAsync();
            Finitions = await _context.Finitions.ToListAsync();

            return Page();
        }

        [BindProperty]
        public int DimensionId { get; set; }

        [BindProperty]
        public int FinitionId { get; set; }

        [BindProperty]
        public int ImageId { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Tableau = new Tableau();
            Tableau.Image = await _context.Images.FirstOrDefaultAsync(m => m.Id == ImageId);
            Tableau.Dimension = await _context.Dimensions.FirstOrDefaultAsync(m => m.Id == DimensionId);
            Tableau.Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.Id == FinitionId);

            Tableau.NombreImpression = _context.Tableaux.Count(t => t.Image.Id == ImageId) + 1;

            _context.Tableaux.Add(Tableau);
            await _context.SaveChangesAsync();

            return RedirectToPage("./End", new { Tableau.Id });
        }
    }
}
