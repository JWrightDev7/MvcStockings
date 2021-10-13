using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MvcStockings.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            //Retruns the About page when it is called
            return View();
        }

        
    }
}
