using System.Net.Http.Json;
using Wiki.App.Entities;

namespace Wiki.App.Services
{
    public class WikiClient : IWikiClient
    {
        private readonly HttpClient _httpClient;
        public WikiClient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7123");
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Character> GetCharacterByIdAsync(int? Id)
        {
            return await _httpClient.GetFromJsonAsync<Character>($"api/characters/{Id}");
        }

        public async Task<IEnumerable<Character>?> GetCharactersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Character>>("api/characters");
        }

        public Task<Paragraph> GetParagraphByIdAsync(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Paragraph>> GetParagraphsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Paragraph>>("api/characters");
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
