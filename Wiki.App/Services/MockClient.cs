using System.Text.Json;
using Wiki.App.Entities;

namespace Wiki.App.Services
{
    public class MockClient : IWikiClient
    {
        private readonly HttpClient _httpClient;
        private readonly List<Character> characters= new List<Character>();
        private readonly List<Paragraph> paragraphs = new List<Paragraph>();
        public MockClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            characters = new List<Character>()
            {
                new Character()
                {
                    Id= 1,
                    Name="Zev",
                    Quote="Integer vehicula vitae velit quis semper. Aliquam porta erat sit amet aliquam lobortis. Vivamus et ligula eget justo pharetra sagittis. Fusce lorem ipsum, sagittis quis turpis a, maximus auctor ipsum.",
                    PortraitUrl="https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/zev.png?raw=true",

                    Text="Lorem ipsum"

                },
                new Character()
                {
                    Id= 2,
                    Name="Alex",
                    Quote="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et arcu et est semper molestie at sit amet urna. Integer eget aliquam sapien, sed tempor velit. ",
                    PortraitUrl="https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/alex.png?raw=true",

                    Text="Lorem ipsum"
                }
            };
            paragraphs = new List<Paragraph>() {
                new Paragraph()
                {
                    Header="Overview",
                    Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et arcu et est semper molestie at sit amet urna. Integer eget aliquam sapien, sed tempor velit. "
                },
                new Paragraph()
                {
                    Header="Early life",
                    Body="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et arcu et est semper molestie at sit amet urna. Integer eget aliquam sapien, sed tempor velit. "
                }
            };
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return characters;
        }

        public async Task<Character> GetCharacterByIdAsync(int? Id)
        {

            return characters.FirstOrDefault(c => c.Id == Id);
        }
        public async Task<IEnumerable<Paragraph>> GetParagraphsAsync()
        {
            return paragraphs;
        }
        public async Task<Paragraph> GetParagraphByIdAsync(int? Id)
        {

            return paragraphs.FirstOrDefault(c => c.Id == Id);
        }

        public Task<Character> PostAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<Character> Remove(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
