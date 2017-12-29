using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class HistoryRecord
    {
        public HistoryRecord()
        {
            Changed = DateTimeOffset.UtcNow;
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        public Guid Key { get; set; }
        public string Entity { get; set; }
        public Guid? ParentKey { get; set; }
        public string ParentEntity { get; set; }
        public DateTimeOffset Changed { get; set; }
        public string ChangedBy { get; set; }
        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public string Path { get; set; }
        public string Operation { get; set; }
        public string OriginalValue { get; set; }
        public string OriginalFormated { get; set; }
        public string OriginalType { get; set; }
        public string CurrentValue { get; set; }
        public string CurrentFormated { get; set; }
        public string CurrentType { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }

    }
}