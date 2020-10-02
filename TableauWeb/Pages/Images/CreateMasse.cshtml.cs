using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Model;
using TableauWeb.Services;

namespace TableauWeb
{
    public class CreateMasseModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;

        public NamesService NomService { get; set; }

        public CreateMasseModel(NamesService namesService,
            TableauxContext context,
            IFichierService fichierService)
        {
            NomService = namesService;
            _context = context;
            _fichierService = fichierService;
        }

        public async Task<IActionResult> OnGet()
        {
            foreach (var fileName in Directory.GetFiles(NomService.DossierVignettes))
            {
                var fi = new FileInfo(fileName);

                var newFileName = await _fichierService.CreateFile(fi);
                var nomSansExtension = fi.Name.Replace(fi.Extension, "");

                if(!_context.Images.Any(i => i.Nom == nomSansExtension))
                {
                    var image = new ImageTableau()
                    {
                        EstActif = true,
                        MaxImpression = 50,
                        Nom = nomSansExtension,
                        NomBase = newFileName
                    };

                    _context.Images.Add(image);

                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}