using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;

namespace azure_functions_cosmosclient
{
    public class MyFunc
    {
        private readonly CosmosClient _cosmosClient;

        public MyFunc(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }

        [FunctionName("MyFunc")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            await _cosmosClient.CreateDatabaseIfNotExistsAsync("MyCosmosDb");
            return new NoContentResult();
        }
    }
}