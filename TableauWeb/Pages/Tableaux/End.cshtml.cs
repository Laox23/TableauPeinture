using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Model;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;

namespace TableauWeb.Tableaux
{
    public class EndModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;

        private IWebHostEnvironment _webHostEnvironment;
        private NamesService _namesService { get; set; }

        public Tableau Tableau { get; set; }

        [BindProperty]
        public ImagesInformation Image { get; set; }

        [BindProperty]
        public int ImageTableauId { get; set; }
        [BindProperty]
        public int DimensionId { get; set; }
        [BindProperty]
        public int FinitionId { get; set; }

        public EndModel(IWebHostEnvironment webHostEnvironment,
                            TableauxContext context,
                            IFichierService fichierService,
                            NamesService namesService)
        {
            _context = context;
            _fichierService = fichierService;
            _webHostEnvironment = webHostEnvironment;
            _namesService = namesService;
        }

        public async Task<IActionResult> OnGetAsync(int imageTableauId, int dimensionId, int finitionId)
        {
            if(imageTableauId == 0 || dimensionId == 0 || finitionId == 0)
            {
                return Redirect("/Tableaux/Index");
            }

            ImageTableauId = imageTableauId;
            DimensionId = dimensionId;
            FinitionId = finitionId;

            var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == imageTableauId);

            Image = new ImagesInformation()
            {
                ImageTableauId = image.ImageTableauId,
                MaxImpression = image.MaxImpression,
                Nom = image.Nom,
                NomBase = image.NomBase,
                UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId)
            };

            Tableau = new Tableau()
            {
                Dimension = await _context.Dimensions.FirstOrDefaultAsync(m => m.DimensionId == dimensionId),
                Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.FinitionId == finitionId),
                NombreImpression = _context.Tableaux.Count(t => t.Image.ImageTableauId == imageTableauId) + 1
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()//int? id)
        {
            if(Tableau == null || Tableau.TableauId == 0)
            {
                var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == ImageTableauId);
                var nombresImpression = _context.Tableaux.Count(t => t.Image.ImageTableauId == ImageTableauId) + 1;

                Tableau = new Tableau()
                {
                    Image = image,
                    Dimension = await _context.Dimensions.FirstOrDefaultAsync(m => m.DimensionId == DimensionId),
                    Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.FinitionId == FinitionId),
                    NombreImpression = nombresImpression,
                    NomPdf = image.Nom.Trim().Replace(" ", "_") + "_" + nombresImpression.ToString("D4") + ".pdf"
                };

                _context.Tableaux.Add(Tableau);
                _context.SaveChanges();
            }

            return RedirectToPage("./Show", new { Tableau.TableauId });
        }
    }
}