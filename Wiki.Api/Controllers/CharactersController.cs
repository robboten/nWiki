using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wiki.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly List<Character> characters = new();
        public CharactersController()
        {
            characters = new List<Character>()
            {
                new Character()
                {
                    Id= 1,
                    Name="Zev",
                    Age=23,
                    Quote="Integer vehicula vitae velit quis semper. Aliquam porta erat sit amet aliquam lobortis. Vivamus et ligula eget justo pharetra sagittis. Fusce lorem ipsum, sagittis quis turpis a, maximus auctor ipsum.",
                    PortraitUrl="https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/zev.png?raw=true",

                },
                new Character()
                {
                    Id= 2,
                    Name="Alex",
                    Age=24,
                    Quote="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et arcu et est semper molestie at sit amet urna. Integer eget aliquam sapien, sed tempor velit. ",
                    PortraitUrl="https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/alex.png?raw=true",
                }
            };
        }

        [HttpGet]
        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return characters;
        }

    }
}
