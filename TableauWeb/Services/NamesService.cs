using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TableauWeb.Services
{
    public class NamesService
    {
        public string DossierVignettes { get; private set; }
        public string DossierImagesTableaux { get; private set; }
        public string DossierPdf { get; private set; }


        public NamesService(IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            var dossierImagesTableaux = config.GetValue<string>("Constantes:DossierImagesTableaux");
            var dossierPdf = config.GetValue<string>("Constantes:DossierPdf");
            var dossierVignettes = config.GetValue<string>("Constantes:DossierVignettes");

            DossierImagesTableaux = dossierImagesTableaux;
            DossierPdf = dossierPdf;
            DossierVignettes = Path.Combine(webHostEnvironment.WebRootPath, dossierVignettes);

            if (!Directory.Exists(Path.Combine(webHostEnvironment.WebRootPath, DossierImagesTableaux)))
                Directory.CreateDirectory(Path.Combine(webHostEnvironment.WebRootPath, DossierImagesTableaux));

            if (!Directory.Exists(Path.Combine(webHostEnvironment.WebRootPath, DossierPdf)))
                Directory.CreateDirectory(Path.Combine(webHostEnvironment.WebRootPath, DossierPdf));
        }
    }
}