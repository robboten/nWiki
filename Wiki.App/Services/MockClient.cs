using System.Text.Json;
using Wiki.App.Entities;

namespace Wiki.App.Services
{
    public class MockClient
    {
        private readonly HttpClient _httpClient;
        public MockClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            var result = new List<Character>()
            {
                new Character()
                {
                    Id= 1,
                    Name="Zev",
                    Age=23
                }
            };
            return result;
        }
    }
}
