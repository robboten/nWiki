using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Wiki.Api;
using Wiki.Api.Data;

internal class SeedData
{
    public static async Task InitAsync(IApplicationBuilder applicationBuilder)
    {
        WikiApiContext wikiApiContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<WikiApiContext>();

        wikiApiContext.Database.EnsureCreated();

        var jsonData = System.IO.File.ReadAllText(@"Data/SeedData.json");

        List<Character>? characters = JsonConvert.DeserializeObject<List<Character>>(jsonData);

        wikiApiContext.AddRange(characters);
        wikiApiContext.SaveChanges();
    }


}