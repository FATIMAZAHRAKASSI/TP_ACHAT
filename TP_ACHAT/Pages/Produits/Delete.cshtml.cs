using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP_ACHAT.Data;
using TP_ACHAT.Models;

namespace TP_ACHAT.Pages.Produits
{
    public class DeleteModel : PageModel
    {
        private readonly TP_ACHAT.Data.TP_ACHATContext _context;

        public DeleteModel(TP_ACHAT.Data.TP_ACHATContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Produit Produit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit.FirstOrDefaultAsync(m => m.Id == id);

            if (produit == null)
            {
                return NotFound();
            }
            else 
            {
                Produit = produit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }
            var produit = await _context.Produit.FindAsync(id);

            if (produit != null)
            {
                Produit = produit;
                _context.Produit.Remove(Produit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
