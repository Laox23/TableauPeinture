using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TableauWeb.Services
{
    public class NamesService
    {
        public string DossierImagesTableaux { get; private set; }
        public string DossierPdf { get; private set; }


        public NamesService(IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
           // var dossierDonnees = config.GetValue<string>("Constantes:DossierDonnees");
            var dossierImagesTableaux = config.GetValue<string>("Constantes:DossierImagesTableaux");
            var dossierPdf = config.GetValue<string>("Constantes:DossierPdf");

            DossierImagesTableaux = dossierImagesTableaux;
            DossierPdf = dossierPdf;

            //DossierImagesTableaux = Path.Combine(dossierDonnees, dossierImagesTableaux);
            //DossierPdf = Path.Combine(dossierDonnees, dossierPdf);

            if (!Directory.Exists(Path.Combine(webHostEnvironment.ContentRootPath, DossierImagesTableaux)))
                Directory.CreateDirectory(Path.Combine(webHostEnvironment.WebRootPath, DossierImagesTableaux));

            if (!Directory.Exists(Path.Combine(webHostEnvironment.ContentRootPath, DossierPdf)))
                Directory.CreateDirectory(Path.Combine(webHostEnvironment.WebRootPath, DossierPdf));

            if (!Directory.Exists(DossierImagesTableaux))
                Directory.CreateDirectory(DossierImagesTableaux);

            if (!Directory.Exists(DossierPdf))
                Directory.CreateDirectory(DossierPdf);

        }
    }
}