using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        private readonly IWebHostEnvironment _environment;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public NamesService NamesService { get; set; }

        public IndexModel(TableauxContext context,
            IWebHostEnvironment environment,
            NamesService namesService)
        {
            _context = context;
            NamesService = namesService;
            _environment = environment;
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

            var tableaux = await _context.Tableaux.Where(t => images.Select(i => i.Id).Contains(t.Image.Id)).ToListAsync();

            foreach (var image in images)
            {
                var tableauxDeLimage = tableaux.Where(t => t.ImageId == image.Id);

                var nombreImpressionDejaFaite = tableauxDeLimage.Any() ? tableauxDeLimage.Count() : 0;

                TableauxInfo.Add(new TableauInformation()
                {
                    ImageId = image.Id,
                    Url = image.Url,
                    Nom = image.Nom,
                    NombreImpression = string.Format("({0} / {1})", nombreImpressionDejaFaite, image.MaxImpression)
                });
            }
            Path.Combine(_environment.ContentRootPath, NamesService.DossierImagesTableaux);

            //var files = Directory.GetFiles(Path.Combine(_environment.ContentRootPath, NamesService.DossierImagesTableaux));

            //TableauxInfo.Add(new TableauInformation()
            //{
            //    ImageId = 0,
            //    Url = Path.Combine(_environment.ContentRootPath, NamesService.DossierImagesTableaux),
            //    Nom = Path.Combine(_environment.ContentRootPath, NamesService.DossierImagesTableaux),
            //    NombreImpression = string.Format("({0} / {1})", 0, 0)
            //});

            //for (int i = 0; i < files.Length; i++)
            //{
            //    TableauxInfo.Add(new TableauInformation()
            //    {
            //        ImageId =i+ 1,
            //        Url = files[i],
            //        Nom = files[i],
            //        NombreImpression = string.Format("({0} / {1})",0,0)
            //    });
            //}

            TableauxInfo = new Collection<TableauInformation>(TableauxInfo.OrderBy(t => t.ImageId).ToList());
        }

    }
}