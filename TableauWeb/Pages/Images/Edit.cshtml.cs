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

            var image = await _context.Images.FirstOrDefaultAsync(m => m.Id == id);

            Image = new ImagesInformation()
            {
                ImageId = image.Id,
                MaxImpression = image.MaxImpression,
                Nom = image.Nom,
                NomBase = image.NomBase,
                UrlAffichage = _fichierService.GetUrlImage(image.Id)
            };

            if (Image == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var imageAUpdate = await _context.Images.FirstOrDefaultAsync(i => i.Id == Image.ImageId);
            if (imageAUpdate == null)
            {
                return NotFound();
            }

            //imageAUpdate.Nom = Image.Nom;
            //imageAUpdate.MaxImpression = Image.MaxImpression;

            imageAUpdate.Nom = Image.Nom;
            imageAUpdate.MaxImpression = Image.MaxImpression;

            try
            {
                _context.Entry(imageAUpdate).CurrentValues.SetValues(Image);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageTableauExists(imageAUpdate.Id))
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
            return _context.Images.Any(e => e.Id == id);
        }
    }
}