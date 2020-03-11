using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppQa.Controllers
{
    [Route("api/Home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            //return View();
            return "Reached";
        }


        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
