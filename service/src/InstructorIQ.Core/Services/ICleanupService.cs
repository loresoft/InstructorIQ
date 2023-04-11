using System.Threading;
using System.Threading.Tasks;

namespace InstructorIQ.Core.Services;

public interface ICleanupService
{
    Task ProcessAsync(CancellationToken cancellationToken = default);
}
