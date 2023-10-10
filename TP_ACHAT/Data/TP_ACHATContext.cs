using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_ACHAT.Models;

namespace TP_ACHAT.Data
{
    public class TP_ACHATContext : DbContext
    {
        public TP_ACHATContext (DbContextOptions<TP_ACHATContext> options)
            : base(options)
        {
        }

        public DbSet<TP_ACHAT.Models.Produit> Produit { get; set; } = default!;
    }
}
