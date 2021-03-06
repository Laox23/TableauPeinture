﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;

namespace TableauWeb.Images
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TableauxContext _context;
        private readonly IFichierService _fichierService;

        public NamesService NamesService { get; set; }

        public IndexModel(TableauxContext context, 
            NamesService namesService,
            IFichierService fichierService)
        {
            _context = context;
            _fichierService = fichierService;
            NamesService = namesService;
        }

        public Collection<ImagesInformation> Images { get;set; }

        public async Task OnGetAsync()
        {
            var images = await _context.Images.OrderByDescending(i => i.EstActif).ToListAsync();

            Images = new Collection<ImagesInformation>();
            foreach (var image in images)
            {
                Images.Add(new ImagesInformation()
                {
                    ImageTableauId = image.ImageTableauId,
                    MaxImpression = image.MaxImpression,
                    Nom = image.Nom,
                    NomBase = image.NomBase,
                    EstActif = image.EstActif,
                    UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId)
                });
            }
        }
    }
}