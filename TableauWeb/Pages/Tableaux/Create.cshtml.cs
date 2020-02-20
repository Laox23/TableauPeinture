using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableauWeb.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;
using Microsoft.AspNetCore.Authorization;

namespace TableauWeb.Tableaux
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;

        public NamesService NamesService { get; set; }

        [BindProperty]
        public Tableau Tableau { get; set; }

        [BindProperty]
        public ImagesInformation Image { get; set; }


        [BindProperty]
        public int DimensionId { get; set; }

        [BindProperty]
        public int FinitionId { get; set; }

        [BindProperty]
        public int ImageTableauId { get; set; }


        public IList<Dimension> Dimensions { get; set; }
        public IList<Finition> Finitions { get; set; }
        public IList<Tableau> Tableaux { get; set; }


        public CreateModel(TableauxContext context,
            NamesService namesService,
            IFichierService fichierService)
        {
            _context = context;
            _fichierService = fichierService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == id);

            Image = new ImagesInformation()
            {
                ImageTableauId = image.ImageTableauId,
                MaxImpression = image.MaxImpression,
                Nom = image.Nom,
                NomBase = image.NomBase,
                UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId)
            };

            if (Image == null)
            {
                return NotFound();
            }

            Dimensions = await _context.Dimensions.Where(t => t.EstActif == true).OrderByDescending(d => d.Hauteur).ToListAsync();
            Finitions = await _context.Finitions.Where(t => t.EstActif == true).ToListAsync();

            return Page();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./End", new { ImageTableauId, DimensionId, FinitionId });
        }
    }
}
