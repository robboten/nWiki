using Microsoft.AspNetCore.Components;
using Wiki.App.Entities;
using static Wiki.Azure.Api.Entities.AzureTableItems;

namespace Wiki.Azure.Api.Extensions
{
    public static class Mapper
    {
        //private const string PartitionKeyPage = "WikiPage";

        //public static WikiPageTable PostToWikiPageTable(this WikiPagePost wikiPage)
        //{
        //    var guid = Guid.NewGuid();
        //    return new WikiPageTable
        //    {
        //        Guid = guid,
        //        Published = wikiPage.Published,
        //        Name = wikiPage.Name,
        //        Content = wikiPage.Content,
        //        Created = DateTime.UtcNow,
        //        Updated = new DateTime(1602, 1, 1).ToUniversalTime(),
        //        PartitionKey = PartitionKeyPage,
        //        RowKey = guid.ToString(),
        //    };
        //}

        //public static WikiPageTable PutToWikiPageTable(this WikiPagePut wikiPage)
        //{
        //    return new WikiPageTable
        //    {
        //        Guid = wikiPage.Guid,
        //        Name = wikiPage.Name,
        //        Content = wikiPage.Content,
        //        Published = wikiPage.Published,
        //        Created = DateTime.UtcNow,
        //        Updated = new DateTime(1602, 1, 1).ToUniversalTime(),

        //        PartitionKey = PartitionKeyPage,
        //        RowKey = wikiPage.Guid.ToString(),
        //    };
        //}

        public static WikiPage ToWikiPage(this WikiPageTable wikiPageTable)
        {
            return new WikiPage
            {
                //Id = wikiPageTable.Id,
                Guid = wikiPageTable.Guid,
                Name = wikiPageTable.Name,
                Content = wikiPageTable.Content,
                Published = wikiPageTable.Published,
                Created = wikiPageTable.Created,
                Updated = wikiPageTable.Updated,
                PageType = wikiPageTable.PageType,
            };

        }
    }
}
