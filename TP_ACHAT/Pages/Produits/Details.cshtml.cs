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
    public class DetailsModel : PageModel
    {
        private readonly TP_ACHAT.Data.TP_ACHATContext _context;

        public DetailsModel(TP_ACHAT.Data.TP_ACHATContext context)
        {
            _context = context;
        }

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
    }
}
