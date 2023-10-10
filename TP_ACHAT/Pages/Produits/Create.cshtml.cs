using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP_ACHAT.Data;
using TP_ACHAT.Models;

namespace TP_ACHAT.Pages.Produits
{
    public class CreateModel : PageModel
    {
        private readonly TP_ACHAT.Data.TP_ACHATContext _context;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public CreateModel(TP_ACHAT.Data.TP_ACHATContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Produit Produit { get; set; } = default!;

        // Property to represent the uploaded image file
        [BindProperty]
        public IFormFile ImageFile { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Produit == null || Produit == null)
            {

                return Page();
            }
            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Generate a unique filename using a timestamp
                var fileName = DateTime.Now.Ticks + Path.GetExtension(ImageFile.FileName);

                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload");
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Ensure the uploads folder exists
                Directory.CreateDirectory(uploadsFolder);
                // Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                // Save the file path in your database
                Produit.image = "/Upload/" + fileName; // Update the path as per your project structure
            }

                _context.Produit.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
