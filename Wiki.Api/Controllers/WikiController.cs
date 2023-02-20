using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wiki.Api.Data;
using Wiki.Api.Entities;

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

        //GET: api/Paragraphs
       [HttpGet]
        public async Task<ActionResult<IEnumerable<TextBlock>>> GetAsync()
        {
            if (_context.TextBlock == null)
            {
                return NotFound();
            }
            return await _context.TextBlock.ToListAsync();
        }
    }
}
