using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FIAP14NET.Receita.Core.Persistencia.Storage
{
    public class ImageStore
    {
        CloudBlobClient blobClient;
        string baseUri = "https://trabfiap14netstorage.blob.core.windows.net/";

        public ImageStore()
        {
            var credentials = new StorageCredentials("trabfiap14netstorage", "R/zjMFUFUKZkXRWgwAdhWDoMks/fVrkPBHaBpF5FC8v5eEFlv3ooFTjGAoXXGG4Je0/fAHZc7awoeAmafXnmcA==");
            blobClient = new CloudBlobClient(new Uri(baseUri), credentials);
        }

        public async Task<string> SaveImage(Stream imageStream, Guid id)
        {
            var imageId = id.ToString();
            var container = blobClient.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(imageId);
            await blob.UploadFromStreamAsync(imageStream);
            return imageId;
        }

        public string UriFor(string imageId)
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-30),
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30)
            };

            var container = blobClient.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(imageId);
            var sas = blob.GetSharedAccessSignature(sasPolicy);
            return $"{baseUri}images/{imageId}{sas}";
        }
    }
}
