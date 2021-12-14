using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Azure.Storage.Blobs;

using InstructorIQ.Core.Options;

using Microsoft.Extensions.Options;

namespace InstructorIQ.Core.Services
{
    public class StorageService : IStorageService
    {
        private readonly IOptions<StorageConfiguration> _storageOptions;

        public StorageService(IOptions<StorageConfiguration> storageOptions)
        {
            _storageOptions = storageOptions;
        }

        public async Task UploadAsync(string blobName, Stream stream, CancellationToken cancellationToken)
        {
            var blob = await GetBlobClient(blobName, cancellationToken);

            await blob.UploadAsync(stream, cancellationToken);
        }

        public async Task<Stream> OpenReadAsync(string blobName, CancellationToken cancellationToken)
        {
            var blob = await GetBlobClient(blobName, cancellationToken);

            return await blob.OpenReadAsync(cancellationToken: cancellationToken);
        }


        private async Task<BlobClient> GetBlobClient(string blobName, CancellationToken cancellationToken)
        {
            var options = _storageOptions.Value;

            var container = new BlobContainerClient(options.ConnectionString, options.Container);
            await container.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.None, cancellationToken: cancellationToken);

            return container.GetBlobClient(blobName);
        }
    }
}
