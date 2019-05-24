using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace InstructorIQ.Core.Services
{
    public interface IStorageService
    {
        CloudStorageAccount StorageAccount { get; }

        CloudBlobClient Client { get; }

        CloudBlobContainer Container { get; }
    }
}
