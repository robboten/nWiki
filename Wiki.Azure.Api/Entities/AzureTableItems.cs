using Azure;
using Azure.Data.Tables;

namespace Wiki.Azure.Api.Entities
{
    public class AzureTableItems
    {

        public class WikiPagePost
        {
            public string Name { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public bool Published { get; set; }
        }

        public class WikiPagePut
        {
            public string Name { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public bool Published { get; set; }
            public Guid Guid { get; set; }
        }

        public class WikiPageTable : BaseTableEntity
        {
            //public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public bool Published { get; set; }
            public DateTime Created { get; set; } = DateTime.Now;
            public DateTime Updated { get; set; }
            public Guid Guid { get; set; }
            public string Content { get; set; } = string.Empty;
            //public MarkupString Content { get; set ; }
        }

        public class BaseTableEntity : ITableEntity
        {
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
