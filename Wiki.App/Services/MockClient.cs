using System.Text.Json;
using Wiki.App.Entities;

namespace Wiki.App.Services
{
    public class MockClient : IWikiClient
    {
        private readonly HttpClient _httpClient;
        private readonly List<Character> characters= new List<Character>();
        public MockClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            characters = new List<Character>()
            {
                new Character()
                {
                    Id= 1,
                    Name="Zev",
                    Age=23,
                    Quote="Integer vehicula vitae velit quis semper. Aliquam porta erat sit amet aliquam lobortis. Vivamus et ligula eget justo pharetra sagittis. Fusce lorem ipsum, sagittis quis turpis a, maximus auctor ipsum.",
                    PortraitUrl="https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/zev.png?raw=true",
                    BasicInfo=new BasicInfo()
                    {
                        Age=23,
                        Speices="Humanoid"
                    }

                },
                new Character()
                {
                    Id= 2,
                    Name="Alex",
                    Age=24,
                    Quote="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent et arcu et est semper molestie at sit amet urna. Integer eget aliquam sapien, sed tempor velit. ",
                    PortraitUrl="https://github.com/NoahFerm/Wiki1.0/blob/main/Wiki/bilder/alex.png?raw=true",
                                        BasicInfo=new BasicInfo()
                    {
                        Age=24,
                        Speices="Lizard"
                    }
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
    }
}
