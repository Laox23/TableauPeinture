using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Model;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using PdfSharpCore.Utils;
using System;
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

        public async Task OnGetAsync(int? tableauId)
        {
            Tableau = _context.Tableaux
                .Include(t => t.Image)
                .Include(t => t.Dimension)
                .Include(t => t.Finition)
                .First(e => e.TableauId == tableauId);

            var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == Tableau.ImageTableauId);

            Image = new ImagesInformation()
            {
                ImageTableauId = image.ImageTableauId,
                MaxImpression = image.MaxImpression,
                Nom = image.Nom,
                NomBase = image.NomBase,
                UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId)
            };
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var tableau = await _context.Tableaux.FirstOrDefaultAsync(t => t.TableauId == id);
            var image = await _context.Images.FirstOrDefaultAsync(t => t.ImageTableauId == tableau.ImageTableauId);

            string nomPdf = EcrisOuRetourneLePdfTableau(tableau, image);

            var net = new System.Net.WebClient();
            var data = net.DownloadData(Path.Combine(_webHostEnvironment.WebRootPath, _namesService.DossierPdf, nomPdf));
            var content = new MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";

            return File(content, contentType, nomPdf);
        }

        private string EcrisOuRetourneLePdfTableau(Tableau tableau, ImageTableau image)
        {
            var nomPdf = tableau.NomPdf;

            GlobalFontSettings.FontResolver = new FontResolver();

            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var tf = new XTextFormatter(gfx);

            var options = new XPdfFontOptions(PdfFontEncoding.WinAnsi);
            var  font = new XFont("OpenSans", 20, XFontStyle.Regular, options);

            var pagewidth = page.Width;

            tf.DrawString(image.Nom, new XFont("Helvetica", 8), XBrushes.Black, new XRect(0, 20, page.Width, page.Height));
            tf.DrawString(tableau.TexteImpressionAffichage, new XFont("Helvetica", 8), XBrushes.Black, new XRect(0, 40, page.Width, page.Height));
            tf.DrawString(DateTime.Now.ToShortDateString(), new XFont("Helvetica", 8), XBrushes.Black, new XRect(0, 100, page.Width, page.Height));

            //gfx.DrawString(image.Nom, font, XBrushes.Black, new XRect(0, 20, page.Width, page.Height), XStringFormats.Center);
            //gfx.DrawString(tableau.TexteImpressionAffichage, font, XBrushes.Black, new XRect(0, 40, page.Width, page.Height), XStringFormats.Center);
            //gfx.DrawString(DateTime.Now.ToShortDateString(), font, XBrushes.Black, new XRect(0, 100, page.Width, page.Height), XStringFormats.Center);

            using (var imagePdf = XImage.FromFile(Path.Combine(_webHostEnvironment.WebRootPath, _namesService.DossierImagesTableaux, image.NomBase)))
            {
                int imagewidth = (int)(pagewidth.Value / 2);
                var height = imagewidth;
                gfx.DrawImage(imagePdf, (int)(pagewidth.Value / 2) - (imagewidth / 2), 100, imagewidth, height);
            };

            document.Save(Path.Combine(_webHostEnvironment.WebRootPath, _namesService.DossierPdf, nomPdf));
            return nomPdf;
        }
    }
}