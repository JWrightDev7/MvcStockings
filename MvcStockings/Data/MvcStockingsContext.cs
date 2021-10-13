using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcStockings.Models;

namespace MvcStockings.Data
{
    public class MvcStockingsContext : DbContext
    {
        public MvcStockingsContext (DbContextOptions<MvcStockingsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcStockings.Models.Stocking> Stocking { get; set; }
    }
}
