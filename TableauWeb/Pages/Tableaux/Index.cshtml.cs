using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableauWeb.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;

namespace TableauWeb.Tableaux
{
    public class IndexModel : PageModel
    {
        private readonly TableauxContext _context;
        private readonly IFichierService _fichierService;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public NamesService NamesService { get; set; }

        public IndexModel(TableauxContext context,
            NamesService namesService,
            IFichierService fichierService)
        {
            _context = context;
            NamesService = namesService;
            _fichierService = fichierService;
        }

        public Collection<TableauInformation> TableauxInfo { get; set; }

        public async Task OnGetAsync()
        {
            var images = new List<ImageTableau>();
            TableauxInfo = new Collection<TableauInformation>();

            if (string.IsNullOrWhiteSpace(SearchString))
            {
                images = await _context.Images.ToListAsync();
            }
            else
            {
                images = await _context.Images.Where(i => i.Nom.Contains(SearchString)).ToListAsync();
            }

            var tableaux = await _context.Tableaux.Where(t => images.Select(i => i.ImageTableauId).Contains(t.Image.ImageTableauId)).ToListAsync();

            foreach (var image in images)
            {
                var tableauxDeLimage = tableaux.Where(t => t.ImageTableauId == image.ImageTableauId);

                var nombreImpressionDejaFaite = tableauxDeLimage.Any() ? tableauxDeLimage.Count() : 0;

                TableauxInfo.Add(new TableauInformation()
                {
                    ImageTableauId = image.ImageTableauId,
                    UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId),
                    Nom = image.Nom,
                    NombreImpression = string.Format("({0} / {1})", nombreImpressionDejaFaite, image.MaxImpression),
                    PeutEtreSelectionnee = nombreImpressionDejaFaite < image.MaxImpression
                }); ;
            }

            TableauxInfo = new Collection<TableauInformation>(TableauxInfo.OrderBy(t => t.ImageTableauId).ToList());
        }
    }
}