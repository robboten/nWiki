﻿using Azure;
using Azure.Data.Tables;

namespace Wiki.Azure.Api.Entities
{
    public class AzureTableItems
    {

        private const string PartitionKeyPage = "WikiPage";

        public class WikiPagePost
        {
            //public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public bool Published { get; set; }
            public Guid Guid { get; set; } = Guid.NewGuid();
            public string PageType { get; set; } = "page";
        }

        public class WikiPagePut
        {
            //public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public bool Published { get; set; }
            public Guid Guid { get; set; }
            public string PageType { get; set; } = "page";
        }

        public class WikiPageTable : BaseTableEntity
        {
            public WikiPageTable()
            {
            }

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
            public WikiPageTable(WikiPagePost page) : base(PartitionKeyPage, page.Guid.ToString())
            {
               // Id= page.Id;
                Name = page.Name;
                Content = page.Content;
                Published = page.Published;
                Guid = page.Guid;
                Created = DateTime.UtcNow;
                PageType = page.PageType;
            }

            public WikiPageTable(WikiPagePut page) : base(PartitionKeyPage, page.Guid.ToString())
            {
                //Id= page.Id;
                Name= page.Name;
                Content= page.Content;
                Published= page.Published;
                Guid = page.Guid;
                PageType = page.PageType;

            }
            //public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public bool Published { get; set; }
            public DateTime Created { get; set; } = DateTime.UtcNow;
            public DateTime? Updated { get; set; }
            public Guid Guid { get; set; }
            public string Content { get; set; } = string.Empty;
            public string PageType { get; set; } = "page";
            //public MarkupString Content { get; set ; }
        }

        public class BaseTableEntity : ITableEntity
        {
            public BaseTableEntity()
            {  
            }

            public BaseTableEntity(string PartitionKey)
            {
                this.PartitionKey = PartitionKey;
            }
            public BaseTableEntity(string PartitionKey, string RowKey)
            {
                this.PartitionKey= PartitionKey;
                this.RowKey= RowKey;
            }

            public string PartitionKey { get; set; } = string.Empty;
            public string RowKey { get; set; } = string.Empty;
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }

        //public record WikiPageTableR(string PartitionKey, string RowKey, string Name, string Content, DateTime Created, DateTime Updated)
        //{
        //    /// <summary>
        //    /// create
        //    /// </summary>
        //    /// <param name="post"></param>
        //    /// <param name="rowKey"></param>
        //    public WikiPageTableR(WikiPagePost post, string rowKey)
        //        : this(nameof(WikiPageTable), rowKey, post.Name, post.Content, DateTime.UtcNow, DateTime.UtcNow)
        //    {
        //    }

        //    /// <summary>
        //    /// update
        //    /// </summary>
        //    /// <param name="put"></param>
        //    /// <param name="rowKey"></param>
        //    /// <param name="existingEntity"></param>
        //    public WikiPageTableR(WikiPagePut put, string rowKey, WikiPageTable existingEntity)
        //        : this(nameof(WikiPageTable), rowKey, put.Name, put.Content, existingEntity.Created, DateTime.UtcNow)
        //    {
        //    }
        //}

    }
}
