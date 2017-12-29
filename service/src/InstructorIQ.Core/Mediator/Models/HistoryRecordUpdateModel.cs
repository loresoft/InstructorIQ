using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class HistoryRecordUpdateModel : EntityUpdateModel
    {
        #region Generated Properties
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

        #endregion
    }
}