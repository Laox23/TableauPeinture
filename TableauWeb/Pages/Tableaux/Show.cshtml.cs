using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableauWeb.Model;
using System.IO;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;
using Microsoft.AspNetCore.Authorization;

namespace TableauWeb.Tableaux
{
    [Authorize]
    public class ShowModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;

        private IWebHostEnvironment _webHostEnvironment;
        private NamesService _namesService { get; set; }


        public Tableau Tableau { get; set; }

        [BindProperty]
        public ImagesInformation Image { get; set; }


        [BindProperty]
        public int TableauId { get; set; }


        public ShowModel(IWebHostEnvironment webHostEnvironment,
                            TableauxContext context,
                            IFichierService fichierService,
                            NamesService namesService)
        {
            _context = context;
            _fichierService = fichierService;
            _webHostEnvironment = webHostEnvironment;
            _namesService = namesService;
        }

        public async Task<IActionResult> OnGetAsync(int tableauId)
        {
            TableauId = tableauId;
            var tableau = await _context.Tableaux.FirstOrDefaultAsync(t => t.TableauId == TableauId);
            var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == tableau.ImageTableauId);

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
                Dimension = await _context.Dimensions.FirstOrDefaultAsync(m => m.DimensionId == tableau.DimensionId),
                Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.FinitionId == tableau.FinitionId),
                NombreImpression = tableau.NombreImpression
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var tableau = await _context.Tableaux.FirstOrDefaultAsync(t => t.TableauId == TableauId);

            string nomPdf = await _fichierService.EcrisOuRetourneLePdfTableau(tableau);

            var net = new System.Net.WebClient();
            var data = net.DownloadData(Path.Combine(_webHostEnvironment.WebRootPath, _namesService.DossierPdf, nomPdf));
            var content = new MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";

            return File(content, contentType, nomPdf);
        }
    }
}