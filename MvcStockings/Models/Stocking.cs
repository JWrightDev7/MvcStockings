using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStockings.Models
{
    public class Stocking
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
    }
}
