using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Wiki.Azure.Api
{
    public class Functions
    {
        private readonly ILogger _logger;
        private readonly TableServiceClient _tableServiceClient;
        public Functions(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Functions>();
            _tableServiceClient = new TableServiceClient(
                new Uri("https://nwikiapp83f1.table.core.windows.net"),
                new TableSharedKeyCredential("nwikiapp83f1", "BF8lcvP03t/Xsh1caNXGiL11svKb4srSxb5I8oq56NF2Q0CHOeiIXPfjUaNPmaNdCcQXZmnJWhhY+AStIFUXbw=="));
        }

        [Function("Function1")]
        public HttpResponseData Run3(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "wiki55")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");
            return response;
        }


        [Function("AddText")]
        public async Task<HttpResponseData> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "wiki")] HttpRequestData req,
            [TableInput("MyTable", "queue", Connection = "WikiKeys")] IEnumerable<MyTableData> tableInput
            )
        {

            //foreach (MyTableData table in tableInput)
            //{
            //    Console.WriteLine(table.Text);
            //}

            ///services test---------

            //var tableName = "MyTable";
            //Pageable<TableItem> queryTableResults = _tableServiceClient.Query(filter: $"TableName eq '{tableName}'");

            //Console.WriteLine("The following are the names of the tables in the query results:");


            //// Iterate the <see cref="Pageable"> in order to access queried tables.

            //foreach (TableItem table in queryTableResults)
            //{
            //    Console.WriteLine(table.Name);
            //}

            ///----------------------
            //_logger.LogInformation($"PK={tableInput.PartitionKey}, RK={tableInput.RowKey}, Text={tableInput.Text}");

            var response = req.CreateResponse();

            var tableData = tableInput.Select(t=>
                new MyTableData()
                {
                    PartitionKey = t.PartitionKey,
                    RowKey =t.RowKey,
                    Text = t.Text,
                    Timestamp = t.Timestamp,
                }
                );

            await response.WriteAsJsonAsync(tableData);

            return response;
        }

        public class MyTableData
        {
            public string Text { get; set; }

            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }

        }

        private async Task<TableClient> GetTableClient()
        {
            var connectionString = Environment.GetEnvironmentVariable("Wikikeys");
            //var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var client = new TableClient(connectionString, "MyTable");
            await client.CreateIfNotExistsAsync();
            return client;
        }
    }



}
