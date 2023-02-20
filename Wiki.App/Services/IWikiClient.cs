using Wiki.App.Entities;

namespace Wiki.App.Services
{
    public interface IWikiClient
    {
        Task<IEnumerable<Character>> GetCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int? Id);
        Task<IEnumerable<Paragraph>> GetParagraphsAsync();
        Task<Paragraph> GetParagraphByIdAsync(int? Id);

        Task<Character> PostAsync(Character character);
        Task<Character> Remove(Character character);
        public Task<bool> RemoveAsync(int id);
    }
}