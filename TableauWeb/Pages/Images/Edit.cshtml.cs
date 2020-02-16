using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;

namespace TableauWeb.Images
{
    public class EditModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;

        public EditModel(TableauxContext context,
            IFichierService fichierService)
        {
            _context = context;
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
                EstActif = image.EstActif,
                UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId)
            };

            if (Image == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var imageAUpdate = await _context.Images.FirstOrDefaultAsync(i => i.ImageTableauId == Image.ImageTableauId);
            if (imageAUpdate == null)
            {
                return NotFound();
            }

            Image.NomBase = imageAUpdate.NomBase;

            try
            {
                _context.Entry(imageAUpdate).CurrentValues.SetValues(Image);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageTableauExists(imageAUpdate.ImageTableauId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ImageTableauExists(int id)
        {
            return _context.Images.Any(e => e.ImageTableauId == id);
        }
    }
}