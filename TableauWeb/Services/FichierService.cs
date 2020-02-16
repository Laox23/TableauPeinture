using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TableauWeb.Data;

namespace TableauWeb.Services
{
    public interface IFichierService
    {
        Task<string> CreateFile(IFormFile formFile);
        //Task<string> GetUrlImage(string imageNomBase);
        Task<string> GetUrlImage(int id);
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

        public async Task<string> GetUrlImage(int id)
        {
            var imageBase = _context.Set<ImageTableau>().FirstOrDefault(i => i.ImageTableauId == id);
            if (imageBase != null)
            {
                return "/" + Path.Combine(_namesService.DossierImagesTableaux , imageBase.NomBase);
            }

            return string.Empty;
        }
    }
}