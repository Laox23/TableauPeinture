using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TableauWeb.Data;
using TableauWeb.Services;

namespace TableauWeb.Controllers
{
    public class BaseController : Controller
    {
        protected readonly TableauxContext _context;
        protected readonly IWebHostEnvironment _environment;
        protected readonly IFichierService _fichierService;

        public NamesService NamesService { get; set; }

        public BaseController(TableauxContext context,
            IWebHostEnvironment environment,
            NamesService namesService,
            IFichierService fichierService)
        {
            _context = context;
            _environment = environment;
            _fichierService = fichierService;

            NamesService = namesService;
        }
    }
}