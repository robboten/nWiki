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

        //GET: api/wiki
       [HttpGet]
        public async Task<ActionResult<IEnumerable<TextBlock>>> GetAsync()
        {
            if (_context.TextBlock == null)
            {
                return NotFound();
            }
            return await _context.TextBlock.ToListAsync();
        }

        // PUT: api/wiki/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, TextBlock textBlock)
        {
            if (id != textBlock.Id)
            {
                return BadRequest();
            }

            _context.Entry(textBlock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WikiExists(id))
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
        private bool WikiExists(int id)
        {
            return (_context.TextBlock?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
