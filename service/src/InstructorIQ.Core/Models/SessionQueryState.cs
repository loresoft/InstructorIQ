using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Models
{
    public class SessionQueryState
    {
        public int? Year { get; set; }

        public int? Month { get; set; }

        public string Query { get; set; }

        public Guid? TopicId { get; set; }

        public string UserName { get; set; }
    }
}
