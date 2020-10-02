using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Model;

namespace TableauWeb.Services
{
    public interface IFichierService
    {
        Task<string> CreateFile(FileInfo fileInfo);
        Task<string> CreateFile(IFormFile formFile);
        Task<string> GetUrlImage(int id);
        Task<string> EcrisOuRetourneLePdfTableau(Tableau tableau);
    }

    public class FichierService : IFichierService
    {
        private readonly NamesService _namesService;
        private readonly TableauxContext _context;
        private readonly IWebHostEnvironment _environment;

        public FichierService(NamesService namesService,
            TableauxContext context,
            IWebHostEnvironment environment)
        {
            _namesService = namesService;
            _context = context;
            _environment = environment;
        }

        public async Task<string> CreateFile(IFormFile formFile)
        {
            var newFileName = string.Empty;

            if (formFile.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                var FileExtension = Path.GetExtension(fileName);
                newFileName = myUniqueFileName + FileExtension;

                fileName = Path.Combine(_environment.WebRootPath, _namesService.DossierImagesTableaux, newFileName);

                using (FileStream fs = File.Create(fileName))
                {
                    formFile.CopyTo(fs);
                    fs.Flush();
                }
            }

            return newFileName;
        }

        public async Task<string> CreateFile(FileInfo fileInfo)
        {
            var fileName = fileInfo.FullName.Trim('"');
            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
            var FileExtension = Path.GetExtension(fileName);
            var newFileName = myUniqueFileName + FileExtension;

            fileName = Path.Combine(_environment.WebRootPath, _namesService.DossierImagesTableaux, newFileName);

            fileInfo.CopyTo(fileName);

            return newFileName;
        }

        public async Task<string> GetUrlImage(int id)
        {
            var imageBase = _context.Set<ImageTableau>().FirstOrDefault(i => i.ImageTableauId == id);
            if (imageBase != null)
            {
                return "/" + Path.Combine(_namesService.DossierImagesTableaux, imageBase.NomBase);
            }

            return string.Empty;
        }

        public async Task<string> EcrisOuRetourneLePdfTableau(Tableau tableau)
        {
            var nomPdf = tableau.NomPdf;

            if (File.Exists(Path.Combine(_environment.WebRootPath, _namesService.DossierPdf, tableau.NomPdf)))
            {
                return tableau.NomPdf;
            }

            var image = await _context.Images.FirstOrDefaultAsync(t => t.ImageTableauId == tableau.ImageTableauId);

            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var options = new XPdfFontOptions(PdfFontEncoding.WinAnsi);
            var font = new XFont("OpenSans", 20, XFontStyle.Regular, options);

            var pagewidth = page.Width;

            gfx.DrawString(image.Nom, font, XBrushes.Black, new XRect(0, 20, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString(tableau.TexteImpressionAffichage, font, XBrushes.Black, new XRect(0, 40, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString(tableau.DateCreation.ToShortDateString(), font, XBrushes.Black, new XRect(0, 100, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString(tableau.CodeVerif, font, XBrushes.Black, new XRect(0, 160, page.Width, page.Height), XStringFormats.Center);

            using (var imagePdf = XImage.FromFile(Path.Combine(_environment.WebRootPath, _namesService.DossierImagesTableaux, image.NomBase)))
            {
                int imagewidth = (int)(pagewidth.Value / 2);
                var height = imagewidth;
                gfx.DrawImage(imagePdf, (int)(pagewidth.Value / 2) - (imagewidth / 2), 100, imagewidth, height);
            };

            document.Save(Path.Combine(_environment.WebRootPath, _namesService.DossierPdf, nomPdf));

            return nomPdf;
        }
    }
}