using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;

namespace TableauWeb.Images
{
    public class DeleteModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;

        private NamesService _namesService { get; set; }

        public DeleteModel(TableauxContext context,
            NamesService namesService,
            IFichierService fichierService)
        {
            _context = context;
            _namesService = namesService;
            _fichierService = fichierService;
        }

        [BindProperty]
        public ImagesInformation Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == id);

            Image = new ImagesInformation()
            {
                ImageTableauId = image.ImageTableauId,
                MaxImpression = image.MaxImpression,
                Nom = image.Nom,
                NomBase = image.NomBase,
                UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId)
            };

            if (Image == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var imageADelete = await _context.Images.FirstOrDefaultAsync(i => i.ImageTableauId == id);
            if (imageADelete == null)
            {
                return NotFound();
            }

            _context.Images.Remove(imageADelete);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
