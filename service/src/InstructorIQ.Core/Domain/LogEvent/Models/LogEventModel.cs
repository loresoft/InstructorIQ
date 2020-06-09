using System;
using System.Text.Json;

namespace InstructorIQ.Core.Domain.Models
{
    public class LogEventModel
    {
        public DateTime TimeStamp { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public JsonElement Properties { get; set; }
    }
}
