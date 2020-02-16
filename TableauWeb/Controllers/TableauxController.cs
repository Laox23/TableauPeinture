using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Dto;
using TableauWeb.Services;

namespace TableauWeb.Controllers
{
    public class TableauxController : BaseController
    {
        public TableauxController(TableauxContext context,
            IWebHostEnvironment environment,
            NamesService namesService,
            IFichierService fichierService) : base (context, environment, namesService, fichierService)
        {

        }

        //public Collection<TableauInformation> TableauxInfo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }


        // GET: Tableaux
        public async Task<ActionResult> Index()
        {
            var images = new List<ImageTableau>();
            var tableauxInfo = new Collection<TableauInformation>();

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

                tableauxInfo.Add(new TableauInformation()
                {
                    ImageTableauId = image.ImageTableauId,
                    UrlAffichage = await _fichierService.GetUrlImage(image.ImageTableauId),
                    Nom = image.Nom,
                    NombreImpression = string.Format("({0} / {1})", nombreImpressionDejaFaite, image.MaxImpression)
                });
            }

            tableauxInfo = new Collection<TableauInformation>(tableauxInfo.OrderBy(t => t.ImageTableauId).ToList());

            //ViewData["TableauxInfo"] = tableauxInfo;

            return View(tableauxInfo);
        }

        // GET: Tableaux/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tableaux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tableaux/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tableaux/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tableaux/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tableaux/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tableaux/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}