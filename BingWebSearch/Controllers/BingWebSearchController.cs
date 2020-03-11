using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingWebSearch.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BingWebSearch.Controllers
{
    [Route("api/BingWebSearch")]
    [ApiController]
    public class BingWebSearchController : Controller
    {
        private BingWebSearchContext _context;

        public BingWebSearchController(BingWebSearchContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] value request)
        {
            _context.Add(request);
            _context.SaveChanges();
            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> Get([FromBody] value request)
        //{
        //    _context.Add(request);
        //    _context.SaveChanges();
        //    return Ok();
        //}


        [HttpGet("{userId}")]
        public IActionResult Get(string userID)
        {
            var images = _context.SaveUrlInfo.Where(image => image.userid == userID);

            List<value> valuesArray = new List<value>();
            ArryValues al = new ArryValues();

            foreach (value v in images)
            {
                valuesArray.Add(v);

            }
       //     al = JsonConvert.DeserializeObject<ArryValues>(images);
//
            return Ok(valuesArray);
        }

        public class ArryValues
        {
            public List<value> lstValues { get; set; }
        }

    }
}