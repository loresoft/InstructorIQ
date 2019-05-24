using System;
using System.Threading;
using System.Threading.Tasks;

namespace InstructorIQ.Core.Services
{
    public interface IImportProcessService
    {
        Task ImportMembersAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }
}