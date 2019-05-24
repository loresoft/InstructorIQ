using System;
using InstructorIQ.Core.Options;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Options;

namespace InstructorIQ.Core.Services
{
    public class StorageService : IStorageService
    {
        private readonly IOptions<StorageConfiguration> _storageOptions;

        private readonly Lazy<CloudStorageAccount> _storageAccount;
        private readonly Lazy<CloudBlobClient> _blobClient;
        private readonly Lazy<CloudBlobContainer> _container;

        public StorageService(IOptions<StorageConfiguration> storageOptions)
        {
            _storageOptions = storageOptions;

            _storageAccount = new Lazy<CloudStorageAccount>(() => CloudStorageAccount.Parse(_storageOptions.Value.ConnectionString));

            _blobClient = new Lazy<CloudBlobClient>(() => StorageAccount.CreateCloudBlobClient());

            _container = new Lazy<CloudBlobContainer>(() =>
            {
                var container = Client.GetContainerReference(_storageOptions.Value.Container);
                container.CreateIfNotExists(BlobContainerPublicAccessType.Off);

                return container;
            });
        }


        public CloudStorageAccount StorageAccount => _storageAccount.Value;

        public CloudBlobClient Client => _blobClient.Value;

        public CloudBlobContainer Container => _container.Value;
    }
}