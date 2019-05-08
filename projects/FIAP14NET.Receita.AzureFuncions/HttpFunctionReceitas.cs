using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;

namespace FIAP14NET.Receita.AzureFuncions
{
    public static class HttpFunctionReceitas
    {
        [FunctionName("PegarUrlImagem")]
        public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")]
        HttpRequest req, ILogger log)
        {
            CloudBlobClient blobClient;
            string baseUri = "https://trabfiap14netstorage.blob.core.windows.net/";
            string id = req.Query["id"];
            var credentials = new StorageCredentials("trabfiap14netstorage", "R/zjMFUFUKZkXRWgwAdhWDoMks/fVrkPBHaBpF5FC8v5eEFlv3ooFTjGAoXXGG4Je0/fAHZc7awoeAmafXnmcA==");
            blobClient = new CloudBlobClient(new Uri(baseUri), credentials);

            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-30),
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30)
            };

            var container = blobClient.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(id);
            var sas = blob.GetSharedAccessSignature(sasPolicy);
            return new OkObjectResult($"{baseUri}images/{id}{sas}");
        }
        
    }
}
