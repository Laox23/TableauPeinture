﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Model;
using TableauWeb.Services;

namespace TableauWeb.Images
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;

        public CreateModel(TableauxContext context,
            IFichierService fichierService)
        {
            _context = context;
            _fichierService = fichierService;
        }

        [BindProperty]
        public ImageTableau ImageTableau { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Request.Form.Files != null)
            {
                var file = HttpContext.Request.Form.Files.FirstOrDefault();

                var newFileName = await _fichierService.CreateFile(file);

                if (!string.IsNullOrWhiteSpace(newFileName))
                {
                    ImageTableau.NomBase = newFileName;
                    ImageTableau.EstActif = true;

                    _context.Images.Add(ImageTableau);
                    await _context.SaveChangesAsync();
                }

            }
            return RedirectToPage("./Index");
        }
    }
}