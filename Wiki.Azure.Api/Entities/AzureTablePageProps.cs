using Azure;
using Azure.Data.Tables;
using Wiki.Shared.Entities;

namespace Wiki.Azure.Api.Entities
{
    public class AzureTablePageProps
    {

        private const string PartitionKeyPageProp = "WikiPageProp";

        public class WikiPagePropTable :  WikiPageProp, ITableEntity
        {
            public WikiPagePropTable(WikiPageProp pageProp)
            {
                Id= pageProp.Id;
                PageGuid = pageProp.PageGuid;
                PropKey = pageProp.PropKey;
                PropValue = pageProp.PropValue;

                //must be changed later on!
                RowKey = pageProp.Id.ToString();
                PartitionKey = PartitionKeyPageProp;
            }

            //Azure TableEntity
            public string PartitionKey { get; set; } = string.Empty;
            public string RowKey { get; set; } = string.Empty;
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }

    }
}
