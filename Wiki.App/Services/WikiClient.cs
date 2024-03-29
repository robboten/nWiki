﻿using System.Net.Http;
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

        public async Task<Character?> PostAsync(Character character)
        {
            var response = await _httpClient.PostAsJsonAsync("api/characters", character);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Character>() : null;
        }

        public async Task<bool> PutAsync(Character character)
        {
            var temp = await _httpClient.PutAsJsonAsync($"api/characters/{character.Id}", character);
            return temp.IsSuccessStatusCode;
        }

        public Task<Character> Remove(Character character)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return (await _httpClient.DeleteAsync($"api/characters/{id}")).IsSuccessStatusCode;
        }

        public Task<Paragraph> GetParagraphByIdAsync(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PutParagraphAsync(Paragraph paragraph)
        {
            return (await _httpClient.PutAsJsonAsync($"api/wiki/{paragraph.Id}", paragraph)).IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Paragraph>> GetParagraphsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Paragraph>>("api/wiki");
        }
    }
}
