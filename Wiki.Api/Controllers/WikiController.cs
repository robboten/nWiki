using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wiki.Api.Data;

namespace Wiki.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class WikiController : ControllerBase
    {
        private readonly WikiApiContext _context;

        public WikiController(WikiApiContext context)
        {
            _context = context;
        }

        // GET: api/Paragraphs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Character>>> GetAsync()
        //{
        //    if (_context.Character == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Character.ToListAsync();
        //}
    }
}
