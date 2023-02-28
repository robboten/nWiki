using Wiki.App.Entities;

namespace Wiki.App.Services
{
    public interface IWikiClient
    {
        Task<IEnumerable<Character>> GetCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int? Id);
        Task<bool> PutAsync(Character character);
        Task<Character> PostAsync(Character character);
        Task<Character> Remove(Character character);
        public Task<bool> RemoveAsync(int id);

        Task<IEnumerable<WikiPage>> GetPostsAsync();
        Task<WikiPage> GetPostByIdAsync(string? Guid);
        public Task<bool> PutPostAsync(WikiPage page);
    }
}