using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Services;

namespace TableauWeb.Tableaux
{
    public class EndModel : PageModel
    {
        private readonly TableauxContext _context;

        public Tableau Tableau { get; set; }

        [BindProperty]
        public ImageTableau Image { get; set; }

        public NamesService NamesService { get; set; }

        public IWebHostEnvironment WebHostEnvironment { get; set; }


        public EndModel(IWebHostEnvironment webHostEnvironment,
            TableauxContext context, NamesService namesService)
        {
            _context = context;
            NamesService = namesService;
            WebHostEnvironment = webHostEnvironment;
        }

        public async Task OnGetAsync(int id)
        {
            Tableau = _context.Tableaux
                .Include(t => t.Image)
                .Include(t => t.Dimension)
                .Include(t => t.Finition)
                .First(e => e.Id == id);
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(Path.Combine(WebHostEnvironment.WebRootPath, NamesService.DossierPdf, "pdf-test.pdf"));
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = "resultat.pdf";
            return File(content, contentType, fileName);
        }
    }
}