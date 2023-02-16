using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wiki.Api;
using Wiki.Api.Data;

namespace Wiki.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly WikiApiContext _context;

        public CharactersController(WikiApiContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacter()
        {
          if (_context.Character == null)
          {
              return NotFound();
          }
            return await _context.Character.ToListAsync();
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
          if (_context.Character == null)
          {
              return NotFound();
          }
            var character = await _context.Character.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
          if (_context.Character == null)
          {
              return Problem("Entity set 'WikiApiContext.Character'  is null.");
          }
            _context.Character.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (_context.Character == null)
            {
                return NotFound();
            }
            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Character.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return (_context.Character?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}



//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Wiki.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Produces("application/json")]
//    public class CharactersController : ControllerBase
//    {
//        private readonly List<Character> characters = new();
//        public CharactersController()
//        {
//            characters = new List<Character>()
//            {
//                new Character()
//                {
//                    Id= 1,
//                    Name="Zev",
//                    Age=23,
//                    Quote="Integer vehicula vitae velit quis semper. Aliquam porta erat sit amet aliquam lobortis. Vivamus et ligula eget justo pharetra sagittis. Fusce lorem ipsum, sagittis quis turpis a, maximus auctor ipsum.",
//                    PortraitUrl="https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/zev.png?raw=true",

//                },
//                new Character()
//                {
//                    Id= 2,
//                    Name="Alex",
//                    Age=24,
//                    Quote="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et arcu et est semper molestie at sit amet urna. Integer eget aliquam sapien, sed tempor velit. ",
//                    PortraitUrl="https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/alex.png?raw=true",
//                }
//            };
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersAsync()
//        {
//            return Ok(characters);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Character>> GetCharacterByIdAsync(int? id)
//        {

//            return Ok(characters.FirstOrDefault(c => c.Id == id));
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Character>> DeleteCharacter(int id)
//        {

//            return NoContent();
//        }

//    }
//}
