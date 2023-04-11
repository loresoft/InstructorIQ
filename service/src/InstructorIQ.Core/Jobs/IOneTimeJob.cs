using System;
using System.Threading;
using System.Threading.Tasks;

namespace InstructorIQ.Core.Jobs;

public interface IOneTimeJob
{
    Guid Id { get; }
    Task ExecuteAsync(CancellationToken stoppingToken);
}
