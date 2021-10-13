using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStockings.Models
{
    public class StockingTypeViewModel
    {
        public List<Stocking> Stockings { get; set; }
        public SelectList Types { get; set; }
        public string StockingType { get; set; }
        public string search { get; set; }
    }
}
