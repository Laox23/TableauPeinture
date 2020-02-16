﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;

namespace TableauWeb.Pdf
{
    public class IndexModel : PageModel
    {
        private readonly IFichierService _fichierService;
        private readonly TableauxContext _context;

        private IWebHostEnvironment _webHostEnvironment;
        private NamesService _namesService { get; set; }

        public IndexModel(IWebHostEnvironment webHostEnvironment,
                            TableauxContext context,
                            IFichierService fichierService,
                            NamesService namesService)
        {
            _context = context;
            _fichierService = fichierService;
            _webHostEnvironment = webHostEnvironment;
            _namesService = namesService;
        }

        public IList<Tableau> Tableaux { get; set; }

        public async Task OnGetAsync()
        {
            var tableaux = _context.Tableaux
                .Include(t => t.Dimension)
                .Include(t => t.Finition)
                .Include(t => t.Image);

            Tableaux = await tableaux.OrderBy(t => t.ImageTableauId).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var tableau = await _context.Tableaux.FirstOrDefaultAsync(t => t.TableauId == id);

            string nomPdf = await _fichierService.EcrisOuRetourneLePdfTableau(tableau);

            var net = new System.Net.WebClient();
            var data = net.DownloadData(Path.Combine(_webHostEnvironment.WebRootPath, _namesService.DossierPdf, nomPdf));
            var content = new MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";

            return File(content, contentType, nomPdf);
        }
    }
}