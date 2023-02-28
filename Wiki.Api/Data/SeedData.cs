using Newtonsoft.Json;
using Wiki.Api.Data;
using Wiki.Api.Entities;
using Wiki.App.Entities;

internal class SeedData
{
    public static async Task InitAsync(IApplicationBuilder applicationBuilder)
    {
        WikiApiContext wikiApiContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<WikiApiContext>();

        wikiApiContext.Database.EnsureCreated();

        var jsonData = System.IO.File.ReadAllText(@"Data/SeedData.json");

        List<Character>? characters = JsonConvert.DeserializeObject<List<Character>>(jsonData);

        jsonData = System.IO.File.ReadAllText(@"Data/SeedDataText.json");

        var options = new Newtonsoft.Json.JsonSerializerSettings{  Formatting = Formatting.Indented };

        List<WikiPage>? wikipages = JsonConvert.DeserializeObject<List<WikiPage>>(jsonData);

        await wikiApiContext.AddRangeAsync(characters);
        await wikiApiContext.AddRangeAsync(wikipages);
        await wikiApiContext.SaveChangesAsync();
    }


}