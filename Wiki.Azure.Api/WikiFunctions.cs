using Azure;
using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Wiki.Azure.Api.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Wiki.Azure.Api.Entities.AzureTablePages;

namespace Wiki.Azure.Api
{
    public class Functions
    {
        //private const string partitionName = nameof(WikiPageTable.PartitionKey);
        private const string partitionName = "WikiPage";
        private const string ConnectionName = "WikiKeys";
        private readonly ILogger _logger;
        public Functions(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Functions>();
        }

        [Function("GetAllPagesAsync")]
        public static async Task<HttpResponseData> GetAllPagesAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "wiki/pages/")] HttpRequestData req,
        [TableInput("Wiki", partitionName, Connection = ConnectionName)] IEnumerable<WikiPageTable> tableInput
        )
        {
            var response = req.CreateResponse();

            var tableData = tableInput.Select(Mapper.ToWikiPage);

            await response.WriteAsJsonAsync(tableData);

            return response;
        }

        //[Function("TestAsync2")]
        //public async Task<IEnumerable<WikiPageTable>> GetAllAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "wiki/test2/")] HttpRequestData req)
        //{
        //    var tableClient = await GetTableClient();
        //    IList<WikiPageTable> pageList = new List<WikiPageTable>();
        //    var pages = tableClient.QueryAsync<WikiPageTable>( x => x.Published==true, maxPerPage: 10);

        //    await foreach (var page in pages)
        //    {
        //        pageList.Add(page);
        //    }

        //    AsyncPageable<TableEntity> queryResultsSelect = tableClient.QueryAsync<TableEntity>();
        //    await foreach (var q in queryResultsSelect)
        //    {
        //        var d = q.GetDateTime("Timestamp");
        //        Console.WriteLine(d);
        //    }

        //    var partitionKey = "WikiPage";
        //    Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");

        //    // Iterate the <see cref="Pageable"> to access all queried entities.
        //    foreach (TableEntity qEntity in queryResultsFilter)
        //    {
        //        Console.WriteLine($"{qEntity.GetString("Name")}: {qEntity.GetString("Content")}");
        //    }

        //    Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");

        //    return pageList;
        //}



        [Function("GetPageByIdAsync")]
        public static async Task<HttpResponseData> GetPageByIdAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "wiki/pages/{rowKey}")] HttpRequestData req,
            string rowKey)
        {
            var response = req.CreateResponse();

            if (string.IsNullOrEmpty(rowKey))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            var tableClient = await GetTableClient();

            NullableResponse<WikiPageTable> tableData = await tableClient.GetEntityIfExistsAsync<WikiPageTable>(partitionName, rowKey);

            if (tableData.HasValue)
            {
                await response.WriteAsJsonAsync(Mapper.ToWikiPage(tableData.Value));
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }

            return response;
        }

        [Function("UpsertPageAsync")]
        public static async Task<HttpResponseData> UpsertPageAsync(
    [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "wiki/pages/")] HttpRequestData req)
        {
            var response = req.CreateResponse();
            //var response = new PageResponse<WikiPage>();

            //var createdItem = JsonSerializer.Deserialize<WikiPagePut>(req.Body);

            var createdItem = await req.ReadFromJsonAsync<WikiPagePut>();

            if (createdItem is null || string.IsNullOrWhiteSpace(createdItem.Content))
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

            var rowKey = createdItem.Guid.ToString();

            var tableClient = await GetTableClient();

            NullableResponse<WikiPageTable> tableData = await tableClient.GetEntityIfExistsAsync<WikiPageTable>(partitionName, rowKey);

            //var page = Mapper.PutToWikiPageTable(createdItem);
            var page = new WikiPageTable(createdItem);

            if (tableData.HasValue)
            {
                page.Updated = DateTime.UtcNow;
                page.Created = tableData.Value.Created;
            }

            await tableClient.UpsertEntityAsync(page);

            await response.WriteAsJsonAsync(Mapper.ToWikiPage(page));
            return response;
        }


        [Function("DeletePageAsync")]
        public static async Task<HttpResponseData> DeletePageAsync(
    [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "wiki/pages/{rowKey}")] HttpRequestData req,
    string rowKey)
        {
            var response = req.CreateResponse();

            if (string.IsNullOrEmpty(rowKey))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            var tableClient = await GetTableClient();
            var isOk = await tableClient.DeleteEntityAsync(partitionName, rowKey);

            if (isOk.Status == 404)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }

        [Function("AddPageAsync")]
        public static async Task<HttpResponseData> AddPageAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "wiki/pages/")] HttpRequestData req)
        {
            var response = req.CreateResponse();

            //var stream = await new StreamReader(req.Body).ReadToEndAsync();

            var createdItem = JsonSerializer.Deserialize<WikiPagePost>(req.Body);

            if (createdItem == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            var tableData = new WikiPageTable(createdItem);
            var tableClient = await GetTableClient();

            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync(tableData);


            await response.WriteAsJsonAsync(Mapper.ToWikiPage(tableData));
            response.StatusCode = HttpStatusCode.Created;

            return response;
        }

        [Function("AddPagesAsync")]
        public static async Task<HttpResponseData> AddPagesAsync(
       [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "wiki/pages/batch/")] HttpRequestData req)
        {
            var response = req.CreateResponse();

            //var stream = await new StreamReader(req.Body).ReadToEndAsync();
            var createdItems = await req.ReadFromJsonAsync<IEnumerable<WikiPagePost>>();

            if (createdItems is null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tableClient = await GetTableClient();

            var pages = createdItems.Select(p => new WikiPageTable(p));

            await tableClient.CreateIfNotExistsAsync();
            foreach (var page in pages)
            {
                await tableClient.AddEntityAsync(page);
            }

            await response.WriteAsJsonAsync(createdItems);
            response.StatusCode = HttpStatusCode.Created;
            return response;
        }

        private static async Task<TableClient> GetTableClient()
        {
            //var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var connectionString = Environment.GetEnvironmentVariable(ConnectionName);
            var client = new TableClient(connectionString, "Wiki");
            await client.CreateIfNotExistsAsync();
            return client;
        }
    }



}
