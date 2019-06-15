using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Models
{
    public class HistoryRecord
    {
        public Guid Key { get; set; }

        public string Entity { get; set; }

        public string Description { get; set; }

        public DateTimeOffset Changed { get; set; }

        public string ChangedBy { get; set; }

        public string PropertyName { get; set; }

        public string DisplayName { get; set; }

        public string Operation { get; set; }

        public string OriginalFormatted { get; set; }

        public string CurrentFormatted { get; set; }

    }
}
