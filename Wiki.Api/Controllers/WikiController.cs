using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wiki.Api.Data;
using Wiki.Api.Entities;
using Wiki.App.Entities;

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

        //GET: api/wiki
       [HttpGet]
        public async Task<ActionResult<IEnumerable<WikiPage>>> GetAsync()
        {
            if (_context.WikiPage == null)
            {
                return NotFound();
            }
            return await _context.WikiPage.ToListAsync();
        }

        // PUT: api/wiki/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{guid}")]
        public async Task<IActionResult> PutAsync(string guid, WikiPage wikiPage)
        {
            if (!guid.Equals(wikiPage.Guid.ToString()))
            {
                return BadRequest();
            }

            _context.Entry(wikiPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WikiExists(guid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool WikiExists(string guid)
        {
            return (_context.WikiPage?.Any(e => e.Equals(guid))).GetValueOrDefault();
        }
    }
}
