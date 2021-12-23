using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace InstructorIQ.Core.Services
{
    public interface IStorageService
    {
        Task<Stream> OpenReadAsync(string blobName, CancellationToken cancellationToken);
        Task UploadAsync(string blobName, Stream stream, CancellationToken cancellationToken);
    }
}
