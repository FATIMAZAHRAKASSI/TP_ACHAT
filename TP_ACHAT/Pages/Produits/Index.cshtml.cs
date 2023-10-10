using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_ACHAT.Data;
using TP_ACHAT.Models;

namespace TP_ACHAT.Pages.Produits
{
    public class IndexModel : PageModel
    {
        private readonly TP_ACHAT.Data.TP_ACHATContext _context;

        public IndexModel(TP_ACHAT.Data.TP_ACHATContext context)
        {
            _context = context;
        }

        public IList<Produit> Produit { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString2 { get; set; }
        public async Task OnGetAsync()
        {
            var movies = from m in _context.Produit
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SearchString2))
            {
                movies = movies.Where(s => s.Description.Contains(SearchString2));
            }

            Produit = await movies.ToListAsync();
        }


    }
}
