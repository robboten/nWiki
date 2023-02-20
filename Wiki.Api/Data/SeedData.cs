using Newtonsoft.Json;
using Wiki.Api.Data;
using Wiki.Api.Entities;

internal class SeedData
{
    public static async Task InitAsync(IApplicationBuilder applicationBuilder)
    {
        WikiApiContext wikiApiContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<WikiApiContext>();

        wikiApiContext.Database.EnsureCreated();

        var jsonData = System.IO.File.ReadAllText(@"Data/SeedData.json");

        List<Character>? characters = JsonConvert.DeserializeObject<List<Character>>(jsonData);

        jsonData = System.IO.File.ReadAllText(@"Data/SeedDataText.json");

        List<TextBlock>? textblocks = JsonConvert.DeserializeObject<List<TextBlock>>(jsonData);

        wikiApiContext.AddRange(characters);
        wikiApiContext.AddRange(textblocks);
        wikiApiContext.SaveChanges();
    }


}