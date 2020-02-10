using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TableauWeb.Data;
using TableauWeb.Services;

namespace TableauWeb.Images
{
    public class CreateModel : PageModel
    {
        private readonly TableauxContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly NamesService _namesService;

        public CreateModel(IWebHostEnvironment webHostEnvironment,
            TableauxContext context,
            NamesService nameService)
        {
            _environment = webHostEnvironment;
            _context = context;
            _namesService = nameService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ImageTableau ImageTableau { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var file = HttpContext.Request.Form.Files.FirstOrDefault();

                if (file.Length > 0)
                {
                    //Getting FileName
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var FileExtension = Path.GetExtension(fileName);

                    // concating  FileName + FileExtension
                    newFileName = myUniqueFileName + FileExtension;

                    // Combines two strings into a path.
                    //fileName = Path.Combine(_environment.WebRootPath, _namesService.DossierImagesTableaux + $@"\{newFileName}");
                    fileName = Path.Combine(_namesService.DossierImagesTableaux + $@"\{ newFileName}");

                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }

                ImageTableau.Url = newFileName;

                _context.Images.Add(ImageTableau);
                await _context.SaveChangesAsync();

            }
            return RedirectToPage("./Index");
        }
    }
}