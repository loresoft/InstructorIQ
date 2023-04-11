using System.Collections.Generic;

namespace InstructorIQ.Core.Domain.Models;

public class LogPagedResult
{
    public string ContinuationToken { get; set; }

    public IReadOnlyCollection<LogEventModel> Data { get; set; }
}
