using BingWebSearch.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingWebSearch.Controllers
{
    [Route("api/Notes")]
    [ApiController]
    public class NotesController:Controller
    {
        private BingWebSearchContext _context;
        public NotesController(BingWebSearchContext context)
        {
            _context = context;

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Note request)
        {
            _context.Add(request);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("{userId}")]
        public IActionResult Get(string userID)
        {
            var images = _context.Note.Where(image => image.moreInfo == "MoreInfo");

            List<Note> valuesArray = new List<Note>();

            foreach (Note v in images)
            {
                valuesArray.Add(v);

            }
            return Ok(valuesArray);
        }
    }
}
