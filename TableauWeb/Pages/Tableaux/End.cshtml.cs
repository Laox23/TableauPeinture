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

        public Tableau Tableau { get; set; }

        [BindProperty]
        public ImagesInformation Image { get; set; }

        //public NamesService namesService { get; set; }

        public EndModel(IWebHostEnvironment webHostEnvironment,
                            TableauxContext context,
                            IFichierService fichierService)
        {
            _context = context;
            _fichierService = fichierService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task OnGetAsync(int id)
        {
            Tableau = _context.Tableaux
                .Include(t => t.Image)
                .Include(t => t.Dimension)
                .Include(t => t.Finition)
                .First(e => e.Id == id);

            var image = await _context.Images.FirstOrDefaultAsync(m => m.Id == Tableau.ImageId);

            Image = new ImagesInformation()
            {
                ImageId = image.Id,
                MaxImpression = image.MaxImpression,
                Nom = image.Nom,
                NomBase = image.NomBase,
                UrlAffichage = _fichierService.GetUrlImage(image.Id)
            };

        }
        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    return Page();

        //    //var net = new System.Net.WebClient();
        //    //var data = net.DownloadData(Path.Combine(WebHostEnvironment.WebRootPath, NamesService.DossierPdf, "pdf-test.pdf"));
        //    //var content = new System.IO.MemoryStream(data);
        //    //var contentType = "APPLICATION/octet-stream";
        //    //var fileName = "resultat.pdf";
        //    //return File(content, contentType, fileName);
        //}
    }
}