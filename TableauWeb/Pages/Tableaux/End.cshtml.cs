using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Model;
using TableauWeb.Services;

namespace TableauWeb.Tableaux
{
    [Authorize]
    public class EndModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;
        private UserManager<Utilisateur> _userManager;

        public Tableau Tableau { get; set; }

        [BindProperty]
        public ImagesInformation Image { get; set; }

        [BindProperty]
        public int ImageTableauId { get; set; }
        [BindProperty]
        public int DimensionId { get; set; }
        [BindProperty]
        public int FinitionId { get; set; }

        public EndModel(TableauxContext context,
            IFichierService fichierService,
           UserManager<Utilisateur> userManager)
        {
            _context = context;
            _fichierService = fichierService;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int imageTableauId, int dimensionId, int finitionId)
        {
            if(imageTableauId == 0 || dimensionId == 0 || finitionId == 0)
            {
                return Redirect("/Tableaux/Index");
            }

            ImageTableauId = imageTableauId;
            DimensionId = dimensionId;
            FinitionId = finitionId;

            var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == imageTableauId);

            Image = new ImagesInformation()
            {
                ImageTableauId = image.ImageTableauId,
                MaxImpression = image.MaxImpression,
                Nom = image.Nom,
                NomBase = image.NomBase,
                UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId)
            };

            Tableau = new Tableau()
            {
                Dimension = await _context.Dimensions.FirstOrDefaultAsync(m => m.DimensionId == dimensionId),
                Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.FinitionId == finitionId),
                NombreImpression = _context.Tableaux.Count(t => t.Image.ImageTableauId == imageTableauId) + 1
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()//int? id)
        {
            if(Tableau == null || Tableau.TableauId == 0)
            {
                var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageTableauId == ImageTableauId);
                var nombresImpression = _context.Tableaux.Count(t => t.Image.ImageTableauId == ImageTableauId) + 1;

                var utilisateur = await _userManager.GetUserAsync(User);

                var guid = System.Guid.NewGuid();

                Tableau = new Tableau()
                {
                    Image = image,
                    Dimension = await _context.Dimensions.FirstOrDefaultAsync(m => m.DimensionId == DimensionId),
                    Finition = await _context.Finitions.FirstOrDefaultAsync(m => m.FinitionId == FinitionId),
                    NombreImpression = nombresImpression,
                    NomPdf = image.Nom.Trim().Replace(" ", "_") + "_" + nombresImpression.ToString("D4") + ".pdf",
                    Utilisateur = utilisateur,
                    CodeVerif = guid.ToString().GetHashCode().ToString("x"),
                    DateCreation = DateTime.Now.Date
                };

                _context.Tableaux.Add(Tableau);
                _context.SaveChanges();
            }

            return RedirectToPage("./Show", new { Tableau.TableauId });
        }
    }
}