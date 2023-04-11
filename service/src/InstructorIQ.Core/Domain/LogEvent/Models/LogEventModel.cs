using System;

using Azure;
using Azure.Data.Tables;

namespace InstructorIQ.Core.Domain.Models;

public class LogEventModel : ITableEntity
{
    public string PartitionKey { get; set; }

    public string RowKey { get; set; }

    public DateTimeOffset? Timestamp { get; set; }

    public ETag ETag { get; set; }

    public string Level { get; set; }

    public string MessageTemplate { get; set; }

    public string RenderedMessage { get; set; }

    public string Exception { get; set; }

    public string Data { get; set; }
}
